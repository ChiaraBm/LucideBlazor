namespace LucideBlazor.Extensions;

public static class StrokeLineCapExtensions
{
    public static string ToKebabCase(this StrokeLineCap obj) => obj switch
    {
        StrokeLineCap.Butt => "butt",
        StrokeLineCap.Round => "round",
        StrokeLineCap.Square => "square",
        _ => throw new ArgumentOutOfRangeException(nameof(obj), obj, null)
    };
}