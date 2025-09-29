//simple code method
using System;

class Program
{
    static void SayHello()
    {
        Console.WriteLine("Hello!");
    }

    static void Main()
    {
        SayHello(); // Call the named method
    }
}
// using anonymous method

class Program
{
    delegate void MyDelegate();

    static void Main()
    {
        // Define the method without a name
        MyDelegate hello = delegate ()
        {
            Console.WriteLine("Hello!");
        };

        hello(); // Call the anonymous method
    }
}
