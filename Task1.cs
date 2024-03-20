using System;

public static class task1
{
    private const double inchesToMillimetersConversion = 25.4;
    private const double pi = 3.14159;

    public static double ReturnSquareNumber(double number)
    {
        double result = number * number;
        return Math.Round(result, 3);
    }

    public static double ReturnLengthInMillimeters(double lengthInInches)
    {
        double result = lengthInInches * inchesToMillimetersConversion;
        return Math.Round(result, 3);
    }

    public static double ReturnRootNumber(double number)
    {
        double result = number;
        double epsilon = 0.00001;
        double guess = number / 2;

        while ((guess * guess - number) * (guess * guess - number) > epsilon * epsilon)
        {
            guess = (guess + number / guess) / 2;
        }

        return Math.Round(guess, 3);
    }

    public static double ReturnCubedNumber(double number)
    {
        double result = number * number * number;
        return Math.Round(result, 3);
    }

    public static double ReturnCircleArea(double number)
    {
        double result = number * pi;
        return Math.Round(result, 3);
    }

    public static string ReturnGreeting(string name)
    {
        return "Good afternoon " + name + ". I hope you have a good day!";
    }
}