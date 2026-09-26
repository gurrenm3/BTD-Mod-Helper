#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModVanillaContent<T> Class

ModContent Class for modifying a certain set of vanilla towers

```csharp
public abstract class ModVanillaContent<T> : BTD_Mod_Helper.Api.Towers.ModVanillaContent
    where T : Model
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModVanillaContent](BTD_Mod_Helper.Api.Towers.ModVanillaContent.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent') &#129106; ModVanillaContent<T>

Derived  
&#8627; [ModVanillaBloon](BTD_Mod_Helper.Api.Bloons.ModVanillaBloon.md 'BTD_Mod_Helper.Api.Bloons.ModVanillaBloon')  
&#8627; [ModVanillaBloons](BTD_Mod_Helper.Api.Bloons.ModVanillaBloons.md 'BTD_Mod_Helper.Api.Bloons.ModVanillaBloons')  
&#8627; [ModVanillaTower](BTD_Mod_Helper.Api.Towers.ModVanillaTower.md 'BTD_Mod_Helper.Api.Towers.ModVanillaTower')  
&#8627; [ModVanillaUpgrade](BTD_Mod_Helper.Api.Towers.ModVanillaUpgrade.md 'BTD_Mod_Helper.Api.Towers.ModVanillaUpgrade')
### Methods

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.Apply(T,GameModel)'></a>

## ModVanillaContent<T>.Apply(T, GameModel) Method

Applies the modifications to the vanilla content

```csharp
public virtual void Apply(T model, GameModel gameModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.Apply(T,GameModel).model'></a>

`model` [T](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md#BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.T 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>.T')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.Apply(T,GameModel).gameModel'></a>

`gameModel` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.Apply(T)'></a>

## ModVanillaContent<T>.Apply(T) Method

Applies the modifications to the vanilla content

```csharp
public virtual void Apply(T model);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.Apply(T).model'></a>

`model` [T](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md#BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.T 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>.T')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.GetAffected(GameModel)'></a>

## ModVanillaContent<T>.GetAffected(GameModel) Method

Gets the TowerModels that this will affect in the GameModel

```csharp
public abstract System.Collections.Generic.IEnumerable<T> GetAffected(GameModel gameModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.GetAffected(GameModel).gameModel'></a>

`gameModel` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md#BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.T 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.GetAffectedModels(GameModel)'></a>

## ModVanillaContent<T>.GetAffectedModels(GameModel) Method

Gets the TowerModels that this will affect in the GameModel

```csharp
public sealed override System.Collections.Generic.IEnumerable<Model> GetAffectedModels(GameModel gameModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.GetAffectedModels(GameModel).gameModel'></a>

`gameModel` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')