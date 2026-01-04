namespace LucideBlazor.Extensions;

public static class StrokeLineJoinExtensions
{
    public static string ToString(this StrokeLineJoin obj) => obj switch
    {
        StrokeLineJoin.Arcs => "arcs",
        StrokeLineJoin.Bevel => "bevel",
        StrokeLineJoin.Miter => "miter",
        StrokeLineJoin.MiterClip => "miter-clip",
        StrokeLineJoin.Round => "round",
        _ => throw new ArgumentOutOfRangeException(nameof(obj), obj, null)
    };

    public static StrokeLineJoin FromString(string obj) => obj switch
    {
        "arcs" => StrokeLineJoin.Arcs,
        "bevel" => StrokeLineJoin.Bevel,
        "miter" => StrokeLineJoin.Miter,
        "miter-clip" => StrokeLineJoin.MiterClip,
        "round" => StrokeLineJoin.Round,
        _ => throw new ArgumentOutOfRangeException(nameof(obj), obj, null)
    };
}