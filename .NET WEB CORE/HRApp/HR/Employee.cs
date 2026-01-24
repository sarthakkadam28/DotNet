using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

namespace HRAPP.HR
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public string Position { get; set; }

        public Employee()
        {
        }

        public Employee(int employeeId, string firstName, string lastName, string email, 
                       string phone, string department, decimal salary, DateTime hireDate, string position)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Department = department;
            Salary = salary;
            HireDate = hireDate;
            Position = position;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public override string ToString()
        {
            return $"ID: {EmployeeId}, Name: {GetFullName()}, Position: {Position}, Department: {Department}";
        }
        public virtual string Dowork()
        {
          return $"{GetFullName()} is working as a{Position} in {Department} department.";
        }
        public virtual decimal ComputePay()
        {
          return Salary;
        }
        
    }
}