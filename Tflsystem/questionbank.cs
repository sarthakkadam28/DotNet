using System;
namespace app
{
    public class QuestionBank
    {
       private List<Question> questions;  //

        public QuestionBank()
        {
            questions = new List<Question>(); //to store the list of the questions 
        }
        public void InsertQuestion(Question thequestion)
        {
            if (thequestion != null)
            {
                questions.Add(thequestion);
                Console.WriteLine("Question added");
            }
            else
            {
                Console.WriteLine("Invalid question.");
            } 
        }
        public void UpdateQuestion(int questionId)
        {
         
        }
        public void ShowQuestion(int questionId)
        {
            
        }
        public void RemoveQuestion(int questionId)
        {
            
        }

    }
}