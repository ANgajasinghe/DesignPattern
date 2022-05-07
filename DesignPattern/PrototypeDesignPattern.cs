namespace DesignPattern;

// GENERAL - Custom way to create
public interface IPrototype {
    IPrototype Clone();
}

public class Employee : IPrototype
{
    public int Age { get;set; }
    public string? Name { get;set; }
    public double Salary{ get;set; }


    public Employee()
    {
        Console.WriteLine("CONSTRUCTOR");
    }

    public Employee(int age, string? name, double salary)
    {
        Age = age;
        Name = name;
        Salary = salary;
    }

    public IPrototype Clone()
    {
        return new Employee(Age, Name, Salary);
    }


    public override string ToString()
    {
        return $"Age: {Age}, Name: {Name}, Salary: {Salary}";
    }
}


// C# way to create with Object.MemberwiseClone()
public class Person
{
    public int Age;
    public DateTime BirthDate;
    public string Name;
    public IdInfo IdInfo;

    public Person ShallowCopy()
    {
        return (Person) this.MemberwiseClone();
    }

    public Person DeepCopy()
    {
        Person clone = (Person) this.MemberwiseClone();
        clone.IdInfo = new IdInfo(IdInfo.IdNumber);
        clone.Name = Name;
        return clone;
    }
}

public class IdInfo
{
    public int IdNumber;

    public IdInfo(int idNumber)
    {
        this.IdNumber = idNumber;
    }
}

public static class PrototypePattern
{
    public static void Run()
    {
        Person p1 = new Person();
        p1.Age = 42;
        p1.BirthDate = Convert.ToDateTime("1977-01-01");
        p1.Name = "Jack Daniels";
        p1.IdInfo = new IdInfo(666);

// Perform a shallow copy of p1 and assign it to p2.
        Person p2 = p1.ShallowCopy();
// Make a deep copy of p1 and assign it to p3.
        Person p3 = p1.DeepCopy();

// Display values of p1, p2 and p3.
        Console.WriteLine("Original values of p1, p2, p3:");
        Console.WriteLine("   p1 instance values: ");
        DisplayValues(p1);
        Console.WriteLine("   p2 instance values:");
        DisplayValues(p2);
        Console.WriteLine("   p3 instance values:");
        DisplayValues(p3);

// Change the value of p1 properties and display the values of p1,
// p2 and p3.
        p1.Age = 32;
        p1.BirthDate = Convert.ToDateTime("1900-01-01");
        p1.Name = "Frank";
        p1.IdInfo.IdNumber = 7878;
        Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
        Console.WriteLine("   p1 instance values: ");
        DisplayValues(p1);
        Console.WriteLine("   p2 instance values (reference values have changed):");
        DisplayValues(p2);
        Console.WriteLine("   p3 instance values (everything was kept the same):");
        DisplayValues(p3);

        static void DisplayValues(Person p)
        {
            Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
                p.Name, p.Age, p.BirthDate);
            Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
        }

    }

    public static void CustomPrototype()
    {
        Employee e1 = new Employee(32, "John", 5000);
        Console.WriteLine(e1.ToString());
        
        Employee e2 = (Employee)e1.Clone();
        Console.WriteLine("Cloning e1 to e2");
        Console.WriteLine(e2.ToString());
        
        
    }
}