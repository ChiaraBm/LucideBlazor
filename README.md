<div align="center">
<img alt="LucideBlazor Logo" src="https://raw.githubusercontent.com/ChiaraBm/LucideBlazor/refs/heads/main/LucideBlazor/icon.svg" width="120" />
  <h1>LucideBlazor</h1>
  <p><strong>A blazor port of the popular <a href="https://lucide.dev">lucide</a> icon library.</strong></p>
</div>

## What is LucideBlazor?

LucideBlazor is a port of the popular lucide icon library which contains a lot of open source icons. This blazor port
is inspired by the react version of lucide and has the following features

- **Performance:** All icon components are plain and sealed `IComponent` deriving classes so blazor doesnt need to process the lifecyle on these components.
    The icon contents are baked into the class constants
- **Modern:**: With the use of incremental source generators the classes representing the components are generated directly out of the lucide repository
- **Small** Using the IL-Trim feature only used components are published in the final build of your app when publishing it with trimming enabled 


## Installation

To install LucideBlazor just open your terminal or use the IDEs nuget package manager to install the [nuget package](https://www.nuget.org/packages/LucideBlazor)
````shell
dotnet add package LucideBlazor
````


## Contributing

This is a small and new project so contributions, bug reports, and ideas are welcome.


## License

LucideBlazor is released under the **MIT License**.
For lucides license have a look [here](https://github.com/lucide-icons/lucide/blob/main/LICENSE)