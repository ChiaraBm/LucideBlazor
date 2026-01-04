using LucideBlazor.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace LucideBlazor;

public abstract class IconBase : IComponent
{
    [Parameter] public string? ClassName { get; set; }
    [Parameter] public int Size { get; set; } = 24;
    [Parameter] public string Fill { get; set; } = "none";
    [Parameter] public string Stroke { get; set; } = "currentColor";
    [Parameter] public double StrokeWidth { get; set; } = 2;
    [Parameter] public StrokeLineCap StrokeLineCap { get; set; } = StrokeLineCap.Round;
    [Parameter] public StrokeLineJoin StrokeLineJoin { get; set; } = StrokeLineJoin.Round;

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? Props { get; set; }

    private RenderHandle _handle;

    public void Attach(RenderHandle renderHandle)
    {
        _handle = renderHandle;
    }

    protected void RenderIcon(RenderTreeBuilder builder, string svgContent)
    {
        var counter = 0;

        builder.OpenElement(0, "svg");
        builder.AddAttribute(counter++, "class", ClassName);

        AddIfNotInProps("xmlns", "http://www.w3.org/2000/svg");
        AddIfNotInProps("width", Size);
        AddIfNotInProps("height", Size);
        AddIfNotInProps("viewBox", "0 0 24 24");
        AddIfNotInProps("fill", Fill);
        AddIfNotInProps("stroke", Stroke);
        AddIfNotInProps("stroke-width", StrokeWidth);
        AddIfNotInProps("stroke-linecap", StrokeLineCapExtensions.ToString(StrokeLineCap));
        AddIfNotInProps("stroke-linejoin", StrokeLineJoinExtensions.ToString(StrokeLineJoin));

        if (Props is not null)
            builder.AddMultipleAttributes(counter++, Props);

        builder.AddMarkupContent(counter, svgContent);
        builder.CloseElement();

        return;

        // Helper to add attribute if not present in Props
        void AddIfNotInProps(string name, object value)
        {
            if (Props is null || !Props.ContainsKey(name))
                builder.AddAttribute(counter++, name, value);
        }
    }

    protected abstract void HandleRender(RenderTreeBuilder builder);

    public Task SetParametersAsync(ParameterView parameters)
    {
        foreach (var parameter in parameters)
        {
            switch (parameter.Name)
            {
                case nameof(ClassName):
                    ClassName = (string?)parameter.Value;
                    break;
                case nameof(Size):
                    Size = (int)parameter.Value;
                    break;
                case nameof(Fill):
                    Fill = (string)parameter.Value;
                    break;
                case nameof(Stroke):
                    Stroke = (string)parameter.Value;
                    break;
                case nameof(StrokeWidth):
                    StrokeWidth = parameter.Value is int i ? i : (double)parameter.Value;
                    break;
                case nameof(StrokeLineCap):
                    StrokeLineCap = parameter.Value switch
                    {
                        int capInt => (StrokeLineCap)capInt,
                        string str => StrokeLineCapExtensions.FromString(str),
                        StrokeLineCap capEnum => capEnum,
                        _ => StrokeLineCap
                    };
                    break;
                case nameof(StrokeLineJoin):
                    StrokeLineJoin = parameter.Value switch
                    {
                        int joinInt => (StrokeLineJoin)joinInt,
                        string str => StrokeLineJoinExtensions.FromString(str),
                        StrokeLineJoin joinEnum => joinEnum,
                        _ => StrokeLineJoin
                    };
                    break;
                default:
                    Props ??= new Dictionary<string, object>();
                    Props[parameter.Name] = parameter.Value;

                    break;
            }
        }

        _handle.Render(HandleRender);
        return Task.CompletedTask;
    }
}