using System;
using Partialclass;
class Program
{
    public static void Main(string[] args)
    {
        Employee emp = new Employee
        {
            Firstname = "sarthak",
            Lastname = "kadam",
            Salary = 65000
        };
        emp.DisplayName();
        emp.DisplaySalary();
    }
}
