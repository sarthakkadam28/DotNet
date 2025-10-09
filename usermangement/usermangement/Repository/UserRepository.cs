using MySql.Data.MySqlClient;
using usermangement.Entities;
namespace usermangement.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Missing connection string DefaultConnection");
        }
        public async Task<bool> AddUserWithRole (AddUser user)
        {
            
            string query = @"INSERT INTO users(aadharid, firstname, lastname, email, contactnumber, password, createdon, modifiedon,roleid)
                            VALUES (@AadharId,@FirstName,@LastName, @Email , @ContactNumber, @Password, @CreatedOn, @ModifiedOn,@RoleId)";
                        
            MySqlConnection connection = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);
            {
                command.Parameters.AddWithValue(@"Aadharid", user.Aadharid);
                command.Parameters.AddWithValue(@"FirstName", user.FirstName);
                command.Parameters.AddWithValue(@"Lastname", user.LastName);
                command.Parameters.AddWithValue(@"Email", user.Email);
                command.Parameters.AddWithValue(@"ContactNumber", user.ContactNumber);
                command.Parameters.AddWithValue(@"Password", user.Password);
                command.Parameters.AddWithValue(@"CreatedOn", user.CreatedOn);
                command.Parameters.AddWithValue(@"ModifiedOn", user.ModifiedOn);
                command.Parameters.AddWithValue(@"RoleId", user.RoleId);
            }
            try
            {
                await connection.OpenAsync();
                int rowsAffected = await command.ExecuteNonQueryAsync();
                bool status = rowsAffected > 0;
                if (status)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                await connection.CloseAsync();
            }
            return true;
            
        }
        
    }

   
}
