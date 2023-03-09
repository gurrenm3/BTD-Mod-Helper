#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper](README.md#BTD_Mod_Helper 'BTD_Mod_Helper')

## AdvancedBloonsTD6Mod Class

A more advanced version of the BloonsTD6Mod Class that has postfixes and prefixes for all hooks, along with instances and all parameters for each patch

```csharp
public abstract class AdvancedBloonsTD6Mod : BTD_Mod_Helper.BloonsTD6Mod
```

Inheritance [MelonLoader.MelonMod](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonMod 'MelonLoader.MelonMod') &#129106; [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod') &#129106; [BloonsTD6Mod](BTD_Mod_Helper.BloonsTD6Mod.md 'BTD_Mod_Helper.BloonsTD6Mod') &#129106; AdvancedBloonsTD6Mod
### Methods

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostBloonEmissionsAdded(Spawner,Il2CppReferenceArray_BloonEmissionModel_,int,int)'></a>

## AdvancedBloonsTD6Mod.PostBloonEmissionsAdded(Spawner, Il2CppReferenceArray<BloonEmissionModel>, int, int) Method

Called after a new bloon emission is added to the spawner  
<br/>  
Equivalent to a HarmonyPostfix on Spawner.AddEmissions

```csharp
public virtual void PostBloonEmissionsAdded(Spawner spawner, Il2CppReferenceArray<BloonEmissionModel> newEmissions, int round, int index=0);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostBloonEmissionsAdded(Spawner,Il2CppReferenceArray_BloonEmissionModel_,int,int).spawner'></a>

`spawner` [Il2CppAssets.Scripts.Simulation.Track.Spawner](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Track.Spawner 'Il2CppAssets.Scripts.Simulation.Track.Spawner')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostBloonEmissionsAdded(Spawner,Il2CppReferenceArray_BloonEmissionModel_,int,int).newEmissions'></a>

`newEmissions` [Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostBloonEmissionsAdded(Spawner,Il2CppReferenceArray_BloonEmissionModel_,int,int).round'></a>

`round` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostBloonEmissionsAdded(Spawner,Il2CppReferenceArray_BloonEmissionModel_,int,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostBloonEmitted(Spawner,BloonModel,int,int,float,Bloon)'></a>

## AdvancedBloonsTD6Mod.PostBloonEmitted(Spawner, BloonModel, int, int, float, Bloon) Method

Called after a bloon is emitted from a spawner  
<br/>  
Equivalent to a HarmonyPostfix on Spawner.Emit

```csharp
public virtual void PostBloonEmitted(Spawner spawner, BloonModel bloonModel, int round, int index, float startingDist, ref Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostBloonEmitted(Spawner,BloonModel,int,int,float,Bloon).spawner'></a>

`spawner` [Il2CppAssets.Scripts.Simulation.Track.Spawner](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Track.Spawner 'Il2CppAssets.Scripts.Simulation.Track.Spawner')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostBloonEmitted(Spawner,BloonModel,int,int,float,Bloon).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostBloonEmitted(Spawner,BloonModel,int,int,float,Bloon).round'></a>

`round` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostBloonEmitted(Spawner,BloonModel,int,int,float,Bloon).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostBloonEmitted(Spawner,BloonModel,int,int,float,Bloon).startingDist'></a>

`startingDist` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostBloonEmitted(Spawner,BloonModel,int,int,float,Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostButtonClicked(Button,PointerEventData)'></a>

## AdvancedBloonsTD6Mod.PostButtonClicked(Button, PointerEventData) Method

Called after any button in the game is clicked  
<br/>  
Equivalent to a HarmonyPostfix on Button.OnPointerClick

```csharp
public virtual void PostButtonClicked(Button button, PointerEventData clickData);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostButtonClicked(Button,PointerEventData).button'></a>

`button` [UnityEngine.UI.Button](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Button 'UnityEngine.UI.Button')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostButtonClicked(Button,PointerEventData).clickData'></a>

`clickData` [UnityEngine.EventSystems.PointerEventData](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.EventSystems.PointerEventData 'UnityEngine.EventSystems.PointerEventData')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostCashPickup(Cash,float)'></a>

## AdvancedBloonsTD6Mod.PostCashPickup(Cash, float) Method

Called after a banana is picked up  
<br/>  
Equivalent to a HarmonyPostfix on Cash.Pickup

```csharp
public virtual void PostCashPickup(Cash banana, ref float amount);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostCashPickup(Cash,float).banana'></a>

`banana` [Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors.Cash](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors.Cash 'Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors.Cash')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostCashPickup(Cash,float).amount'></a>

`amount` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostEnterPlacementMode(TowerModel)'></a>

## AdvancedBloonsTD6Mod.PostEnterPlacementMode(TowerModel) Method

Called after a tower enters placement mode  
<br/>  
Equivalent to a HarmonyPostfix on InputManager.EnterPlacementMode

```csharp
public virtual void PostEnterPlacementMode(TowerModel tower);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostEnterPlacementMode(TowerModel).tower'></a>

`tower` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostGetRoundHint(InGame,string)'></a>

## AdvancedBloonsTD6Mod.PostGetRoundHint(InGame, string) Method

called after the game shows a hint for a specific round  
<br/>  
Equivalent to a HarmonyPostfix on InGame.GetRoundHint

```csharp
public virtual void PostGetRoundHint(InGame inGame, ref string text);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostGetRoundHint(InGame,string).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostGetRoundHint(InGame,string).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the text the hint will have, passed as a ref to allow changes

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostIsParagonLocked(TowerManager,Tower,bool)'></a>

## AdvancedBloonsTD6Mod.PostIsParagonLocked(TowerManager, Tower, bool) Method

Called after the game thinks a paragon is locked  
<br/>  
Equivalent to a HarmonyPostfix on TowerManager.IsParagonLocked

```csharp
public virtual void PostIsParagonLocked(TowerManager towerManager, Tower tower, ref bool result);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostIsParagonLocked(TowerManager,Tower,bool).towerManager'></a>

`towerManager` [Il2CppAssets.Scripts.Simulation.Towers.TowerManager](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.TowerManager 'Il2CppAssets.Scripts.Simulation.Towers.TowerManager')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostIsParagonLocked(TowerManager,Tower,bool).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostIsParagonLocked(TowerManager,Tower,bool).result'></a>

`result` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

The result of the method, since it returns a bool, different from what you return

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostMapLoaded(MapLoader)'></a>

## AdvancedBloonsTD6Mod.PostMapLoaded(MapLoader) Method

Called after a MapLoader loads a map  
<br/>  
Equivalent to a HarmonyPostfix on MapLoader.LoadMap

```csharp
public virtual void PostMapLoaded(MapLoader mapLoader);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostMapLoaded(MapLoader).mapLoader'></a>

`mapLoader` [Il2CppAssets.Scripts.Unity.Map.MapLoader](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Map.MapLoader 'Il2CppAssets.Scripts.Unity.Map.MapLoader')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostParagonDegreeUpdated(ParagonTower)'></a>

## AdvancedBloonsTD6Mod.PostParagonDegreeUpdated(ParagonTower) Method

Called after the degree for a paragon is changed  
<br/>  
Equivalent to a HarmonyPostfix on ParagonTower.UpdateDegree

```csharp
public virtual void PostParagonDegreeUpdated(ParagonTower paragonTower);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostParagonDegreeUpdated(ParagonTower).paragonTower'></a>

`paragonTower` [Il2CppAssets.Scripts.Simulation.Towers.Behaviors.ParagonTower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Behaviors.ParagonTower 'Il2CppAssets.Scripts.Simulation.Towers.Behaviors.ParagonTower')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostPauseScreenClosed(PauseScreen)'></a>

## AdvancedBloonsTD6Mod.PostPauseScreenClosed(PauseScreen) Method

Called after the pause screen is closed  
<br/>  
Equivalent to a HarmonyPostfix on PauseScreen.Close

```csharp
public virtual void PostPauseScreenClosed(PauseScreen pauseScreen);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostPauseScreenClosed(PauseScreen).pauseScreen'></a>

`pauseScreen` [Il2CppAssets.Scripts.Unity.UI_New.Pause.PauseScreen](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Pause.PauseScreen 'Il2CppAssets.Scripts.Unity.UI_New.Pause.PauseScreen')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostPauseScreenOpened(PauseScreen)'></a>

## AdvancedBloonsTD6Mod.PostPauseScreenOpened(PauseScreen) Method

Called after the pause screen is opened  
<br/>  
Equivalent to a HarmonyPostfix on PauseScreen.Open

```csharp
public virtual void PostPauseScreenOpened(PauseScreen pauseScreen);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostPauseScreenOpened(PauseScreen).pauseScreen'></a>

`pauseScreen` [Il2CppAssets.Scripts.Unity.UI_New.Pause.PauseScreen](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Pause.PauseScreen 'Il2CppAssets.Scripts.Unity.UI_New.Pause.PauseScreen')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostPointerEnterSelectable(Selectable,PointerEventData)'></a>

## AdvancedBloonsTD6Mod.PostPointerEnterSelectable(Selectable, PointerEventData) Method

Called after the mouse goes over a button  
<br/>  
Equivalent to a HarmonyPostfix on Button.OnPointerEnter

```csharp
public virtual void PostPointerEnterSelectable(ref Selectable button, PointerEventData eventData);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostPointerEnterSelectable(Selectable,PointerEventData).button'></a>

`button` [UnityEngine.UI.Selectable](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Selectable 'UnityEngine.UI.Selectable')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostPointerEnterSelectable(Selectable,PointerEventData).eventData'></a>

`eventData` [UnityEngine.EventSystems.PointerEventData](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.EventSystems.PointerEventData 'UnityEngine.EventSystems.PointerEventData')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostPointerExitSelectable(Selectable,PointerEventData)'></a>

## AdvancedBloonsTD6Mod.PostPointerExitSelectable(Selectable, PointerEventData) Method

Called after the mouse leaves a button  
<br/>  
Equivalent to a HarmonyPostfix on Button.OnPointerExit

```csharp
public virtual void PostPointerExitSelectable(ref Selectable button, PointerEventData eventData);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostPointerExitSelectable(Selectable,PointerEventData).button'></a>

`button` [UnityEngine.UI.Selectable](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Selectable 'UnityEngine.UI.Selectable')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostPointerExitSelectable(Selectable,PointerEventData).eventData'></a>

`eventData` [UnityEngine.EventSystems.PointerEventData](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.EventSystems.PointerEventData 'UnityEngine.EventSystems.PointerEventData')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostRemoveableDestroyed(Removeable)'></a>

## AdvancedBloonsTD6Mod.PostRemoveableDestroyed(Removeable) Method

Called after a Removeable is destroyed  
<br/>  
Equivalent to a HarmonyPostfix on Map.DestroyRemoveable

```csharp
public virtual void PostRemoveableDestroyed(Removeable removeable);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostRemoveableDestroyed(Removeable).removeable'></a>

`removeable` [Il2CppAssets.Scripts.Simulation.Track.Removeable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Track.Removeable 'Il2CppAssets.Scripts.Simulation.Track.Removeable')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostShowUpgradeTree(TowerModel,bool)'></a>

## AdvancedBloonsTD6Mod.PostShowUpgradeTree(TowerModel, bool) Method

Called after the upgrade tree is shown for a tower  
<br/>  
Equivalent to a HarmonyPostfix on InGame.ShowUpgradeTree

```csharp
public virtual void PostShowUpgradeTree(TowerModel tower, bool fromDoubleTap);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostShowUpgradeTree(TowerModel,bool).tower'></a>

`tower` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostShowUpgradeTree(TowerModel,bool).fromDoubleTap'></a>

`fromDoubleTap` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostSpriteLoaded(SpriteAtlas,string,Sprite)'></a>

## AdvancedBloonsTD6Mod.PostSpriteLoaded(SpriteAtlas, string, Sprite) Method

Called after a sprite is loaded from a SpriteAtlas  
<br/>  
Equivalent to a HarmonyPostfix on SpriteAtlas.GetSprite

```csharp
public virtual void PostSpriteLoaded(SpriteAtlas spriteAtlas, string name, ref Sprite result);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostSpriteLoaded(SpriteAtlas,string,Sprite).spriteAtlas'></a>

`spriteAtlas` [UnityEngine.U2D.SpriteAtlas](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.U2D.SpriteAtlas 'UnityEngine.U2D.SpriteAtlas')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostSpriteLoaded(SpriteAtlas,string,Sprite).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostSpriteLoaded(SpriteAtlas,string,Sprite).result'></a>

`result` [UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostTowerButtonCreated(TowerModel,int,bool,TowerPurchaseButton)'></a>

## AdvancedBloonsTD6Mod.PostTowerButtonCreated(TowerModel, int, bool, TowerPurchaseButton) Method

Called after a TowerPurchaseButton is created  
<br/>  
Equivalent to a HarmonyPostfix on ShopMenu.CreateTowerButton

```csharp
public virtual void PostTowerButtonCreated(TowerModel tower, int index, bool showAmount, ref TowerPurchaseButton button);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostTowerButtonCreated(TowerModel,int,bool,TowerPurchaseButton).tower'></a>

`tower` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostTowerButtonCreated(TowerModel,int,bool,TowerPurchaseButton).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostTowerButtonCreated(TowerModel,int,bool,TowerPurchaseButton).showAmount'></a>

`showAmount` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostTowerButtonCreated(TowerModel,int,bool,TowerPurchaseButton).button'></a>

`button` [Il2CppAssets.Scripts.Unity.UI_New.InGame.StoreMenu.TowerPurchaseButton](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.StoreMenu.TowerPurchaseButton 'Il2CppAssets.Scripts.Unity.UI_New.InGame.StoreMenu.TowerPurchaseButton')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostTowerInventoryInit(TowerInventory,System.Collections.Generic.List_TowerDetailsModel_)'></a>

## AdvancedBloonsTD6Mod.PostTowerInventoryInit(TowerInventory, List<TowerDetailsModel>) Method

Called after a TowerInventory is initialized  
<br/>  
Equivalent to a HarmonyPostfix on TowerInventory.Init

```csharp
public virtual void PostTowerInventoryInit(TowerInventory towerInventory, System.Collections.Generic.List<TowerDetailsModel> baseTowers);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostTowerInventoryInit(TowerInventory,System.Collections.Generic.List_TowerDetailsModel_).towerInventory'></a>

`towerInventory` [Il2CppAssets.Scripts.Simulation.Input.TowerInventory](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Input.TowerInventory 'Il2CppAssets.Scripts.Simulation.Input.TowerInventory')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PostTowerInventoryInit(TowerInventory,System.Collections.Generic.List_TowerDetailsModel_).baseTowers'></a>

`baseTowers` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreBloonEmissionsAdded(Spawner,Il2CppReferenceArray_BloonEmissionModel_,int,int)'></a>

## AdvancedBloonsTD6Mod.PreBloonEmissionsAdded(Spawner, Il2CppReferenceArray<BloonEmissionModel>, int, int) Method

Called before a new bloon emission is added to the spawner  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on Spawner.AddEmissions

```csharp
public virtual bool PreBloonEmissionsAdded(ref Spawner spawner, ref Il2CppReferenceArray<BloonEmissionModel> newEmissions, ref int round, int index=0);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreBloonEmissionsAdded(Spawner,Il2CppReferenceArray_BloonEmissionModel_,int,int).spawner'></a>

`spawner` [Il2CppAssets.Scripts.Simulation.Track.Spawner](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Track.Spawner 'Il2CppAssets.Scripts.Simulation.Track.Spawner')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreBloonEmissionsAdded(Spawner,Il2CppReferenceArray_BloonEmissionModel_,int,int).newEmissions'></a>

`newEmissions` [Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreBloonEmissionsAdded(Spawner,Il2CppReferenceArray_BloonEmissionModel_,int,int).round'></a>

`round` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreBloonEmissionsAdded(Spawner,Il2CppReferenceArray_BloonEmissionModel_,int,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreBloonEmitted(Spawner,BloonModel,int,int,float,Bloon)'></a>

## AdvancedBloonsTD6Mod.PreBloonEmitted(Spawner, BloonModel, int, int, float, Bloon) Method

Called before a bloon is emitted from a spawner  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on Spawner.Emit

```csharp
public virtual bool PreBloonEmitted(ref Spawner spawner, ref BloonModel bloonModel, ref int round, ref int index, ref float startingDist, ref Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreBloonEmitted(Spawner,BloonModel,int,int,float,Bloon).spawner'></a>

`spawner` [Il2CppAssets.Scripts.Simulation.Track.Spawner](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Track.Spawner 'Il2CppAssets.Scripts.Simulation.Track.Spawner')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreBloonEmitted(Spawner,BloonModel,int,int,float,Bloon).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreBloonEmitted(Spawner,BloonModel,int,int,float,Bloon).round'></a>

`round` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreBloonEmitted(Spawner,BloonModel,int,int,float,Bloon).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreBloonEmitted(Spawner,BloonModel,int,int,float,Bloon).startingDist'></a>

`startingDist` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreBloonEmitted(Spawner,BloonModel,int,int,float,Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreButtonClicked(Button,PointerEventData)'></a>

## AdvancedBloonsTD6Mod.PreButtonClicked(Button, PointerEventData) Method

Called before any button in the game is clicked  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on Button.OnPointerClick

```csharp
public virtual bool PreButtonClicked(ref Button button, ref PointerEventData clickData);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreButtonClicked(Button,PointerEventData).button'></a>

`button` [UnityEngine.UI.Button](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Button 'UnityEngine.UI.Button')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreButtonClicked(Button,PointerEventData).clickData'></a>

`clickData` [UnityEngine.EventSystems.PointerEventData](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.EventSystems.PointerEventData 'UnityEngine.EventSystems.PointerEventData')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreCashPickup(Cash,float)'></a>

## AdvancedBloonsTD6Mod.PreCashPickup(Cash, float) Method

Called before a banana is picked up  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on Cash.Pickup

```csharp
public virtual bool PreCashPickup(ref Cash banana, ref float amount);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreCashPickup(Cash,float).banana'></a>

`banana` [Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors.Cash](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors.Cash 'Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors.Cash')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreCashPickup(Cash,float).amount'></a>

`amount` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreEnterPlacementMode(TowerModel)'></a>

## AdvancedBloonsTD6Mod.PreEnterPlacementMode(TowerModel) Method

Called before a tower enters placement mode  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on InputManager.EnterPlacementMode

```csharp
public virtual bool PreEnterPlacementMode(ref TowerModel tower);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreEnterPlacementMode(TowerModel).tower'></a>

`tower` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreGetRoundHint(InGame,string)'></a>

## AdvancedBloonsTD6Mod.PreGetRoundHint(InGame, string) Method

Called before the game shows a hint for a specific round  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on InGame.GetRoundHint

```csharp
public virtual bool PreGetRoundHint(ref InGame inGame, ref string text);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreGetRoundHint(InGame,string).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreGetRoundHint(InGame,string).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the text the hint will have, passed as a ref to allow changes

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreIsParagonLocked(TowerManager,Tower,bool)'></a>

## AdvancedBloonsTD6Mod.PreIsParagonLocked(TowerManager, Tower, bool) Method

Called before the game thinks a paragon is locked  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on TowerManager.IsParagonLocked

```csharp
public virtual bool PreIsParagonLocked(ref TowerManager towerManager, ref Tower tower, ref bool result);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreIsParagonLocked(TowerManager,Tower,bool).towerManager'></a>

`towerManager` [Il2CppAssets.Scripts.Simulation.Towers.TowerManager](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.TowerManager 'Il2CppAssets.Scripts.Simulation.Towers.TowerManager')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreIsParagonLocked(TowerManager,Tower,bool).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreIsParagonLocked(TowerManager,Tower,bool).result'></a>

`result` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

The result of the method, since it returns a bool, different from what you return

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreMapLoaded(MapLoader)'></a>

## AdvancedBloonsTD6Mod.PreMapLoaded(MapLoader) Method

Called before a MapLoader loads a map  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on MapLoader.LoadMap

```csharp
public virtual bool PreMapLoaded(ref MapLoader mapLoader);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreMapLoaded(MapLoader).mapLoader'></a>

`mapLoader` [Il2CppAssets.Scripts.Unity.Map.MapLoader](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Map.MapLoader 'Il2CppAssets.Scripts.Unity.Map.MapLoader')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreMatchEnd(InGame)'></a>

## AdvancedBloonsTD6Mod.PreMatchEnd(InGame) Method

Called before the player returns to the MainMenu from a match  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on InGame.Quit

```csharp
public virtual bool PreMatchEnd(InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreMatchEnd(InGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreMatchStart(InGame)'></a>

## AdvancedBloonsTD6Mod.PreMatchStart(InGame) Method

Called before the game is started  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on InGame.Restart

```csharp
public virtual bool PreMatchStart(InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreMatchStart(InGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreOnVictory(InGame)'></a>

## AdvancedBloonsTD6Mod.PreOnVictory(InGame) Method

Called before the a game is won  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on InGame.OnVictory

```csharp
public virtual bool PreOnVictory(InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreOnVictory(InGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreParagonDegreeUpdated(ParagonTower)'></a>

## AdvancedBloonsTD6Mod.PreParagonDegreeUpdated(ParagonTower) Method

Called before the degree for a paragon is changed  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on ParagonTower.UpdateDegree

```csharp
public virtual bool PreParagonDegreeUpdated(ref ParagonTower paragonTower);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreParagonDegreeUpdated(ParagonTower).paragonTower'></a>

`paragonTower` [Il2CppAssets.Scripts.Simulation.Towers.Behaviors.ParagonTower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Behaviors.ParagonTower 'Il2CppAssets.Scripts.Simulation.Towers.Behaviors.ParagonTower')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PrePauseScreenClosed(PauseScreen)'></a>

## AdvancedBloonsTD6Mod.PrePauseScreenClosed(PauseScreen) Method

Called before the pause screen is closed  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on PauseScreen.Close

```csharp
public virtual bool PrePauseScreenClosed(ref PauseScreen pauseScreen);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PrePauseScreenClosed(PauseScreen).pauseScreen'></a>

`pauseScreen` [Il2CppAssets.Scripts.Unity.UI_New.Pause.PauseScreen](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Pause.PauseScreen 'Il2CppAssets.Scripts.Unity.UI_New.Pause.PauseScreen')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PrePauseScreenOpened(PauseScreen)'></a>

## AdvancedBloonsTD6Mod.PrePauseScreenOpened(PauseScreen) Method

Called before the pause screen is opened  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on PauseScreen.Open

```csharp
public virtual bool PrePauseScreenOpened(ref PauseScreen pauseScreen);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PrePauseScreenOpened(PauseScreen).pauseScreen'></a>

`pauseScreen` [Il2CppAssets.Scripts.Unity.UI_New.Pause.PauseScreen](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.Pause.PauseScreen 'Il2CppAssets.Scripts.Unity.UI_New.Pause.PauseScreen')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PrePointerEnterSelectable(Selectable,PointerEventData)'></a>

## AdvancedBloonsTD6Mod.PrePointerEnterSelectable(Selectable, PointerEventData) Method

Called before the mouse goes over a button  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on Button.OnPointerEnter

```csharp
public virtual bool PrePointerEnterSelectable(ref Selectable button, ref PointerEventData eventData);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PrePointerEnterSelectable(Selectable,PointerEventData).button'></a>

`button` [UnityEngine.UI.Selectable](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Selectable 'UnityEngine.UI.Selectable')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PrePointerEnterSelectable(Selectable,PointerEventData).eventData'></a>

`eventData` [UnityEngine.EventSystems.PointerEventData](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.EventSystems.PointerEventData 'UnityEngine.EventSystems.PointerEventData')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PrePointerExitSelectable(Selectable,PointerEventData)'></a>

## AdvancedBloonsTD6Mod.PrePointerExitSelectable(Selectable, PointerEventData) Method

Called before the mouse leaves a button  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on Button.OnPointerExit

```csharp
public virtual bool PrePointerExitSelectable(ref Selectable button, ref PointerEventData eventData);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PrePointerExitSelectable(Selectable,PointerEventData).button'></a>

`button` [UnityEngine.UI.Selectable](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Selectable 'UnityEngine.UI.Selectable')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PrePointerExitSelectable(Selectable,PointerEventData).eventData'></a>

`eventData` [UnityEngine.EventSystems.PointerEventData](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.EventSystems.PointerEventData 'UnityEngine.EventSystems.PointerEventData')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreRemoveableDestroyed(Removeable)'></a>

## AdvancedBloonsTD6Mod.PreRemoveableDestroyed(Removeable) Method

Called before a Removeable is destroyed  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on Map.DestroyRemoveable

```csharp
public virtual bool PreRemoveableDestroyed(ref Removeable removeable);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreRemoveableDestroyed(Removeable).removeable'></a>

`removeable` [Il2CppAssets.Scripts.Simulation.Track.Removeable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Track.Removeable 'Il2CppAssets.Scripts.Simulation.Track.Removeable')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreRestart(InGame)'></a>

## AdvancedBloonsTD6Mod.PreRestart(InGame) Method

Called before the game is restarted  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on InGame.Restart

```csharp
public virtual bool PreRestart(InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreRestart(InGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreShowUpgradeTree(TowerModel,bool)'></a>

## AdvancedBloonsTD6Mod.PreShowUpgradeTree(TowerModel, bool) Method

Called before the upgrade tree is shown for a tower  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on InGame.ShowUpgradeTree

```csharp
public virtual bool PreShowUpgradeTree(ref TowerModel tower, ref bool fromDoubleTap);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreShowUpgradeTree(TowerModel,bool).tower'></a>

`tower` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreShowUpgradeTree(TowerModel,bool).fromDoubleTap'></a>

`fromDoubleTap` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreSpriteLoaded(SpriteAtlas,string,Sprite)'></a>

## AdvancedBloonsTD6Mod.PreSpriteLoaded(SpriteAtlas, string, Sprite) Method

Called before a sprite is loaded from a SpriteAtlas  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on SpriteAtlas.GetSprite

```csharp
public virtual bool PreSpriteLoaded(ref SpriteAtlas spriteAtlas, ref string name, ref Sprite result);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreSpriteLoaded(SpriteAtlas,string,Sprite).spriteAtlas'></a>

`spriteAtlas` [UnityEngine.U2D.SpriteAtlas](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.U2D.SpriteAtlas 'UnityEngine.U2D.SpriteAtlas')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreSpriteLoaded(SpriteAtlas,string,Sprite).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreSpriteLoaded(SpriteAtlas,string,Sprite).result'></a>

`result` [UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreTowerButtonCreated(TowerModel,int,bool,TowerPurchaseButton)'></a>

## AdvancedBloonsTD6Mod.PreTowerButtonCreated(TowerModel, int, bool, TowerPurchaseButton) Method

Called before a TowerPurchaseButton is created  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on ShopMenu.CreateTowerButton

```csharp
public virtual bool PreTowerButtonCreated(ref TowerModel tower, ref int index, ref bool showAmount, ref TowerPurchaseButton button);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreTowerButtonCreated(TowerModel,int,bool,TowerPurchaseButton).tower'></a>

`tower` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreTowerButtonCreated(TowerModel,int,bool,TowerPurchaseButton).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreTowerButtonCreated(TowerModel,int,bool,TowerPurchaseButton).showAmount'></a>

`showAmount` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreTowerButtonCreated(TowerModel,int,bool,TowerPurchaseButton).button'></a>

`button` [Il2CppAssets.Scripts.Unity.UI_New.InGame.StoreMenu.TowerPurchaseButton](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.StoreMenu.TowerPurchaseButton 'Il2CppAssets.Scripts.Unity.UI_New.InGame.StoreMenu.TowerPurchaseButton')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreTowerInventoryInit(TowerInventory,System.Collections.Generic.IEnumerable_TowerDetailsModel_)'></a>

## AdvancedBloonsTD6Mod.PreTowerInventoryInit(TowerInventory, IEnumerable<TowerDetailsModel>) Method

Called before a TowerInventory is initialized  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on TowerInventory.Init

```csharp
public virtual bool PreTowerInventoryInit(ref TowerInventory towerInventory, ref System.Collections.Generic.IEnumerable<TowerDetailsModel> baseTowers);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreTowerInventoryInit(TowerInventory,System.Collections.Generic.IEnumerable_TowerDetailsModel_).towerInventory'></a>

`towerInventory` [Il2CppAssets.Scripts.Simulation.Input.TowerInventory](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Input.TowerInventory 'Il2CppAssets.Scripts.Simulation.Input.TowerInventory')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreTowerInventoryInit(TowerInventory,System.Collections.Generic.IEnumerable_TowerDetailsModel_).baseTowers'></a>

`baseTowers` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreTowerSold(Tower,float)'></a>

## AdvancedBloonsTD6Mod.PreTowerSold(Tower, float) Method

Called before a tower is sold  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on Tower.OnSold

```csharp
public virtual bool PreTowerSold(ref Tower tower, ref float amount);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreTowerSold(Tower,float).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreTowerSold(Tower,float).amount'></a>

`amount` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreTowerUpgraded(Tower,string,TowerModel)'></a>

## AdvancedBloonsTD6Mod.PreTowerUpgraded(Tower, string, TowerModel) Method

Called before a tower is upgraded  
Return 'false' to prevent the original method from running  
<br/>  
Equivalent to a HarmonyPrefix on TowerManager.UpgradeTower

```csharp
public virtual bool PreTowerUpgraded(ref Tower tower, string upgradeName, ref TowerModel newBaseTowerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreTowerUpgraded(Tower,string,TowerModel).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreTowerUpgraded(Tower,string,TowerModel).upgradeName'></a>

`upgradeName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.AdvancedBloonsTD6Mod.PreTowerUpgraded(Tower,string,TowerModel).newBaseTowerModel'></a>

`newBaseTowerModel` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')