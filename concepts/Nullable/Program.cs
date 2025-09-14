using System;
using Nullable;
public class Value
{
    static void Main()
    {
        Student stud1 = new Student { Name = "sarthak", Age = 23 };
        Student stud2 = new Student { Name = "vishal", Age = null };
        stud1.ShowOff();
        stud2.ShowOff();
        Console.WriteLine();
    }
}
