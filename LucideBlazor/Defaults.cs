using System.Collections.Frozen;

namespace LucideBlazor;

internal static class Defaults
{
    internal static readonly FrozenDictionary<string, object> DefaultAttributes = new Dictionary<string, object>
    {
        ["xmlns"] = "http://www.w3.org/2000/svg",
        ["width"] = 24,
        ["height"] = 24,
        ["viewBox"] = "0 0 24 24",
        ["fill"] = "none",
        ["stroke"] = "currentColor",
        ["stroke-width"] = 2,
        ["stroke-linecap"] = "round",
        ["stroke-linejoin"] = "round"
    }.ToFrozenDictionary();
}