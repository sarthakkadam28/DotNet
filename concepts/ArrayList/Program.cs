using System;
using System.Collections;

class Program
{
    static void Main()
    {
        // Create an ArrayList
        ArrayList list = new ArrayList();

        // elements added into a container
        list.Add(10);
        list.Add("Hello");
        list.Add(3.14);
        list.Add(true);

        // Access by index
        Console.WriteLine("First element: " + list[0]); // 10

        // we are using loop for get individual entity
        Console.WriteLine("All elements:");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        // Remove is built in keyword used in the code 
        list.Remove("Hello");

        Console.WriteLine("After removing 'Hello':");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}

