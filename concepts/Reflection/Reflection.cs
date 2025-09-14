namespace Code
{
    public class Employee
    {
        string? Name { get; set; }
        int Age { get; set; }
        public void ShowOff()
        {
            Console.WriteLine($"my name is {Name},also my age is{Age}");
        }
    }
    
}