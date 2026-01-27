using HRAPP.HR;
namespace HR.Services;
public interface IEmployeeService
{
    decimal GetSalary(Employee employee);
    void PerformDuties(Employee employee);
    void AddEmployee(Employee employee);
    List<Employee>GetEmployees();
}