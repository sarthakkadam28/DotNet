using MySql.Data.MySqlClient;
using ProjectMangement.Entities; 
namespace ProjectMangement.Repository
{
    public class ProjectRepository:IProjectRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ProjectRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Missing connection string DefaultConnection");
        }
         public async Task<List<Userdetail>> GetAllUser()
        {
            List<Userdetail> user = new List<Userdetail>();
            string query = @"SELECT * FROM User";
                
            using MySqlConnection connection = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);
            try
            {
                await connection.OpenAsync();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Userdetail user1 = new Userdetail();
                    user1.UserId = Convert.ToInt32(reader["UserId"]);
                    user1.Name = reader["Name"].ToString();
                    user.Add(user1);
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
            return user;
        } 
    }
    
}