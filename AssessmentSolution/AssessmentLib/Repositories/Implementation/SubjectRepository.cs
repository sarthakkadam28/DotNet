using AssessmentLib.Repositories.Interface;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentLib.Repositories.Implementation
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public SubjectRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("connectionString");
            SqlMapper.AddTypeHandler(new SqlTimeOnlyTypeHandler());
        }

        public async Task<List<SubjectModel>> GetAllSubject()
        {
            List<SubjectModel> subjects = new List<SubjectModel>();
            string query = @"SELECT * FROM Subjects";
           
            MySqlConnection conection = new MySqlConnection(ConnectionString);
            MySqlCommand commmand = new MySqlCommand(query, Connection);

            try
            {
                conection.open();
                MySqlDataReader reader = commmand.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse | (reader["id"].Tostring());
                    string title = reader["title"].Tostring();
                    SubjectModel subject = new SubjectModel();

                    subject.Id = id;
                    subject.Title = title;
                    subjects.Add(subject);
            
                }
                await reader.CloseAsync();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
              await conection.closeAsync();
            }
            return 

        }

        public async Task<int> AddSubject(SubjectModel subject)
        {
         
            
        }
        public async Task<int> DeleteSubject(int subjectId)
        {
              
            
        }
        //public async Task<int> AddSubject(SubjectModel subject)
        //{
        //    string query = @"INSERT INTO subjects (title) VALUES (@Title)";

        //    using (MySqlConnection connection = new MySqlConnection(_connectionString))
        //    using (MySqlCommand command = new MySqlCommand(query, connection))
        //    {
        //        command.Parameters.AddWithValue("@Title", subject.Title);

        //        try
        //        {
        //            await connection.OpenAsync();
        //            return await command.ExecuteNonQueryAsync();
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //            return -1;
        //        }
        //        finally
        //        {
        //            await connection.CloseAsync();
        //        }
        //    }
        //}

    }
}
