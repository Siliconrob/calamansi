namespace calamansi.ServiceInterface.Utils;

public interface IFlatDictionaryProvider
{
    Dictionary<string, string> Execute(object @object, string prefix = "");
}