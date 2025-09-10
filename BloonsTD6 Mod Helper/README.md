# BloonsTD6 Mod Helper

This is the C# project for BTD Mod Helper.

## Requirements

Requires .NET SDK 9.0 or higher to build the project (however the built library itself will still only be targeting
.NET 6.0 because that's what MelonLoader supports)

## Build Configurations

### Release

This configuration is used for the actual released dll.

This configuration will utilize ILRepack to bundle the Nuget dependencies into the released dll, so they don't have to
be downloaded separately.

Running this configuration also triggers the generation of the docs using DefaultDocumentation.

### Debug

This configuration will not use ILRepack for the dependencies, as that messes up .NET's debugging of the process.  
It will instead manually copy their dlls into the BloonsTD6 UserAssemblies folder, which will also work.

This configuration will also include some additional options and buttons in the Mod Settings page for Mod Helper,   
like the ones for generating Vanilla Sprites.