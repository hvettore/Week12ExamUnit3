using System.Text.Json;
public class task2
{
    public static void Flatten(List<object> data, List<int> numbers)
    {
        foreach (var item in data)
        {
            if (item is JsonElement element)
            {
                if (element.ValueKind == JsonValueKind.Array)
                {
                    Flatten(element.EnumerateArray().Select(x => (object)x).ToList(), numbers);
                }
                else if (element.ValueKind == JsonValueKind.Number && element.TryGetInt32(out int number))
                {
                    numbers.Add(number);
                }
            }
        }
    }

}