#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Display](README.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ModDisplay Class

A custom Display that is a copy of an existing Display that can be modified

```csharp
public abstract class ModDisplay : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; ModDisplay

Derived  
&#8627; [ModBloonDisplay](BTD_Mod_Helper.Api.Display.ModBloonDisplay.md 'BTD_Mod_Helper.Api.Display.ModBloonDisplay')  
&#8627; [ModCustomDisplay](BTD_Mod_Helper.Api.Display.ModCustomDisplay.md 'BTD_Mod_Helper.Api.Display.ModCustomDisplay')  
&#8627; [ModDisplay2D](BTD_Mod_Helper.Api.Display.ModDisplay2D.md 'BTD_Mod_Helper.Api.Display.ModDisplay2D')  
&#8627; [ModTowerDisplay](BTD_Mod_Helper.Api.Display.ModTowerDisplay.md 'BTD_Mod_Helper.Api.Display.ModTowerDisplay')
### Fields

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.Generic2dDisplay'></a>

## ModDisplay.Generic2dDisplay Field

The display id for a Red Bloon

```csharp
public const string Generic2dDisplay = "9d3c0064c3ace7448bf8fefa4a97a70f";
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Properties

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.BaseDisplay'></a>

## ModDisplay.BaseDisplay Property

The GUID of the display to copy this ModDisplay off of

```csharp
public virtual string BaseDisplay { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.BaseDisplayReference'></a>

## ModDisplay.BaseDisplayReference Property

The prefab reference itself of the base display that will be used

```csharp
public virtual PrefabReference BaseDisplayReference { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Utils.PrefabReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.PrefabReference 'Il2CppAssets.Scripts.Utils.PrefabReference')

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.ModifiesUnityObject'></a>

## ModDisplay.ModifiesUnityObject Property

If you modify the unity Object and not just the DisplayNode attached to it, then set this to true

