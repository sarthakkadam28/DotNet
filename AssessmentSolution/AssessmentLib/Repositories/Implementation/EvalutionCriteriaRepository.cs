using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentLib.Repositories.Implementation
{
    public class EvalutionCriteriaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public EvalutionCriteriaRepository(IConfiguration configuration)
        {
            _configuration= configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("connectionString");
        }
        public async Task<bool> UpdateCriteria(int EvalutionCriteriaId,int QuestionId)
        {
            bool status = false;
            String query = @"UPDATE questinbank SET EvalutionCriteriaId=@EvalutionCriteriaId WHERE Id=@QuestionId";
            MySqlConnection connection = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("EvalutionCriteriaId", EvalutionCriteriaId);
            command.Parameters.AddWithValue("QustionId", QuestionId);
            try
            {
             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
               connection.Close();
            }
            return status;
        }

    }
}
