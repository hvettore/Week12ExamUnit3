using System.Text.RegularExpressions;

public class Book
{
    public string? title { get; set; }
    public int publication_year { get; set; }
    public string? author { get; set; }
    public string? isbn { get; set; }

    public static List<Book> GetBooksStartingWithThe(List<Book> books)
    {
        return books.Where(book => book.title?.StartsWith("The", StringComparison.OrdinalIgnoreCase) == true).ToList();
    }

    public static List<Book> GetBooksByAuthorsWithTInName(List<Book> books)
    {
        return books.Where(book => book.author?.IndexOf("t", StringComparison.OrdinalIgnoreCase) >= 0).ToList();
    }

    public static int GetNumberOfBooksAfterYear(List<Book> books, int year)
    {
        return books.Count(book => book.publication_year > year);
    }

    public static int GetNumberOfBooksBeforeYear(List<Book> books, int year)
    {
        return books.Count(book => book.publication_year < year);
    }

    public static Dictionary<string, List<string>> GetAuthorNamesWithISBN(List<Book> books, string authorFullName)
    {
        Dictionary<string, List<string>> authorNamesWithISBN = new Dictionary<string, List<string>>();

        foreach (Book book in books)
        {
            if (book.author?.Equals(authorFullName, StringComparison.OrdinalIgnoreCase) == true)
            {
                if (!authorNamesWithISBN.ContainsKey(authorFullName))
                {
                    authorNamesWithISBN[authorFullName] = new List<string>();
                }

                authorNamesWithISBN[authorFullName].Add(book.isbn);
            }
        }

        return authorNamesWithISBN;
    }

    public static List<Book> GetBookInAlphabeticalOrderAscending(List<Book> books)
    {
        return books.OrderBy(book => book.title).ToList();
    }

    public static List<Book> GetBookInAlphabeticalOrderDescending(List<Book> books)
    {
        return books.OrderByDescending(book => book.title).ToList();
    }

    public static List<Book> GetBookInChronologicalOrderAscending(List<Book> books)
    {
        return books.OrderBy(book => book.publication_year).ToList();
    }

    public static List<Book> GetBookInChronologicalOrderDescending(List<Book> books)
    {
        return books.OrderByDescending(book => book.publication_year).ToList();
    }

    public static List<Book> GetBookGroupedAuthorLastName(List<Book> books)
    {
        return books.OrderBy(book => GetLastNameWithoutBrackets(book.author)).ToList();
    }

    private static string GetLastNameWithoutBrackets(string author)
    {
        string lastName = Regex.Replace(author, @"\([^()]*\)", ""); // Remove content within brackets
        lastName = Regex.Replace(lastName, @"\s+", " ").Trim(); // Remove extra spaces
        return lastName?.Split(" ").Last();
    }

    public static List<Book> GetBookGroupedAuthorFirstName(List<Book> books)
    {
        return books.OrderBy(book => GetFirstNameWithoutBrackets(book.author)).ToList();
    }

    private static string GetFirstNameWithoutBrackets(string author)
    {
        string firstName = Regex.Replace(author, @"\([^()]*\)", ""); // Remove content within brackets
        firstName = Regex.Replace(firstName, @"\s+", " ").Trim(); // Remove extra spaces
        return firstName?.Split(" ").First();
    }

    public static List<Book> GetBookGroupedAuthorFullName(List<Book> books)
    {
        return books.OrderBy(book => GetFullNameNameWithoutBrackets(book.author)).ToList();
    }

    private static string GetFullNameNameWithoutBrackets(string author)
    {
        string fullName = Regex.Replace(author, @"\([^()]*\)", ""); // Remove content within brackets
        fullName = Regex.Replace(fullName, @"\s+", " ").Trim(); // Remove extra spaces
        return fullName;
    }

}
