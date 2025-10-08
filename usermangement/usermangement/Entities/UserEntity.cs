namespace usermangement.Entities
{
    public class User
    {
        public int AadharId{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int ContactNumber { get; set; }
        public int  Password { get; set; }
        public int RoleId { get; set; }
    }
}