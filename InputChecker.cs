using System;

public class InputChecker
{
    public const string inputQuery = "Input: ";
    public const string invalidDecimal = "Invalid input, please enter a number or decimal.";
    public const string invalidString = "Invalid input, please enter a valid string without numbers or symbols.";
    
    public static double GetNumberOrDecimal()
    {
        double result;
        string input;

        while (true)
        {
            Console.Write(inputQuery);
            input = Console.ReadLine() ?? string.Empty;

            if (double.TryParse(input, out result))
            {
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine(invalidDecimal);
            }
        }

        return result;
    }

    public static string GetString()
    {
        string input;

        while (true)
        {
            Console.Write(inputQuery);
            input = Console.ReadLine() ?? string.Empty;

            if (!string.IsNullOrEmpty(input) && input.All(char.IsLetter))
            {
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine(invalidString);
            }
        }
        return input;
    }

    public static string GetStringWithSpaceAndParentheses()
    {
        string input;

        while (true)
        {
            Console.Write(inputQuery);
            input = Console.ReadLine() ?? string.Empty;

            if (!string.IsNullOrEmpty(input) && input.All(c => char.IsLetter(c) || c == ' ' || c == '(' || c == ')'))
            {
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine(invalidString);
            }
        }
        return input;
    }
}