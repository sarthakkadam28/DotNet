using System;
using Microsoft.EntityFrameworkCore;
namespace Entity_Framework;
class Program
{
    static void Main()
    {
        using (var context = new SchoolContext())
        {
             context.Database.EnsureCreated();
            context.Students.Add(new Student { Name= "sarthak", Age = 23 });
            context.SaveChanges();
        }
    }
}
