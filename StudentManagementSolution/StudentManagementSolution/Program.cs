
using System;
using StudentMangementLIb.StudentEntity;

class Program
{
    static void Main()
    {
        int choice;
        StudentManager manager = new StudentManager(); 

        do
        {
            manager.ShowMenu();
            choice = manager.GetChoice();

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Student Id:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Student Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Student Age:");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Student Department:");
                    string dept = Console.ReadLine();

                    manager.AddStudent(id, name, age, dept);
                    break;

                case 2:
                    Console.WriteLine("Enter Student Id to search:");
                    id = Convert.ToInt32(Console.ReadLine());
                    manager.SearchStudent(id);
                    break;

                case 3:
                    Console.WriteLine("Enter Student Id to delete:");
                    id = Convert.ToInt32(Console.ReadLine());
                    manager.DeleteStudent(id);
                    break;

                case 4:
                    Console.WriteLine("Enter Student Id to edit:");
                    id = Convert.ToInt32(Console.ReadLine());
                    manager.EditStudent(id);
                    break;

                case 5:
                    manager.ViewStudents();
                    break;

                case 6:
                    Console.WriteLine("Exiting the application.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        } while (choice != 6);
    }
}



