
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
        public Student AddStudent(Student student)
        {

            SchoolOffice office = new SchoolOffice();
            office.AddStudent(student);
            return student;
        }
        public void SearchStudent(int id)
        {
            SchoolOffice office = new SchoolOffice();
            Student student = office.SearchStudent(id);

        }
        public void EditStudent()
        {
            SchoolOffice office = new SchoolOffice();
            office.EditStudent();
        }
        public void DeleteStudent(int id)
        {
            SchoolOffice office = new SchoolOffice();
            office.DeleteStudent();
        }
        public void ViewStudent()
        {
            SchoolOffice office = new SchoolOffice();
            office.ViewStudent();
        }
    }
}