#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper](README.md#BTD_Mod_Helper 'BTD_Mod_Helper')

## BloonsTD6Mod Class

Extend this Class instead of MelonMod to gain access to dozens of easy to use built-in hooks

```csharp
public abstract class BloonsTD6Mod : BTD_Mod_Helper.BloonsMod
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [MelonLoader.MelonBase](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonBase 'MelonLoader.MelonBase') &#129106; [MelonLoader.MelonTypeBase&lt;](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonTypeBase-1 'MelonLoader.MelonTypeBase`1')[MelonLoader.MelonMod](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonMod 'MelonLoader.MelonMod')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonTypeBase-1 'MelonLoader.MelonTypeBase`1') &#129106; [MelonLoader.MelonMod](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.MelonMod 'MelonLoader.MelonMod') &#129106; [BloonsMod](BTD_Mod_Helper.BloonsMod.md 'BTD_Mod_Helper.BloonsMod') &#129106; BloonsTD6Mod

Derived  
&#8627; [AdvancedBloonsTD6Mod](BTD_Mod_Helper.AdvancedBloonsTD6Mod.md 'BTD_Mod_Helper.AdvancedBloonsTD6Mod')
### Methods

<a name='BTD_Mod_Helper.BloonsTD6Mod.ActOnMessage(Message)'></a>

## BloonsTD6Mod.ActOnMessage(Message) Method

Acts on a Network message that's been sent to the client  
<br/>  
Use [ReadMessage&lt;T&gt;(Message)](BTD_Mod_Helper.Api.Coop.MessageUtils.md#BTD_Mod_Helper.Api.Coop.MessageUtils.ReadMessage_T_(Message) 'BTD_Mod_Helper.Api.Coop.MessageUtils.ReadMessage<T>(Message)') to read back the message you sent.  
<br/>  
If this is one of your messages and you're consuming and acting on it, return true.  
Otherwise, return false. Seriously.  
Note: Only invoked if [CheatMod](BTD_Mod_Helper.BloonsMod.md#BTD_Mod_Helper.BloonsMod.CheatMod 'BTD_Mod_Helper.BloonsMod.CheatMod') == true.

```csharp
public virtual bool ActOnMessage(Message message);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.ActOnMessage(Message).message'></a>

`message` [Il2CppNinjaKiwi.NKMulti.Message](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.Message 'Il2CppNinjaKiwi.NKMulti.Message')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAbilityCast(Ability)'></a>

## BloonsTD6Mod.OnAbilityCast(Ability) Method

Called when a ability is cast  
<br/>  
Equivalent to a HarmonyPostFix on Ability.Activate

```csharp
public virtual void OnAbilityCast(Ability ability);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAbilityCast(Ability).ability'></a>

`ability` [Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities.Ability](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities.Ability 'Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities.Ability')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAttackCreated(Attack,Entity,Model)'></a>

## BloonsTD6Mod.OnAttackCreated(Attack, Entity, Model) Method

Called right after an Attack is created  
<br/>  
Equivalent to a HarmonyPostFix on Attack.Initialise

```csharp
public virtual void OnAttackCreated(Attack attack, Entity entity, Model modelToUse);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAttackCreated(Attack,Entity,Model).attack'></a>

