public class A
{
    public string Ctor { get; set; }
    public B B { get; set; }

    public int IntField { get; set; }

    public int IntValue;
    public short ShortValue;
    public string StringValue;

    public string StringProp { get; set; }
    public int Id;
    public bool BoolField { get; set; }

    private A()
    {
        Ctor = "A()";
    }

    public A(int id)
    {
        Ctor = "A(string)";
        Id = id;
    }
}

public class B
{
    public C C { get; set; }
}

public class C
{
    public A A { get; set; }
}

public class Person { public string name; public byte age; }

public class Car { public string Id { get; set; } }

class Programm
{
    public static void Main()
    {
        Faker.Faker f = new();
        A a = f.Create<A>();
        Console.WriteLine($".ctor {a.Ctor};\nIntField: {a.IntField};\n" +
                  $"IntValue: {a.IntValue};\n" +
                  $"ShortValue: {a.ShortValue};\nStringValue: {a.StringValue};\n" +
                  $"StringProp: {a.StringProp};\nId: {a.Id};\nBoolField: {a.BoolField}");

        var person = f.Create<Person>();
        Console.WriteLine(person.name);
    }
} 