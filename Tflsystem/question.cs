using System;
namespace app
{
    public class Question
    {
        private string title;
        private string option;
        private string answer;
        private string evalutioncriteria;


        public string Title
        {
            get { return title; }
            set { title = value; }
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


        public Question(string title, string option, string answer, string evalutioncriteria)
        {
            this.title = title;
            this.option = option;
            this.answer = answer;
            this.evalutioncriteria = evalutioncriteria;
        }
        public void Display()
        {
            Console.WriteLine("Question: "+ title);
            Console.WriteLine("Option: "+ option);
            Console.WriteLine("Answer: "+ answer);
            Console.WriteLine("Evaluation Criteria: "+evalutioncriteria);
        }
        public override string ToString()
        {
            return "Question: {title}, Option: {option}, Answer: {answer}, Evaluation Criteria: {evalutioncriteria}";
        }

    }
}