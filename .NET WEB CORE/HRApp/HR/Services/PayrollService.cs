using HRAPP.HR;
namespace HRAPP.HR.Services;
public class payrollService:IPayrollService
{
    public void GeneratePayslip(Employee emp)
    {
        Console.WriteLine($"Payslip Generated for {emp.FirstName}");
    }
}