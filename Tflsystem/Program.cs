// See https://aka.ms/new-console-template for more information
int choice;
do
{
    Console.WriteLine(" ____Main Menu____");

    Console.WriteLine("Enter your choice: ");
    Console.ReadLine();

    Console.WriteLine("1. Add Question");
    Console.WriteLine("2. Edit Question");  
    Console.WriteLine("3. Show Question");
    Console.WriteLine("4. Remove Question");
    Console.WriteLine("5. Exit");




    switch (choice)
    {
        case 1: Console.WriteLine("Enter question text: ");
                 string question = Console.ReadLine();

        case 2: Console.WriteLine("Enter question ID to edit: ");
            int questionId = Console.ReadLine();
                 Console.WriteLine("Enter new question text: ");
                 string newQuestion = Console.ReadLine();
              
        case 3: Console.WriteLine("Enter question id to show");
            int ShowQuestion = Console.ReadLine();


        case 4:Console.WriteLine("Enter question id to remove");
            int RemoveQuestion = Console.ReadLine();


        default: Console.WriteLine("Invalid choice");

    }

} while (true);
