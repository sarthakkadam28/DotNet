using MySql.Data.MySqlClient;
using usermangement.Entities;
using usermangement.Entities.UserRoleWithProjectAssignment;
using System.Collections.Generic;
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
        
        public async Task<bool> AddUserWithRole1 (AddUser user)
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
                int result = await command.ExecuteNonQueryAsync();
                return result > 0;
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

        }

        public async Task<bool> AddUserWithRole(AddUser user)
        {
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            using MySqlTransaction transaction = await connection.BeginTransactionAsync();

            try
            {
                // 1. Insert the user
                string insertUserQuery = @"
                    INSERT INTO users (aadharid, firstname, lastname, email, contactnumber, password, createdon, modifiedon)
                    VALUES (@AadharId, @FirstName, @LastName, @Email, @ContactNumber, @Password, @CreatedOn, @ModifiedOn);
                    SELECT LAST_INSERT_ID();";

                using var insertUserCmd = new MySqlCommand(insertUserQuery, connection, transaction);
                insertUserCmd.Parameters.AddWithValue("@AadharId", user.Aadharid);
                insertUserCmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                insertUserCmd.Parameters.AddWithValue("@LastName", user.LastName);
                insertUserCmd.Parameters.AddWithValue("@Email", user.Email);
                insertUserCmd.Parameters.AddWithValue("@ContactNumber", user.ContactNumber);
                insertUserCmd.Parameters.AddWithValue("@Password", user.Password);
                insertUserCmd.Parameters.AddWithValue("@CreatedOn", user.CreatedOn);
                insertUserCmd.Parameters.AddWithValue("@ModifiedOn", user.ModifiedOn);

                // Execute insert and get the new user ID
                var newUserIdObj = await insertUserCmd.ExecuteScalarAsync();
                //ExecuteScalarAsync()which is returns a one obj but we dont want object we require id so we convert it into a new id also type casting  
                int newUserId = Convert.ToInt32(newUserIdObj);

                // 2. Insert into userroles table
                string insertUserRoleQuery = @"
                    INSERT INTO userroles (userid, roleid)
                    VALUES (@UserId, @RoleId);";

                using var insertRoleCmd = new MySqlCommand(insertUserRoleQuery, connection, transaction);
                insertRoleCmd.Parameters.AddWithValue("@UserId", newUserId);
                insertRoleCmd.Parameters.AddWithValue("@RoleId", user.RoleId);

                await insertRoleCmd.ExecuteNonQueryAsync();


                string employeeQuery = @"
            INSERT INTO employees (userid, firstname, lastname, email, contact)
            VALUES (@userId, @firstname, @lastname, @email, @contact);";

                using var employeeCommand = new MySqlCommand(employeeQuery, connection, transaction);
                employeeCommand.Parameters.AddWithValue("@userId", newUserId);
                employeeCommand.Parameters.AddWithValue("@firstname", user.FirstName);
                employeeCommand.Parameters.AddWithValue("@lastname", user.LastName);
                employeeCommand.Parameters.AddWithValue("@email", user.Email);
                employeeCommand.Parameters.AddWithValue("@contact", user.ContactNumber);

                await employeeCommand.ExecuteNonQueryAsync();

                // Commit transaction
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                await transaction.RollbackAsync();
                return false;
            }
        }
        // public async Task<bool> AddUserWithEmployee(AddUser user)
        // {
        //     using var connection = new MySqlConnection(_connectionString);
        //     await connection.OpenAsync();

        //     using var transaction = await connection.BeginTransactionAsync();

        //     try
        //     {
        //         string userQuery = @"
        //     INSERT INTO users (aadharid, firstname, lastname, email, contactnumber, password)
        //     VALUES (@aadharid, @firstname, @lastname, @email, @contactnumber, @password);
        //     SELECT LAST_INSERT_ID();";

        //         using var userCommand = new MySqlCommand(userQuery, connection, transaction);
        //         userCommand.Parameters.AddWithValue("@aadharid", user.Aadharid);
        //         userCommand.Parameters.AddWithValue("@firstname", user.FirstName);
        //         userCommand.Parameters.AddWithValue("@lastname", user.LastName);
        //         userCommand.Parameters.AddWithValue("@email", user.Email);
        //         userCommand.Parameters.AddWithValue("@contactnumber", user.ContactNumber);
        //         userCommand.Parameters.AddWithValue("@password", user.Password);

        //         var result = await userCommand.ExecuteScalarAsync();
        //         int newUserId = Convert.ToInt32(result);

        //         string roleQuery = @"INSERT INTO userroles (userid, roleid) VALUES (@userId, @roleid);";
        //         using var roleCommand = new MySqlCommand(roleQuery, connection, transaction);

        //         roleCommand.Parameters.AddWithValue("@userId", newUserId);
        //         roleCommand.Parameters.AddWithValue("@roleid", user.RoleId);

        //         await roleCommand.ExecuteNonQueryAsync();

        //         string employeeQuery = @"
        //     INSERT INTO employees (userid, firstname, lastname, email, contact)
        //     VALUES (@userId, @firstname, @lastname, @email, @contact);";

        //         using var employeeCommand = new MySqlCommand(employeeQuery, connection, transaction);
        //         employeeCommand.Parameters.AddWithValue("@userId", newUserId);
        //         employeeCommand.Parameters.AddWithValue("@firstname", user.FirstName);
        //         employeeCommand.Parameters.AddWithValue("@lastname", user.LastName);
        //         employeeCommand.Parameters.AddWithValue("@email", user.Email);
        //         employeeCommand.Parameters.AddWithValue("@contact", user.ContactNumber);

        //         await employeeCommand.ExecuteNonQueryAsync();
        //         await transaction.CommitAsync();
        //         return true;
        //     }
        //     catch (Exception ex)
        //     {
        //         await transaction.RollbackAsync();
        //         Console.WriteLine("Transaction failed: " + ex.Message);
        //         return false;
        //     }
        //     finally
        //     {
        //         await connection.CloseAsync();
        //     }
        // }

        public async Task<List<Userdetail>> GetAllUser()
        {
            List<Userdetail> user = new List<Userdetail>();
            string query1 = @"INSERT INTO Users (UserId, Name)
                VALUES (@UserId,@Name)"
                ;
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand(query1, connection);
            try
            {
                MySqlDataReader reader = command.ExecuteReader();
                Userdetail user1 = new Userdetail();
                user1.UserId = Convert.ToInt32(reader["UserId"]);
                user1.Name = reader["Name"].ToString();

               

                string query2 = @"INSERT INTO PROJECTS(ProjectId,ProjectName)VALUES(@Pro)";

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            finally
            {
                await connection.CloseAsync();
            }


        }


    }


}
