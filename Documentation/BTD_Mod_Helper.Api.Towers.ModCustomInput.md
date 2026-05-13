#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModCustomInput Class

ModContent for defining Custom Input that can be used in Tower Selection Menu Themes or via  
  
```csharp  
inputManager.PrimeCustomInput(ModContent.GetInstance<ModCustomInput>().Activate(inputManager));  
```

```csharp
public abstract class ModCustomInput : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; ModCustomInput
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.ActiveInput'></a>

## ModCustomInput.ActiveInput Property

The currently active Modded Custom Input, null if none are active

```csharp
public static BTD_Mod_Helper.Api.Towers.ModCustomInput ActiveInput { get; set; }
```

#### Property Value
[ModCustomInput](BTD_Mod_Helper.Api.Towers.ModCustomInput.md 'BTD_Mod_Helper.Api.Towers.ModCustomInput')
### Methods

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.Activate(InputManager,TowerToSimulation,string)'></a>

## ModCustomInput.Activate(InputManager, TowerToSimulation, string) Method

Activates this Custom Input and returns the CustomInput that can be passed to [Il2CppAssets.Scripts.Unity.UI_New.InGame.InputManager.PrimeCustomInput(Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput)](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InputManager.PrimeCustomInput#Il2CppAssets_Scripts_Unity_UI_New_InGame_InputManager_PrimeCustomInput_Il2CppAssets_Scripts_Unity_UI_New_InGame_CustomInput_ 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InputManager.PrimeCustomInput(Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput)') or other places

```csharp
public CustomInput Activate(InputManager inputManager, TowerToSimulation tower=null, string buttonId=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.Activate(InputManager,TowerToSimulation,string).inputManager'></a>

`inputManager` [Il2CppAssets.Scripts.Unity.UI_New.InGame.InputManager](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.InputManager 'Il2CppAssets.Scripts.Unity.UI_New.InGame.InputManager')

InputManager

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.Activate(InputManager,TowerToSimulation,string).tower'></a>

`tower` [Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation')

tower, if relevant

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.Activate(InputManager,TowerToSimulation,string).buttonId'></a>

`buttonId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

tsm buttonId, if relevant

#### Returns
[Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput 'Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput')  
CustomInput object

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.Deactivate(CustomInput)'></a>

## ModCustomInput.Deactivate(CustomInput) Method

Deactivates the specified CustomInput

```csharp
public static void Deactivate(CustomInput customInput);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.Deactivate(CustomInput).customInput'></a>

`customInput` [Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput 'Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput')

CustomInput

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.EnterInputMode(CustomInput)'></a>

## ModCustomInput.EnterInputMode(CustomInput) Method

<seealso cref="M:Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput.EnterInputMode"/>

```csharp
public virtual void EnterInputMode(CustomInput customInput);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.EnterInputMode(CustomInput).customInput'></a>

`customInput` [Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput 'Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput')

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.ExitInputMode(CustomInput)'></a>

## ModCustomInput.ExitInputMode(CustomInput) Method

<seealso cref="M:Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput.ExitInputMode"/>

```csharp
public virtual void ExitInputMode(CustomInput customInput);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.ExitInputMode(CustomInput).customInput'></a>

`customInput` [Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput 'Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput')

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.GetCantActivateMessage(CustomInput)'></a>

## ModCustomInput.GetCantActivateMessage(CustomInput) Method

<seealso cref="M:Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput.GetCantActivateMessage"/>

```csharp
public virtual string GetCantActivateMessage(CustomInput customInput);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.GetCantActivateMessage(CustomInput).customInput'></a>

`customInput` [Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput 'Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.GetHelperMessage(CustomInput)'></a>

## ModCustomInput.GetHelperMessage(CustomInput) Method

<seealso cref="M:Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput.GetHelperMessage"/>

```csharp
public virtual string GetHelperMessage(CustomInput customInput);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.GetHelperMessage(CustomInput).customInput'></a>

`customInput` [Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput 'Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.IsPositionValid(CustomInput,Vector2,bool)'></a>

## ModCustomInput.IsPositionValid(CustomInput, Vector2, bool) Method

<seealso cref="M:Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput.IsPositionValid(UnityEngine.Vector2,System.Boolean)"/>

```csharp
public virtual bool IsPositionValid(CustomInput customInput, Vector2 cursorPosWorld, bool isCursorInWorld);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.IsPositionValid(CustomInput,Vector2,bool).customInput'></a>

`customInput` [Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput 'Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput')

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.IsPositionValid(CustomInput,Vector2,bool).cursorPosWorld'></a>

`cursorPosWorld` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.IsPositionValid(CustomInput,Vector2,bool).isCursorInWorld'></a>

`isCursorInWorld` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.OnInvalidPositionCursorUp(CustomInput,Vector2,bool)'></a>

## ModCustomInput.OnInvalidPositionCursorUp(CustomInput, Vector2, bool) Method

<seealso cref="M:Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput.OnInvalidPositionCursorUp(UnityEngine.Vector2,System.Boolean)"/>

```csharp
public virtual void OnInvalidPositionCursorUp(CustomInput customInput, Vector2 cursorPosWorld, bool isCursorInWorld);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.OnInvalidPositionCursorUp(CustomInput,Vector2,bool).customInput'></a>

`customInput` [Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput 'Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput')

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.OnInvalidPositionCursorUp(CustomInput,Vector2,bool).cursorPosWorld'></a>

`cursorPosWorld` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.OnInvalidPositionCursorUp(CustomInput,Vector2,bool).isCursorInWorld'></a>

`isCursorInWorld` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.OnValidPositionCursorUp(CustomInput,Vector2,bool)'></a>

## ModCustomInput.OnValidPositionCursorUp(CustomInput, Vector2, bool) Method

<seealso cref="M:Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput.OnValidPositionCursorUp(UnityEngine.Vector2,System.Boolean)"/>

```csharp
public virtual void OnValidPositionCursorUp(CustomInput customInput, Vector2 cursorPosWorld, bool isCursorInWorld);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.OnValidPositionCursorUp(CustomInput,Vector2,bool).customInput'></a>

`customInput` [Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput 'Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput')

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.OnValidPositionCursorUp(CustomInput,Vector2,bool).cursorPosWorld'></a>

`cursorPosWorld` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.OnValidPositionCursorUp(CustomInput,Vector2,bool).isCursorInWorld'></a>

`isCursorInWorld` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.Update(CustomInput,Vector3,Vector2,bool)'></a>

## ModCustomInput.Update(CustomInput, Vector3, Vector2, bool) Method

<seealso cref="M:Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput.Update(UnityEngine.Vector3,UnityEngine.Vector2,System.Boolean)"/>

```csharp
public virtual void Update(CustomInput customInput, Vector3 cursorPosUnityWorld, Vector2 cursorPosWorld, bool isCursorActive);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.Update(CustomInput,Vector3,Vector2,bool).customInput'></a>

`customInput` [Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput 'Il2CppAssets.Scripts.Unity.UI_New.InGame.CustomInput')

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.Update(CustomInput,Vector3,Vector2,bool).cursorPosUnityWorld'></a>

`cursorPosUnityWorld` [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.Update(CustomInput,Vector3,Vector2,bool).cursorPosWorld'></a>

`cursorPosWorld` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Towers.ModCustomInput.Update(CustomInput,Vector3,Vector2,bool).isCursorActive'></a>

`isCursorActive` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')