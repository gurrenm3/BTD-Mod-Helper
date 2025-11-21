#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Scenarios](README.md#BTD_Mod_Helper.Api.Scenarios 'BTD_Mod_Helper.Api.Scenarios')

## ModGameMode Class

Class for a custom GameMode that will be added to the modes screen when starting a new match

```csharp
public abstract class ModGameMode : BTD_Mod_Helper.Api.NamedModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; ModGameMode
### Properties

<a name='BTD_Mod_Helper.Api.Scenarios.ModGameMode.ApplyChallengeRules'></a>

## ModGameMode.ApplyChallengeRules Property

Whether this Game Mode should always apply custom challenge rules to the match via a DailyChallengeModel

```csharp
public virtual bool ApplyChallengeRules { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Scenarios.ModGameMode.BaseGameMode'></a>

## ModGameMode.BaseGameMode Property

The id of the existing GameMode to use as a base. Use GameModeType.[name]  
If this GameModeType.None, empty, or null, then an empty base will be used

```csharp
public abstract string BaseGameMode { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Scenarios.ModGameMode.Difficulty'></a>

## ModGameMode.Difficulty Property

Where this Mode should show up within the Mode Select screen. Use DifficultyType.[name]

```csharp
public abstract string Difficulty { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Scenarios.ModGameMode.DisplayNamePlural'></a>

## ModGameMode.DisplayNamePlural Property

The name that will actually be display when referring to multiple of these

```csharp
public sealed override string DisplayNamePlural { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Scenarios.ModGameMode.Icon'></a>

## ModGameMode.Icon Property

The Icon for the Button for this Mode within the UI, by default looking for the same name as the file

```csharp
public virtual string Icon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Scenarios.ModGameMode.IconReference'></a>

## ModGameMode.IconReference Property

If you're not going to use a custom .png for your Icon, use this to directly control its SpriteReference

```csharp
public virtual SpriteReference IconReference { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference 'Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference')
### Methods

<a name='BTD_Mod_Helper.Api.Scenarios.ModGameMode.ModifyBaseGameModeModel(ModModel)'></a>

## ModGameMode.ModifyBaseGameModeModel(ModModel) Method

Implemented by a ModGameMode to modify the base game mode, for instance by adding or removing mutator mods

```csharp
public abstract void ModifyBaseGameModeModel(ModModel gameModeModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Scenarios.ModGameMode.ModifyBaseGameModeModel(ModModel).gameModeModel'></a>

`gameModeModel` [Il2CppAssets.Scripts.Models.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.ModModel 'Il2CppAssets.Scripts.Models.ModModel')

<a name='BTD_Mod_Helper.Api.Scenarios.ModGameMode.ModifyChallengeRules(DailyChallengeModel)'></a>

## ModGameMode.ModifyChallengeRules(DailyChallengeModel) Method

Modifies the DailyChallengeModel used for the challenge rules of the match.  
If this mode is used in a custom challenge, this will override the settings of that challenge.  
<br/>  
For normal matches, the DailyChallengeModel is null.  
To make normal matches have challenge rules, set the [ApplyChallengeRules](BTD_Mod_Helper.Api.Scenarios.ModGameMode.md#BTD_Mod_Helper.Api.Scenarios.ModGameMode.ApplyChallengeRules 'BTD_Mod_Helper.Api.Scenarios.ModGameMode.ApplyChallengeRules') property to true

```csharp
public virtual void ModifyChallengeRules(DailyChallengeModel challengeModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Scenarios.ModGameMode.ModifyChallengeRules(DailyChallengeModel).challengeModel'></a>

`challengeModel` [Il2CppAssets.Scripts.Models.ServerEvents.DailyChallengeModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.ServerEvents.DailyChallengeModel 'Il2CppAssets.Scripts.Models.ServerEvents.DailyChallengeModel')

dcm

<a name='BTD_Mod_Helper.Api.Scenarios.ModGameMode.ModifyGameModel(GameModel)'></a>

## ModGameMode.ModifyGameModel(GameModel) Method

Modifies the GameModel that's used for matches played with this mode

```csharp
public virtual void ModifyGameModel(GameModel gameModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Scenarios.ModGameMode.ModifyGameModel(GameModel).gameModel'></a>

`gameModel` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')