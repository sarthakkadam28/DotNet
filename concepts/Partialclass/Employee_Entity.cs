namespace Partialclass
{
    public partial class Employee
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Salary { get; set; }

    }
}
//A partial class in C# is a special feature that allows splitting the definition of a single class across
// multiple source files using the partial keyword.
// When the program is compiled, the compiler combines all those parts into one complete class.