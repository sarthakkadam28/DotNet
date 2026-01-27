using HRAPP.HR;
namespace HRAPP.HR.Repositories;
public interface IFileEmployeeRepository
{
    public void GetEmployeesByLocation(string location);
}