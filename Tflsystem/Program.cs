// See https://aka.ms/new-console-template for more information



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
    choice=int.Parse(Console.ReadLine());
    switch (choice)
        {
            case 1: Console.WriteLine("Enter question text: ");
                 string question = Console.ReadLine();
            break;

            case 2: Console.WriteLine("Enter question ID to edit: ");
                int questionId = int.Parse(Console.ReadLine());
                 Console.WriteLine("Enter new question text: ");
                 string newQuestion = Console.ReadLine();
            break;
              
            case 3: Console.WriteLine("Enter question id to show");
                int ShowQuestion = int.Parse(Console.ReadLine());

            break;
            
            case 4:
            Console.WriteLine("Enter question id to remove");
            int RemoveQuestion = int.Parse(Console.ReadLine());
            break;

            case 5: Console.WriteLine("Exit");
                 return;
            break;

            default: Console.WriteLine("Invalid choice");
            break;
    }

} while (true);


