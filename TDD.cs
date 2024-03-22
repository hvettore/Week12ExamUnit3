using System.Text.Json;
public static class TDD
{
    public static void PrintTestResultSuccess(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static void PrintTestResultFail(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static void TestTask1()
    {
        double number = 5;
        double expected = 25;
        double actual = Task1.ReturnSquareNumber(number);
        if (expected != actual)
        {
            PrintTestResultFail($"Test 1 failed. Expected: {expected}, Actual: {actual}");
        }
        else
        {
            PrintTestResultSuccess("Test 1 passed.");
        }

        number = 5;
        expected = 127;
        actual = Task1.ReturnLengthInMillimeters(number);
        if (expected != actual)
        {
            PrintTestResultFail($"Test 2 failed. Expected: {expected}, Actual: {actual}");
        }
        else
        {
            PrintTestResultSuccess("Test 2 passed.");
        }

        number = 25;
        expected = 5;
        actual = Task1.ReturnRootNumber(number);
        if (expected != actual)
        {
            PrintTestResultFail($"Test 3 failed. Expected: {expected}, Actual: {actual}");
        }
        else
        {
            PrintTestResultSuccess("Test 3 passed.");
        }

        number = 5;
        expected = 125;
        actual = Task1.ReturnCubedNumber(number);
        if (expected != actual)
        {
            PrintTestResultFail($"Test 4 failed. Expected: {expected}, Actual: {actual}");
        }
        else
        {
            PrintTestResultSuccess("Test 4 passed.");
        }

        number = 5;
        expected = 15.708;
        actual = Task1.ReturnCircleArea(number);
        if (expected != actual)
        {
            PrintTestResultFail($"Test 5 failed. Expected: {expected}, Actual: {actual}");
        }
        else
        {
            PrintTestResultSuccess("Test 5 passed.");
        }

        string name = "John";
        string expectedString = "Good afternoon John. I hope you have a good day!";
        string actualString = Task1.ReturnGreeting(name);
        if (expectedString != actualString)
        {
            PrintTestResultFail($"Test 6 failed. Expected: {expectedString}, Actual: {actualString}");
        }
        else
        {
            PrintTestResultSuccess("Test 6 passed.");
        }
    }

    public static void TestTask2()
    {
        string expectedString = "[435, 2028, 3047, 4910, 8146, 7999, 1433, 7211, 1197, 6002, 2821, 3508]";
        string json = File.ReadAllText("TDD_files/arrays.json");
        List<object>? data = JsonSerializer.Deserialize<List<object>>(json);
        if (data != null)
        {
            List<int> numbers = new List<int>();
            Task2.Flatten(data, numbers);
            string numbersString = string.Join(GeneralText.commaSeparator, numbers);
            string actualString = $"[{numbersString}]";

            if (actualString == expectedString)
            {
                PrintTestResultSuccess("Test passed!");
            }
            else
            {
                PrintTestResultFail($"Test failed! Expected: {expectedString}, Actual: {actualString}");
            }
        }
        else
        {
            Console.WriteLine(GeneralText.invalidJSON);
        }
    }

    public static void TestTask3()
    {
        string json = File.ReadAllText("TDD_files/nodes.json");
        Node? mainNode = JsonSerializer.Deserialize<Node>(json);

        if (mainNode != null)
        {
            string expectedString = "Sum = 1942" + GeneralText.newLine + "Deepest level = 4" + GeneralText.newLine + "Node count = 5";

            int sum = Task3.ValueSum(mainNode);
            int deepestLevel = Task3.LocateDeepestLevel(mainNode);
            int nodeCount = Task3.NodeCount(mainNode);

            string actualString = TextTask3.task3Part1 + sum + GeneralText.newLine + TextTask3.task3Part2 + deepestLevel + GeneralText.newLine + TextTask3.task3Part3 + nodeCount;
            if (actualString == expectedString)
            {
                PrintTestResultSuccess("Test passed!");
            }
            else
            {
                PrintTestResultFail($"Test failed! Expected: {expectedString}, Actual: {actualString}");
            }
        }
        else
        {
            Console.WriteLine(GeneralText.invalidJSON);
        }
    }

    public static void TestTask4()
    {
        string json = File.ReadAllText("TDD_files/books.json");
        List<Task4>? books = JsonSerializer.Deserialize<List<Task4>>(json);

        if (books != null)
        {
            string expectedString1 = "- The Collapsing Empire" + "\n" + "- The Colour of Magic" + "\n" + "- The Last Emperox" + "\n";
            List<Task4> booksStartingWithThe = Task4.GetBooksStartingWithThe(books);
            string actualString1 = "";

            foreach (var book in booksStartingWithThe)
            {
                actualString1 += GeneralText.hifenSpace + book.title + "\n";
            }

            if (actualString1 == expectedString1)
            {
                PrintTestResultSuccess("Test #1 passed!");
            }
            else
            {
                PrintTestResultFail($"Test failed!" + "\n" + "Expected:" + "\n" + $"{expectedString1}" + "\n" + "Actual:" + "\n" + $"{actualString1}");
            }

            string expectedString2 = "- Snuff" + "\n" + "- The Colour of Magic" + "\n" + "- Thief of Time" + "\n" + "- Reaper Man" + "\n";
            List<Task4> booksByAuthorsWithTInName = Task4.GetBooksByAuthorsWithTInName(books);
            string actualString2 = "";
            foreach (var book in booksByAuthorsWithTInName)
            {
                actualString2 += GeneralText.hifenSpace + book.title + "\n";
            }

            if (actualString2 == expectedString2)
            {
                PrintTestResultSuccess("Test #2 passed!");
            }
            else
            {
                PrintTestResultFail($"Test failed!" + "\n" + "Expected:" + "\n" + $"{expectedString2}" + "\n" + "Actual:" + "\n" + $"{actualString2}");
            }

            string expectedString3 = "4";
            string actualString3 = Task4.GetNumberOfBooksAfterYear(books, 1992).ToString();
            if (expectedString3 == actualString3)
            {
                PrintTestResultSuccess("Test #3 passed!");
            }
            else
            {
                PrintTestResultFail($"Test failed!" + "\n" + "Expected:" + "\n" + $"{expectedString3}" + "\n" + "Actual:" + "\n" + $"{actualString3}");
            }

            string expectedString4 = "3";
            string actualString4 = Task4.GetNumberOfBooksBeforeYear(books, 2004).ToString();
            if (expectedString4 == actualString4)
            {
                PrintTestResultSuccess("Test #4 passed!");
            }
            else
            {
                PrintTestResultFail($"Test failed!" + "\n" + "Expected:" + "\n" + $"{expectedString4}" + "\n" + "Actual:" + "\n" + $"{actualString4}");
            }

            string expectedString5 = "- 0-385-61823-5" + GeneralText.newLine + "- 0-86140-324-X" + GeneralText.newLine + "- 0-385-60224-3" + GeneralText.newLine + "- 0-575-04979-4" + GeneralText.newLine;
            string actualString5 = "";
            string authorFullName = "Terry Pratchett";
            Dictionary<string, List<string>> authorNamesWithISBN;
            authorNamesWithISBN = Task4.GetAuthorNamesWithISBN(books, authorFullName);
            foreach (var isbn in authorNamesWithISBN[authorFullName])
            {
                actualString5 += GeneralText.hifenSpace + isbn + GeneralText.newLine;
            }
            if (expectedString5 == actualString5)
            {
                PrintTestResultSuccess("Test #5 passed!");
            }
            else
            {
                PrintTestResultFail($"Test failed!" + "\n" + "Expected:" + "\n" + $"{expectedString5}" + "\n" + "Actual:" + "\n" + $"{actualString5}");
            }

            string expectedString6 = "- Reaper Man by Terry Pratchett" + GeneralText.newLine + "- Snuff by Terry Pratchett" + GeneralText.newLine + "- The Collapsing Empire by John Scalzi" + GeneralText.newLine + "- The Colour of Magic by Terry Pratchett" + GeneralText.newLine + "- The Last Emperox by John Scalzi" + GeneralText.newLine + "- Thief of Time by Terry Pratchett" + GeneralText.newLine;
            string actualString6 = "";
            List<Task4> booksInAlphabeticalOrder = Task4.GetBookInAlphabeticalOrderAscending(books);
            foreach (var book in booksInAlphabeticalOrder)
            {
                actualString6 += GeneralText.hifenSpace + book.title + TextTask4.task4BookBy + book.author + GeneralText.newLine;
            }
            if (expectedString6 == actualString6)
            {
                PrintTestResultSuccess("Test #6 passed!");
            }
            else
            {
                PrintTestResultFail($"Test failed!" + "\n" + "Expected:" + "\n" + $"{expectedString6}" + "\n" + "Actual:" + "\n" + $"{actualString6}");
            }

            string expectedString7 = "- The Colour of Magic written in 1983" + GeneralText.newLine + "- Reaper Man written in 1991" + GeneralText.newLine + "- Thief of Time written in 2001" + GeneralText.newLine + "- Snuff written in 2011" + GeneralText.newLine + "- The Collapsing Empire written in 2017" + GeneralText.newLine + "- The Last Emperox written in 2020" + GeneralText.newLine;
            string actualString7 = "";
            List<Task4> booksInChronologicalOrder = global::Task4.GetBookInChronologicalOrderAscending(books);
            foreach (var book in booksInChronologicalOrder)
            {
                actualString7 += GeneralText.hifenSpace + book.title + TextTask4.task4Part7Output + book.publication_year + GeneralText.newLine;
            }
            if (expectedString7 == actualString7)
            {
                PrintTestResultSuccess("Test #7 passed!");
            }
            else
            {
                PrintTestResultFail($"Test failed!" + "\n" + "Expected:" + "\n" + $"{expectedString7}" + "\n" + "Actual:" + "\n" + $"{actualString7}");
            }

            string expectedString8 = "- Snuff by Terry Pratchett" + GeneralText.newLine + "- The Colour of Magic by Terry Pratchett" + GeneralText.newLine + "- Thief of Time by Terry Pratchett" + GeneralText.newLine + "- Reaper Man by Terry Pratchett" + GeneralText.newLine + "- The Collapsing Empire by John Scalzi" + GeneralText.newLine + "- The Last Emperox by John Scalzi" + GeneralText.newLine;
            string actualString8 = "";
            List<Task4> booksGroupedByAuthorLastName = global::Task4.GetBookGroupedAuthorLastName(books);
            foreach (var book in booksGroupedByAuthorLastName)
            {
                actualString8 += GeneralText.hifenSpace + book.title + TextTask4.task4BookBy + book.author + GeneralText.newLine;
            }
            if (expectedString8 == actualString8)
            {
                PrintTestResultSuccess("Test #8 passed!");
            }
            else
            {
                PrintTestResultFail($"Test failed!" + "\n" + "Expected:" + "\n" + $"{expectedString8}" + "\n" + "Actual:" + "\n" + $"{actualString8}");
            }

            string expectedString9 = "- The Collapsing Empire by John Scalzi" + GeneralText.newLine + "- The Last Emperox by John Scalzi" + GeneralText.newLine + "- Snuff by Terry Pratchett" + GeneralText.newLine + "- The Colour of Magic by Terry Pratchett" + GeneralText.newLine + "- Thief of Time by Terry Pratchett" + GeneralText.newLine + "- Reaper Man by Terry Pratchett" + GeneralText.newLine;
            string actualString9 = "";
            List<Task4> booksGroupedByAuthorFirstName = global::Task4.GetBookGroupedAuthorFirstName(books);
            foreach (var book in booksGroupedByAuthorFirstName)
            {
                actualString9 += GeneralText.hifenSpace + book.title + TextTask4.task4BookBy + book.author + GeneralText.newLine;
            }
            if (expectedString9 == actualString9)
            {
                PrintTestResultSuccess("Test #9 passed!");
            }
            else
            {
                PrintTestResultFail($"Test failed!" + "\n" + "Expected:" + "\n" + $"{expectedString9}" + "\n" + "Actual:" + "\n" + $"{actualString9}");
            }
        }
        else
        {
            Console.WriteLine(GeneralText.invalidJSON);
        }

    }
}