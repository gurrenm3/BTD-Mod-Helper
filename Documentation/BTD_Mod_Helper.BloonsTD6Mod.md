#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper](README.md#BTD_Mod_Helper 'BTD_Mod_Helper')

## BloonsTD6Mod Class

Extend this Class instead of MelonMod to gain access to dozens of easy to use built-in hooks

```csharp
public abstract class BloonsTD6Mod : BTD_Mod_Helper.BloonsMod
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [MelonLoader.MelonBase](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonBase 'MelonLoader.MelonBase') &#129106; [MelonLoader.MelonTypeBase&lt;](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonTypeBase-1 'MelonLoader.MelonTypeBase`1')[MelonLoader.MelonMod](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonMod 'MelonLoader.MelonMod')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonTypeBase-1 'MelonLoader.MelonTypeBase`1') &#129106; [MelonLoader.MelonMod](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonMod 'MelonLoader.MelonMod') &#129106; [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod') &#129106; BloonsTD6Mod
### Methods

<a name='BTD_Mod_Helper.BloonsTD6Mod.ActOnMessage(NinjaKiwi.NKMulti.Message)'></a>

## BloonsTD6Mod.ActOnMessage(Message) Method

Acts on a Network message that's been sent to the client  
<br/>  
Use [ReadMessage&lt;T&gt;(Message)](BTD_Mod_Helper.Api.Coop.MessageUtils.md#BTD_Mod_Helper.Api.Coop.MessageUtils.ReadMessage_T_(NinjaKiwi.NKMulti.Message) 'BTD_Mod_Helper.Api.Coop.MessageUtils.ReadMessage<T>(NinjaKiwi.NKMulti.Message)') to read back the message you sent.  
<br/>  
If this is one of your messages and you're consuming and acting on it, return true.  
Otherwise, return false. Seriously.  
Note: Only invoked if [CheatMod](BTD_Mod_Helper.BloonsMod.md#BTD_Mod_Helper.BloonsMod.CheatMod 'BTD_Mod_Helper.BloonsMod.CheatMod') == true.

```csharp
public virtual bool ActOnMessage(NinjaKiwi.NKMulti.Message message);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.ActOnMessage(NinjaKiwi.NKMulti.Message).message'></a>

`message` [NinjaKiwi.NKMulti.Message](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.Message 'NinjaKiwi.NKMulti.Message')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAbilityCast(Assets.Scripts.Simulation.Towers.Behaviors.Abilities.Ability)'></a>

## BloonsTD6Mod.OnAbilityCast(Ability) Method

Called when a ability is cast  
<br/>  
Equivalent to a HarmonyPostFix on Ability.Activate

```csharp
public virtual void OnAbilityCast(Assets.Scripts.Simulation.Towers.Behaviors.Abilities.Ability ability);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAbilityCast(Assets.Scripts.Simulation.Towers.Behaviors.Abilities.Ability).ability'></a>

`ability` [Assets.Scripts.Simulation.Towers.Behaviors.Abilities.Ability](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Behaviors.Abilities.Ability 'Assets.Scripts.Simulation.Towers.Behaviors.Abilities.Ability')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAttackCreated(Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack,Assets.Scripts.Simulation.Objects.Entity,Assets.Scripts.Models.Model)'></a>

## BloonsTD6Mod.OnAttackCreated(Attack, Entity, Model) Method

Called right after an Attack is created  
<br/>  
Equivalent to a HarmonyPostFix on Attack.Initialise

```csharp
public virtual void OnAttackCreated(Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack attack, Assets.Scripts.Simulation.Objects.Entity entity, Assets.Scripts.Models.Model modelToUse);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAttackCreated(Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack,Assets.Scripts.Simulation.Objects.Entity,Assets.Scripts.Models.Model).attack'></a>

