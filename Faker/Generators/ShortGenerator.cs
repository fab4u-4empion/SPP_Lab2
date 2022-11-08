using Faker.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generators
{
    public class ShortGenerator : RandomValueGenerator
    {
        public override object Generate(Type type)
        {
            return (short)_random.Next();
        }

        public override string TypeName()
        {
            return nameof(Int16);
        }
    }
}
