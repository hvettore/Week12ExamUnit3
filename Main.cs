﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Task1();
        Task2();
        Task3();
        Task4();
    }

    static void Task1()
    {
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
    }

    static void Task2()
    {
        Console.WriteLine("This is Task #2 of Exam Unit 3 \n");
    }

    static void Task3()
    {
        Console.WriteLine("This is Task #3 of Exam Unit 3 \n");
    }

    static void Task4()
    {
        Console.WriteLine("This is Task #4 of Exam Unit 3 \n");


        string json = File.ReadAllText("example_files/books.json");
        List<Book> books = JsonSerializer.Deserialize<List<Book>>(json);

        //Task 1: Return only books starting with `The`
        List<Book> booksStartingWithThe = Book.GetBooksStartingWithThe(books);
        Console.WriteLine("Books starting with 'The':");
        foreach (var book in booksStartingWithThe)
        {
            Console.WriteLine($"- {book.title}");
        }

        Console.WriteLine();

        //Task 2: Return only books written by authors with a 't' in their name
        List<Book> booksByAuthorsWithTInName = Book.GetBooksByAuthorsWithTInName(books);
        Console.WriteLine("Books written by authors with 't' in their name:");
        foreach (var book in booksByAuthorsWithTInName)
        {
            Console.WriteLine($"- {book.title} by {book.author}");
        }
        Console.WriteLine();

        // Task 3: The number of books written after 1992
        int numberOfBooksAfter1992 = Book.GetNumberOfBooksAfterYear(books, 1992);
        Console.WriteLine($"Number of books written after 1992: {numberOfBooksAfter1992}");

        // Task 4: The number of books written before `2004`
        int numberOfBooksBefore2004 = Book.GetNumberOfBooksBeforeYear(books, 2004);
        Console.WriteLine($"Number of books written before 2004: {numberOfBooksBefore2004}");
        Console.WriteLine();

        // Task 5: Return isbn book numbers based on author input

        Console.WriteLine("Write the first and last name of an author to get their books' ISBNs:");
        string authorFullName = Console.ReadLine();

        Dictionary<string, List<string>> authorNamesWithISBN = Book.GetAuthorNamesWithISBN(books, authorFullName);

        if (authorNamesWithISBN.ContainsKey(authorFullName))
        {
            Console.WriteLine($"ISBN numbers of books written by {authorFullName}:");
            foreach (var isbn in authorNamesWithISBN[authorFullName])
            {
                Console.WriteLine($"- {isbn}");
            }
        }
        else
        {
            Console.WriteLine($"No books found for author: {authorFullName}");
        }

        //Task 6: List books alphabetically assending or decendig 
        Console.WriteLine("Would you like the books ordered alphabetically ascending or descending?");
        string alphabeticallyChoice = Console.ReadLine();
        if (alphabeticallyChoice == "ascending")
        {
            List<Book> booksInAlphabeticalOrder = Book.GetBookInAlphabeticalOrderAscending(books);
            Console.WriteLine("Books in ascending alphabetical order:");
            foreach (var book in booksInAlphabeticalOrder)
            {
                Console.WriteLine($"- {book.title} by {book.author}");
            }
            Console.WriteLine();
        }
        else if (alphabeticallyChoice == "descending")
        {
            List<Book> booksInAlphabeticalOrder = Book.GetBookInAlphabeticalOrderDescending(books);
            Console.WriteLine("Books in descending alphabetical order:");
            foreach (var book in booksInAlphabeticalOrder)
            {
                Console.WriteLine($"- {book.title} by {book.author}");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Invalid choice");
        }


        //Task 7: List books chronologically assending or decendig
        Console.WriteLine("Would you like the books ordered chronologically ascending or descending?");
        string chronologicallyChoice = Console.ReadLine();
        if (chronologicallyChoice == "ascending")
        {
            List<Book> booksInChronologicalOrder = Book.GetBookInChronologicalOrderAscending(books);
            Console.WriteLine("Books in ascending chronolgical order:");
            foreach (var book in booksInChronologicalOrder)
            {
                Console.WriteLine($"- {book.title} written in {book.publication_year}");
            }
            Console.WriteLine();
        }
        else if (chronologicallyChoice == "descending")
        {
            List<Book> booksInChronologicalOrder = Book.GetBookInChronologicalOrderDescending(books);
            Console.WriteLine("Books in descending chronolgical order:");
            foreach (var book in booksInChronologicalOrder)
            {
                Console.WriteLine($"- {book.title} written in {book.publication_year}");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Invalid choice");
        }

        //Task 8: List books grouped by author last name

        List<Book> booksGroupedByAuthorLastName = Book.GetBookGroupedAuthorLastName(books);
        Console.WriteLine("Books grouped by the author's last name:");
        foreach (var book in booksGroupedByAuthorLastName)
        {
            Console.WriteLine($"- {book.title} by {book.author}");
        }
        Console.WriteLine();

        //Task 9: Lits books grouped by author first name

        List<Book> booksGroupedByAuthorFirstName = Book.GetBookGroupedAuthorFirstName(books);
        Console.WriteLine("Books grouped by the author's first name:");
        foreach (var book in booksGroupedByAuthorFirstName)
        {
            Console.WriteLine($"- {book.title} by {book.author}");
        }
        Console.WriteLine();
    }
}
