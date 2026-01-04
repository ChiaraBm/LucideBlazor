using LucideBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace LucideBlazor;

public class LucideIcon : ComponentBase
{
    [Parameter] public string Name { get; set; } = string.Empty;
    [Parameter] public string? ClassName { get; set; }
    [Parameter] public int Size { get; set; } = 24;
    [Parameter] public string Fill { get; set; } = "none";
    [Parameter] public string Stroke { get; set; } = "white";
    [Parameter] public double StrokeWidth { get; set; } = 2;
    [Parameter] public StrokeLineCap StrokeLineCap { get; set; } = StrokeLineCap.Round;
    [Parameter] public StrokeLineJoin StrokeLineJoin { get; set; } = StrokeLineJoin.Round;

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? Props { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (string.IsNullOrEmpty(Name)) return;

        var iconType = IconMap.GetIconType(Name);
        if (iconType is null) return;

        builder.OpenComponent(0, iconType);

        if (ClassName is not null)
            builder.AddAttribute(1, nameof(IconBase.ClassName), ClassName);

        builder.AddAttribute(2, nameof(IconBase.Size), Size);
        builder.AddAttribute(3, nameof(IconBase.Fill), Fill);
        builder.AddAttribute(4, nameof(IconBase.Stroke), Stroke);
        builder.AddAttribute(5, nameof(IconBase.StrokeWidth), StrokeWidth);
        builder.AddAttribute(6, nameof(IconBase.StrokeLineCap), StrokeLineCapExtensions.ToString(StrokeLineCap));
        builder.AddAttribute(7, nameof(IconBase.StrokeLineJoin), StrokeLineJoinExtensions.ToString(StrokeLineJoin));

        if (Props is not null)
            builder.AddMultipleAttributes(8, Props);

        builder.CloseComponent();
    }
}