```csharp
public virtual bool ModifiesUnityObject { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.PixelsPerUnit'></a>

## ModDisplay.PixelsPerUnit Property

How many pixels in a sprite texture should be equal to one unit

```csharp
public virtual float PixelsPerUnit { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.PositionOffset'></a>

## ModDisplay.PositionOffset Property

The position offset to render the display at (z axis is up toward camera)

```csharp
public virtual Vector3 PositionOffset { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Simulation.SMath.Vector3](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.SMath.Vector3 'Il2CppAssets.Scripts.Simulation.SMath.Vector3')

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.Scale'></a>

## ModDisplay.Scale Property

The scale to render the display at

```csharp
public virtual float Scale { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')
### Methods

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.Apply(BloonModel)'></a>

## ModDisplay.Apply(BloonModel) Method

Applies this ModDisplay to a given BloonModel

```csharp
public void Apply(BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.Apply(BloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.Apply(DisplayModel)'></a>

## ModDisplay.Apply(DisplayModel) Method

Applies this ModDisplay to a given DisplayModel

```csharp
public virtual void Apply(DisplayModel displayModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.Apply(DisplayModel).displayModel'></a>

`displayModel` [Il2CppAssets.Scripts.Models.GenericBehaviors.DisplayModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GenericBehaviors.DisplayModel 'Il2CppAssets.Scripts.Models.GenericBehaviors.DisplayModel')

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.Apply(ProjectileModel)'></a>

## ModDisplay.Apply(ProjectileModel) Method

Applies this ModDisplay to a given ProjectileModel

```csharp
public virtual void Apply(ProjectileModel projectileModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.Apply(ProjectileModel).projectileModel'></a>

`projectileModel` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.Apply(TowerModel)'></a>

## ModDisplay.Apply(TowerModel) Method

Applies this ModDisplay to a given TowerModel

```csharp
public virtual void Apply(TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.Apply(TowerModel).towerModel'></a>

`towerModel` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.GetDisplay(string,int,int,int)'></a>

## ModDisplay.GetDisplay(string, int, int, int) Method

Gets the Display for a given tower, optionally for the given tiers

```csharp
protected string GetDisplay(string tower, int top=0, int mid=0, int bot=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.GetDisplay(string,int,int,int).tower'></a>

`tower` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The tower base id

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.GetDisplay(string,int,int,int).top'></a>

`top` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Path 1 tier

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.GetDisplay(string,int,int,int).mid'></a>

`mid` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Path 2 tier

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.GetDisplay(string,int,int,int).bot'></a>

`bot` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Path 3 tier

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The display GUID

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.GetDisplayModel()'></a>

## ModDisplay.GetDisplayModel() Method

Gets a new DisplayModel based on this ModDisplay

```csharp
public DisplayModel GetDisplayModel();
```

#### Returns
[Il2CppAssets.Scripts.Models.GenericBehaviors.DisplayModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GenericBehaviors.DisplayModel 'Il2CppAssets.Scripts.Models.GenericBehaviors.DisplayModel')

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.ModifyDisplayNode(UnityDisplayNode)'></a>

## ModDisplay.ModifyDisplayNode(UnityDisplayNode) Method

Alters the UnityDisplayNode that was copied from the one used by [BaseDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md#BTD_Mod_Helper.Api.Display.ModDisplay.BaseDisplay 'BTD_Mod_Helper.Api.Display.ModDisplay.BaseDisplay')

```csharp
public virtual void ModifyDisplayNode(UnityDisplayNode node);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.ModifyDisplayNode(UnityDisplayNode).node'></a>

`node` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

The prototype unity display node

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.ModifyDisplayNodeAsync(UnityDisplayNode,System.Action)'></a>

## ModDisplay.ModifyDisplayNodeAsync(UnityDisplayNode, Action) Method

Allows you to modify this node asynchronously. On complete must be called for load to work! Takes  
place after the non-async ModifyDisplayNode call

```csharp
public virtual void ModifyDisplayNodeAsync(UnityDisplayNode node, System.Action onComplete);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.ModifyDisplayNodeAsync(UnityDisplayNode,System.Action).node'></a>

`node` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

The prototype unity display node

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.ModifyDisplayNodeAsync(UnityDisplayNode,System.Action).onComplete'></a>

`onComplete` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

Callback for when you've finished changing the node

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.Set2DTexture(UnityDisplayNode,string)'></a>

## ModDisplay.Set2DTexture(UnityDisplayNode, string) Method

Sets the sprite texture to that of a named png

```csharp
protected void Set2DTexture(UnityDisplayNode node, string textureName);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.Set2DTexture(UnityDisplayNode,string).node'></a>

`node` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

The UnityDisplayNode

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.Set2DTexture(UnityDisplayNode,string).textureName'></a>

`textureName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the texture, without .png

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.SetMeshOutlineColor(UnityDisplayNode,Color,int)'></a>

## ModDisplay.SetMeshOutlineColor(UnityDisplayNode, Color, int) Method

Sets the outline color for the index'th mesh renderer in the given node

```csharp
protected void SetMeshOutlineColor(UnityDisplayNode node, Color color, int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.SetMeshOutlineColor(UnityDisplayNode,Color,int).node'></a>

`node` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

The UnityDisplayNode

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.SetMeshOutlineColor(UnityDisplayNode,Color,int).color'></a>

`color` [UnityEngine.Color](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Color 'UnityEngine.Color')

The color for it to be outlined (when not highlighted)

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.SetMeshOutlineColor(UnityDisplayNode,Color,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

What index of mesh renderer to use

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.SetMeshOutlineColor(UnityDisplayNode,Color)'></a>

## ModDisplay.SetMeshOutlineColor(UnityDisplayNode, Color) Method

Sets the outline color for the first mesh renderer in the given node

```csharp
protected void SetMeshOutlineColor(UnityDisplayNode node, Color color);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.SetMeshOutlineColor(UnityDisplayNode,Color).node'></a>

`node` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

The UnityDisplayNode

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.SetMeshOutlineColor(UnityDisplayNode,Color).color'></a>

`color` [UnityEngine.Color](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Color 'UnityEngine.Color')

The color for it to be outlined (when not highlighted)

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.SetMeshTexture(UnityDisplayNode,string,int)'></a>

## ModDisplay.SetMeshTexture(UnityDisplayNode, string, int) Method

Sets the mesh texture to that of a named png

```csharp
protected void SetMeshTexture(UnityDisplayNode node, string textureName, int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.SetMeshTexture(UnityDisplayNode,string,int).node'></a>

`node` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

The UnityDisplayNode

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.SetMeshTexture(UnityDisplayNode,string,int).textureName'></a>

`textureName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the texture, without .png

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.SetMeshTexture(UnityDisplayNode,string,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The index to set at

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.SetMeshTexture(UnityDisplayNode,string)'></a>

## ModDisplay.SetMeshTexture(UnityDisplayNode, string) Method

Sets the mesh texture to that of a named png

```csharp
protected void SetMeshTexture(UnityDisplayNode node, string textureName);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.SetMeshTexture(UnityDisplayNode,string).node'></a>

`node` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

The UnityDisplayNode

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.SetMeshTexture(UnityDisplayNode,string).textureName'></a>

`textureName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the texture, without .png

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.UseNode(string,System.Action_UnityDisplayNode_)'></a>

## ModDisplay.UseNode(string, Action<UnityDisplayNode>) Method

Gets a UnityDisplayNode for a different guid

```csharp
protected void UseNode(string guid, System.Action<UnityDisplayNode> action);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.UseNode(string,System.Action_UnityDisplayNode_).guid'></a>

`guid` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The asset reference guid to get the node from

<a name='BTD_Mod_Helper.Api.Display.ModDisplay.UseNode(string,System.Action_UnityDisplayNode_).action'></a>

`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

What to do with the node