using System.Reflection;

namespace calamansi.ServiceInterface.Utils;

public static class ObjectExtensions
{
    public static IEnumerable<T> OrderByDynamic<T>(this IEnumerable<T> entities, string propertyName, bool ascending = false) where T : class, new()
    {
        var orderBy = entities as T[] ?? entities.ToArray();
        if (orderBy.Length == 0 || string.IsNullOrWhiteSpace(propertyName))
        {
            return orderBy;
        }
        var propertyInfo = orderBy.First().GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        var ordered = orderBy.OrderBy(e => propertyInfo?.GetValue(e, null));
        return !ascending ? ordered : ordered.Reverse();
    }
}