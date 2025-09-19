using System;
using System.Text.Json;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        // Create an object
        Person person = new Person { Name = "Alice", Age = 30 };

        // Serialize to JSON
        string jsonString = JsonSerializer.Serialize(person);
        Console.WriteLine("Serialized JSON:\n" + jsonString);

        // Deserialize back to object
        Person deserialized = JsonSerializer.Deserialize<Person>(jsonString);
        Console.WriteLine($"\nDeserialized:\nName: {deserialized.Name}, Age: {deserialized.Age}");
    }
}
usinf
