using System.Text.Json;

class Program
{
    static void Main()
    {
        Console.Clear();
        //Task1();
        //Task2();
        //Task3();
        Task4();
    }

    static void Task1()
    {
        Console.WriteLine(TextTask1.task1Introduction);

        Console.WriteLine(TextTask1.task1Part1Question);
        double inputNumberToSquare = Convert.ToDouble(InputChecker.GetNumberOrDecimal());
        double squaredResult = global::Task1.ReturnSquareNumber(inputNumberToSquare);
        Console.WriteLine(TextTask1.task1Part1Result + squaredResult + GeneralText.newLine);

        Console.WriteLine(TextTask1.task1Part2Question);
        double inputLength = Convert.ToDouble(InputChecker.GetNumberOrDecimal());
        double inchesToMillimetersResult = global::Task1.ReturnLengthInMillimeters(inputLength);
        Console.WriteLine(inputLength + TextTask1.task1Part2Result1 + inchesToMillimetersResult + TextTask1.task1Part2Result2 + GeneralText.newLine);

        Console.WriteLine(TextTask1.task1Part3Question);
        double inputNumberRoot = Convert.ToDouble(InputChecker.GetNumberOrDecimal());
        double rootResult = global::Task1.ReturnRootNumber(inputNumberRoot);
        Console.WriteLine(TextTask1.task1Part3Result + rootResult + GeneralText.newLine);

        Console.WriteLine(TextTask1.task1Part4Question);
        double inputNumberToCube = Convert.ToDouble(InputChecker.GetNumberOrDecimal());
        double cubedResult = global::Task1.ReturnCubedNumber(inputNumberToCube);
        Console.WriteLine(TextTask1.task1Part4Result + cubedResult + GeneralText.newLine);

        Console.WriteLine(TextTask1.task1Part5Question);
        double inputCircleRadius = Convert.ToDouble(InputChecker.GetNumberOrDecimal());
        double circleAreaResult = global::Task1.ReturnCircleArea(inputCircleRadius);
        Console.WriteLine(TextTask1.task1Part5Result + circleAreaResult + GeneralText.newLine);

        Console.WriteLine(TextTask1.task1Part6Question);
        string inputName = InputChecker.GetString() ?? string.Empty;
        string greetingPhrase = global::Task1.ReturnGreeting(inputName);
        Console.WriteLine(greetingPhrase);
        new Prompt().WaitForEnterKey();
    }

    static void Task2()
    {
        Console.Clear();
        Console.WriteLine(TextTask2.task2Introduction + GeneralText.newLine);

        string json = File.ReadAllText(TextTask2.task2JSONRead);
        List<object>? data = JsonSerializer.Deserialize<List<object>>(json);

        if (data != null)
        {
            List<int> numbers = new List<int>();
            global::Task2.Flatten(data, numbers);

            string numbersString = string.Join(GeneralText.commaSeparator, numbers);
            Console.WriteLine($"[{numbersString}]");
        }
        else
        {
            Console.WriteLine(GeneralText.invalidJSON);
        }

        new Prompt().WaitForEnterKey();
    }


    static void Task3()
    {
        Console.Clear();
        Console.WriteLine(TextTask3.task3Introduction);

        string json = File.ReadAllText(TextTask3.task3JSONRead);
        Node? mainNode = JsonSerializer.Deserialize<Node>(json);

        if (mainNode != null)
        {
            int sum = global::Task3.ValueSum(mainNode);
            int deepestLevel = global::Task3.LocateDeepestLevel(mainNode);
            int nodeCount = global::Task3.NodeCount(mainNode);

            Console.WriteLine(TextTask3.task3Part1 + sum);
            Console.WriteLine(TextTask3.task3Part2 + deepestLevel);
            Console.WriteLine(TextTask3.task3Part3 + nodeCount);
        }
        else
        {
            Console.WriteLine(GeneralText.invalidJSON);
        }

        new Prompt().WaitForEnterKey();
    }


