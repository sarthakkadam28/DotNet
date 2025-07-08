
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;
using Assesment.Entities;
namespace Persistance
{
    public class QuestionBank
    {
       public  List<Question> questions;  //same type of datatype stored in the questions

        public QuestionBank()
        {
            questions = new List<Question>(); //to store the list of the questions 
        }

        //  Apan main madhe jevha Question queation1=New Question();object banvto tevha jo data asel to 
        // to theQuestion madhe yeto 
       public void InsertQuestion(Question theQuestion)
        {
            //nanter to object gheun apan pudhe use karto
            if (theQuestion != null)
            {
                // jo kahi data asel for exam-title,option,answer,evalutioncriteria to thequestion madhe yeil
                // to aplyla list of questions madhe add karychaa ahe
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
        public List<Question> GetAllQuestions()
        {
            return questions; //returning the list of questions
        }
        public void RemoveQuestion(string questionTitle)
        {
            List<Question> AllRemoveQuestions = new List<Question>();
             for (int i = questions.Count - 1; i >= 0; i--)
            {
                if (questions[i].Title == questionTitle)//list madhaly prateyk question cha title check karycha ahe tysathi 
                // array of i title sathi karun te enduser ttle la match hota ka nahi pahat ahe  
                {
                    questions.Remove(questions[i]);
                    Console.WriteLine("question removed");
                    return;
                }

            }

            
               // foreach (var q in questions)
            // {
            //     if (q.Title == questionTitle)
            //     {
            //         questions.Remove(q);
            //         Console.WriteLine("Question removed");
            //         return;
            //     }
            // }
            //Unhandled exception. System.ArgumentOutOfRangeException: Index was out of range.
            //Must be non-negative and less than the size of the collection. (Parameter 'index')
            //jr i++ kela tr index match hota nahi tymula error yete 

            // questions.Remove(questionTitle);
            // Console.WriteLine("Question removed");
        }
    
    }
}