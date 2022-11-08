using Faker.Abstraction;

namespace Faker.Generators
{
    public class ByteGenerator : RandomValueGenerator
    {
        public override object Generate(Type type)
        {
            return (byte)_random.Next(); 
        }

        public override string TypeName()
        {
            return nameof(Byte);
        }
    }
}
