using Faker.Abstraction;

namespace StringGeneratorPlugin
{
    public class StringGenerator : RandomValueGenerator
    {
        public override object Generate(Type type)
        {
            string str = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            string result = "";
            for (byte i = 0; i < _random.Next(1, 25); i++)
                result += str[_random.Next(0, str.Length)];
            return result;
        }

        public override string TypeName()
        {
            return nameof(String);
        }
    }
}