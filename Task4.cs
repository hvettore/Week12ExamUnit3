using System.Text.RegularExpressions;

public class task4
{
    public string? title { get; set; }
    public int publication_year { get; set; }
    public string? author { get; set; }
    public string? isbn { get; set; }

    public static List<task4> GetBooksStartingWithThe(List<task4> books)
    {
        return books.Where(book => book.title?.StartsWith("The", StringComparison.OrdinalIgnoreCase) == true).ToList();
    }

    public static List<task4> GetBooksByAuthorsWithTInName(List<task4> books)
    {
        return books.Where(book => book.author?.IndexOf("t", StringComparison.OrdinalIgnoreCase) >= 0).ToList();
    }

    public static int GetNumberOfBooksAfterYear(List<task4> books, int year)
    {
        return books.Count(book => book.publication_year > year);
    }

    public static int GetNumberOfBooksBeforeYear(List<task4> books, int year)
    {
        return books.Count(book => book.publication_year < year);
    }

    public static Dictionary<string, List<string>> GetAuthorNamesWithISBN(List<task4> books, string authorFullName)
    {
        Dictionary<string, List<string>> authorNamesWithISBN = new Dictionary<string, List<string>>();

        foreach (task4 book in books)
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

    public static List<task4> GetBookInAlphabeticalOrderAscending(List<task4> books)
    {
        return books.OrderBy(book => book.title).ToList();
    }

    public static List<task4> GetBookInAlphabeticalOrderDescending(List<task4> books)
    {
        return books.OrderByDescending(book => book.title).ToList();
    }

    public static List<task4> GetBookInChronologicalOrderAscending(List<task4> books)
    {
        return books.OrderBy(book => book.publication_year).ToList();
    }

    public static List<task4> GetBookInChronologicalOrderDescending(List<task4> books)
    {
        return books.OrderByDescending(book => book.publication_year).ToList();
    }

    public static List<task4> GetBookGroupedAuthorLastName(List<task4> books)
    {
        return books.OrderBy(book => GetLastNameWithoutBrackets(book.author)).ToList();
    }

    private static string GetLastNameWithoutBrackets(string author)
    {
        string lastName = Regex.Replace(author, @"\([^()]*\)", ""); // Remove content within brackets
        lastName = Regex.Replace(lastName, @"\s+", " ").Trim(); // Remove extra spaces
        return lastName?.Split(" ").Last();
    }

    public static List<task4> GetBookGroupedAuthorFirstName(List<task4> books)
    {
        return books.OrderBy(book => GetFirstNameWithoutBrackets(book.author)).ToList();
    }

    private static string GetFirstNameWithoutBrackets(string author)
    {
        string firstName = Regex.Replace(author, @"\([^()]*\)", ""); // Remove content within brackets
        firstName = Regex.Replace(firstName, @"\s+", " ").Trim(); // Remove extra spaces
        return firstName?.Split(" ").First();
    }

    public static List<task4> GetBookGroupedAuthorFullName(List<task4> books)
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
