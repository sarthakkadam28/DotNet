using HRAPP.HR;

namespace HRAPP.HR.Repositories;

public class MemoryEmployeeRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees = new();

    public void Add(Employee employee)
    {
        _employees.Add(employee);
        Console.WriteLine("Employee added to repository.");
    }

    public void Update(Employee employee)
    {
        var emp = GetById(employee.EmployeeId);
        if (emp != null)
        {
            _employees.Remove(emp);
            _employees.Add(employee);
            Console.WriteLine("Employee updated.");
        }
    }

    public Employee GetById(int id)
    {
        return _employees.FirstOrDefault(e => e.EmployeeId == id);
    }

    public List<Employee> GetAll()
    {
        return _employees;
    }
    public List<Employee> GetByLocation(string location)
{
    return _employees
        .Where(e => e.Location == location)
        .ToList();
}

}