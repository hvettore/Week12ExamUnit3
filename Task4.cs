using System.Text.RegularExpressions;

public class Task4
{
    public string? title { get; set; }
    public int publication_year { get; set; }
    public string? author { get; set; }
    public string? isbn { get; set; }

    public static List<Task4> GetBooksStartingWithThe(List<Task4> books)
    {
        return books.Where(book => book.title?.StartsWith(TextTask4.task4Part1Query, StringComparison.OrdinalIgnoreCase) == true).ToList();
    }

    public static List<Task4> GetBooksByAuthorsWithTInName(List<Task4> books)
    {
        return books.Where(book => book.author?.IndexOf(TextTask4.task4Part2Query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
    }

    public static int GetNumberOfBooksAfterYear(List<Task4> books, int year)
    {
        return books.Count(book => book.publication_year > year);
    }

    public static int GetNumberOfBooksBeforeYear(List<Task4> books, int year)
    {
        return books.Count(book => book.publication_year < year);
    }

    public static Dictionary<string, List<string>> GetAuthorNamesWithISBN(List<Task4> books, string authorFullName)
    {
        Dictionary<string, List<string>> authorNamesWithISBN = new Dictionary<string, List<string>>();

        foreach (Task4 book in books)
        {
            if (book.author?.Equals(authorFullName, StringComparison.OrdinalIgnoreCase) == true)
            {
                if (!authorNamesWithISBN.ContainsKey(authorFullName))
                {
                    authorNamesWithISBN[authorFullName] = new List<string>();
                }

                string isbn = book.isbn ?? "";
                authorNamesWithISBN[authorFullName].Add(isbn);
            }
        }

        return authorNamesWithISBN;
    }

    public static List<Task4> GetBookInAlphabeticalOrderAscending(List<Task4> books)
    {
        return books.OrderBy(book => book.title).ToList();
    }

    public static List<Task4> GetBookInAlphabeticalOrderDescending(List<Task4> books)
    {
        return books.OrderByDescending(book => book.title).ToList();
    }

    public static List<Task4> GetBookInChronologicalOrderAscending(List<Task4> books)
    {
        return books.OrderBy(book => book.publication_year).ToList();
    }

    public static List<Task4> GetBookInChronologicalOrderDescending(List<Task4> books)
    {
        return books.OrderByDescending(book => book.publication_year).ToList();
    }

    public static List<Task4> GetBookGroupedAuthorLastName(List<Task4> books)
    {
        return books.OrderBy(book => GetLastNameWithoutBrackets(book.author)).ToList();
    }

    private static string? GetLastNameWithoutBrackets(string? author)
    {
        if (author == null)
        {
            return "";
        }
        string? lastName = Regex.Replace(author, TextTask4.task4RegexReplace, "");
        if (lastName != null)
        {
            lastName = Regex.Replace(lastName, TextTask4.task4RegexReplace, " ").Trim();
            return lastName.Split(" ").Last();
        }
        return null;
    }


    public static List<Task4> GetBookGroupedAuthorFirstName(List<Task4> books)
    {
        return books.OrderBy(book => GetFirstNameWithoutBrackets(book.author)).ToList();
    }


    private static string? GetFirstNameWithoutBrackets(string? author)
    {
        if (author == null)
        {
            return "";
        }
        string? firstName = Regex.Replace(author, TextTask4.task4RegexReplace, "");
        if (firstName != null)
        {
            firstName = Regex.Replace(firstName, GeneralText.extraSpace, " ").Trim();
            return firstName.Split(" ").First();
        }
        return null;
    }


    public static List<Task4> GetBookGroupedAuthorFullName(List<Task4> books)
    {
        return books.OrderBy(book => GetFullNameNameWithoutBrackets(book.author)).ToList();
    }

    private static string GetFullNameNameWithoutBrackets(string? author)
    {
        if (author == null)
        {
            return "";
        }
        string? fullName = Regex.Replace(author, TextTask4.task4RegexReplace, "");
        fullName = Regex.Replace(fullName, GeneralText.extraSpace, " ").Trim();
        return fullName;
    }

}
