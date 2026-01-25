using HRAPP.HR;
using HRAPP.HR.interfaces;
Employee emp1 = new SalesEmployee(
    1,
    "Amit",
    "Sharma",
    "amit@company.com",
    "9999999999",
    "Sales",
    50000,
    new DateTime(2020, 6, 15),
    "developer",
    8000
);


Employee emp2 = new SalesManger(
    2,
    "Neha",
    "Patil",
    "neha@company.com",
    "8888888888",
    "Marketing",
    70000m,
    new DateTime(2020, 3, 22),
    "Sales Manager",
    15000m,
    10000m
);


emp1.Dowork();
emp2.Dowork();

Console.WriteLine(emp1);
Console.WriteLine("Salary: " + emp1.ComputePay());

Console.WriteLine(emp2);
Console.WriteLine("Salary: " + emp2.ComputePay());

SalesManger manager = new SalesManger();

IAppraisable appraisable = manager;
appraisable.ConductAppraisal();

IBonusEligible bonusEligible = manager;
Console.WriteLine("Bonus: " + bonusEligible.CalculateBonus());

IInterviePanel panel = manager;
panel.TakeInterview();

ITrainer trainer = manager;
trainer.Train();