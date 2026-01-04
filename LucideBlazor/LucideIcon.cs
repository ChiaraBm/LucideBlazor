using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace LucideBlazor;

public class LucideIcon : ComponentBase
{
    [Parameter] public string Name { get; set; } = string.Empty;

    [Parameter] public string? ClassName { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object?>? Props { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (string.IsNullOrEmpty(Name))
            return;

        var iconType = IconMap.GetIconType(Name);
        if (iconType is null) return;

        builder.OpenComponent(0, iconType);

        if (ClassName is not null)
            builder.AddAttribute(1, nameof(IconBase.ClassName), ClassName);

        if (Props is not null)
            builder.AddAttribute(2, nameof(IconBase.Props), Props);

        builder.CloseComponent();
    }
}