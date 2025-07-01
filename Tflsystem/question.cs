using System;
namespace app
{
    public class Question
    {
        private string question;
        private string option;
        private string answer;
        private string evalutioncriteria;


        public string QuestionText
        {
            get { return question; }
            set { question = value; }
        }
        public string Option
        {
            get { return option; }
            set { option = value; }
        }
        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }
        public string EvaluationCriteria
        {
            get { return evalutioncriteria; }
            set { evalutioncriteria = value; }
        }
        public Question(string question, string option, string answer, string evalutioncriteria)
        {
            this.question = question;
            this.option = option;
            this.answer = answer;
            this.evalutioncriteria = evalutioncriteria;
        }
        public void Display()
        {
            Console.WriteLine("Question: "+ question);
            Console.WriteLine("Option: "+ option);
            Console.WriteLine("Answer: "+ answer);
            Console.WriteLine("Evaluation Criteria: "+evalutioncriteria);
        }
        public override string ToString()
        {
            return "Question: {question}, Option: {option}, Answer: {answer}, Evaluation Criteria: {evalutioncriteria}";
        }

    }
}