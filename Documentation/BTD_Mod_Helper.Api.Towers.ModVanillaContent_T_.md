#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.Towers](index.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModVanillaContent<T> Class

ModContent Class for modifying a certain set of vanilla towers

```csharp
public abstract class ModVanillaContent<T> : BTD_Mod_Helper.Api.Towers.ModVanillaContent
    where T : Assets.Scripts.Models.Model
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModVanillaContent](BTD_Mod_Helper.Api.Towers.ModVanillaContent.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent') &#129106; ModVanillaContent<T>

Derived  
&#8627; [ModVanillaBloon](BTD_Mod_Helper.Api.Bloons.ModVanillaBloon.md 'BTD_Mod_Helper.Api.Bloons.ModVanillaBloon')  
&#8627; [ModVanillaTower](BTD_Mod_Helper.Api.Towers.ModVanillaTower.md 'BTD_Mod_Helper.Api.Towers.ModVanillaTower')  
&#8627; [ModVanillaUpgrade](BTD_Mod_Helper.Api.Towers.ModVanillaUpgrade.md 'BTD_Mod_Helper.Api.Towers.ModVanillaUpgrade')
### Methods

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.Apply(Assets.Scripts.Models.Model)'></a>

## ModVanillaContent<T>.Apply(Model) Method

Applies the modifications to the vanilla content

```csharp
internal override void Apply(Assets.Scripts.Models.Model model);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.Apply(Assets.Scripts.Models.Model).model'></a>

`model` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.Apply(Assets.Scripts.Models.Model,Assets.Scripts.Models.GameModel)'></a>

## ModVanillaContent<T>.Apply(Model, GameModel) Method

Applies the modifications to the vanilla content

```csharp
internal override void Apply(Assets.Scripts.Models.Model model, Assets.Scripts.Models.GameModel gameModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.Apply(Assets.Scripts.Models.Model,Assets.Scripts.Models.GameModel).model'></a>

`model` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.Apply(Assets.Scripts.Models.Model,Assets.Scripts.Models.GameModel).gameModel'></a>

`gameModel` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.Apply(T)'></a>

## ModVanillaContent<T>.Apply(T) Method

Applies the modifications to the vanilla content

```csharp
public virtual void Apply(T model);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.Apply(T).model'></a>

`model` [T](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md#BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.T 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>.T')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.Apply(T,Assets.Scripts.Models.GameModel)'></a>

## ModVanillaContent<T>.Apply(T, GameModel) Method

Applies the modifications to the vanilla content

```csharp
public virtual void Apply(T model, Assets.Scripts.Models.GameModel gameModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.Apply(T,Assets.Scripts.Models.GameModel).model'></a>

`model` [T](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md#BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.T 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>.T')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.Apply(T,Assets.Scripts.Models.GameModel).gameModel'></a>

`gameModel` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.GetAffected(Assets.Scripts.Models.GameModel)'></a>

## ModVanillaContent<T>.GetAffected(GameModel) Method

Gets the TowerModels that this will affect in the GameModel

```csharp
public abstract System.Collections.Generic.IEnumerable<T> GetAffected(Assets.Scripts.Models.GameModel gameModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.GetAffected(Assets.Scripts.Models.GameModel).gameModel'></a>

`gameModel` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md#BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.T 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.GetAffectedModels(Assets.Scripts.Models.GameModel)'></a>

## ModVanillaContent<T>.GetAffectedModels(GameModel) Method

Gets the TowerModels that this will affect in the GameModel

```csharp
public sealed override System.Collections.Generic.IEnumerable<Assets.Scripts.Models.Model> GetAffectedModels(Assets.Scripts.Models.GameModel gameModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.GetAffectedModels(Assets.Scripts.Models.GameModel).gameModel'></a>

`gameModel` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')