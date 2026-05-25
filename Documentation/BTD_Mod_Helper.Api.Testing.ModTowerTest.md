#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Testing](README.md#BTD_Mod_Helper.Api.Testing 'BTD_Mod_Helper.Api.Testing')

## ModTowerTest Class

Runs a set of default tests for a ModTower

```csharp
public class ModTowerTest : BTD_Mod_Helper.Api.Testing.ModContentDefaultTest<BTD_Mod_Helper.Api.Towers.ModTower>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModTest](BTD_Mod_Helper.Api.Testing.ModTest.md 'BTD_Mod_Helper.Api.Testing.ModTest') &#129106; [BTD_Mod_Helper.Api.Testing.ModContentDefaultTest&lt;](BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_.md 'BTD_Mod_Helper.Api.Testing.ModContentDefaultTest<T>')[ModTower](BTD_Mod_Helper.Api.Towers.ModTower.md 'BTD_Mod_Helper.Api.Towers.ModTower')[&gt;](BTD_Mod_Helper.Api.Testing.ModContentDefaultTest_T_.md 'BTD_Mod_Helper.Api.Testing.ModContentDefaultTest<T>') &#129106; ModTowerTest

Derived  
&#8627; [ModTowerTest&lt;T&gt;](BTD_Mod_Helper.Api.Testing.ModTowerTest_T_.md 'BTD_Mod_Helper.Api.Testing.ModTowerTest<T>')
### Methods

<a name='BTD_Mod_Helper.Api.Testing.ModTowerTest.PostTowerCreated(TowerToSimulation)'></a>

## ModTowerTest.PostTowerCreated(TowerToSimulation) Method

Hook for any additional testing after creating

```csharp
public virtual System.Collections.IEnumerator PostTowerCreated(TowerToSimulation tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTowerTest.PostTowerCreated(TowerToSimulation).tower'></a>

`tower` [Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation')

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Api.Testing.ModTowerTest.PostTowerUpgraded(TowerToSimulation,BTD_Mod_Helper.Api.Towers.ModUpgrade)'></a>

## ModTowerTest.PostTowerUpgraded(TowerToSimulation, ModUpgrade) Method

Hook for any additional testing after upgrading

```csharp
public virtual System.Collections.IEnumerator PostTowerUpgraded(TowerToSimulation tower, BTD_Mod_Helper.Api.Towers.ModUpgrade modUpgrade);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Testing.ModTowerTest.PostTowerUpgraded(TowerToSimulation,BTD_Mod_Helper.Api.Towers.ModUpgrade).tower'></a>

`tower` [Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.TowerToSimulation')

<a name='BTD_Mod_Helper.Api.Testing.ModTowerTest.PostTowerUpgraded(TowerToSimulation,BTD_Mod_Helper.Api.Towers.ModUpgrade).modUpgrade'></a>

`modUpgrade` [ModUpgrade](BTD_Mod_Helper.Api.Towers.ModUpgrade.md 'BTD_Mod_Helper.Api.Towers.ModUpgrade')

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Api.Testing.ModTowerTest.Test()'></a>

## ModTowerTest.Test() Method

Primary test coroutine

```csharp
public override System.Collections.IEnumerator Test();
```

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')