using Faker.Abstraction;

namespace Faker.Generators
{
    public class CharGenerator : RandomValueGenerator
    {
        public override object Generate(Type type)
        {
            return (char)_random.Next();
        }

        public override string TypeName()
        {
            return nameof(Char);
        }
    }
}
