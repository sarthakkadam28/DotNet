using HRAPP.HR;
using HRAPP.HR.Repositories;
using HRAPP.HR.interfaces;
public class FileEmployeeRepository:IFileEmployeeRepository
{
    public List<Employee> GetByLocation(string location)
{
    return LoadFromFile()
        .Where(e => e.Location == location)
        .ToList();
}

}