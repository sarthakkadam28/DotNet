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
        

       public void InsertQuestion(Question theQuestion)
        {

            if (theQuestion != null)
            {
                questions.Add(theQuestion);
                Console.WriteLine("Question added");
            }
            else
            {
                Console.WriteLine("Invalid question.");
            }
        }
        
        public void UpdateQuestion(string  title, Question thequestion)
         {
             //This line starts a foreach loop that goes through each item (qt) in the list called questions.
             // Each qt represents a Question object.
             foreach (Question qt in questions)
             {
                 if (qt.Title == title)
                 {
                     qt.Title = thequestion.Title;
                     qt.Optiona= thequestion.Optiona;
                     qt.Optionb= thequestion.Optionb;
                     qt.Optionc= thequestion.Optionc;
                     qt.Optiond= thequestion.Optiond;
                     qt.Answer = thequestion.Answer;
                     qt.EvaluationCriteria = thequestion.EvaluationCriteria;
                     Console.WriteLine("Question updated");
                     return;
                 }

             }

         }
        public void ShowQuestion()
        {
            foreach (Question q in questions)
            {
                    q.Display();
            }

        }
       public void RemoveQuestion(string questionTitle)
        {
            List<Question> AllRemoveQuestions = new List<Question>();
            foreach (var q in questions)
            {
                if (q.Title == questionTitle)
                {
                    questions.Remove(q);
                    Console.WriteLine("Question removed");
                    return;
                }
            }
            // questions.Remove(questionTitle);
            // Console.WriteLine("Question removed");
        }
    
    }
}