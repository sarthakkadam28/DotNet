using System;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
namespace SchoolApp
{
    public class SchoolOffice
    {
        private List<Student> students;
        public SchoolOffice()
        {
            students = new List<Student>();
        }


        public void AddStudent(Student stud)
        {
            Student s = new Student();
            Console.WriteLine("Enter student ID");
            s.Id =  int.Parse(Console.ReadLine());
            Console.WriteLine("enter student name:");
            s.Name = Console.ReadLine();
            Console.WriteLine("Enter the age ");
            s.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Department");
            s.Department = Console.ReadLine();

        }

        
        /*
        
        public void EditStudent()
        
        {
        foreach (Student student in students)
        {
                if (student.Id == id)
                {
                    student.Name = stud.Title;
                    student.Age = stud.Age;
                    student.Department = stud.Department;
            }
        }
        }*/
        public void DeleteStudent()
        {
        }
        public void ViewStudent()
        {
        }
    }

}