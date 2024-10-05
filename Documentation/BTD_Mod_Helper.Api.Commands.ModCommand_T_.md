#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Commands](README.md#BTD_Mod_Helper.Api.Commands 'BTD_Mod_Helper.Api.Commands')

## ModCommand<T> Class

```csharp
public abstract class ModCommand<T> : BTD_Mod_Helper.Api.Commands.ModCommand
    where T : BTD_Mod_Helper.Api.Commands.ModCommand
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Commands.ModCommand_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModCommand](BTD_Mod_Helper.Api.Commands.ModCommand.md 'BTD_Mod_Helper.Api.Commands.ModCommand') &#129106; ModCommand<T>
### Properties

<a name='BTD_Mod_Helper.Api.Commands.ModCommand_T_.ParentCommand'></a>

## ModCommand<T>.ParentCommand Property

Other ModCommand that this is nested under, or null if a root command

```csharp
public sealed override BTD_Mod_Helper.Api.Commands.ModCommand ParentCommand { get; }
```

#### Property Value
[ModCommand](BTD_Mod_Helper.Api.Commands.ModCommand.md 'BTD_Mod_Helper.Api.Commands.ModCommand')