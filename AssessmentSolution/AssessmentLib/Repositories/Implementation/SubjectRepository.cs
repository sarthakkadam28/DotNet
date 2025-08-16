using AssessmentLib.Repositories.Interface;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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

        public Task<List<SubjectModel>> GetAllSubject()
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
                reader.CloseAsync();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conection.close();
            }
            return Subjects;

        }

        public async Task<int> AddSubject(SubjectModel subject)
        {
            string query = "INSERT INTO subjects(title)VALUES(@Title)";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);

            {
                command.Parameters.AddWithValue("@Title", subject.Title);
                try
                {
                    connection.Open();
                    return await command.ExecuteNonQueryAsync();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public async Task<int> DeleteSubject(int subjectId)
        {
            string query = @"DELETE FROM subjects(id) VALUES(@Title)";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);
            {
                command.parameters.AddWithValue("@title", subject.Title);
                {
                    try
                    {
                        connection.Open();
                        return await commans.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }
        }
        Public int  DeleteSubject(int subjectId)
        {
            string query = @"DELETE FROM subjects WHERE id =@Id";
            MySqlConnection connection = new MySqlConection(conectionString);
            MySqlCommand command = new MySqlCommand(query, connection);
                {
                    command.Parameters.AddWithValue("@Id", subjectId);
                    try
                    {
                        connetion.Open();
                        return command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return -1;
                    }
                    finally
                    {
                        connection.Close();
                    }
                    
                }
        }
     }
}
