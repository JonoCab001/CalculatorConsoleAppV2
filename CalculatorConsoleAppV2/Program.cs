using System.Text.RegularExpressions;

class calculator
{
    public static double DoOperation(double numb1, double numb2, string operation)
    {
        double result = double.NaN; // "not-a-number" is the default value

        // We'll use the switch statment to do the math
        switch (operation)
        {
            case "+":
                result = numb1 + numb2;
                break;
            case "-":
                result = numb1 - numb2;
                break;
            case "*":
                result = numb1 * numb2;
                break;
            case "/":
                // Ask the user to enter a non-zero divisor
                if (numb2 != 0)
                {
                    result = numb1 / numb2;
                }
                break;

                // Return text for incorrect option entry
                break;
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;

        // Display the title as the C# Console Calculator App
        Console.WriteLine("C# Console Calculator App\r");
        Console.WriteLine("-------------------------\n");

        while (!endApp)
        {
            // Declare variables and assign it to empty
            // Use a nullable type (with ?) to match type of System.Console.Readline
            string? numbInput1 = "";
            string? numbInput2 = "";
            double result = 0;

            // Ask the user to type in the first number
            Console.Write("Please enter a number, then press enter: ");
            numbInput1 = Console.ReadLine();

            double cleanNumb1 = 0;
            while (!double.TryParse(numbInput1, out cleanNumb1))
            {
                Console.Write("\nThis input is invalid. Please enter a numeric value: ");
                numbInput1 = Console.ReadLine();
            }

            // Ask the user to type in the second number
            Console.Write("\nPlease enter a second number, then press enter: ");
            numbInput2 = Console.ReadLine();

            double cleanNumb2 = 0;
            while (!double.TryParse(numbInput2, out cleanNumb2))
            {
                Console.Write("\nThis input is invalid. Please enter a numeric value: ");
                numbInput2 = Console.ReadLine();
            }

            // Prompt the user to select an option
            Console.WriteLine("Select an option from the following list below:");
            Console.WriteLine("\t+ - Add");
            Console.WriteLine("\t- - Subtract");
            Console.WriteLine("\t* - Multiply");
            Console.WriteLine("\t/ - Divide");
            Console.Write("Your option?: ");

            string? op = Console.ReadLine();

            // Validate input is not null and ensure it matches the pattern
            if (op == null || !Regex.IsMatch(op, "[+|-|*|/]"))
            {
                Console.WriteLine("\nError: input is unrecognized");
            }
            else
            {
                try
                {
                    result = calculator.DoOperation(cleanNumb1, cleanNumb2, op);

                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Warning: This operation could result in a mathematical error. \n");
                    }
                    else
                    {
                        Console.WriteLine("Your result: {0:0.##}\n", result);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nUh oh! An exception has occurred while trying to do the math. \n - Details: " + e.Message);
                }
            }
            Console.WriteLine("------------------------\n");

            // Wait for user to respond before closing the application
            Console.Write("\nPlease press 'n' and Enter to terminate the app or press any other key to continue...");

            if (Console.ReadLine() == "n")
            {
                endApp = true;
                Console.WriteLine("\n");
            }
        }

        return;
    }
}