using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
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
        public async Task<UserWithRole> GetUserWithRoleAsync(int aadharId)
        {
            
            string query = @"SELECT u.id AS UserId, ur.roleid AS RoleId
                            FROM users u
                            JOIN userroles ur ON u.id = ur.userid
                            JOIN roles r ON ur.roleid = r.id
                            WHERE u.aadharid = @AadharId";
            MySqlConnection connection = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);
            UserWithRole role = null;
            {
                command.Parameters.AddWithValue(@"Aadharid", aadharId);
                try
                {
                    await connection.OpenAsync();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        role = new UserWithRole();
                        role.UserId = Convert.ToInt32(reader["UserId"]);
                        role.RoleId = Convert.ToInt32(reader["RoleId"]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    await connection.CloseAsync();
                }
                return role;
            }
        }
        
    }

   
}
