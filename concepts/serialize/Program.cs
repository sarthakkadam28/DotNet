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
// using xml serialization

// using System;
// using System.IO;
// using System.Xml.Serialization;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        Person person = new Person { Name = "Bob", Age = 45 };

        XmlSerializer serializer = new XmlSerializer(typeof(Person));

        // Serialize to XML string
        using (StringWriter writer = new StringWriter())
        {
            serializer.Serialize(writer, person);
            string xmlString = writer.ToString();
            Console.WriteLine("Serialized XML:\n" + xmlString);

            // Deserialize back
            using (StringReader reader = new StringReader(xmlString))
            {
                Person deserialized = (Person)serializer.Deserialize(reader);
                Console.WriteLine($"\nDeserialized:\nName: {deserialized.Name}, Age: {deserialized.Age}");
            }
        }
    }
}

