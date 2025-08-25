using AssessmentLib.Entities;
using AssessmentLib.Repositories.Interface;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Sec;
using System;
using System.Collections.Generic;
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
             _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("connectionString");
         }

        public Task<List<QuestionTitle>> GetAllQuestion()
        {

        }
        public Task<List<SubjetQuestion>> GetQuestionsBySubject(int Id)
        {

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
