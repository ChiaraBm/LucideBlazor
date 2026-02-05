using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using LucideBlazor.Extensions;

namespace LucideBlazor;

/// <summary>
/// Base class for all lucide icons
/// </summary>
public abstract class IconBase : ComponentBase
{
    /// <summary>
    /// The ClassName property represents the CSS class name that will be applied to the SVG element
    /// </summary>
    [Parameter]
    public string? ClassName { get; set; }

    /// <summary>
    /// Gets or sets the Size property. This represents the size of the icon
    /// </summary>
    [Parameter]
    public int Size { get; set; } = 24;

    /// <summary>
    /// Gets or sets the fill property of the SVG element
    /// </summary>
    [Parameter]
    public string Fill { get; set; } = "none";
    
    /// <summary>
    /// Gets or sets the stroke color of the SVG element. Default is "currentColor" which inherits the text color
    /// </summary>
    [Parameter] public string Stroke { get; set; } = "currentColor";
    
    /// <summary>
    /// Gets or sets the stroke width of the SVG element. Default is 2
    /// </summary>
    [Parameter] public double StrokeWidth { get; set; } = 2;
    
    /// <summary>
    /// Gets or sets the stroke line cap style of the SVG element. Default is Round
    /// </summary>
    [Parameter] public StrokeLineCap StrokeLineCap { get; set; } = StrokeLineCap.Round;
    
    /// <summary>
    /// Gets or sets the stroke line join style of the SVG element. Default is Round
    /// </summary>
    [Parameter] public StrokeLineJoin StrokeLineJoin { get; set; } = StrokeLineJoin.Round;

    /// <summary>
    /// Gets or sets additional attributes that will be applied to the SVG element
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>
    /// Gets the inner SVG content markup for the icon. This must be implemented by derived icon classes
    /// </summary>
    protected abstract string SvgContent { get; }

    /// <inheritdoc />
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