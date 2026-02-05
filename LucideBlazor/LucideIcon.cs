using Microsoft.AspNetCore.Components;

namespace LucideBlazor;

/// <summary>
/// Dynamic component for rendering an icon by its name
/// </summary>
public class LucideIcon : IconBase
{
    /// <summary>
    /// Name of the icon which should be rendered
    /// </summary>
    [Parameter, EditorRequired]
    public string Name { get; set; } = string.Empty;

    /// <inheritdoc/>
    protected override string SvgContent => IconMap.GetIconSvg(Name) ?? string.Empty;
}
