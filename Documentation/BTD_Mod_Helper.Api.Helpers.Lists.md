#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## Lists Class

Provides quick access to many major BTD6 object lists

```csharp
public class Lists
```

Inheritance [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; Lists
### Properties

<a name='BTD_Mod_Helper.Api.Helpers.Lists.AllEntities'></a>

## Lists.AllEntities Property

All Entities in the current game, or null if not in a game

```csharp
public static Entity[] AllEntities { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Entity 'Il2CppAssets.Scripts.Simulation.Objects.Entity')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Api.Helpers.Lists.AllTowers'></a>

## Lists.AllTowers Property

All towers currently placed in the game, or null if not in a game

```csharp
public static Tower[] AllTowers { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Api.Helpers.Lists.AllTTS'></a>

## Lists.AllTTS Property

All TowerToSimulation objects currently placed in the game, or null if not in a game

```csharp
public static TowerToSimulation[] AllTTS { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')