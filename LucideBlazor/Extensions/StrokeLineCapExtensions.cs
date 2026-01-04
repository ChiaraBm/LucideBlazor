namespace LucideBlazor.Extensions;

public static class StrokeLineCapExtensions
{
    public static string ToString(this StrokeLineCap obj) => obj switch
    {
        StrokeLineCap.Butt => "butt",
        StrokeLineCap.Round => "round",
        StrokeLineCap.Square => "square",
        _ => throw new ArgumentOutOfRangeException(nameof(obj), obj, null)
    };
    
    public static StrokeLineCap FromString(string obj) => obj switch
    {
        "butt" => StrokeLineCap.Butt,
        "round" => StrokeLineCap.Round,
        "square" => StrokeLineCap.Square,
        _ => throw new ArgumentOutOfRangeException(nameof(obj), obj, null)
    };
}