`attack` [Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAttackCreated(Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack,Assets.Scripts.Simulation.Objects.Entity,Assets.Scripts.Models.Model).entity'></a>

`entity` [Assets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Objects.Entity 'Assets.Scripts.Simulation.Objects.Entity')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAttackCreated(Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack,Assets.Scripts.Simulation.Objects.Entity,Assets.Scripts.Models.Model).modelToUse'></a>

`modelToUse` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAttackModelChanged(Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack,Assets.Scripts.Models.Model)'></a>

## BloonsTD6Mod.OnAttackModelChanged(Attack, Model) Method

Called right after a Tower's Attack is changed for any reason (creation, upgrading, etc.)  
<br/>  
Equivalent to a HarmonyPostFix on Attack.UpdatedModel

```csharp
public virtual void OnAttackModelChanged(Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack attack, Assets.Scripts.Models.Model newModel);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAttackModelChanged(Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack,Assets.Scripts.Models.Model).attack'></a>

`attack` [Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAttackModelChanged(Assets.Scripts.Simulation.Towers.Behaviors.Attack.Attack,Assets.Scripts.Models.Model).newModel'></a>

`newModel` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAudioFactoryStart(Assets.Scripts.Unity.Audio.AudioFactory)'></a>

## BloonsTD6Mod.OnAudioFactoryStart(AudioFactory) Method

Called when the games audioFactory is loaded  
<br/>  
Equivalent to a HarmonyPostFix on AudioFactory_Start

```csharp
public virtual void OnAudioFactoryStart(Assets.Scripts.Unity.Audio.AudioFactory audioFactory);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAudioFactoryStart(Assets.Scripts.Unity.Audio.AudioFactory).audioFactory'></a>

`audioFactory` [Assets.Scripts.Unity.Audio.AudioFactory](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Audio.AudioFactory 'Assets.Scripts.Unity.Audio.AudioFactory')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonCreated(Assets.Scripts.Simulation.Bloons.Bloon)'></a>

## BloonsTD6Mod.OnBloonCreated(Bloon) Method

Called right after a Bloon is first created  
<br/>  
Equivalent to a HarmonyPostFix on Bloon.Initialise

```csharp
public virtual void OnBloonCreated(Assets.Scripts.Simulation.Bloons.Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonCreated(Assets.Scripts.Simulation.Bloons.Bloon).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonDestroy(Assets.Scripts.Simulation.Bloons.Bloon)'></a>

## BloonsTD6Mod.OnBloonDestroy(Bloon) Method

Called right after a Bloon is destroyed  
<br/>  
Equivalent to a HarmonyPostFix on Bloon.OnDestroy

```csharp
public virtual void OnBloonDestroy(Assets.Scripts.Simulation.Bloons.Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonDestroy(Assets.Scripts.Simulation.Bloons.Bloon).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonModelUpdated(Assets.Scripts.Simulation.Bloons.Bloon,Assets.Scripts.Models.Model)'></a>

## BloonsTD6Mod.OnBloonModelUpdated(Bloon, Model) Method

Called right after a Bloon's BloonModel is updated  
<br/>  
Equivalent to a HarmonyPostFix on Bloon.UpdatedModel

```csharp
public virtual void OnBloonModelUpdated(Assets.Scripts.Simulation.Bloons.Bloon bloon, Assets.Scripts.Models.Model model);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonModelUpdated(Assets.Scripts.Simulation.Bloons.Bloon,Assets.Scripts.Models.Model).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonModelUpdated(Assets.Scripts.Simulation.Bloons.Bloon,Assets.Scripts.Models.Model).model'></a>

`model` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonPopped(Assets.Scripts.Simulation.Bloons.Bloon)'></a>

## BloonsTD6Mod.OnBloonPopped(Bloon) Method

Called right after a Bloon is destroyed, but only when it's popped and not leaked

```csharp
public virtual void OnBloonPopped(Assets.Scripts.Simulation.Bloons.Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonPopped(Assets.Scripts.Simulation.Bloons.Bloon).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnCashAdded(double,Assets.Scripts.Simulation.Simulation.CashType,int,Assets.Scripts.Simulation.Simulation.CashSource,Assets.Scripts.Simulation.Towers.Tower)'></a>

## BloonsTD6Mod.OnCashAdded(double, CashType, int, CashSource, Tower) Method

Called right after Cash is added in a game  
Tower might be null  
<br/>  
Equivalent to a HarmonyPostFix on Simulation.AddCash

```csharp
public virtual void OnCashAdded(double amount, Assets.Scripts.Simulation.Simulation.CashType from, int cashIndex, Assets.Scripts.Simulation.Simulation.CashSource source, Assets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnCashAdded(double,Assets.Scripts.Simulation.Simulation.CashType,int,Assets.Scripts.Simulation.Simulation.CashSource,Assets.Scripts.Simulation.Towers.Tower).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnCashAdded(double,Assets.Scripts.Simulation.Simulation.CashType,int,Assets.Scripts.Simulation.Simulation.CashSource,Assets.Scripts.Simulation.Towers.Tower).from'></a>

`from` [Assets.Scripts.Simulation.Simulation.CashType](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Simulation.CashType 'Assets.Scripts.Simulation.Simulation.CashType')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnCashAdded(double,Assets.Scripts.Simulation.Simulation.CashType,int,Assets.Scripts.Simulation.Simulation.CashSource,Assets.Scripts.Simulation.Towers.Tower).cashIndex'></a>

`cashIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnCashAdded(double,Assets.Scripts.Simulation.Simulation.CashType,int,Assets.Scripts.Simulation.Simulation.CashSource,Assets.Scripts.Simulation.Towers.Tower).source'></a>

`source` [Assets.Scripts.Simulation.Simulation.CashSource](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Simulation.CashSource 'Assets.Scripts.Simulation.Simulation.CashSource')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnCashAdded(double,Assets.Scripts.Simulation.Simulation.CashType,int,Assets.Scripts.Simulation.Simulation.CashSource,Assets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnCashRemoved(double,Assets.Scripts.Simulation.Simulation.CashType,int,Assets.Scripts.Simulation.Simulation.CashSource)'></a>

## BloonsTD6Mod.OnCashRemoved(double, CashType, int, CashSource) Method

Called right after Cash is removed in a game  
<br/>  
Equivalent to a HarmonyPostFix on Simulation.RemoveCash

```csharp
public virtual void OnCashRemoved(double amount, Assets.Scripts.Simulation.Simulation.CashType from, int cashIndex, Assets.Scripts.Simulation.Simulation.CashSource source);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnCashRemoved(double,Assets.Scripts.Simulation.Simulation.CashType,int,Assets.Scripts.Simulation.Simulation.CashSource).amount'></a>

`amount` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnCashRemoved(double,Assets.Scripts.Simulation.Simulation.CashType,int,Assets.Scripts.Simulation.Simulation.CashSource).from'></a>

`from` [Assets.Scripts.Simulation.Simulation.CashType](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Simulation.CashType 'Assets.Scripts.Simulation.Simulation.CashType')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnCashRemoved(double,Assets.Scripts.Simulation.Simulation.CashType,int,Assets.Scripts.Simulation.Simulation.CashSource).cashIndex'></a>

`cashIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnCashRemoved(double,Assets.Scripts.Simulation.Simulation.CashType,int,Assets.Scripts.Simulation.Simulation.CashSource).source'></a>

`source` [Assets.Scripts.Simulation.Simulation.CashSource](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Simulation.CashSource 'Assets.Scripts.Simulation.Simulation.CashSource')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnConnected(NinjaKiwi.NKMulti.NKMultiGameInterface)'></a>

## BloonsTD6Mod.OnConnected(NKMultiGameInterface) Method

Executed once the user has connected to a game session.  
Note: Only invoked if [CheatMod](BTD_Mod_Helper.BloonsMod.md#BTD_Mod_Helper.BloonsMod.CheatMod 'BTD_Mod_Helper.BloonsMod.CheatMod') == true.

```csharp
public virtual void OnConnected(NinjaKiwi.NKMulti.NKMultiGameInterface nkGi);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnConnected(NinjaKiwi.NKMulti.NKMultiGameInterface).nkGi'></a>

`nkGi` [NinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.NKMultiGameInterface 'NinjaKiwi.NKMulti.NKMultiGameInterface')

The interface used to interact with the game.

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnConnectFail(NinjaKiwi.NKMulti.NKMultiGameInterface)'></a>

## BloonsTD6Mod.OnConnectFail(NKMultiGameInterface) Method

Executed once the user has tried to connect to a server, but failed to do so.  
Note: Only invoked if [CheatMod](BTD_Mod_Helper.BloonsMod.md#BTD_Mod_Helper.BloonsMod.CheatMod 'BTD_Mod_Helper.BloonsMod.CheatMod') == true.

```csharp
public virtual void OnConnectFail(NinjaKiwi.NKMulti.NKMultiGameInterface nkGi);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnConnectFail(NinjaKiwi.NKMulti.NKMultiGameInterface).nkGi'></a>

`nkGi` [NinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.NKMultiGameInterface 'NinjaKiwi.NKMulti.NKMultiGameInterface')

The interface used to interact with the game.

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnDefeat()'></a>

## BloonsTD6Mod.OnDefeat() Method

Called right after a match ends in defeat  
<br/>  
Equivalent to a HarmonyPostFix on Simulation.OnDefeat

```csharp
public virtual void OnDefeat();
```

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnDisconnected(NinjaKiwi.NKMulti.NKMultiGameInterface)'></a>

## BloonsTD6Mod.OnDisconnected(NKMultiGameInterface) Method

Executed once the player has disconnected from a server.  
Note: Only invoked if [CheatMod](BTD_Mod_Helper.BloonsMod.md#BTD_Mod_Helper.BloonsMod.CheatMod 'BTD_Mod_Helper.BloonsMod.CheatMod') == true.

```csharp
public virtual void OnDisconnected(NinjaKiwi.NKMulti.NKMultiGameInterface nkGi);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnDisconnected(NinjaKiwi.NKMulti.NKMultiGameInterface).nkGi'></a>

`nkGi` [NinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.NKMultiGameInterface 'NinjaKiwi.NKMulti.NKMultiGameInterface')

The interface used to interact with the game.

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnFastForwardChanged(bool)'></a>

## BloonsTD6Mod.OnFastForwardChanged(bool) Method

Called right after a game ends in victory  
<br/>  
Equivalent to a HarmonyPostFix on TimeManager.SetFastForward

```csharp
public virtual void OnFastForwardChanged(bool newValue);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnFastForwardChanged(bool).newValue'></a>

`newValue` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnGameDataLoaded(Assets.Scripts.Data.GameData)'></a>

## BloonsTD6Mod.OnGameDataLoaded(GameData) Method

Called when the GameData.Instance object is first loaded

```csharp
public virtual void OnGameDataLoaded(Assets.Scripts.Data.GameData gameData);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnGameDataLoaded(Assets.Scripts.Data.GameData).gameData'></a>

`gameData` [Assets.Scripts.Data.GameData](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Data.GameData 'Assets.Scripts.Data.GameData')

GameData.Instance

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnGameModelLoaded(Assets.Scripts.Models.GameModel)'></a>

## BloonsTD6Mod.OnGameModelLoaded(GameModel) Method

Called when Game.instance.model is not null

```csharp
public virtual void OnGameModelLoaded(Assets.Scripts.Models.GameModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnGameModelLoaded(Assets.Scripts.Models.GameModel).model'></a>

`model` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnGameObjectsReset()'></a>

## BloonsTD6Mod.OnGameObjectsReset() Method

Called when all of the existing GameObjects within a match are destroyed

```csharp
public virtual void OnGameObjectsReset();
```

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnInGameLoaded(Assets.Scripts.Unity.UI_New.InGame.InGame)'></a>

## BloonsTD6Mod.OnInGameLoaded(InGame) Method

Called when InGame.instance.UnityToSimulation.Simulation is not null

```csharp
public virtual void OnInGameLoaded(Assets.Scripts.Unity.UI_New.InGame.InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnInGameLoaded(Assets.Scripts.Unity.UI_New.InGame.InGame).inGame'></a>

`inGame` [Assets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.UI_New.InGame.InGame 'Assets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnMainMenu()'></a>

## BloonsTD6Mod.OnMainMenu() Method

Called when you go to the main menu screen  
<br/>  
Equivalent to a HarmonyPostFix on MainMenu.OnEnable

```csharp
public virtual void OnMainMenu();
```

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnMapModelLoaded(Assets.Scripts.Models.Map.MapModel)'></a>

## BloonsTD6Mod.OnMapModelLoaded(MapModel) Method

Called when a map model is loaded by the game. Equivelant to MapLoader.Load.

```csharp
public virtual void OnMapModelLoaded(ref Assets.Scripts.Models.Map.MapModel mapModel);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnMapModelLoaded(Assets.Scripts.Models.Map.MapModel).mapModel'></a>

`mapModel` [Assets.Scripts.Models.Map.MapModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Map.MapModel 'Assets.Scripts.Models.Map.MapModel')

The map that was just loaded. It is passed by reference to allow for modifications.

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnMatchEnd()'></a>

## BloonsTD6Mod.OnMatchEnd() Method

Called when the player returns to the MainMenu from a match  
<br/>  
Equivalent to a HarmonyPostFix on InGame.Quit

```csharp
public virtual void OnMatchEnd();
```

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnMatchStart()'></a>

## BloonsTD6Mod.OnMatchStart() Method

Called right after a match is started up (restart included it seems like)  
<br/>  
Equivalent to a HarmonyPostFix on InGame.StartMatch

```csharp
public virtual void OnMatchStart();
```

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnModelLoaded(Assets.Scripts.Unity.Display.Factory,string,Il2CppSystem.Action_Assets.Scripts.Unity.Display.UnityDisplayNode_)'></a>

## BloonsTD6Mod.OnModelLoaded(Factory, string, Action<UnityDisplayNode>) Method

Called when a display is being loaded such as a towers 3d model  
<br/>  
Equivalent to a HarmonyPostFix on GameModel_CreatedModded

```csharp
public virtual void OnModelLoaded(Assets.Scripts.Unity.Display.Factory factory, string ModelToLoad, Il2CppSystem.Action<Assets.Scripts.Unity.Display.UnityDisplayNode> action);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnModelLoaded(Assets.Scripts.Unity.Display.Factory,string,Il2CppSystem.Action_Assets.Scripts.Unity.Display.UnityDisplayNode_).factory'></a>

`factory` [Assets.Scripts.Unity.Display.Factory](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.Factory 'Assets.Scripts.Unity.Display.Factory')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnModelLoaded(Assets.Scripts.Unity.Display.Factory,string,Il2CppSystem.Action_Assets.Scripts.Unity.Display.UnityDisplayNode_).ModelToLoad'></a>

`ModelToLoad` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnModelLoaded(Assets.Scripts.Unity.Display.Factory,string,Il2CppSystem.Action_Assets.Scripts.Unity.Display.UnityDisplayNode_).action'></a>

`action` [Il2CppSystem.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Action-1 'Il2CppSystem.Action`1')[Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Action-1 'Il2CppSystem.Action`1')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnNewGameModel(Assets.Scripts.Models.GameModel)'></a>

## BloonsTD6Mod.OnNewGameModel(GameModel) Method

Called when a new GameModel is created, aka when things like Monkey Knowledge are applied to towers  
<br/>  
Equivalent to a HarmonyPostFix on GameModel_CreatedModded

```csharp
public virtual void OnNewGameModel(Assets.Scripts.Models.GameModel result);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnNewGameModel(Assets.Scripts.Models.GameModel).result'></a>

`result` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnNewGameModel(Assets.Scripts.Models.GameModel,Il2CppSystem.Collections.Generic.List_Assets.Scripts.Models.Towers.Mods.ModModel_)'></a>

## BloonsTD6Mod.OnNewGameModel(GameModel, List<ModModel>) Method

Called when a new GameModel is created, aka when things like Monkey Knowledge are applied to towers  
<br/>  
Equivalent to a HarmonyPostFix on GameModel_CreatedModded

```csharp
public virtual void OnNewGameModel(Assets.Scripts.Models.GameModel result, Il2CppSystem.Collections.Generic.List<Assets.Scripts.Models.Towers.Mods.ModModel> mods);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnNewGameModel(Assets.Scripts.Models.GameModel,Il2CppSystem.Collections.Generic.List_Assets.Scripts.Models.Towers.Mods.ModModel_).result'></a>

`result` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnNewGameModel(Assets.Scripts.Models.GameModel,Il2CppSystem.Collections.Generic.List_Assets.Scripts.Models.Towers.Mods.ModModel_).mods'></a>

`mods` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnPeerConnected(NinjaKiwi.NKMulti.NKMultiGameInterface,int)'></a>

## BloonsTD6Mod.OnPeerConnected(NKMultiGameInterface, int) Method

Executed when a new client has joined the game session.  
Note: Only invoked if [CheatMod](BTD_Mod_Helper.BloonsMod.md#BTD_Mod_Helper.BloonsMod.CheatMod 'BTD_Mod_Helper.BloonsMod.CheatMod') == true.

```csharp
public virtual void OnPeerConnected(NinjaKiwi.NKMulti.NKMultiGameInterface nkGi, int peerId);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnPeerConnected(NinjaKiwi.NKMulti.NKMultiGameInterface,int).nkGi'></a>

`nkGi` [NinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.NKMultiGameInterface 'NinjaKiwi.NKMulti.NKMultiGameInterface')

The interface used to interact with the game.

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnPeerConnected(NinjaKiwi.NKMulti.NKMultiGameInterface,int).peerId'></a>

`peerId` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Index of the peer in question.

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnPeerDisconnected(NinjaKiwi.NKMulti.NKMultiGameInterface,int)'></a>

## BloonsTD6Mod.OnPeerDisconnected(NKMultiGameInterface, int) Method

Executed when a new client has left the game session.  
Note: Only invoked if [CheatMod](BTD_Mod_Helper.BloonsMod.md#BTD_Mod_Helper.BloonsMod.CheatMod 'BTD_Mod_Helper.BloonsMod.CheatMod') == true.

```csharp
public virtual void OnPeerDisconnected(NinjaKiwi.NKMulti.NKMultiGameInterface nkGi, int peerId);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnPeerDisconnected(NinjaKiwi.NKMulti.NKMultiGameInterface,int).nkGi'></a>

`nkGi` [NinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.NKMultiGameInterface 'NinjaKiwi.NKMulti.NKMultiGameInterface')

The interface used to interact with the game.

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnPeerDisconnected(NinjaKiwi.NKMulti.NKMultiGameInterface,int).peerId'></a>

`peerId` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Index of the peer in question.

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProfileLoaded(Assets.Scripts.Models.Profile.ProfileModel)'></a>

## BloonsTD6Mod.OnProfileLoaded(ProfileModel) Method

Called when the player's ProfileModel is loaded.  
<br/>  
Equivalent to a HarmonyPostFix on ProfileModel_Validate

```csharp
public virtual void OnProfileLoaded(Assets.Scripts.Models.Profile.ProfileModel result);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProfileLoaded(Assets.Scripts.Models.Profile.ProfileModel).result'></a>

`result` [Assets.Scripts.Models.Profile.ProfileModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Profile.ProfileModel 'Assets.Scripts.Models.Profile.ProfileModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProjectileCreated(Assets.Scripts.Simulation.Towers.Projectiles.Projectile,Assets.Scripts.Simulation.Objects.Entity,Assets.Scripts.Models.Model)'></a>

## BloonsTD6Mod.OnProjectileCreated(Projectile, Entity, Model) Method

Called right after a Projectile is created  
<br/>  
Equivalent to a HarmonyPostFix on Projectile.Initialise

```csharp
public virtual void OnProjectileCreated(Assets.Scripts.Simulation.Towers.Projectiles.Projectile projectile, Assets.Scripts.Simulation.Objects.Entity entity, Assets.Scripts.Models.Model modelToUse);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProjectileCreated(Assets.Scripts.Simulation.Towers.Projectiles.Projectile,Assets.Scripts.Simulation.Objects.Entity,Assets.Scripts.Models.Model).projectile'></a>

`projectile` [Assets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Projectiles.Projectile 'Assets.Scripts.Simulation.Towers.Projectiles.Projectile')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProjectileCreated(Assets.Scripts.Simulation.Towers.Projectiles.Projectile,Assets.Scripts.Simulation.Objects.Entity,Assets.Scripts.Models.Model).entity'></a>

`entity` [Assets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Objects.Entity 'Assets.Scripts.Simulation.Objects.Entity')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProjectileCreated(Assets.Scripts.Simulation.Towers.Projectiles.Projectile,Assets.Scripts.Simulation.Objects.Entity,Assets.Scripts.Models.Model).modelToUse'></a>

`modelToUse` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProjectileModelChanged(Assets.Scripts.Simulation.Towers.Projectiles.Projectile,Assets.Scripts.Models.Model)'></a>

## BloonsTD6Mod.OnProjectileModelChanged(Projectile, Model) Method

Called right after a Tower's TowerModel is changed for any reason (creation, upgrading, etc.)  
<br/>  
Equivalent to a HarmonyPostFix on Projectile.UpdatedModel

```csharp
public virtual void OnProjectileModelChanged(Assets.Scripts.Simulation.Towers.Projectiles.Projectile projectile, Assets.Scripts.Models.Model newModel);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProjectileModelChanged(Assets.Scripts.Simulation.Towers.Projectiles.Projectile,Assets.Scripts.Models.Model).projectile'></a>

`projectile` [Assets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Projectiles.Projectile 'Assets.Scripts.Simulation.Towers.Projectiles.Projectile')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProjectileModelChanged(Assets.Scripts.Simulation.Towers.Projectiles.Projectile,Assets.Scripts.Models.Model).newModel'></a>

`newModel` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnRestart()'></a>

## BloonsTD6Mod.OnRestart() Method

Called when a match is restarted  
<br/>  
Equivalent to a HarmonyPostFix on InGame.Restart

```csharp
public virtual void OnRestart();
```

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnRoundEnd()'></a>

## BloonsTD6Mod.OnRoundEnd() Method

Called right after a round starts  
<br/>  
Equivalent to a HarmonyPostFix on Simulation.OnRoundEnd

```csharp
public virtual void OnRoundEnd();
```

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnRoundStart()'></a>

## BloonsTD6Mod.OnRoundStart() Method

Called right after a round starts  
<br/>  
Equivalent to a HarmonyPostFix on Simulation.OnRoundStart

```csharp
public virtual void OnRoundStart();
```

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnSpriteLoad(Assets.Scripts.Utils.SpriteReference,UnityEngine.UI.Image)'></a>

## BloonsTD6Mod.OnSpriteLoad(SpriteReference, Image) Method

Called when a sprite is being loaded  
<br/>  
Equivalent to a HarmonyPostFix on ResourceLoader_LoadSpriteFromSpriteReferenceAsync

```csharp
public virtual void OnSpriteLoad(Assets.Scripts.Utils.SpriteReference spriteref, UnityEngine.UI.Image image);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnSpriteLoad(Assets.Scripts.Utils.SpriteReference,UnityEngine.UI.Image).spriteref'></a>

`spriteref` [Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnSpriteLoad(Assets.Scripts.Utils.SpriteReference,UnityEngine.UI.Image).image'></a>

`image` [UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTitleScreen()'></a>

## BloonsTD6Mod.OnTitleScreen() Method

Called right after the game finishes loading everything  
<br/>  
Equivalent to a HarmonyPostFix on TitleScreen.Start

```csharp
public virtual void OnTitleScreen();
```

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerCreated(Assets.Scripts.Simulation.Towers.Tower,Assets.Scripts.Simulation.Objects.Entity,Assets.Scripts.Models.Model)'></a>

## BloonsTD6Mod.OnTowerCreated(Tower, Entity, Model) Method

Called right after a Tower is initialized  
<br/>  
Equivalent to a HarmonyPostFix on Tower.Initialise

```csharp
public virtual void OnTowerCreated(Assets.Scripts.Simulation.Towers.Tower tower, Assets.Scripts.Simulation.Objects.Entity target, Assets.Scripts.Models.Model modelToUse);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerCreated(Assets.Scripts.Simulation.Towers.Tower,Assets.Scripts.Simulation.Objects.Entity,Assets.Scripts.Models.Model).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerCreated(Assets.Scripts.Simulation.Towers.Tower,Assets.Scripts.Simulation.Objects.Entity,Assets.Scripts.Models.Model).target'></a>

`target` [Assets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Objects.Entity 'Assets.Scripts.Simulation.Objects.Entity')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerCreated(Assets.Scripts.Simulation.Towers.Tower,Assets.Scripts.Simulation.Objects.Entity,Assets.Scripts.Models.Model).modelToUse'></a>

`modelToUse` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerDeselected(Assets.Scripts.Simulation.Towers.Tower)'></a>

## BloonsTD6Mod.OnTowerDeselected(Tower) Method

Called right after a Tower is deselected by the player  
<br/>  
Equivalent to a HarmonyPostFix on Tower.UnHighlight

```csharp
public virtual void OnTowerDeselected(Assets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerDeselected(Assets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerDestroyed(Assets.Scripts.Simulation.Towers.Tower)'></a>

## BloonsTD6Mod.OnTowerDestroyed(Tower) Method

Called right after a Tower is destroyed  
<br/>  
Equivalent to a HarmonyPostFix on Tower.Destroyed

```csharp
public virtual void OnTowerDestroyed(Assets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerDestroyed(Assets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerGraphicsCreated(Assets.Scripts.Models.Towers.TowerModel,Il2CppSystem.Collections.Generic.List_Assets.Scripts.Unity.Display.UnityDisplayNode_)'></a>

## BloonsTD6Mod.OnTowerGraphicsCreated(TowerModel, List<UnityDisplayNode>) Method

Called right before a Tower's 3D graphics are initialized  
<br/>  
Equivalent to a HarmonyPreFix on InputManager.CreateTowerGraphicsAsync

```csharp
public virtual void OnTowerGraphicsCreated(Assets.Scripts.Models.Towers.TowerModel towerModel, Il2CppSystem.Collections.Generic.List<Assets.Scripts.Unity.Display.UnityDisplayNode> placementGraphics);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerGraphicsCreated(Assets.Scripts.Models.Towers.TowerModel,Il2CppSystem.Collections.Generic.List_Assets.Scripts.Unity.Display.UnityDisplayNode_).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerGraphicsCreated(Assets.Scripts.Models.Towers.TowerModel,Il2CppSystem.Collections.Generic.List_Assets.Scripts.Unity.Display.UnityDisplayNode_).placementGraphics'></a>

`placementGraphics` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerInventoryInitialized(Assets.Scripts.Simulation.Input.TowerInventory,Il2CppSystem.Collections.Generic.List_Assets.Scripts.Models.TowerSets.TowerDetailsModel_)'></a>

## BloonsTD6Mod.OnTowerInventoryInitialized(TowerInventory, List<TowerDetailsModel>) Method

Called when the TowerInventory is initialized for a game

```csharp
public virtual void OnTowerInventoryInitialized(Assets.Scripts.Simulation.Input.TowerInventory towerInventory, Il2CppSystem.Collections.Generic.List<Assets.Scripts.Models.TowerSets.TowerDetailsModel> allTowersInTheGame);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerInventoryInitialized(Assets.Scripts.Simulation.Input.TowerInventory,Il2CppSystem.Collections.Generic.List_Assets.Scripts.Models.TowerSets.TowerDetailsModel_).towerInventory'></a>

`towerInventory` [Assets.Scripts.Simulation.Input.TowerInventory](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Input.TowerInventory 'Assets.Scripts.Simulation.Input.TowerInventory')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerInventoryInitialized(Assets.Scripts.Simulation.Input.TowerInventory,Il2CppSystem.Collections.Generic.List_Assets.Scripts.Models.TowerSets.TowerDetailsModel_).allTowersInTheGame'></a>

`allTowersInTheGame` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[Assets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.TowerSets.TowerDetailsModel 'Assets.Scripts.Models.TowerSets.TowerDetailsModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerLoaded(Assets.Scripts.Simulation.Towers.Tower,Assets.Scripts.Models.Profile.TowerSaveDataModel)'></a>

## BloonsTD6Mod.OnTowerLoaded(Tower, TowerSaveDataModel) Method

Called when you load a save file and a Tower's save data get loaded for the tower  
<br/>  
Use saveData.metaData to load custom information  
<br/>  
Equivalent to a HarmonyPostFix on Tower.SetSavedData

```csharp
public virtual void OnTowerLoaded(Assets.Scripts.Simulation.Towers.Tower tower, Assets.Scripts.Models.Profile.TowerSaveDataModel saveData);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerLoaded(Assets.Scripts.Simulation.Towers.Tower,Assets.Scripts.Models.Profile.TowerSaveDataModel).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerLoaded(Assets.Scripts.Simulation.Towers.Tower,Assets.Scripts.Models.Profile.TowerSaveDataModel).saveData'></a>

`saveData` [Assets.Scripts.Models.Profile.TowerSaveDataModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Profile.TowerSaveDataModel 'Assets.Scripts.Models.Profile.TowerSaveDataModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerModelChanged(Assets.Scripts.Simulation.Towers.Tower,Assets.Scripts.Models.Model)'></a>

## BloonsTD6Mod.OnTowerModelChanged(Tower, Model) Method

Called right after a Tower's TowerModel is changed for any reason (creation, upgrading, etc.)  
<br/>  
Equivalent to a HarmonyPostFix on Tower.UpdatedModel

```csharp
public virtual void OnTowerModelChanged(Assets.Scripts.Simulation.Towers.Tower tower, Assets.Scripts.Models.Model newModel);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerModelChanged(Assets.Scripts.Simulation.Towers.Tower,Assets.Scripts.Models.Model).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerModelChanged(Assets.Scripts.Simulation.Towers.Tower,Assets.Scripts.Models.Model).newModel'></a>

`newModel` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerSaved(Assets.Scripts.Simulation.Towers.Tower,Assets.Scripts.Models.Profile.TowerSaveDataModel)'></a>

## BloonsTD6Mod.OnTowerSaved(Tower, TowerSaveDataModel) Method

Called at the end of each round when a Tower's data is saved  
<br/>  
Use saveData.metaData to save custom information  
<br/>  
Equivalent to a HarmonyPostFix on Tower.GetSavedData

```csharp
public virtual void OnTowerSaved(Assets.Scripts.Simulation.Towers.Tower tower, Assets.Scripts.Models.Profile.TowerSaveDataModel saveData);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerSaved(Assets.Scripts.Simulation.Towers.Tower,Assets.Scripts.Models.Profile.TowerSaveDataModel).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerSaved(Assets.Scripts.Simulation.Towers.Tower,Assets.Scripts.Models.Profile.TowerSaveDataModel).saveData'></a>

`saveData` [Assets.Scripts.Models.Profile.TowerSaveDataModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Profile.TowerSaveDataModel 'Assets.Scripts.Models.Profile.TowerSaveDataModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerSelected(Assets.Scripts.Simulation.Towers.Tower)'></a>

## BloonsTD6Mod.OnTowerSelected(Tower) Method

Called right after a Tower is selected by the player  
<br/>  
Equivalent to a HarmonyPostFix on TowerSelectionMenu.Show

```csharp
public virtual void OnTowerSelected(Assets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerSelected(Assets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerSold(Assets.Scripts.Simulation.Towers.Tower,float)'></a>

## BloonsTD6Mod.OnTowerSold(Tower, float) Method

Called right after a Tower is sold  
<br/>  
Equivalent to a HarmonyPostFix on Tower.OnSold

```csharp
public virtual void OnTowerSold(Assets.Scripts.Simulation.Towers.Tower tower, float amount);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerSold(Assets.Scripts.Simulation.Towers.Tower,float).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerSold(Assets.Scripts.Simulation.Towers.Tower,float).amount'></a>

`amount` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerUpgraded(Assets.Scripts.Simulation.Towers.Tower,string,Assets.Scripts.Models.Towers.TowerModel)'></a>

## BloonsTD6Mod.OnTowerUpgraded(Tower, string, TowerModel) Method

Called right after a Tower is upgraded

```csharp
public virtual void OnTowerUpgraded(Assets.Scripts.Simulation.Towers.Tower tower, string upgradeName, Assets.Scripts.Models.Towers.TowerModel newBaseTowerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerUpgraded(Assets.Scripts.Simulation.Towers.Tower,string,Assets.Scripts.Models.Towers.TowerModel).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerUpgraded(Assets.Scripts.Simulation.Towers.Tower,string,Assets.Scripts.Models.Towers.TowerModel).upgradeName'></a>

`upgradeName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerUpgraded(Assets.Scripts.Simulation.Towers.Tower,string,Assets.Scripts.Models.Towers.TowerModel).newBaseTowerModel'></a>

`newBaseTowerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnVictory()'></a>

## BloonsTD6Mod.OnVictory() Method

Called right after a match ends in victory  
<br/>  
Equivalent to a HarmonyPostFix on InGame.OnVictory

```csharp
public virtual void OnVictory();
```

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponCreated(Assets.Scripts.Simulation.Towers.Weapons.Weapon,Assets.Scripts.Simulation.Objects.Entity,Assets.Scripts.Models.Model)'></a>

## BloonsTD6Mod.OnWeaponCreated(Weapon, Entity, Model) Method

Called right after a Weapon is created  
<br/>  
Equivalent to a HarmonyPostFix on Weapon.Initialise

```csharp
public virtual void OnWeaponCreated(Assets.Scripts.Simulation.Towers.Weapons.Weapon weapon, Assets.Scripts.Simulation.Objects.Entity entity, Assets.Scripts.Models.Model modelToUse);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponCreated(Assets.Scripts.Simulation.Towers.Weapons.Weapon,Assets.Scripts.Simulation.Objects.Entity,Assets.Scripts.Models.Model).weapon'></a>

`weapon` [Assets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Weapons.Weapon 'Assets.Scripts.Simulation.Towers.Weapons.Weapon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponCreated(Assets.Scripts.Simulation.Towers.Weapons.Weapon,Assets.Scripts.Simulation.Objects.Entity,Assets.Scripts.Models.Model).entity'></a>

`entity` [Assets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Objects.Entity 'Assets.Scripts.Simulation.Objects.Entity')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponCreated(Assets.Scripts.Simulation.Towers.Weapons.Weapon,Assets.Scripts.Simulation.Objects.Entity,Assets.Scripts.Models.Model).modelToUse'></a>

`modelToUse` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponFire(Assets.Scripts.Simulation.Towers.Weapons.Weapon)'></a>

## BloonsTD6Mod.OnWeaponFire(Weapon) Method

Called when a weapon fires  
<br/>  
Equivalent to a HarmonyPostFix on Weapon.SpawnDart

```csharp
public virtual void OnWeaponFire(Assets.Scripts.Simulation.Towers.Weapons.Weapon weapon);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponFire(Assets.Scripts.Simulation.Towers.Weapons.Weapon).weapon'></a>

`weapon` [Assets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Weapons.Weapon 'Assets.Scripts.Simulation.Towers.Weapons.Weapon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponModelChanged(Assets.Scripts.Simulation.Towers.Weapons.Weapon,Assets.Scripts.Models.Model)'></a>

## BloonsTD6Mod.OnWeaponModelChanged(Weapon, Model) Method

Called right after a Tower's WeaponModel is changed for any reason (creation, upgrading, etc.)  
<br/>  
Equivalent to a HarmonyPostFix on Weapon.UpdatedModel

```csharp
public virtual void OnWeaponModelChanged(Assets.Scripts.Simulation.Towers.Weapons.Weapon weapon, Assets.Scripts.Models.Model newModel);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponModelChanged(Assets.Scripts.Simulation.Towers.Weapons.Weapon,Assets.Scripts.Models.Model).weapon'></a>

`weapon` [Assets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Weapons.Weapon 'Assets.Scripts.Simulation.Towers.Weapons.Weapon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponModelChanged(Assets.Scripts.Simulation.Towers.Weapons.Weapon,Assets.Scripts.Models.Model).newModel'></a>

`newModel` [Assets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Model 'Assets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Assets.Scripts.Simulation.Bloons.Bloon,float,Assets.Scripts.Simulation.Towers.Projectiles.Projectile,bool,bool,bool,Assets.Scripts.Simulation.Towers.Tower,global__BloonProperties,bool,bool,bool)'></a>

## BloonsTD6Mod.PostBloonDamaged(Bloon, float, Projectile, bool, bool, bool, Tower, BloonProperties, bool, bool, bool) Method

Called right after a Bloon is damaged  
<br/>  
Equivalent to a HarmonyPostFix on Bloon.Damaged

```csharp
public virtual void PostBloonDamaged(Assets.Scripts.Simulation.Bloons.Bloon bloon, float totalAmount, Assets.Scripts.Simulation.Towers.Projectiles.Projectile projectile, bool distributeToChildren, bool overrideDistributeBlocker, bool createEffect, Assets.Scripts.Simulation.Towers.Tower tower, global::BloonProperties immuneBloonProperties, bool canDestroyProjectile=true, bool ignoreNonTargetable=false, bool blockSpawnChildren=false);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Assets.Scripts.Simulation.Bloons.Bloon,float,Assets.Scripts.Simulation.Towers.Projectiles.Projectile,bool,bool,bool,Assets.Scripts.Simulation.Towers.Tower,global__BloonProperties,bool,bool,bool).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Assets.Scripts.Simulation.Bloons.Bloon,float,Assets.Scripts.Simulation.Towers.Projectiles.Projectile,bool,bool,bool,Assets.Scripts.Simulation.Towers.Tower,global__BloonProperties,bool,bool,bool).totalAmount'></a>

`totalAmount` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Assets.Scripts.Simulation.Bloons.Bloon,float,Assets.Scripts.Simulation.Towers.Projectiles.Projectile,bool,bool,bool,Assets.Scripts.Simulation.Towers.Tower,global__BloonProperties,bool,bool,bool).projectile'></a>

`projectile` [Assets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Projectiles.Projectile 'Assets.Scripts.Simulation.Towers.Projectiles.Projectile')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Assets.Scripts.Simulation.Bloons.Bloon,float,Assets.Scripts.Simulation.Towers.Projectiles.Projectile,bool,bool,bool,Assets.Scripts.Simulation.Towers.Tower,global__BloonProperties,bool,bool,bool).distributeToChildren'></a>

`distributeToChildren` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Assets.Scripts.Simulation.Bloons.Bloon,float,Assets.Scripts.Simulation.Towers.Projectiles.Projectile,bool,bool,bool,Assets.Scripts.Simulation.Towers.Tower,global__BloonProperties,bool,bool,bool).overrideDistributeBlocker'></a>

`overrideDistributeBlocker` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Assets.Scripts.Simulation.Bloons.Bloon,float,Assets.Scripts.Simulation.Towers.Projectiles.Projectile,bool,bool,bool,Assets.Scripts.Simulation.Towers.Tower,global__BloonProperties,bool,bool,bool).createEffect'></a>

`createEffect` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Assets.Scripts.Simulation.Bloons.Bloon,float,Assets.Scripts.Simulation.Towers.Projectiles.Projectile,bool,bool,bool,Assets.Scripts.Simulation.Towers.Tower,global__BloonProperties,bool,bool,bool).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Assets.Scripts.Simulation.Bloons.Bloon,float,Assets.Scripts.Simulation.Towers.Projectiles.Projectile,bool,bool,bool,Assets.Scripts.Simulation.Towers.Tower,global__BloonProperties,bool,bool,bool).immuneBloonProperties'></a>

`immuneBloonProperties` [BloonProperties](https://docs.microsoft.com/en-us/dotnet/api/BloonProperties 'BloonProperties')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Assets.Scripts.Simulation.Bloons.Bloon,float,Assets.Scripts.Simulation.Towers.Projectiles.Projectile,bool,bool,bool,Assets.Scripts.Simulation.Towers.Tower,global__BloonProperties,bool,bool,bool).canDestroyProjectile'></a>

`canDestroyProjectile` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Assets.Scripts.Simulation.Bloons.Bloon,float,Assets.Scripts.Simulation.Towers.Projectiles.Projectile,bool,bool,bool,Assets.Scripts.Simulation.Towers.Tower,global__BloonProperties,bool,bool,bool).ignoreNonTargetable'></a>

`ignoreNonTargetable` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Assets.Scripts.Simulation.Bloons.Bloon,float,Assets.Scripts.Simulation.Towers.Projectiles.Projectile,bool,bool,bool,Assets.Scripts.Simulation.Towers.Tower,global__BloonProperties,bool,bool,bool).blockSpawnChildren'></a>

`blockSpawnChildren` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonLeaked(Assets.Scripts.Simulation.Bloons.Bloon)'></a>

## BloonsTD6Mod.PostBloonLeaked(Bloon) Method

Called right after a Bloon leaks.  
Return 'false' to prevent the leak from happening  
<br/>  
Equivalent to a HarmonyPostFix on Bloon.Leaked

```csharp
public virtual void PostBloonLeaked(Assets.Scripts.Simulation.Bloons.Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonLeaked(Assets.Scripts.Simulation.Bloons.Bloon).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostCleanProfile(Assets.Scripts.Models.Profile.ProfileModel)'></a>

## BloonsTD6Mod.PostCleanProfile(ProfileModel) Method

If you removed any data in PreCleanProfile, you may want to add it back here, or just call [OnProfileLoaded(ProfileModel)](BTD_Mod_Helper.BloonsTD6Mod.md#BTD_Mod_Helper.BloonsTD6Mod.OnProfileLoaded(Assets.Scripts.Models.Profile.ProfileModel) 'BTD_Mod_Helper.BloonsTD6Mod.OnProfileLoaded(Assets.Scripts.Models.Profile.ProfileModel)')  
again on the profile.

```csharp
public virtual void PostCleanProfile(Assets.Scripts.Models.Profile.ProfileModel profile);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostCleanProfile(Assets.Scripts.Models.Profile.ProfileModel).profile'></a>

`profile` [Assets.Scripts.Models.Profile.ProfileModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Profile.ProfileModel 'Assets.Scripts.Models.Profile.ProfileModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PreBloonLeaked(Assets.Scripts.Simulation.Bloons.Bloon)'></a>

## BloonsTD6Mod.PreBloonLeaked(Bloon) Method

Called right before a Bloon would leak.  
Return 'false' to prevent the leak from happening  
<br/>  
Equivalent to a HarmonyPreFix on Bloon.Leaked

```csharp
public virtual bool PreBloonLeaked(Assets.Scripts.Simulation.Bloons.Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.PreBloonLeaked(Assets.Scripts.Simulation.Bloons.Bloon).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PreCleanProfile(Assets.Scripts.Models.Profile.ProfileModel)'></a>

## BloonsTD6Mod.PreCleanProfile(ProfileModel) Method

Perform actions on a profile right before the Mod Helper cleans it. If you see that the Mod Helper cleans  
past profile data from your mod on startup, it should be removed here.

```csharp
public virtual void PreCleanProfile(Assets.Scripts.Models.Profile.ProfileModel profile);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.PreCleanProfile(Assets.Scripts.Models.Profile.ProfileModel).profile'></a>

`profile` [Assets.Scripts.Models.Profile.ProfileModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Profile.ProfileModel 'Assets.Scripts.Models.Profile.ProfileModel')