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
                MySqlDataReader reader = command.ExecuteReader();
                Userdetail user1 = new Userdetail();
                user1.UserId = Convert.ToInt32(reader["UserId"]);
                user1.Name = reader["Name"].ToString();

                // Project pro = new Project();
                // pro.ProjectId = Convert.ToInt32(reader["ProjectId"]);
                // pro.ProjectName = reader["ProjectName"].ToString();

                // ProjectAssignment projectAssi = new ProjectAssignment();
                // projectAssi.AssignmentId = Convert.ToInt32(reader["AssignmentId"]);
                // projectAssi.UserId = Convert.ToInt32(reader["UserId"]);
                // projectAssi.ProjectId = Convert.ToInt32(reader["ProjectId"]);
                // projectAssi.Role = reader["Role"].ToString();
                
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