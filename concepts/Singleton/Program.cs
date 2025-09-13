using System;
using Singleton; // ✅ This brings the Singleton namespace into scope

class Program
{
    static void Main(string[] args)
    {
        OfficeBoy obj1 = OfficeBoy.GetObject();
        OfficeBoy obj2 = OfficeBoy.GetObject();

        Console.WriteLine(obj1 == obj2); // Output: True (same instance)

        obj1.Value = 99;
        Console.WriteLine(obj2.Value);   // Output: 99 (shared object)
    }
}
