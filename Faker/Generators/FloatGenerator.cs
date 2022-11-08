using Faker.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generators
{
    public class FloatGenerator : RandomValueGenerator
    {
        public override object Generate(Type type)
        {
            return (float) _random.NextDouble();
        }

        public override string TypeName()
        {
            return nameof(Single);
        }
    }
}
