// See https://aka.ms/new-console-template for more information

using app;

int choice;
QuestionBank questionbank = new QuestionBank();


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

    switch (choice)
    {
        case 1:
            {
                Question thequestion = new Question();


                // take input question to end user
                Console.WriteLine("enter title");
                thequestion.Title = Console.ReadLine();
                // Console.WriteLine(thequestion.Title);
                Console.WriteLine("Enter Option A: ");
                thequestion.Optiona = Console.ReadLine();

                Console.WriteLine("Enter Option b: ");
                thequestion.Optionb = Console.ReadLine();

                Console.WriteLine("Enter Option c: ");
                thequestion.Optionc = Console.ReadLine();

                Console.WriteLine("Enter Option d: ");
                thequestion.Optiond = Console.ReadLine();

                Console.WriteLine("Enter Answer: ");
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
                 thequestion.Optiona = Console.ReadLine();
                Console.WriteLine("Enter new Answer B: ");
                thequestion.Optionb = Console.ReadLine();
                Console.WriteLine("Enter new Option c: ");
                 thequestion.Optionc = Console.ReadLine();
                 Console.WriteLine("Enter new Option d: ");
                 thequestion.Optiond = Console.ReadLine();
                Console.WriteLine(" Enter the Answer");
                thequestion.Answer = Console.ReadLine();
                Console.WriteLine("Enter new evalutioncriteria : ");
                thequestion.EvaluationCriteria = Console.ReadLine();

                questionbank.UpdateQuestion(title, thequestion);
            }
            break;

        case 3:
            {
                // Console.WriteLine("Enter question title to show");
                //string questionTitle = (Console.ReadLine());
                questionbank.ShowQuestion();
            }
            break;

        case 4:
            {

                Console.WriteLine("Enter question title to remove");
                string questionTitle = Console.ReadLine();
                Console.WriteLine("Name " + questionTitle);
                questionbank.RemoveQuestion(questionTitle);
            }
            break;


        case 5:
            Console.WriteLine("Exit");
            return;
            break;

        default:
            Console.WriteLine("Invalid choice");
            break;
    }

} while (true);


