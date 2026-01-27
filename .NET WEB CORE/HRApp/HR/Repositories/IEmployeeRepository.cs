using HRAPP.HR;

namespace HRAPP.HR.Repositories;

public interface IEmployeeRepository
{
    void Add(Employee employee);
    void Update(Employee employee);
    Employee GetById(int id);
    List<Employee> GetAll();
    List<Employee> GetByLocation(string location);
}