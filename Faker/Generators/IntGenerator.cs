using Faker.Abstraction;

namespace Faker.Generators
{
    public class IntGenerator : RandomValueGenerator
    {
        public override object Generate(Type type)
        {
            return _random.Next(int.MinValue, int.MaxValue);
        }

        public override string TypeName()
        {
            return nameof(Int32);
        }
    }
}
