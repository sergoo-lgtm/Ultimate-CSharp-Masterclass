Console.WriteLine("Hello");

Console.WriteLine("input the first number");
int firstNumber = int.Parse(Console.ReadLine());

Console.WriteLine("input the second number");
int secondNumber = int.Parse(Console.ReadLine());

Console.WriteLine("what do you want to do");
Console.WriteLine("[A]dd numbers");
Console.WriteLine("[S]ubtract numbers");
Console.WriteLine("[D]ivision numbers");
Console.WriteLine("[M]ultiply numbers");

string userInput = Console.ReadLine();

void PrintOperation(string symbol, int result) //method Prints the result of an operation between two numbers
{Console.WriteLine($"{firstNumber} {symbol} {secondNumber}  =  {result}");}

switch (userInput.ToUpper())
{
    case "A":
        PrintOperation("+", firstNumber + secondNumber);
        break;

    case "S":
        PrintOperation("-", firstNumber - secondNumber);
        break;

    case "M":
        PrintOperation("*", firstNumber * secondNumber);
        break;

    case "D":
        if (secondNumber != 0)
             PrintOperation("/", firstNumber / secondNumber);
        else
             Console.WriteLine("Cannot divide by zero! \n press any key to close calculator.");
        break;

    default:
        Console.WriteLine("invalid choice! \n press any key to close calculator.");
        break;
}



Console.ReadLine();



