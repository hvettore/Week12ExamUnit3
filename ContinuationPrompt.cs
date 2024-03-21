
public class Prompt
{
    public void WaitForEnterKey()
    {
        Console.WriteLine(GeneralText.newLine + GeneralText.continuationPrompt);
        while (Console.ReadKey().Key != ConsoleKey.Enter)
        {
        }
        Console.WriteLine(GeneralText.newLine);
    }
}