`attack` [Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAttackCreated(Attack,Entity,Model).entity'></a>

`entity` [Il2CppAssets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Entity 'Il2CppAssets.Scripts.Simulation.Objects.Entity')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAttackCreated(Attack,Entity,Model).modelToUse'></a>

`modelToUse` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAttackModelChanged(Attack,Model)'></a>

## BloonsTD6Mod.OnAttackModelChanged(Attack, Model) Method

Called right after a Tower's Attack is changed for any reason (creation, upgrading, etc.)  
<br/>  
Equivalent to a HarmonyPostFix on Attack.UpdatedModel

```csharp
public virtual void OnAttackModelChanged(Attack attack, Model newModel);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAttackModelChanged(Attack,Model).attack'></a>

`attack` [Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack 'Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack.Attack')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAttackModelChanged(Attack,Model).newModel'></a>

`newModel` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAudioFactoryStart(AudioFactory)'></a>

## BloonsTD6Mod.OnAudioFactoryStart(AudioFactory) Method

Called when the games audioFactory is loaded  
<br/>  
Equivalent to a HarmonyPostFix on AudioFactory_Start

```csharp
public virtual void OnAudioFactoryStart(AudioFactory audioFactory);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnAudioFactoryStart(AudioFactory).audioFactory'></a>

`audioFactory` [Il2CppAssets.Scripts.Unity.Audio.AudioFactory](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Audio.AudioFactory 'Il2CppAssets.Scripts.Unity.Audio.AudioFactory')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonCreated(Bloon)'></a>

## BloonsTD6Mod.OnBloonCreated(Bloon) Method

Called right after a Bloon is first created  
<br/>  
Equivalent to a HarmonyPostFix on Bloon.Initialise

```csharp
public virtual void OnBloonCreated(Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonCreated(Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonDestroy(Bloon)'></a>

## BloonsTD6Mod.OnBloonDestroy(Bloon) Method

Called right after a Bloon is destroyed  
<br/>  
Equivalent to a HarmonyPostFix on Bloon.OnDestroy

```csharp
public virtual void OnBloonDestroy(Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonDestroy(Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonModelUpdated(Bloon,Model)'></a>

## BloonsTD6Mod.OnBloonModelUpdated(Bloon, Model) Method

Called right after a Bloon's BloonModel is updated  
<br/>  
Equivalent to a HarmonyPostFix on Bloon.UpdatedModel

```csharp
public virtual void OnBloonModelUpdated(Bloon bloon, Model model);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonModelUpdated(Bloon,Model).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonModelUpdated(Bloon,Model).model'></a>

`model` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonPopped(Bloon)'></a>

## BloonsTD6Mod.OnBloonPopped(Bloon) Method

Called right after a Bloon is destroyed, but only when it's popped and not leaked

```csharp
public virtual void OnBloonPopped(Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnBloonPopped(Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnConnected(NKMultiGameInterface)'></a>

## BloonsTD6Mod.OnConnected(NKMultiGameInterface) Method

Executed once the user has connected to a game session.  
Note: Only invoked if [CheatMod](BTD_Mod_Helper.BloonsMod.md#BTD_Mod_Helper.BloonsMod.CheatMod 'BTD_Mod_Helper.BloonsMod.CheatMod') == true.

```csharp
public virtual void OnConnected(NKMultiGameInterface nkGi);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnConnected(NKMultiGameInterface).nkGi'></a>

`nkGi` [Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface 'Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface')

The interface used to interact with the game.

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnConnectFail(NKMultiGameInterface)'></a>

## BloonsTD6Mod.OnConnectFail(NKMultiGameInterface) Method

Executed once the user has tried to connect to a server, but failed to do so.  
Note: Only invoked if [CheatMod](BTD_Mod_Helper.BloonsMod.md#BTD_Mod_Helper.BloonsMod.CheatMod 'BTD_Mod_Helper.BloonsMod.CheatMod') == true.

```csharp
public virtual void OnConnectFail(NKMultiGameInterface nkGi);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnConnectFail(NKMultiGameInterface).nkGi'></a>

`nkGi` [Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface 'Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface')

The interface used to interact with the game.

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnDefeat()'></a>

## BloonsTD6Mod.OnDefeat() Method

Called right after a match ends in defeat  
<br/>  
Equivalent to a HarmonyPostFix on Simulation.OnDefeat

```csharp
public virtual void OnDefeat();
```

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnDisconnected(NKMultiGameInterface)'></a>

## BloonsTD6Mod.OnDisconnected(NKMultiGameInterface) Method

Executed once the player has disconnected from a server.  
Note: Only invoked if [CheatMod](BTD_Mod_Helper.BloonsMod.md#BTD_Mod_Helper.BloonsMod.CheatMod 'BTD_Mod_Helper.BloonsMod.CheatMod') == true.

```csharp
public virtual void OnDisconnected(NKMultiGameInterface nkGi);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnDisconnected(NKMultiGameInterface).nkGi'></a>

`nkGi` [Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface 'Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface')

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

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnGameDataLoaded(GameData)'></a>

## BloonsTD6Mod.OnGameDataLoaded(GameData) Method

Called when the GameData.Instance object is first loaded

```csharp
public virtual void OnGameDataLoaded(GameData gameData);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnGameDataLoaded(GameData).gameData'></a>

`gameData` [Il2CppAssets.Scripts.Data.GameData](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Data.GameData 'Il2CppAssets.Scripts.Data.GameData')

GameData.Instance

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnGameModelLoaded(GameModel)'></a>

## BloonsTD6Mod.OnGameModelLoaded(GameModel) Method

Called when Game.instance.model is not null

```csharp
public virtual void OnGameModelLoaded(GameModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnGameModelLoaded(GameModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnGameObjectsReset()'></a>

## BloonsTD6Mod.OnGameObjectsReset() Method

Called when all of the existing GameObjects within a match are destroyed

```csharp
public virtual void OnGameObjectsReset();
```

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnInGameLoaded(InGame)'></a>

## BloonsTD6Mod.OnInGameLoaded(InGame) Method

Called when InGame.instance.UnityToSimulation.Simulation is not null

```csharp
public virtual void OnInGameLoaded(InGame inGame);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnInGameLoaded(InGame).inGame'></a>

`inGame` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnMainMenu()'></a>

## BloonsTD6Mod.OnMainMenu() Method

Called when you go to the main menu screen  
<br/>  
Equivalent to a HarmonyPostFix on MainMenu.OnEnable

```csharp
public virtual void OnMainMenu();
```

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnMapModelLoaded(MapModel)'></a>

## BloonsTD6Mod.OnMapModelLoaded(MapModel) Method

Called when a map model is loaded by the game. Equivelant to MapLoader.Load.

```csharp
public virtual void OnMapModelLoaded(ref MapModel mapModel);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnMapModelLoaded(MapModel).mapModel'></a>

`mapModel` [Il2CppAssets.Scripts.Models.Map.MapModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Map.MapModel 'Il2CppAssets.Scripts.Models.Map.MapModel')

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

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnModelLoaded(Factory,string,Action_UnityDisplayNode_)'></a>

## BloonsTD6Mod.OnModelLoaded(Factory, string, Action<UnityDisplayNode>) Method

Called when a display is being loaded such as a towers 3d model  
<br/>  
Equivalent to a HarmonyPostFix on GameModel_CreatedModded

```csharp
public virtual void OnModelLoaded(Factory factory, string ModelToLoad, Action<UnityDisplayNode> action);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnModelLoaded(Factory,string,Action_UnityDisplayNode_).factory'></a>

`factory` [Il2CppAssets.Scripts.Unity.Display.Factory](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.Factory 'Il2CppAssets.Scripts.Unity.Display.Factory')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnModelLoaded(Factory,string,Action_UnityDisplayNode_).ModelToLoad'></a>

`ModelToLoad` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnModelLoaded(Factory,string,Action_UnityDisplayNode_).action'></a>

`action` [Il2CppSystem.Action](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Action 'Il2CppSystem.Action')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnNewGameModel(GameModel,List_ModModel_)'></a>

## BloonsTD6Mod.OnNewGameModel(GameModel, List<ModModel>) Method

Called when a new GameModel is created, aka when things like Monkey Knowledge are applied to towers  
<br/>  
Equivalent to a HarmonyPostFix on GameModel_CreatedModded

```csharp
public virtual void OnNewGameModel(GameModel result, List<ModModel> mods);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnNewGameModel(GameModel,List_ModModel_).result'></a>

`result` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnNewGameModel(GameModel,List_ModModel_).mods'></a>

`mods` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnNewGameModel(GameModel)'></a>

## BloonsTD6Mod.OnNewGameModel(GameModel) Method

Called when a new GameModel is created, aka when things like Monkey Knowledge are applied to towers  
<br/>  
Equivalent to a HarmonyPostFix on GameModel_CreatedModded

```csharp
public virtual void OnNewGameModel(GameModel result);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnNewGameModel(GameModel).result'></a>

`result` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnPeerConnected(NKMultiGameInterface,int)'></a>

## BloonsTD6Mod.OnPeerConnected(NKMultiGameInterface, int) Method

Executed when a new client has joined the game session.  
Note: Only invoked if [CheatMod](BTD_Mod_Helper.BloonsMod.md#BTD_Mod_Helper.BloonsMod.CheatMod 'BTD_Mod_Helper.BloonsMod.CheatMod') == true.

```csharp
public virtual void OnPeerConnected(NKMultiGameInterface nkGi, int peerId);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnPeerConnected(NKMultiGameInterface,int).nkGi'></a>

`nkGi` [Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface 'Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface')

The interface used to interact with the game.

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnPeerConnected(NKMultiGameInterface,int).peerId'></a>

`peerId` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Index of the peer in question.

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnPeerDisconnected(NKMultiGameInterface,int)'></a>

## BloonsTD6Mod.OnPeerDisconnected(NKMultiGameInterface, int) Method

Executed when a new client has left the game session.  
Note: Only invoked if [CheatMod](BTD_Mod_Helper.BloonsMod.md#BTD_Mod_Helper.BloonsMod.CheatMod 'BTD_Mod_Helper.BloonsMod.CheatMod') == true.

```csharp
public virtual void OnPeerDisconnected(NKMultiGameInterface nkGi, int peerId);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnPeerDisconnected(NKMultiGameInterface,int).nkGi'></a>

`nkGi` [Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface 'Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface')

The interface used to interact with the game.

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnPeerDisconnected(NKMultiGameInterface,int).peerId'></a>

`peerId` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Index of the peer in question.

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProfileLoaded(ProfileModel)'></a>

## BloonsTD6Mod.OnProfileLoaded(ProfileModel) Method

Called when the player's ProfileModel is loaded.  
<br/>  
Equivalent to a HarmonyPostFix on ProfileModel_Validate

```csharp
public virtual void OnProfileLoaded(ProfileModel result);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProfileLoaded(ProfileModel).result'></a>

`result` [Il2CppAssets.Scripts.Models.Profile.ProfileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Profile.ProfileModel 'Il2CppAssets.Scripts.Models.Profile.ProfileModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProjectileCreated(Projectile,Entity,Model)'></a>

## BloonsTD6Mod.OnProjectileCreated(Projectile, Entity, Model) Method

Called right after a Projectile is created  
<br/>  
Equivalent to a HarmonyPostFix on Projectile.Initialise

```csharp
public virtual void OnProjectileCreated(Projectile projectile, Entity entity, Model modelToUse);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProjectileCreated(Projectile,Entity,Model).projectile'></a>

`projectile` [Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile 'Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProjectileCreated(Projectile,Entity,Model).entity'></a>

`entity` [Il2CppAssets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Entity 'Il2CppAssets.Scripts.Simulation.Objects.Entity')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProjectileCreated(Projectile,Entity,Model).modelToUse'></a>

`modelToUse` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProjectileModelChanged(Projectile,Model)'></a>

## BloonsTD6Mod.OnProjectileModelChanged(Projectile, Model) Method

Called right after a Tower's TowerModel is changed for any reason (creation, upgrading, etc.)  
<br/>  
Equivalent to a HarmonyPostFix on Projectile.UpdatedModel

```csharp
public virtual void OnProjectileModelChanged(Projectile projectile, Model newModel);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProjectileModelChanged(Projectile,Model).projectile'></a>

`projectile` [Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile 'Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnProjectileModelChanged(Projectile,Model).newModel'></a>

`newModel` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

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

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnSpriteLoad(SpriteReference,Image)'></a>

## BloonsTD6Mod.OnSpriteLoad(SpriteReference, Image) Method

Called when a sprite is being loaded  
<br/>  
Equivalent to a HarmonyPostFix on ResourceLoader_LoadSpriteFromSpriteReferenceAsync

```csharp
public virtual void OnSpriteLoad(SpriteReference spriteref, Image image);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnSpriteLoad(SpriteReference,Image).spriteref'></a>

`spriteref` [Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnSpriteLoad(SpriteReference,Image).image'></a>

`image` [UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTitleScreen()'></a>

## BloonsTD6Mod.OnTitleScreen() Method

Called right after the game finishes loading everything  
<br/>  
Equivalent to a HarmonyPostFix on TitleScreen.Start

```csharp
public virtual void OnTitleScreen();
```

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerCreated(Tower,Entity,Model)'></a>

## BloonsTD6Mod.OnTowerCreated(Tower, Entity, Model) Method

Called right after a Tower is initialized  
<br/>  
Equivalent to a HarmonyPostFix on Tower.Initialise

```csharp
public virtual void OnTowerCreated(Tower tower, Entity target, Model modelToUse);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerCreated(Tower,Entity,Model).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerCreated(Tower,Entity,Model).target'></a>

`target` [Il2CppAssets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Entity 'Il2CppAssets.Scripts.Simulation.Objects.Entity')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerCreated(Tower,Entity,Model).modelToUse'></a>

`modelToUse` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerDeselected(Tower)'></a>

## BloonsTD6Mod.OnTowerDeselected(Tower) Method

Called right after a Tower is deselected by the player  
<br/>  
Equivalent to a HarmonyPostFix on Tower.UnHighlight

```csharp
public virtual void OnTowerDeselected(Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerDeselected(Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerDestroyed(Tower)'></a>

## BloonsTD6Mod.OnTowerDestroyed(Tower) Method

Called right after a Tower is destroyed  
<br/>  
Equivalent to a HarmonyPostFix on Tower.Destroyed

```csharp
public virtual void OnTowerDestroyed(Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerDestroyed(Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerGraphicsCreated(TowerModel,List_UnityDisplayNode_)'></a>

## BloonsTD6Mod.OnTowerGraphicsCreated(TowerModel, List<UnityDisplayNode>) Method

Called right before a Tower's 3D graphics are initialized  
<br/>  
Equivalent to a HarmonyPreFix on InputManager.CreateTowerGraphicsAsync

```csharp
public virtual void OnTowerGraphicsCreated(TowerModel towerModel, List<UnityDisplayNode> placementGraphics);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerGraphicsCreated(TowerModel,List_UnityDisplayNode_).towerModel'></a>

`towerModel` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerGraphicsCreated(TowerModel,List_UnityDisplayNode_).placementGraphics'></a>

`placementGraphics` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerInventoryInitialized(TowerInventory,List_TowerDetailsModel_)'></a>

## BloonsTD6Mod.OnTowerInventoryInitialized(TowerInventory, List<TowerDetailsModel>) Method

Called when the TowerInventory is initialized for a game

```csharp
public virtual void OnTowerInventoryInitialized(TowerInventory towerInventory, List<TowerDetailsModel> allTowersInTheGame);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerInventoryInitialized(TowerInventory,List_TowerDetailsModel_).towerInventory'></a>

`towerInventory` [Il2CppAssets.Scripts.Simulation.Input.TowerInventory](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Input.TowerInventory 'Il2CppAssets.Scripts.Simulation.Input.TowerInventory')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerInventoryInitialized(TowerInventory,List_TowerDetailsModel_).allTowersInTheGame'></a>

`allTowersInTheGame` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerLoaded(Tower,TowerSaveDataModel)'></a>

## BloonsTD6Mod.OnTowerLoaded(Tower, TowerSaveDataModel) Method

Called when you load a save file and a Tower's save data get loaded for the tower  
<br/>  
Use saveData.metaData to load custom information  
<br/>  
Equivalent to a HarmonyPostFix on Tower.SetSavedData

```csharp
public virtual void OnTowerLoaded(Tower tower, TowerSaveDataModel saveData);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerLoaded(Tower,TowerSaveDataModel).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerLoaded(Tower,TowerSaveDataModel).saveData'></a>

`saveData` [Il2CppAssets.Scripts.Models.Profile.TowerSaveDataModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Profile.TowerSaveDataModel 'Il2CppAssets.Scripts.Models.Profile.TowerSaveDataModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerModelChanged(Tower,Model)'></a>

## BloonsTD6Mod.OnTowerModelChanged(Tower, Model) Method

Called right after a Tower's TowerModel is changed for any reason (creation, upgrading, etc.)  
<br/>  
Equivalent to a HarmonyPostFix on Tower.UpdatedModel

```csharp
public virtual void OnTowerModelChanged(Tower tower, Model newModel);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerModelChanged(Tower,Model).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerModelChanged(Tower,Model).newModel'></a>

`newModel` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerSaved(Tower,TowerSaveDataModel)'></a>

## BloonsTD6Mod.OnTowerSaved(Tower, TowerSaveDataModel) Method

Called at the end of each round when a Tower's data is saved  
<br/>  
Use saveData.metaData to save custom information  
<br/>  
Equivalent to a HarmonyPostFix on Tower.GetSavedData

```csharp
public virtual void OnTowerSaved(Tower tower, TowerSaveDataModel saveData);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerSaved(Tower,TowerSaveDataModel).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerSaved(Tower,TowerSaveDataModel).saveData'></a>

`saveData` [Il2CppAssets.Scripts.Models.Profile.TowerSaveDataModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Profile.TowerSaveDataModel 'Il2CppAssets.Scripts.Models.Profile.TowerSaveDataModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerSelected(Tower)'></a>

## BloonsTD6Mod.OnTowerSelected(Tower) Method

Called right after a Tower is selected by the player  
<br/>  
Equivalent to a HarmonyPostFix on TowerSelectionMenu.Show

```csharp
public virtual void OnTowerSelected(Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerSelected(Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerSold(Tower,float)'></a>

## BloonsTD6Mod.OnTowerSold(Tower, float) Method

Called right after a Tower is sold  
<br/>  
Equivalent to a HarmonyPostFix on Tower.OnSold

```csharp
public virtual void OnTowerSold(Tower tower, float amount);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerSold(Tower,float).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerSold(Tower,float).amount'></a>

`amount` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerUpgraded(Tower,string,TowerModel)'></a>

## BloonsTD6Mod.OnTowerUpgraded(Tower, string, TowerModel) Method

Called right after a Tower is upgraded

```csharp
public virtual void OnTowerUpgraded(Tower tower, string upgradeName, TowerModel newBaseTowerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerUpgraded(Tower,string,TowerModel).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerUpgraded(Tower,string,TowerModel).upgradeName'></a>

`upgradeName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnTowerUpgraded(Tower,string,TowerModel).newBaseTowerModel'></a>

`newBaseTowerModel` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnVictory()'></a>

## BloonsTD6Mod.OnVictory() Method

Called right after a match ends in victory  
<br/>  
Equivalent to a HarmonyPostFix on InGame.OnVictory

```csharp
public virtual void OnVictory();
```

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponCreated(Weapon,Entity,Model)'></a>

## BloonsTD6Mod.OnWeaponCreated(Weapon, Entity, Model) Method

Called right after a Weapon is created  
<br/>  
Equivalent to a HarmonyPostFix on Weapon.Initialise

```csharp
public virtual void OnWeaponCreated(Weapon weapon, Entity entity, Model modelToUse);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponCreated(Weapon,Entity,Model).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon 'Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponCreated(Weapon,Entity,Model).entity'></a>

`entity` [Il2CppAssets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Entity 'Il2CppAssets.Scripts.Simulation.Objects.Entity')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponCreated(Weapon,Entity,Model).modelToUse'></a>

`modelToUse` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponFire(Weapon)'></a>

## BloonsTD6Mod.OnWeaponFire(Weapon) Method

Called when a weapon fires  
<br/>  
Equivalent to a HarmonyPostFix on Weapon.SpawnDart

```csharp
public virtual void OnWeaponFire(Weapon weapon);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponFire(Weapon).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon 'Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponModelChanged(Weapon,Model)'></a>

## BloonsTD6Mod.OnWeaponModelChanged(Weapon, Model) Method

Called right after a Tower's WeaponModel is changed for any reason (creation, upgrading, etc.)  
<br/>  
Equivalent to a HarmonyPostFix on Weapon.UpdatedModel

```csharp
public virtual void OnWeaponModelChanged(Weapon weapon, Model newModel);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponModelChanged(Weapon,Model).weapon'></a>

`weapon` [Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon 'Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.OnWeaponModelChanged(Weapon,Model).newModel'></a>

`newModel` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,bool,bool,bool)'></a>

## BloonsTD6Mod.PostBloonDamaged(Bloon, float, Projectile, bool, bool, bool, Tower, BloonProperties, bool, bool, bool) Method

Called right after a Bloon is damaged  
<br/>  
Equivalent to a HarmonyPostFix on Bloon.Damaged

```csharp
public virtual void PostBloonDamaged(Bloon bloon, float totalAmount, Projectile projectile, bool distributeToChildren, bool overrideDistributeBlocker, bool createEffect, Tower tower, BloonProperties immuneBloonProperties, bool canDestroyProjectile=true, bool ignoreNonTargetable=false, bool blockSpawnChildren=false);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,bool,bool,bool).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,bool,bool,bool).totalAmount'></a>

`totalAmount` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,bool,bool,bool).projectile'></a>

`projectile` [Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile 'Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Projectile')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,bool,bool,bool).distributeToChildren'></a>

`distributeToChildren` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,bool,bool,bool).overrideDistributeBlocker'></a>

`overrideDistributeBlocker` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,bool,bool,bool).createEffect'></a>

`createEffect` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,bool,bool,bool).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,bool,bool,bool).immuneBloonProperties'></a>

`immuneBloonProperties` [Il2Cpp.BloonProperties](https://docs.microsoft.com/en-us/dotnet/api/Il2Cpp.BloonProperties 'Il2Cpp.BloonProperties')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,bool,bool,bool).canDestroyProjectile'></a>

`canDestroyProjectile` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,bool,bool,bool).ignoreNonTargetable'></a>

`ignoreNonTargetable` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonDamaged(Bloon,float,Projectile,bool,bool,bool,Tower,BloonProperties,bool,bool,bool).blockSpawnChildren'></a>

`blockSpawnChildren` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonLeaked(Bloon)'></a>

## BloonsTD6Mod.PostBloonLeaked(Bloon) Method

Called right after a Bloon leaks.  
<br/>  
Equivalent to a HarmonyPostFix on Bloon.Leaked

```csharp
public virtual void PostBloonLeaked(Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostBloonLeaked(Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostCleanProfile(ProfileModel)'></a>

## BloonsTD6Mod.PostCleanProfile(ProfileModel) Method

If you removed any data in PreCleanProfile, you may want to add it back here, or just call [OnProfileLoaded(ProfileModel)](BTD_Mod_Helper.BloonsTD6Mod.md#BTD_Mod_Helper.BloonsTD6Mod.OnProfileLoaded(ProfileModel) 'BTD_Mod_Helper.BloonsTD6Mod.OnProfileLoaded(ProfileModel)')  
again on the profile.

```csharp
public virtual void PostCleanProfile(ProfileModel profile);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.PostCleanProfile(ProfileModel).profile'></a>

`profile` [Il2CppAssets.Scripts.Models.Profile.ProfileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Profile.ProfileModel 'Il2CppAssets.Scripts.Models.Profile.ProfileModel')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PreBloonLeaked(Bloon)'></a>

## BloonsTD6Mod.PreBloonLeaked(Bloon) Method

Called right before a Bloon would leak.  
Return 'false' to prevent the leak from happening  
<br/>  
Equivalent to a HarmonyPreFix on Bloon.Leaked

```csharp
public virtual bool PreBloonLeaked(Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.PreBloonLeaked(Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.BloonsTD6Mod.PreCleanProfile(ProfileModel)'></a>

## BloonsTD6Mod.PreCleanProfile(ProfileModel) Method

Perform actions on a profile right before the Mod Helper cleans it. If you see that the Mod Helper cleans  
past profile data from your mod on startup, it should be removed here.

```csharp
public virtual void PreCleanProfile(ProfileModel profile);
```
#### Parameters

<a name='BTD_Mod_Helper.BloonsTD6Mod.PreCleanProfile(ProfileModel).profile'></a>

`profile` [Il2CppAssets.Scripts.Models.Profile.ProfileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Profile.ProfileModel 'Il2CppAssets.Scripts.Models.Profile.ProfileModel')