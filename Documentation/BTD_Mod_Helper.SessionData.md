#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper](index.md#BTD_Mod_Helper 'BTD_Mod_Helper')

## SessionData Class

This class is used in the API to store data about the current state of the game,  
like whether or not the player is in a Public Coop game

```csharp
public class SessionData
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SessionData
### Fields

<a name='BTD_Mod_Helper.SessionData.bloonPopValues'></a>

## SessionData.bloonPopValues Field

How much cash each bloon is worth when completely popped

```csharp
public readonly Dictionary<string,int> bloonPopValues;
```

#### Field Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')
### Properties

<a name='BTD_Mod_Helper.SessionData.DestroyedBloons'></a>

## SessionData.DestroyedBloons Property

Contains all the Bloons that were destroyed during this round

```csharp
public System.Collections.Generic.List<Assets.Scripts.Simulation.Bloons.Bloon> DestroyedBloons { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.SessionData.Instance'></a>

## SessionData.Instance Property

Singleton instance of SessionData

```csharp
public static BTD_Mod_Helper.SessionData Instance { get; set; }
```

#### Property Value
[SessionData](BTD_Mod_Helper.SessionData.md 'BTD_Mod_Helper.SessionData')

<a name='BTD_Mod_Helper.SessionData.IsInOdyssey'></a>

## SessionData.IsInOdyssey Property

If the player is in a game, are they in a Odyssey game

```csharp
public bool IsInOdyssey { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.SessionData.IsInPublicCoop'></a>

## SessionData.IsInPublicCoop Property

If the player is in Coop, this value represents whether it's a   
Public Coop match or not

```csharp
public bool IsInPublicCoop { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.SessionData.IsInRace'></a>

## SessionData.IsInRace Property

If the player is in a game, is it a Race game

```csharp
public bool IsInRace { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.SessionData.LeakedBloons'></a>

## SessionData.LeakedBloons Property

Contains all the Bloons that were leaked during this round  
Used to track which bloons were popped and which leaked

```csharp
public System.Collections.Generic.List<Assets.Scripts.Simulation.Bloons.Bloon> LeakedBloons { get; set; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.SessionData.NkGI'></a>

## SessionData.NkGI Property

The instance of [NinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.NKMultiGameInterface 'NinjaKiwi.NKMulti.NKMultiGameInterface') that is used during a   
multiplayer game

```csharp
public NinjaKiwi.NKMulti.NKMultiGameInterface NkGI { get; set; }
```

#### Property Value
[NinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.NKMultiGameInterface 'NinjaKiwi.NKMulti.NKMultiGameInterface')

<a name='BTD_Mod_Helper.SessionData.PlayerSaveStrategy'></a>

## SessionData.PlayerSaveStrategy Property

The instance of [NinjaKiwi.Players.Files.FileSaveStrategy](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.Players.Files.FileSaveStrategy 'NinjaKiwi.Players.Files.FileSaveStrategy') that is used to load the Player save.

```csharp
public NinjaKiwi.Players.Files.FileSaveStrategy PlayerSaveStrategy { get; set; }
```

#### Property Value
[NinjaKiwi.Players.Files.FileSaveStrategy](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.Players.Files.FileSaveStrategy 'NinjaKiwi.Players.Files.FileSaveStrategy')

<a name='BTD_Mod_Helper.SessionData.PoppedBloons'></a>

## SessionData.PoppedBloons Property

Keeping track of popped bloons

```csharp
public System.Collections.Generic.Dictionary<string,int> PoppedBloons { get; set; }
```

#### Property Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='BTD_Mod_Helper.SessionData.SaveDirectory'></a>

## SessionData.SaveDirectory Property

The directory of the save file.   
Gets set when [NinjaKiwi.Players.Files.FileSaveStrategy.Choose(System.String,NinjaKiwi.Players.SaveStrategy)](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.Players.Files.FileSaveStrategy.Choose#NinjaKiwi_Players_Files_FileSaveStrategy_Choose_System_String,NinjaKiwi_Players_SaveStrategy_ 'NinjaKiwi.Players.Files.FileSaveStrategy.Choose(System.String,NinjaKiwi.Players.SaveStrategy)')  
tries to load the Player Save

```csharp
public string SaveDirectory { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='BTD_Mod_Helper.SessionData.Reset()'></a>

## SessionData.Reset() Method

Resets all the values in SessionData

```csharp
public static void Reset();
```