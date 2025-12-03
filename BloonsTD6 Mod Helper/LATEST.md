## NOTE: As of this release, BTD6 still needs the latest NIGHTLY build of MelonLoader. 0.7.0 or 0.7.1 will not work. [See the Install Guide](https://gurrenm3.github.io/BTD-Mod-Helper/wiki/Install-Guide)

<!--Mod Browser Message Start-->

- Initial fixes for BTD6 v52
- Added support for using .ogg files for audio
  - btd6.targets will now automatically mark .ogg files as Embedded Resources
- Fixed issue where custom sounds could stop being available via PrefabReference from the AudioFactory after quitting a match
- Added better support for ModGameModes using and modifying `DailyChallengeModel`s for games
  - Override `ApplyChallengeRules` to true to make normal games have challenge rules (since they otherwise don't)
  - Override `ModifyChallengeRules(DailyChallengeModel)` to edit challenge rules
- Added the ability to register sound GUIDs that will correspond to a different random sound from a list each time they're played, for example to make "CustomSound" choose from any of CustomSound1.mp3, CustomSound2.mp3 or CustomSound3.mp3 in your mod you can do

```csharp
public override void OnTitleScreen()
{
    RegisterRandomizedAudioClip("CustomSound", "CustomSound1", "CustomSound2", "CustomSound3");
}

...
  
GetAudioClipReference<MyMod>("CustomSound")
```
- Using the new C# 14 static extensions feature, added new static .Create() methods for many Models. These have the benefit of not breaking if the constructor for the model gets changed by an update
```csharp
new DamageModel("", 2, 0, true, false, false, Lead | Frozen, Lead | Frozen, false, false)
// ... now can instead do
DamageModel.Create(new()
{
    damage = 2, distributeToChildren = true, immuneBloonProperties = Lead | Frozen, immuneBloonPropertiesOriginal = Lead | Frozen
}),
```