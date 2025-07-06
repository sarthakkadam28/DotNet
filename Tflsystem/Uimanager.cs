
using System;
namespace app
{
    public class Uimanger
    {

        public void showMenu()
        {
            int choice;
            do
            {
                Console.WriteLine(" ____Main Menu____");
                Console.WriteLine("1. Add Question");
                Console.WriteLine("2. Edit Question");
                Console.WriteLine("3. Show Question");
                Console.WriteLine("4. Remove Question");
                Console.WriteLine("5. Exit");

                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                QuestionBank questionbank = new QuestionBank();
                switch (choice)
                {
                    case 1:
                        {
                            Question thequestion = new Question();

                            Console.WriteLine("Enter question Title: ");
                            // take input question to end user
                            Console.WriteLine("enter title");
                            thequestion.Title = Console.ReadLine();
                            // Console.WriteLine(thequestion.Title);
                            Console.WriteLine("Enter Option A: ");
                            thequestion.Option = Console.ReadLine();
                            Console.WriteLine("Enter Answer A: ");
                            thequestion.Answer = Console.ReadLine();
                            Console.WriteLine("Enter evalutioncriteria : ");
                            thequestion.EvaluationCriteria = Console.ReadLine();
                            // 
                            // call insert question menthod and pass new question
                            questionbank.InsertQuestion(thequestion);
                        }
                        break;

                    case 2:
                        {

                            Console.WriteLine("Enter question title to update");
                            string title = Console.ReadLine();
                            Question thequestion = new Question();

                            Console.WriteLine("Enter new question Title: ");
                            thequestion.Title = Console.ReadLine();
                            Console.WriteLine("Enter new Option A: ");
                            thequestion.Option = Console.ReadLine();
                            Console.WriteLine("Enter new Answer A: ");
                            thequestion.Answer = Console.ReadLine();
                            Console.WriteLine("Enter new evalutioncriteria : ");
                            thequestion.EvaluationCriteria = Console.ReadLine();

                            questionbank.UpdateQuestion(title, thequestion);
                        }
                        break;

                    case 3:
                        {
                            questionbank.ShowQuestion(questionTitle);


                        }
                        break;

                    case 4:
                        {
                            RemoveQuestion();
                        }
                        break;

                    case 5:
                        {
                            Exit();
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Invalid choice, please try again.");
                        }
                        break;
                }
            } while (choice != 5);  
        
        }
    }
}
