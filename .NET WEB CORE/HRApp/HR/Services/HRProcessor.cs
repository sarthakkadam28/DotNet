using HRAPP.HR;
using HRAPP.HR.Services;

namespace HR.Services;

public class HRProcessor
{
    private readonly IEmployeeService _employeeService;
    private readonly IPayrollService _payrollService;

    // Constructor Injection
    public HRProcessor(IEmployeeService employeeService,IPayrollService payrollService)
    {
        _employeeService = employeeService;
        _payrollService = payrollService;
    }

    public void Process(Employee employee)
    {    
        
        decimal salary = _employeeService.GetSalary(employee);
        Console.WriteLine(employee);
        Console.WriteLine("Final Salary: " + salary);
        _payrollService.GeneratePayslip(employee);
    }
}