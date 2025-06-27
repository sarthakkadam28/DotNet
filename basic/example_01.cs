using System;
namespace testerapp
{
    class program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("This is a basic C# program.");
            int count = 45;
            count = count++;
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("hello world" + args[i]);
            }
            Console.WriteLine("welcome to the dotnet programming world");
            int count1 = 45;
            count = count++;
            count = count + 1;
            if (count <= 300)
            {
                while (count <= 200)
                {
                    Console.WriteLine("count is ={0}", count);
                    count++;
                }
            }
            Console.WriteLine("plz enter your name ");
            string name = Console.ReadLine();
            Console.WriteLine("hello {0}", name);
            Console.WriteLine("goodmoring {0}", name);
            Console.ReadLine();
        }
    }
}