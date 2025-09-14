
using System;
using Code;
using System.Reflection;
public class Program
{
    static void Main()
    {
        //typeof is an operator used to get the System.Type object for a given type at compile-time
        Type type = typeof(Employee);

        Console.WriteLine($"Class Name: {type.Name}");

        // which type of properties is used in this code shown by compiler 
        Console.WriteLine("\nProperties:");

        foreach (PropertyInfo prop in type.GetProperties())
        {
            Console.WriteLine($"- {prop.Name} ({prop.PropertyType})");
        }

        // List all methods
        Console.WriteLine("\nMethods:");

        foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            Console.WriteLine($"- {method.Name}");
        }
    }
}


