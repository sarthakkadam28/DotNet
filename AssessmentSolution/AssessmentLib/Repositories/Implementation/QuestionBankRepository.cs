using AssessmentLib.Entities;
using AssessmentLib.Repositories.Interface;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Sec;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentLib.Repositories.Implementation
{
    public class QuestionBankRepository:IQuestionBankRepository
    { 
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public class QustionBankRepository(IConfiguration configuration)
           {
            _configuration = configuration
             _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("connectionString");
           }

        public async Task<List<QuestionTitle>> GetAllQuestion(QuestionTitle question)
        {
            await Task.Delay(2000);
            List<QuestionBank>questions = new List<QuestionBank>();
            string query = "SELECT * From QuestinBank";
            MySqlConnection connection = new MySqlConnection(_connectionString);
            MySqlCommand command = connection.CreateCommand();
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                da.Fill(ds);

                DataTable dtQuestionBank = ds.Tables[0];
                DataRowCollection rows =dtQuestionBank.Rows;
                foreach(DataRow row in rows)
                {
                    int id =int.Parse(row["id"].ToString());
                    string title =row ["title"].ToString();

                    QuestionTitle question = new QuestionTitle();
                    question.Title = title;
                    question.Id = id;

                    questions.Add(question);
                }

            }
            catch(Exception ex)
            {
            Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return questions;
        }
        public async Task<List<SubjetQuestion>> GetQuestionsBySubject(int Id)
        {
            List<SubjectQuestion> questions = new List<SubjectQuestion>();
            string query = @"select questionbank.id as questionid, questionbank.title as question, subjects.title as Subject, subjects.id as subjectid from questionbank,subjects where questionbank.subjectid=subjects.id and subjects.id=@SubjectId";
            MySqlConnection connection = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@SubjectId", Id);
            try
            {
                await connection.OpenAsync();
                MySqlDataReader reader = command.ExecuteReader();
                while (await reader.ReadAsync())
                {
                    int questionId = int.Parse(reader["questionid"].ToString());
                    string strQuestion = reader["question"].ToString();
                    int subjectId = int.Parse(reader["subjectid"].ToString());
                    string subject = reader["subject"].ToString();

                    SubjectQuestion question = new SubjectQuestion();
                    question.QuestionId = questionId;
                    question.Question = strQuestion;
                    question.SubjectId = subjectId;
                    question.Subject = subject;
                    questions.Add(question);

                }
                await reader.CloseAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
               await connection.CloseAsync();
            }
            return questions;
        }
        public Task<List<QuestionDetails>> GetQuestionsBySubjectAndCriteria(int SubjectId, int CriteriaId)
        {


        }
        public Task<List<QuestionDetails>> GetQusstionWithSubjectAndCriteria()
        {

        }
        public Task<List<Question>> GetQuestions(int TestId)
        {


        }
        public Task<bool> UpdateAnswer(int Id, char AnswerrKey)
        {

        }
        public Task<Question> GetQuestion(int QuestionId)
        {

        }
        public Task<bool> UpdateQuestionOption(int Id, Question options)
        {

        }
        public Task<bool> UpdateSubjectCriteria(int questionId,Question question)
        {

        }
        public Task<bool>InsertQuestion(NewQuestion question)
        {

        }
        public Task<bool> GetCriteria(string subject, int QuestiionId)
        {

        }

    }
}
