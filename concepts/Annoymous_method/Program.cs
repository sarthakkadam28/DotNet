//simple code method
using System;

// class Program
// {
//     static void SayHello()
//     {
//         Console.WriteLine("Hello!");
//     }
//     static void  SayBye()
//     {
//         Console.WriteLine("Bye");
//     }

//     static void Main()
//     {
//         SayHello();
//         SayBye(); // Call the named method
//     }
// }
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
        MyDelegate Bye = delegate ()
        {
            Console.WriteLine("bye");
        };

        hello(); // Call the anonymous method
    }
}
 