using System;
namespace SchoolApp
{
    public class Uimanager
    {
        public void showmenu()
        {
            Console.WriteLine("Welcome to the School Management System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Edit Student");
            Console.WriteLine("3. Delete Student");
            Console.WriteLine("4. View Students");
            Console.WriteLine("5. Exit");

        }
        public int GetChoice()
        {
            int choice;
            Console.WriteLine("enter your choice");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public Student GetStudent()
        {
            Student thestudent = new Student();
            Console.WriteLine("Enter student Id:");
            // error-Cannot implicitly convert type 'string' to 'int'
            // if you want to convert a string to an int, use int.Parse() or int.TryParse()
            thestudent.Id = int.Parse(Console.ReadLine());
            Console.WriteLine(" Enter  Name:");
            thestudent.Name = Console.ReadLine();
            Console.WriteLine("Enter Age");
            thestudent.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Department :");
            thestudent.Department = Console.ReadLine();
            return thestudent;
        }
        public void ShowStudent(Student student)
        {
            
        }

    }
}