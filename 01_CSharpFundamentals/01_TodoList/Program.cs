string userChoise ;
List<string> todoList = new List<string>();
do {
Console.WriteLine("hello");
Console.WriteLine("[S]ee all todolists");
Console.WriteLine("[A]dd a todo");
Console.WriteLine("[R]emove a todo");
Console.WriteLine("[E]xit");

userChoise = Console.ReadLine();
void PrintSelectOption(string selectedOption)
{ Console.WriteLine("selected option: " + selectedOption); }


switch (userChoise.ToUpper())
{
    case "S":
        PrintSelectOption("See all TODOS\n");
        if (todoList.Count == 0)
        {
            Console.WriteLine("No TODOs found.\n");
        }
        else
        {
            for (int i = 0; i < todoList.Count; i++)
            {
                Console.WriteLine($"{i + 1} => {todoList[i]}\n");
            }
        }
        break;


    case "A":
        PrintSelectOption("Add a TODO\n");
        Console.WriteLine("Enter TODO description:");
        string todoDescription = Console.ReadLine();
        todoList.Add(todoDescription);
        Console.WriteLine("TODO added.\n");
        break;


    case "R":
        PrintSelectOption("Remove a TODO\n");
        Console.WriteLine("Enter TODO description to remove:");
        string todoToRemove = Console.ReadLine();
        if (todoList.Remove(todoToRemove))
        {
            Console.WriteLine("TODO removed.\n");
        }
        else
        {
            Console.WriteLine("TODO not found.\n");
        }
        break;

    case "E":
        PrintSelectOption("EXIT");
        break;
    default:
        Console.WriteLine("Invalid choice!\n");
        break;
}


} while (userChoise.ToUpper() != "E" );


Console.ReadKey();


