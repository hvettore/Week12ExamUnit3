


Console.WriteLine("This is Task #1 of Exam Unit 3 \n");

Console.WriteLine("Enter Number to be Squared: ");
double inputNumberToSquare = Convert.ToDouble(Console.ReadLine());
double squaredResult = task1.ReturnSquareNumber(inputNumberToSquare);
Console.WriteLine($"The square of {inputNumberToSquare} is " + squaredResult + "\n");

Console.WriteLine("Enter a length in Inches to be converted to Millimeters: ");
double inputLength = Convert.ToDouble(Console.ReadLine());
double inchesToMillimetersResult = task1.ReturnLengthInMillimeters(inputLength);
Console.WriteLine($"{inputLength} millimiters is " + inchesToMillimetersResult + " inches\n");

Console.WriteLine("Enter a Number to Find it's Root: ");
double inputNumberRoot = Convert.ToDouble(Console.ReadLine());
double rootResult = task1.ReturnRootNumber(inputNumberRoot);
Console.WriteLine($"The root of {inputNumberRoot} is " + rootResult + "\n");

Console.WriteLine("Enter Number to be Cubed: ");
double inputNumberToCube = Convert.ToDouble(Console.ReadLine());
double cubedResult = task1.ReturnCubedNumber(inputNumberToCube);
Console.WriteLine($"The cube of {inputNumberToCube} is " + cubedResult + "\n");

Console.WriteLine("Enter Radius of a Circle: ");
double inputCircleRadius = Convert.ToDouble(Console.ReadLine());
double circleAreaResult = task1.ReturnCircleArea(inputCircleRadius);
Console.WriteLine($"If a circle has a radius of {inputCircleRadius}, it's area will be " + circleAreaResult + "\n");

Console.WriteLine("Please Enter Your name: ");
string inputName = Console.ReadLine();
string greetingPhrase = task1.ReturnGreeting(inputName);
Console.WriteLine(greetingPhrase);

Console.WriteLine("This is Task #2 of Exam Unit 3 \n");

//Function that returns the array in a line

Console.WriteLine("This is Task #3 of Exam Unit 3 \n");

//Function that returns the nodes as shown

Console.WriteLine("This is Task #4 of Exam Unit 3 \n");

