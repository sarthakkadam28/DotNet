using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RegisterViewModel
{
    [Key]
    public int Id { get; set; }   // Primary Key – Auto Increment

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [NotMapped]  // Because Age can be calculated → No need to store in DB
    public int Age 
    { 
        get 
        {
            if (BirthDate == DateTime.MinValue) return 0;
            var today = DateTime.Today;
            var age = today.Year - BirthDate.Year;
            if (BirthDate.Date > today.AddYears(-age)) age--;
            return age;
        } 
    }

    public bool IsRegistered { get; set; }

    [Phone]
    public string PhoneNo { get; set; }

    public string Location { get; set; }

    public string MemberShip { get; set; }   // It was 'G' in your JSON

    public string[] Social { get; set; }     // e.g. ["T", "F"] for Twitter, Facebook
}
