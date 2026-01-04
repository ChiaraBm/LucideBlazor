using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using LucideBlazor.Extensions;

namespace LucideBlazor;

public abstract class IconBase : ComponentBase
{
    [Parameter] public string? ClassName { get; set; }
    [Parameter] public int Size { get; set; } = 24;
    [Parameter] public string Fill { get; set; } = "none";
    [Parameter] public string Stroke { get; set; } = "white";
    [Parameter] public double StrokeWidth { get; set; } = 2;
    [Parameter] public StrokeLineCap StrokeLineCap { get; set; } = StrokeLineCap.Round;
    [Parameter] public StrokeLineJoin StrokeLineJoin { get; set; } = StrokeLineJoin.Round;

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    protected abstract string SvgContent { get; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "svg");

        var attributes = new Dictionary<string, object>
        {
            { "xmlns", "http://www.w3.org/2000/svg" },
            { "width", Size },
            { "height", Size },
            { "viewBox", "0 0 24 24" },
            { "fill", Fill },
            { "stroke", Stroke },
            { "stroke-width", StrokeWidth },
            { "stroke-linecap", StrokeLineCapExtensions.ToString(StrokeLineCap) },
            { "stroke-linejoin", StrokeLineJoinExtensions.ToString(StrokeLineJoin) }
        };

        if (ClassName is not null)
            attributes["class"] = ClassName;

        if (AdditionalAttributes is not null)
            foreach (var attr in AdditionalAttributes)
                attributes[attr.Key] = attr.Value;

        builder.AddMultipleAttributes(1, attributes);
        builder.AddMarkupContent(2, SvgContent);
        builder.CloseElement();
    }
}