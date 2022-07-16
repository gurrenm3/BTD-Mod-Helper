#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Patches.ModdedClientChecking](index.md#BTD_Mod_Helper.Patches.ModdedClientChecking 'BTD_Mod_Helper.Patches.ModdedClientChecking')

## ModdedClientBypassing Class

You forced our hand :(

```csharp
public class ModdedClientBypassing
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModdedClientBypassing
### Fields

<a name='BTD_Mod_Helper.Patches.ModdedClientChecking.ModdedClientBypassing.DefaultBypassCheck'></a>

## ModdedClientBypassing.DefaultBypassCheck Field

The nuclear option would be just setting this to true, which would entirely bypass all of NK's clientside checks

```csharp
private const bool DefaultBypassCheck = False;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Properties

<a name='BTD_Mod_Helper.Patches.ModdedClientChecking.ModdedClientBypassing.CurrentlyBypassingCheck'></a>

## ModdedClientBypassing.CurrentlyBypassingCheck Property

Whether the ModdedClient check is currently being bypassed

```csharp
public static bool CurrentlyBypassingCheck { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Patches.ModdedClientChecking.ModdedClientBypassing.StartBypassingCheck()'></a>

## ModdedClientBypassing.StartBypassingCheck() Method

Called in prefix patches on methods where we think modded clients should be accepted

```csharp
internal static void StartBypassingCheck();
```

<a name='BTD_Mod_Helper.Patches.ModdedClientChecking.ModdedClientBypassing.StopBypassingCheck()'></a>

## ModdedClientBypassing.StopBypassingCheck() Method

Called in postfix patches on methods where we think modded clients should be accepted

```csharp
internal static void StopBypassingCheck();
```