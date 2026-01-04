using Microsoft.AspNetCore.Components;

namespace LucideBlazor;

public class LucideIcon : IconBase
{
    [Parameter]
    public string Name { get; set; } = string.Empty;

    protected override string SvgContent => IconMap.GetIconSvg(Name) ?? string.Empty;
}
