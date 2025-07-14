// See https://aka.ms/new-console-template for more information
using System;
using SchoolApp;
int choice;
do
{
    Uimanager ui = new Uimanager();
    ui.showmenu();
    choice = ui.GetChoice();
    switch (choice)
    {
        case 1:
            {
                Console.WriteLine("Enter Student Id:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Student Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Student Age:");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Student Department:");
                string department = Console.ReadLine();

                Student student = new Student(id, name, age, department);
                ui.AddStudent(student);
                break;
            }
        case 2:
            {
                Console.WriteLine("Enter Student Id to search:");
                int id = Convert.ToInt32(Console.ReadLine());
                ui.SearchStudent(id);
                break;
            }
        case 3:
            {
                Console.WriteLine("Enter Student Id to delete:");
                int id = Convert.ToInt32(Console.ReadLine());
                ui.DeleteStudent(id);
                break;
            }
        case 4:
            {
                Console.WriteLine("Enter Student Id to update:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter new Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter new Age:");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter new Department:");
                string department = Console.ReadLine();

                Student student = new Student(id, name, age, department);
                ui.UpdateStudent(student);
                break;
            }
        case 5:
            {
                ui.DisplayAllStudents();
                break;
            }
        case 6:
            {
                Console.WriteLine("Exiting the application.");
                break;
            }
        default:
            {
                Console.WriteLine("Invalid choice. Please try again.");
                break;
            }
    }
} while (choice != 6);

