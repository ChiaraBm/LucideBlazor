namespace LucideBlazor.Extensions;

internal static class StrokeLineCapExtensions
{
    internal static string ToString(this StrokeLineCap obj) => obj switch
    {
        StrokeLineCap.Butt => "butt",
        StrokeLineCap.Round => "round",
        StrokeLineCap.Square => "square",
        _ => throw new ArgumentOutOfRangeException(nameof(obj), obj, null)
    };
}