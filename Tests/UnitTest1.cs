using Faker;

namespace Tests
{
    public class EmptyClass { }

    public class Car { public string Id { get; set; } }

    public class Person { public string name; public byte age; }

    public class Bike
    {
        private byte wheelsCount;

        public Bike(byte whCount)
        {
            wheelsCount = whCount;
        }

        public int GetWheelsCount()
        {
            return wheelsCount;
        }
    }

    public class A { public B _b { get; set; } }

    public class B { public A _a { get; set; } }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateEmptyObject()
        {
            Faker.Faker f = new();
            var c = f.Create<EmptyClass>();
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void CreateObjectWithProperty() {
            Faker.Faker f = new();
            var car = f.Create<Car>();
            Assert.IsNotNull(car);
            Assert.IsNotNull(car.Id);
        }

        [TestMethod]
        public void CreateObjectWithFields()
        {
            Faker.Faker f = new();
            var person = f.Create<Person>();
            Assert.IsNotNull(person);
            Assert.IsNotNull(person.name);
            Assert.IsTrue(person.age != 0);
        }

        [TestMethod]
        public void CreateObjectWithConstructor()
        {
            Faker.Faker f = new();
            var bike = f.Create<Bike>();
            Assert.IsNotNull(bike);
            Assert.IsTrue(bike.GetWheelsCount() > 0);
        }

        [TestMethod]
        public void CreateObjectWithCycle()
        {
            Faker.Faker f = new();
            var a = f.Create<A>();
            Assert.IsNotNull(a);
            Assert.IsNotNull(a._b);
            Assert.IsNull(a._b._a);
        }

        [TestMethod]
        public void CreateValueTypes()
        {
            Faker.Faker f = new();
            Assert.IsNotNull(f.Create<string>());
            Assert.IsTrue(f.Create<byte>() > 0);
            Assert.IsNotNull(f.Create<DateTime>());
        }

        [TestMethod]
        public void CreateList()
        {
            Faker.Faker f = new();
            var bytes = f.Create<List<List<byte>>>();
            Assert.IsNotNull(bytes);
            Assert.IsNotNull(bytes[0]);
            Assert.IsTrue(bytes[0][0] > 0);
        }
    }
}