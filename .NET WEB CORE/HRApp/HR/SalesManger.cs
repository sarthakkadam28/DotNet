using System.Runtime.CompilerServices;
using System.Threading.Channels;
using HRAPP.HR.interfaces;
namespace HRAPP.HR
{   
    public class SalesManger:SalesEmployee,IManagerBenefits,IInterviePanel,ITrainer
    {
    public decimal Bonus{get;set;}
    public SalesManger()
    {
        
    }
    public SalesManger(
    
         int employeeId,
            string firstName,
            string lastName,
            string email,
            string  phone,
            string department,
            decimal salary,
            DateTime hireDate,
            string position,
            decimal incentive,
            decimal bonus
        ): base(employeeId,firstName,lastName,email,phone,department,salary,hireDate,position,incentive)
    {
        
        Bonus=bonus;
    }

    public decimal CalculateBonus()
        {
            return Bonus;
        }
    public decimal GetTotalSalary()
    {
        return Salary + Incentive + Bonus;
    }
    public override string ToString()
    {
        return base. ToString()+ $",Bonus:{Bonus},Final Salary:{GetTotalSalary()}";
    }
    public override string Dowork()
        {
            return base.Dowork();
        }

    public override decimal ComputePay()
    {
        return base.ComputePay();
    }
    public void Approveleave()
        {
           Console.WriteLine("Manager Appraisal completed ");
        }
    public void TakeInterview()
        {
            Console.WriteLine("Sales Manager conducting interview.");
        }
    public void Train()
        {
            Console.WriteLine("Sales Manager training sales team.");
        }

    }
}