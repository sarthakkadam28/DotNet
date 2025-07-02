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
        public void UpdateQuestion(string  title, Question thequestion)
        {

            foreach (Question qt in questions)
            {
                if (qt.Title == title)
                {
                    qt.Title = thequestion.Title;
                    qt.Option = thequestion.Option;
                    qt.Answer = thequestion.Answer;
                    qt.EvaluationCriteria = thequestion.EvaluationCriteria;
                    Console.WriteLine("Question updated");
                    return;
                }
                
            }
         
        }
        public void ShowQuestion(int questionId)
        {
            if (questionId < 0 || questionId >= questions.Count)
            {
                Console.WriteLine("Invalid question ID.");
                return;
            }
            Question qt = questions[questionId];
            qt.Display();
            
        }
        public void RemoveQuestion(int questionId)
        {
            
            if (questionId < 0 || questionId >= questions.Count)
            {
                Console.WriteLine("Invalid question ID.");
                return;
            }
            questions.RemoveAt(questionId);
            Console.WriteLine("Question removed");
        }

    }
}