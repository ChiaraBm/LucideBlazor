namespace LucideBlazor.Extensions;

internal static class StrokeLineJoinExtensions
{
    internal static string ToString(this StrokeLineJoin obj) => obj switch
    {
        StrokeLineJoin.Arcs => "arcs",
        StrokeLineJoin.Bevel => "bevel",
        StrokeLineJoin.Miter => "miter",
        StrokeLineJoin.MiterClip => "miter-clip",
        StrokeLineJoin.Round => "round",
        _ => throw new ArgumentOutOfRangeException(nameof(obj), obj, null)
    };
}