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
            s.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("enter student name:");
            s.Name = Console.ReadLine();
            Console.WriteLine("Enter the age ");
            s.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Department");
            s.Department = Console.ReadLine();

        }
        public Student SearchStudent(int id)
        {
            foreach (Student student in students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            Console.WriteLine("Student not found.");
            return null;
        }



        public void EditStudent()
        {
            Console.WriteLine("Enter the student ID to edit:");
            int id = int.Parse(Console.ReadLine());
            foreach (Student student in students)
            {
                if (student.Id == id)
                {
                    Console.WriteLine("Enter new name:");
                    student.Name = Console.ReadLine();
                    Console.WriteLine("Enter new age:");
                    student.Age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new department:");
                    student.Department = Console.ReadLine();
                    Console.WriteLine("Student details updated.");
                    return;
                }
            }
        }
        public void DeleteStudent()
        {
            Console.WriteLine("Enter the student ID to delete:");
            int id = int.Parse(Console.ReadLine());
            foreach (Student student in students)
            {
                if (student.Id == id)
                {
                    students.Remove(student);
                    Console.WriteLine("Student ID deleted");
                    return;
                }
            }
            Console.WriteLine("Student ID not found.");
        }
        public void ViewStudent()
        {
            foreach (Student student in students)
            {
                student.Display();
            }
        }
    }

}