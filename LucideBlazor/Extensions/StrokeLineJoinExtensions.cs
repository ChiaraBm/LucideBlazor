namespace LucideBlazor.Extensions;

public static class StrokeLineJoinExtensions
{
    public static string ToKebabCase(this StrokeLineJoin obj) => obj switch
    {
        StrokeLineJoin.Arcs => "arcs",
        StrokeLineJoin.Bevel => "bevel",
        StrokeLineJoin.Miter => "miter",
        StrokeLineJoin.MiterClip => "miter-clip",
        StrokeLineJoin.Round => "round",
        _ => throw new ArgumentOutOfRangeException(nameof(obj), obj, null)
    };
}