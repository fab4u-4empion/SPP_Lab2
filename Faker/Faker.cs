using Faker.Abstraction;
using System.Data;
using System.Reflection;

namespace Faker
{
    public class Faker
    {
        private Dictionary<string, RandomValueGenerator?> _generators;
        private List<string> _types;

        public Faker()
        {
            _types = new List<string>();
            _generators = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.BaseType?.FullName == typeof(RandomValueGenerator).FullName)
                .Select(type => Activator.CreateInstance(type) as RandomValueGenerator)
                .ToDictionary(generator => generator.TypeName());
            LoadPlugins();
        }

        private void LoadPlugins()
        {
            string pluginPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");

            DirectoryInfo pluginDirectory = new DirectoryInfo(pluginPath);
            if (!pluginDirectory.Exists)
            {
                pluginDirectory.Create();
            }

            string[] pluginFiles = Directory.GetFiles(pluginPath, "*.dll");

            foreach (string file in pluginFiles)
            {
                Assembly asm = Assembly.LoadFrom(file);
                var generators = asm.GetTypes().Where(i => i.BaseType.FullName == typeof(RandomValueGenerator).FullName);

                foreach (Type g in generators)
                {
                    var generator = Activator.CreateInstance(g) as RandomValueGenerator;
                    _generators.Add(generator.TypeName(), generator);
                }
            }
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        private object CreateObjectUsingConstructor(Type type)
        {
            List<ConstructorInfo> constructors = type
                .GetConstructors(BindingFlags.Instance | BindingFlags.Public)
                .OrderByDescending(c => c.GetParameters().Length)
                .ToList();

            if (constructors.Count == 0 && type.BaseType != typeof(ValueType))
                throw new Exception("Unable to create object with private constructor");

            foreach (ConstructorInfo constructor in constructors)
            {
                List<object> parameterValues = new List<object>();
                ParameterInfo[] parameters = constructor.GetParameters();
                foreach (ParameterInfo parameter in parameters)
                {
                    parameterValues.Add(Create(parameter.ParameterType));

                    try
                    {
                        return Activator.CreateInstance(type, args: parameterValues.ToArray());
                    }
                    catch { }
                }
            }

            return Activator.CreateInstance(type);
        }

        public object Create(Type type)
        {
            if (_types.Any(t => t == type.Name))
                return null;

            if (_generators.ContainsKey(type.Name))
                return _generators[type.Name].Generate(type);

            if (type.IsValueType)
                return Activator.CreateInstance(type);

            _types.Add(type.Name);

            object obj = CreateObjectUsingConstructor(type);

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
                if (property.SetMethod != null && property.SetMethod.IsPublic)
                {
                    var value = property.GetMethod?.Invoke(obj, null);
                    if (value is null || value.Equals(GetDefaultValue(property.PropertyType)))
                        property.SetValue(obj, Create(property.PropertyType));
                }    
                else
                    throw new Exception("Unable to create non-DTO");

            FieldInfo[] fields = type.GetFields();
            foreach (FieldInfo field in fields)
            {
                var value = field.GetValue(obj);
                if (value is null || value.Equals(GetDefaultValue(field.FieldType)))
                    field.SetValue(obj, Create(field.FieldType));
            }
                

            _types.Remove(type.Name);

            return obj;
        }

        private object GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
