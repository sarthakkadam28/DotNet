using CRM;
namespace Membership
{
    public class AccountManager
    {
        public static bool Login(string username, string password)
        {
            bool status = false;
            if (username == "sarthak" && password == "pass")
            {
                status = true;
            }
            return status;
        }
        public static bool Register(string loginId, string name, string password, string email, string contactnumber)
        {
            bool status = false;
            Customer theCustomer = new Customer();
            theCustomer.UserId = loginId;
            theCustomer.password = password;
            theCustomer.email = email;
            theCustomer.ContactNumber = contactnumber;
            theCustomer.Location = "location";

            if (theCustomer != null)
            {
                status = true;
            }
            return status;
        }
        public static bool ChangePassword(string loginId, string oldPassword, string newPassword)
        {
            bool status = false;
            return status;
        }
        public static bool ForgotPassword(string loginId)
        {
            bool status = false;
            return status;
        }
   
   
    }
    
}