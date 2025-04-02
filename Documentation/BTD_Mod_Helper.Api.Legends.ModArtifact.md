#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Legends](README.md#BTD_Mod_Helper.Api.Legends 'BTD_Mod_Helper.Api.Legends')

## ModArtifact Class

Class for adding a custom Artifact to the Rogue Legends mode

```csharp
public abstract class ModArtifact : BTD_Mod_Helper.Api.NamedModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; ModArtifact

Derived  
&#8627; [ModArtifact&lt;TData,TModel&gt;](BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.md 'BTD_Mod_Helper.Api.Legends.ModArtifact<TData,TModel>')
### Fields

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.Common'></a>

## ModArtifact.Common Field

Tier for Common Artifacts

```csharp
protected const int Common = 0;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.Legendary'></a>

## ModArtifact.Legendary Field

Tier for Legendary Artifacts

```csharp
protected const int Legendary = 2;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.Rare'></a>

## ModArtifact.Rare Field

Tier for Rare Artifacts

```csharp
protected const int Rare = 1;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
### Properties

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.DescriptionCommon'></a>

## ModArtifact.DescriptionCommon Property

Description for the Common tier of this Artifact

```csharp
public virtual string DescriptionCommon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.DescriptionLegendary'></a>

## ModArtifact.DescriptionLegendary Property

Description for the Legendary tier of this Artifact

```csharp
public virtual string DescriptionLegendary { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.DescriptionRare'></a>

## ModArtifact.DescriptionRare Property

Description for the Rare tier of this Artifact

```csharp
public virtual string DescriptionRare { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.DisplayNameCommon'></a>

## ModArtifact.DisplayNameCommon Property

Displayed Name for the Common tier of this Artifact

```csharp
public virtual string DisplayNameCommon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.DisplayNameLegendary'></a>

## ModArtifact.DisplayNameLegendary Property

Displayed Name for the Legendary tier of this Artifact

```csharp
public virtual string DisplayNameLegendary { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.DisplayNameRare'></a>

## ModArtifact.DisplayNameRare Property

Displayed Name for the Rare tier of this Artifact

```csharp
public virtual string DisplayNameRare { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.Icon'></a>

## ModArtifact.Icon Property

The Icon for this Artifact, either a VanillaSprites constant or custom texture name

```csharp
public virtual string Icon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.IconCommon'></a>

## ModArtifact.IconCommon Property

The Icon for this Artifact, either a VanillaSprites constant or custom texture name

```csharp
public virtual string IconCommon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.IconCommonReference'></a>

## ModArtifact.IconCommonReference Property

The Icon SpriteReference for this Artifact

```csharp
public virtual SpriteReference IconCommonReference { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference 'Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.IconLegendary'></a>

## ModArtifact.IconLegendary Property

The Icon for this Artifact, either a VanillaSprites constant or custom texture name

```csharp
public virtual string IconLegendary { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.IconLegendaryReference'></a>

## ModArtifact.IconLegendaryReference Property

The Icon SpriteReference for this Artifact

```csharp
public virtual SpriteReference IconLegendaryReference { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference 'Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.IconRare'></a>

## ModArtifact.IconRare Property

The Icon for this Artifact, either a VanillaSprites constant or custom texture name

```csharp
public virtual string IconRare { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.IconRareReference'></a>

## ModArtifact.IconRareReference Property

The Icon SpriteReference for this Artifact

```csharp
public virtual SpriteReference IconRareReference { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference 'Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.IconReference'></a>

## ModArtifact.IconReference Property

The Icon SpriteReference for this Artifact

```csharp
public virtual SpriteReference IconReference { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference 'Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.Ids'></a>

## ModArtifact.Ids Property

All the ArtifactIds that this will be adding

```csharp
public System.Collections.Generic.IEnumerable<string> Ids { get; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.MaxTier'></a>

## ModArtifact.MaxTier Property

Highest tier this artifact can be at

```csharp
public virtual int MaxTier { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.MinTier'></a>

## ModArtifact.MinTier Property

Lowest tier this artifact can be at

```csharp
public virtual int MinTier { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.RarityFrameType'></a>

## ModArtifact.RarityFrameType Property

The tower set themed rarity frame for the artifact

```csharp
public virtual TowerSet RarityFrameType { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.TowerSets.TowerSet](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerSet 'Il2CppAssets.Scripts.Models.TowerSets.TowerSet')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.SmallIcon'></a>

## ModArtifact.SmallIcon Property

Makes the icon for this artifact smaller to mimic the negative space found on dedicated artifact icons

```csharp
public virtual bool SmallIcon { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.Tiers'></a>

## ModArtifact.Tiers Property

The tiers this artifact has

```csharp
public System.Collections.Generic.IEnumerable<(int tier,int index)> Tiers { get; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
### Methods

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.Description(int)'></a>

## ModArtifact.Description(int) Method

Artifact's description for a given tier

```csharp
public virtual string Description(int tier);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.Description(int).tier'></a>

`tier` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

0 for Common, 1 for Rare, 2 for Legendary

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Displayed description

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.GetIcon(int)'></a>

## ModArtifact.GetIcon(int) Method

Gets the icon for a given tier of this artifact

```csharp
public SpriteReference GetIcon(int tier);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.GetIcon(int).tier'></a>

`tier` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

0, 1, or 2

#### Returns
[Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference 'Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference')  
icon reference

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.GetId(int)'></a>

## ModArtifact.GetId(int) Method

Gets the id this should use for the given index

```csharp
public virtual string GetId(int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.GetId(int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

1, 2 or 3

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The ID to use

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.ModifyGameModel(GameModel,int)'></a>

## ModArtifact.ModifyGameModel(GameModel, int) Method

Modifies the game model for a match where this artifact is active at the given tier

```csharp
public virtual void ModifyGameModel(GameModel gameModel, int tier);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.ModifyGameModel(GameModel,int).gameModel'></a>

`gameModel` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

new game model

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.ModifyGameModel(GameModel,int).tier'></a>

`tier` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

artifact tier

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.OnActivated(Simulation,int)'></a>

## ModArtifact.OnActivated(Simulation, int) Method

Triggers when this artifact is activated within the simulation for the given tier  
<br/>  
NOTE: Should be robust against potentially being activated again within the same simulation

```csharp
public virtual void OnActivated(Simulation simulation, int tier);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.OnActivated(Simulation,int).simulation'></a>

`simulation` [Il2CppAssets.Scripts.Simulation.Simulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Simulation 'Il2CppAssets.Scripts.Simulation.Simulation')

current Sim

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact.OnActivated(Simulation,int).tier'></a>

`tier` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

artifact tier