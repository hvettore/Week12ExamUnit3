using System;

public class InputChecker
{
    public static double GetNumberOrDecimal()
    {
        double result;
        string input;

        while (true)
        {
            Console.Write("Input: ");
            input = Console.ReadLine() ?? string.Empty;

            if (double.TryParse(input, out result))
            {
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input, please enter a number or decimal.");
            }
        }

        return result;
    }

    public static string GetString()
    {
        string input;

        while (true)
        {
            Console.Write("Name: ");
            input = Console.ReadLine() ?? string.Empty;

            if (!string.IsNullOrEmpty(input) && input.All(char.IsLetter))
            {
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input, please enter a valid name without numbers or symbols.");
            }
        }

        return input;
    }



}