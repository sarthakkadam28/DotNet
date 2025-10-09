namespace usermangement.Entities
{
    public class AddUser
    {
        public int Aadharid{ get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string Email{ get; set; }
        public string ContactNumber{ get; set; }
        public int Password{ get; set; }
        public DateTime CreatedOn{ get; set; }
        public DateTime ModifiedOn{ get; set; }
        
        public int RoleId { get; set; }
    }
}