using System;

public class Program
{
    // Step 1: Declare a delegate
    public delegate void MyDelegate();

    // Step 2: Define methods that match the delegate
    public static void MethodOne()
    {
        Console.WriteLine("Method One Called");
    }

    public static void MethodTwo()
    {
        Console.WriteLine("Method Two Called");
    }

    public static void MethodThree()
    {
        Console.WriteLine("Method Three Called");
    }

    public static void Main()
    {
        // Step 3: Create delegate instances and chain them
        MyDelegate del = MethodOne;
        del += MethodTwo;
        del += MethodThree;

        // Step 4: Call the chained delegate
        del();

        // You can also remove methods from the chain
        del -= MethodTwo;
        Console.WriteLine("After removing MethodTwo:");
        del();
    }
}

