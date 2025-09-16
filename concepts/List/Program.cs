class Employee
{
   public  int Id { get; set; }
   public string Name { get; set; }

    public Employee(int eid, string ename)
    {
        Id = eid;
        Name = ename;
    }
} 
class EmpComparer:IComparer<Employee> 
{ 
  public int Compare(Employee? e1, Employee? e2) 
  {
        int ret = e1.Name.Length.CompareTo(e2.Name.Length);
        return ret; 
  } 
}

public class Bank
{
    public static void Main()
    {
        List<Employee> lists = new List<Employee>();
        lists.Add(new Employee(1, "Raghu"));
        lists.Add(new Employee(2, "Seeta"));
        lists.Add(new Employee(4, "Leela"));
        EmpComparer ec = new EmpComparer();
        lists.Sort(ec);
        foreach (Employee e in lists) {
            Console.WriteLine(e.Id + "---------"+e.Name);
        }
    }
}