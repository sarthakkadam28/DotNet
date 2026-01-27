using HRAPP.HR;
using HRAPP.HR.Repositories;
namespace HR.Services;

public class EmployeeService : IEmployeeService
{
     
    private readonly IEmployeeRepository _repository;
    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    public decimal GetSalary(Employee employee)
    {
        employee.Dowork();
        // return (float)employee.ComputePay();
        return employee.ComputePay();
    }

    public void PerformDuties(Employee employee)
    {
        employee.Dowork();
        Console.WriteLine("Employee duties completed.");
    }
     public void AddEmployee(Employee employee)
    {
        _repository.Add(employee);
    }

    public List<Employee> GetEmployees()
    {
        return _repository.GetAll();
    }
}