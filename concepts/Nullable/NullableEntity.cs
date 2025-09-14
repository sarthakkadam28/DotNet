namespace Nullable
{
    public class Student
    {
        public string Name { get; set; }
        public int? Age { get; set; }

        public void ShowOff()
        {
            Console.WriteLine($"Name:{Name}");
            if (Age.HasValue)
            {
                Console.WriteLine($"Age:{Age}");
            }
            else
            {
                Console.WriteLine("age is not provided");
            }
        }
    }
}