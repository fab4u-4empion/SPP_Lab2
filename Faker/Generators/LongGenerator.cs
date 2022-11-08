using Faker.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generators
{
    public class LongGenerator : RandomValueGenerator
    {
        public override object Generate(Type type)
        {
            return _random.NextInt64(Int64.MinValue, Int64.MaxValue);
        }

        public override string TypeName()
        {
            return nameof(Int64);
        }
    }
}
