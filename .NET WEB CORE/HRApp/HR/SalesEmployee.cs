namespace HRAPP.HR
{
    public class SalesEmployee:Employee
    {
        public decimal Incentive;
        public  SalesEmployee()
        {
            
        }
        public SalesEmployee(int employeeId,
            string firstName,
            string lastName,
            string email,
            string  phone,
            string department,
            decimal salary,
            DateTime hireDate,
            string position,
            decimal incentive)
                    :base(employeeId,firstName,lastName,email,phone,department,salary,hireDate,position)
        {
            Incentive=incentive;
        }
        public decimal GetTotalSalary()
        {
            return Salary+Incentive;
        }
        public override string ToString()
        {
            return base.ToString() + $",Incentive:{Incentive},Total Salary: {GetTotalSalary()}";
        }
        public override string Dowork()
        {
            return base.Dowork();
        }
        public override decimal ComputePay()
        {
            return Salary;
        }

    }
}