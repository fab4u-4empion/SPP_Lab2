using Faker.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Faker.Generators
{
    internal class DateTimeGenerator : RandomValueGenerator
    {
        public readonly DateTime MinDate = new(1970, 1, 1);
        public readonly DateTime MaxDate = new(2050, 12, 31);

        public override object Generate(Type type)
        {
            return MinDate.Add(MaxDate.Subtract(MinDate).Multiply(_random.NextDouble()));
        }

        public override string TypeName()
        {
            return nameof(DateTime);
        }
    }
}