    static void Task4()
    {
        Console.WriteLine(TextTask4.task4Introduction + GeneralText.newLine);

        string json = File.ReadAllText(TextTask4.task4JSONRead);
        List<Task4>? books = JsonSerializer.Deserialize<List<Task4>>(json);

        if (books != null)
        {
            // Task 1: Return only books starting with `The`
            List<Task4> booksStartingWithThe = global::Task4.GetBooksStartingWithThe(books);
            Console.WriteLine(TextTask4.task4Part1Prompt);
            foreach (var book in booksStartingWithThe)
            {
                Console.WriteLine(GeneralText.hifenSpace + book.title);
            }
            Console.WriteLine(GeneralText.newLine);
            new Prompt().WaitForEnterKey();

            // Task 2: Return only books written by authors with a 't' in their name
            Console.Clear();
            List<Task4> booksByAuthorsWithTInName = global::Task4.GetBooksByAuthorsWithTInName(books);
            Console.WriteLine(TextTask4.task4Part2Prompt);
            foreach (var book in booksByAuthorsWithTInName)
            {
                Console.WriteLine(GeneralText.hifenSpace + book.title + TextTask4.task4BookBy + book.author);
            }
            Console.WriteLine(GeneralText.newLine);
            new Prompt().WaitForEnterKey();

            // Task 3: The number of books written after 1992
            Console.Clear();
            int numberOfBooksAfter1992 = global::Task4.GetNumberOfBooksAfterYear(books, 1992);
            Console.WriteLine(TextTask4.task4Part3Prompt + numberOfBooksAfter1992 + GeneralText.newLine);

            // Task 4: The number of books written before `2004`
            int numberOfBooksBefore2004 = global::Task4.GetNumberOfBooksBeforeYear(books, 2004);
            Console.WriteLine(TextTask4.task4Part4Prompt + numberOfBooksBefore2004 + GeneralText.newLine);
            new Prompt().WaitForEnterKey();

            // Task 5: Return isbn book numbers based on author input
            Console.Clear();
            Console.WriteLine(TextTask4.task4Part5Prompt);
            string authorFullName;
            Dictionary<string, List<string>> authorNamesWithISBN;

            do
            {
                authorFullName = InputChecker.GetStringWithSpaceAndParentheses() ?? string.Empty;
                authorNamesWithISBN = global::Task4.GetAuthorNamesWithISBN(books, authorFullName);

                if (authorNamesWithISBN.ContainsKey(authorFullName))
                {
                    Console.WriteLine(TextTask4.task4Part5Valid + authorFullName);
                    foreach (var isbn in authorNamesWithISBN[authorFullName])
                    {
                        Console.WriteLine(GeneralText.hifenSpace + isbn);
                    }
                }
                else
                {
                    Console.WriteLine(TextTask4.task4Part5Invalid + authorFullName);
                }
            } while (!authorNamesWithISBN.ContainsKey(authorFullName));

            new Prompt().WaitForEnterKey();

            // Task 6: List books alphabetically ascending or descending
            Console.Clear();
            string alphabeticallyChoice;

            do
            {
                Console.WriteLine(TextTask4.task4Part6Prompt);
                alphabeticallyChoice = InputChecker.GetString() ?? string.Empty;

                if (alphabeticallyChoice == GeneralText.ascendingInput)
                {
                    List<Task4> booksInAlphabeticalOrder = global::Task4.GetBookInAlphabeticalOrderAscending(books);
                    Console.WriteLine(TextTask4.task4Part6AscendingOutput);
                    foreach (var book in booksInAlphabeticalOrder)
                    {
                        Console.WriteLine(GeneralText.hifenSpace + book.title + TextTask4.task4BookBy + book.author);
                    }
                    Console.WriteLine(GeneralText.newLine);
                }
                else if (alphabeticallyChoice == GeneralText.descendingInput)
                {
                    List<Task4> booksInAlphabeticalOrder = global::Task4.GetBookInAlphabeticalOrderDescending(books);
                    Console.WriteLine(TextTask4.task4Part6DescendingOutput);
                    foreach (var book in booksInAlphabeticalOrder)
                    {
                        Console.WriteLine(GeneralText.hifenSpace + book.title + TextTask4.task4BookBy + book.author);
                    }
                    Console.WriteLine(GeneralText.newLine);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(TextTask4.task4OrderInvalid);
                }
            } while (alphabeticallyChoice != GeneralText.ascendingInput && alphabeticallyChoice != GeneralText.descendingInput);

            new Prompt().WaitForEnterKey();


            Console.Clear();
            string chronologicallyChoice;

            do
            {
                Console.WriteLine(TextTask4.task4Part7Prompt);
                chronologicallyChoice = InputChecker.GetString() ?? string.Empty;

                if (chronologicallyChoice == GeneralText.ascendingInput)
                {
                    List<Task4> booksInChronologicalOrder = global::Task4.GetBookInChronologicalOrderAscending(books);
                    Console.WriteLine(TextTask4.task4Part7AscendingOutput);
                    foreach (var book in booksInChronologicalOrder)
                    {
                        Console.WriteLine(GeneralText.hifenSpace + book.title + TextTask4.task4Part7Output + book.publication_year);
                    }
                    Console.WriteLine(GeneralText.newLine);
                }
                else if (chronologicallyChoice == GeneralText.descendingInput)
                {
                    List<Task4> booksInChronologicalOrder = global::Task4.GetBookInChronologicalOrderDescending(books);
                    Console.WriteLine(TextTask4.task4Part7DescendingOutput);
                    foreach (var book in booksInChronologicalOrder)
                    {
                        Console.WriteLine(GeneralText.hifenSpace + book.title + TextTask4.task4Part7Output + book.publication_year);
                    }
                    Console.WriteLine(GeneralText.newLine);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(TextTask4.task4OrderInvalid);
                }
            } while (chronologicallyChoice != GeneralText.ascendingInput && chronologicallyChoice != GeneralText.descendingInput);

            new Prompt().WaitForEnterKey();


            // Task 8: List books grouped by author last name
            Console.Clear();
            List<Task4> booksGroupedByAuthorLastName = global::Task4.GetBookGroupedAuthorLastName(books);
            Console.WriteLine(TextTask4.task4Part8);
            foreach (var book in booksGroupedByAuthorLastName)
            {
                Console.WriteLine(GeneralText.hifenSpace + book.title + TextTask4.task4BookBy + book.author);
            }
            Console.WriteLine(GeneralText.newLine);
            new Prompt().WaitForEnterKey();

            // Task 9: List books grouped by author first name
            Console.Clear();
            List<Task4> booksGroupedByAuthorFirstName = global::Task4.GetBookGroupedAuthorFirstName(books);
            Console.WriteLine(TextTask4.task4Part9);
            foreach (var book in booksGroupedByAuthorFirstName)
            {
                Console.WriteLine(GeneralText.hifenSpace + book.title + TextTask4.task4BookBy + book.author);
            }
            Console.WriteLine(GeneralText.newLine);
        }
        else
        {
            Console.WriteLine(GeneralText.invalidJSON);
        }
    }

}

