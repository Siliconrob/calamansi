namespace calamansi.ServiceInterface.Utils;

public static class GenericSearchExtensions
{
    private static readonly IFlatDictionaryProvider Runner = new Flatten();

    public static List<T> SearchAll<T>(this IList<T> targets, string searchTerm) where T : class, new()
    {
        return (targets ?? new List<T>()).Where(z => z.Search(searchTerm)).ToList();
    }
    
    public static bool Search<T>(this T target, string searchTerm) where T : class, new()
    {
        var flatDict = Runner.Execute(target);
        var dataItems = new Queue<string>(flatDict.Values);
        var match = false;
        while (dataItems.Count != 0)
        {
            var itemValue = dataItems.Dequeue();
            if (string.IsNullOrWhiteSpace(itemValue) || !itemValue.Contains(searchTerm))
            {
                continue;
            }
            match = true;
            break;
        }
        return match;
    }
}