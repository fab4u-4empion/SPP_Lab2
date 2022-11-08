using Faker.Abstraction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generators
{
    internal class ListGenerator : RandomValueGenerator
    {
        public override object Generate(Type type)
        {
            Faker f = new();
            var length = _random.Next(1, 5);

            Type[] generics = type.GenericTypeArguments;
            Type returnListType = typeof(List<>).MakeGenericType(generics);
            var returnList = (IList)Activator.CreateInstance(returnListType);

            for (var i = 0; i < length; i++)
            {
                returnList.Add(f.Create(generics[0]));
            }

            return returnList;
        }

        public override string TypeName()
        {
            return typeof(List<>).Name;
        }
    }
}
