using System;
namespace Partialclass
{
    public partial class Employee
    {
        public void DisplayName()
        {
            Console.WriteLine($"full name :{Firstname}{Lastname}");
        }
        public void DisplaySalary()
        {
            Console.WriteLine($"salary :{Salary}");
        }
    }
}