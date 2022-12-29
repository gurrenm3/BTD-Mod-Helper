#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Bloons](README.md#BTD_Mod_Helper.Api.Bloons 'BTD_Mod_Helper.Api.Bloons')

## ModRoundSet Class

Class for a custom RoundSet

```csharp
public abstract class ModRoundSet : BTD_Mod_Helper.Api.NamedModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; ModRoundSet
### Properties

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.AddToOverrideMenu'></a>

## ModRoundSet.AddToOverrideMenu Property

Whether this Round set should show up in the menu allowing you to use any RoundSet for any GameMode

```csharp
public virtual bool AddToOverrideMenu { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.BaseRounds'></a>

## ModRoundSet.BaseRounds Property

The Base Rounds included in the RoundSet specified by BaseRoundSet

```csharp
protected System.Collections.Generic.List<RoundModel> BaseRounds { get; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Models.Rounds.RoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.RoundModel 'Il2CppAssets.Scripts.Models.Rounds.RoundModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.BaseRoundSet'></a>

## ModRoundSet.BaseRoundSet Property

The id of the existing RoundSet to use as a base. Use RoundSetType.[name]  
If this RoundSetType.None, empty, or null, then an empty round set will be used

```csharp
public abstract string BaseRoundSet { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.CustomHints'></a>

## ModRoundSet.CustomHints Property

Whether these rounds should have custom hints, like Alternate Bloons Rounds does

```csharp
public virtual bool CustomHints { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.DefinedRounds'></a>

## ModRoundSet.DefinedRounds Property

The total number of rounds that have specified Bloons.  
<br/>  
After this number of rounds, randomized Free Play rounds will happen

```csharp
public abstract int DefinedRounds { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.DisplayNamePlural'></a>

## ModRoundSet.DisplayNamePlural Property

The name that will actually be display when referring to multiple of these

```csharp
public sealed override string DisplayNamePlural { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.Icon'></a>

## ModRoundSet.Icon Property

The Icon for the Button for this RoundSet within the UI, by default looking for the same name as the file

```csharp
public virtual string Icon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.IconReference'></a>

## ModRoundSet.IconReference Property

If you're not going to use a custom .png for your Icon, use this to directly control its SpriteReference

```csharp
public virtual SpriteReference IconReference { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')
### Methods

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.GetHint(int)'></a>

## ModRoundSet.GetHint(int) Method

Gets the custom hint for a specific round. Make sure [CustomHints](BTD_Mod_Helper.Api.Bloons.ModRoundSet.md#BTD_Mod_Helper.Api.Bloons.ModRoundSet.CustomHints 'BTD_Mod_Helper.Api.Bloons.ModRoundSet.CustomHints') is overriden as true.  
<br/>  
For no hint, return null.

```csharp
public virtual string GetHint(int round);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.GetHint(int).round'></a>

`round` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyEasyRoundModels(RoundModel,int)'></a>

## ModRoundSet.ModifyEasyRoundModels(RoundModel, int) Method

Called to modify specifically just rounds from 1 to 40

```csharp
public virtual void ModifyEasyRoundModels(RoundModel roundModel, int round);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyEasyRoundModels(RoundModel,int).roundModel'></a>

`roundModel` [Il2CppAssets.Scripts.Models.Rounds.RoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.RoundModel 'Il2CppAssets.Scripts.Models.Rounds.RoundModel')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyEasyRoundModels(RoundModel,int).round'></a>

`round` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyGameModel(GameModel)'></a>

## ModRoundSet.ModifyGameModel(GameModel) Method

Modifies the GameModel that's used for matches played with this round set

```csharp
public virtual void ModifyGameModel(GameModel gameModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyGameModel(GameModel).gameModel'></a>

`gameModel` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyHardRoundModels(RoundModel,int)'></a>

## ModRoundSet.ModifyHardRoundModels(RoundModel, int) Method

Called to modify specifically just rounds from 61 to 80

```csharp
public virtual void ModifyHardRoundModels(RoundModel roundModel, int round);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyHardRoundModels(RoundModel,int).roundModel'></a>

`roundModel` [Il2CppAssets.Scripts.Models.Rounds.RoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.RoundModel 'Il2CppAssets.Scripts.Models.Rounds.RoundModel')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyHardRoundModels(RoundModel,int).round'></a>

`round` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyImpoppableRoundModels(RoundModel,int)'></a>

## ModRoundSet.ModifyImpoppableRoundModels(RoundModel, int) Method

Called to modify specifically just rounds from 81 to 100

```csharp
public virtual void ModifyImpoppableRoundModels(RoundModel roundModel, int round);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyImpoppableRoundModels(RoundModel,int).roundModel'></a>

`roundModel` [Il2CppAssets.Scripts.Models.Rounds.RoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.RoundModel 'Il2CppAssets.Scripts.Models.Rounds.RoundModel')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyImpoppableRoundModels(RoundModel,int).round'></a>

`round` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyMediumRoundModels(RoundModel,int)'></a>

## ModRoundSet.ModifyMediumRoundModels(RoundModel, int) Method

Called to modify specifically just rounds from 41 to 60

```csharp
public virtual void ModifyMediumRoundModels(RoundModel roundModel, int round);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyMediumRoundModels(RoundModel,int).roundModel'></a>

`roundModel` [Il2CppAssets.Scripts.Models.Rounds.RoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.RoundModel 'Il2CppAssets.Scripts.Models.Rounds.RoundModel')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyMediumRoundModels(RoundModel,int).round'></a>

`round` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyRoundModels(RoundModel,int)'></a>

## ModRoundSet.ModifyRoundModels(RoundModel, int) Method

Called to modify any/all rounds from 1 to [DefinedRounds](BTD_Mod_Helper.Api.Bloons.ModRoundSet.md#BTD_Mod_Helper.Api.Bloons.ModRoundSet.DefinedRounds 'BTD_Mod_Helper.Api.Bloons.ModRoundSet.DefinedRounds')

```csharp
public virtual void ModifyRoundModels(RoundModel roundModel, int round);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyRoundModels(RoundModel,int).roundModel'></a>

`roundModel` [Il2CppAssets.Scripts.Models.Rounds.RoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.RoundModel 'Il2CppAssets.Scripts.Models.Rounds.RoundModel')

<a name='BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyRoundModels(RoundModel,int).round'></a>

`round` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')