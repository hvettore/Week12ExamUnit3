
const double inchesToMillimetersConversion = 25.4;
const double pi = 3.14159;

Console.WriteLine("This is Task #1 of Exam Unit 3 \n");

Console.WriteLine("Enter Number to be Squared: ");
double inputNumberToSquare = Convert.ToDouble(Console.ReadLine());
double squaredResult = ReturnSquareNumber(inputNumberToSquare);
Console.WriteLine($"The square of {inputNumberToSquare} is " + squaredResult + "\n");

Console.WriteLine("Enter a length in Inches to be converted to Millimeters: ");
double inputLength = Convert.ToDouble(Console.ReadLine());
double inchesToMillimetersResult = ReturnLengthInMillimeters(inputLength);
Console.WriteLine($"{inputLength} millimiters is " + inchesToMillimetersResult + " inches\n");

Console.WriteLine("Enter a Number to Find it's Root: ");
double inputNumberRoot = Convert.ToDouble(Console.ReadLine());
double rootResult = ReturnRootNumber(inputNumberRoot);
Console.WriteLine($"The root of {inputNumberRoot} is " + rootResult + "\n");

Console.WriteLine("Enter Number to be Cubed: ");
double inputNumberToCube = Convert.ToDouble(Console.ReadLine());
double cubedResult = ReturnCubedNumber(inputNumberToCube);
Console.WriteLine($"The cube of {inputNumberToCube} is " + cubedResult + "\n");

Console.WriteLine("Enter Radius of a Circle: ");
double inputCircleRadius = Convert.ToDouble(Console.ReadLine());
double circleAreaResult = ReturnCircleArea(inputCircleRadius);
Console.WriteLine($"If a circle has a radius of {inputCircleRadius}, it's area will be " + circleAreaResult + "\n");

Console.WriteLine("Please Enter Your name: ");
string inputName = Console.ReadLine();
string greetingPhrase = ReturnGreeting(inputName);
Console.WriteLine(greetingPhrase);


double ReturnSquareNumber(double number)
{
    double result = number * number;
    return Math.Round(result, 3);
}

double ReturnLengthInMillimeters(double lengthInInches)
{
    double result = lengthInInches * inchesToMillimetersConversion;
    return Math.Round(result, 3);
}

double ReturnRootNumber(double number)
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

double ReturnCubedNumber(double number)
{
    double result = number * number * number;
    return Math.Round(result, 3);
}

double ReturnCircleArea(double number)
{
    double result = number * pi;
    return Math.Round(result, 3);
}

string ReturnGreeting(string name)
{
    return "Good afternoon " + name + ". I hope you have a good day!";
}