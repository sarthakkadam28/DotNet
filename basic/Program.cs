// See https://aka.ms/new-console-template for more information
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
namespace testerapp
{
    class Program
    {
        private string programname;
        // Property to get or set the program name
        public string Name
        {
            get { return programname; }
            set { programname = value; }
        }
        // default constructor
        // This constructor initializes the program with a default name
        public Program()
        {
            programname = "C# Program";
        }
        //prameterized constructor
        // This constructor allows setting a custom name for the program
        public Program(string name)
        {
            programname = name;
        }
        // Main method: Entry point of the program
       
        static int addition(int num1, int num2)
        {
            int result = num1 + num2;
            return result;
        }
        static int substraction(int num1, int num2)
        {
            int result = num1 - num2;
            return result;
        }
        static int multiplication(int num1, int num2)
        {
            int result = num1 * num2;
            return result;
        }
        public void display()
        {
            Console.WriteLine("Welcome to the C# program");
            Console.WriteLine("This is a basic C# program.");
            int count = 45;
            count = count++;
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("hello world" + Name);
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
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.display();
            int result = addition(10, 20);
            int result2 = substraction(21, 2);
            int result3 = multiplication(10, 20);
            Console.WriteLine("addition result is:" + result);
            Console.WriteLine("substaction is:" + result2);
            Console.WriteLine("multiplication is:" + result3);

            Product product1 = new Product(1, "Laptop", "High performance laptop", 1, 999.99f);
            Product product2= new Product(2, "Smartphone", "Latest model smartphone", 2, 799.99f);

        }
    }
}

          
            
           


 
