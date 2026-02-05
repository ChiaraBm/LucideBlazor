# LucideBlazor

A Blazor port of the [Lucide](https://lucide.dev) icon library. Clean, consistent icons that just work.

## Installation

```shell
dotnet add package LucideBlazor
```

## Usage

Use strongly typed components when you know which icon you need:

```razor
<HomeIcon Size="32" Stroke="blue" />
<SearchIcon ClassName="my-icon" />
```

Or use dynamic lookup when you need flexibility:

```razor
<LucideIcon Name="user" Size="24" />
<LucideIcon Name="@iconName" />
```

## Customization

All icons support these parameters:

- `Size` - Width/height in pixels (default: 24)
- `Stroke` - Stroke color (default: "currentColor")
- `StrokeWidth` - Line thickness (default: 2)
- `Fill` - Fill color (default: "none")
- `StrokeLineCap` / `StrokeLineJoin` - Line styling
- `ClassName` - CSS classes
- Any additional HTML attributes

```razor
<HeartIcon Size="48" Stroke="red" Fill="pink" />
<AlertCircleIcon ClassName="text-warning me-2" />
<InfoIcon id="tooltip" data-toggle="tooltip" />
```

## How it works

A source generator reads Lucide's SVG files at compile time and generates icon components with the SVG content baked in.
This means fast rendering and small bundle sizes when you publish with trimming enabled.

## Contributing

This is a small and new project so contributions, bug reports, and ideas are welcome.


## License

LucideBlazor is released under the **MIT License**.
For lucides license have a look [here](https://github.com/lucide-icons/lucide/blob/main/LICENSE)