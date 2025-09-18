using System;
using System.Collections.Generic;

public class Demo
{
    public static void PrintNames(ICollection<string> names)
    {
        Console.WriteLine("Total names: " + names.Count);
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    public static void Main()
    {
        // this is only used in add and remove opertion
        // also we can accessed it individually and modified it 
        ICollection<string> people = new List<string>();
        people.Add("Alice");
        people.Add("Bob");
        people.Add("Charlie");

        PrintNames(people);
    }
}

