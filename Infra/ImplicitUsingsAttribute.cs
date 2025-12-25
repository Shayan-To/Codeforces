using System.Reflection;

namespace Infra;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
public class ImplicitUsingsAttribute : Attribute
{
    public ImplicitUsingsAttribute(string usings)
    {
        this._Usings = usings;
    }

    private static string[] GetUsings()
    {
        var usings = Assembly.GetEntryAssembly()?.GetCustomAttributes<ImplicitUsingsAttribute>().SingleOrDefault()?._Usings;
        if (usings == "")
        {
            usings = null;
        }
        return usings?.Split(";") ?? [];
    }

    public static IEnumerable<string> Usings { get; } = [.. GetUsings()];


    private readonly string _Usings;
}
