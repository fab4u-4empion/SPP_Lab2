namespace Faker.Abstraction
{
    public abstract class RandomValueGenerator
    {
        protected static Random _random;

        static RandomValueGenerator()
        {
            _random = new Random();
        }

        public abstract object Generate(Type type);

        public abstract string TypeName();
    }
}
