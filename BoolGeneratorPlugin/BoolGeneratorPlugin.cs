using Faker.Abstraction;
using System;

namespace BoolGeneratorPlugin
{
    public class BoolGenerator : RandomValueGenerator
    {
        public override object Generate(Type type)
        {
            return _random.Next(0, 2) == 0;
        }

        public override string TypeName()
        {
            return nameof(Boolean);
        }
    }
}