using System.Reflection;

namespace calamansi.ServiceInterface.Utils;

public static class ObjectExtensions
{
    public static string CacheKey<T>(this T? current, string id = "") where T : class, new()
    {
        return $"{(current ?? new T()).GetType().FullName ?? "prefix"}{id ?? ""}";
    }
    
    public static IEnumerable<T> OrderByDynamic<T>(this IEnumerable<T> entities, string propertyName, bool desc = true) where T : class, new()
    {
        var orderBy = entities as T[] ?? entities.ToArray();
        if (orderBy.Length == 0 || string.IsNullOrWhiteSpace(propertyName))
        {
            return orderBy;
        }
        var propertyInfo = orderBy.First().GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        var ordered = orderBy.OrderBy(e => propertyInfo?.GetValue(e, null));
        return desc ? ordered : ordered.Reverse();
    }
}