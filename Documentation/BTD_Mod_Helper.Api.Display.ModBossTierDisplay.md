#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Display](README.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ModBossTierDisplay Class

A ModDisplay that will automatically apply to a ModBloon

```csharp
public abstract class ModBossTierDisplay : BTD_Mod_Helper.Api.Display.ModBloonDisplay
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay') &#129106; [ModBloonDisplay](BTD_Mod_Helper.Api.Display.ModBloonDisplay.md 'BTD_Mod_Helper.Api.Display.ModBloonDisplay') &#129106; ModBossTierDisplay

Derived  
&#8627; [ModBossTierCustomDisplay](BTD_Mod_Helper.Api.Display.ModBossTierCustomDisplay.md 'BTD_Mod_Helper.Api.Display.ModBossTierCustomDisplay')  
&#8627; [ModBossTierDisplay&lt;T&gt;](BTD_Mod_Helper.Api.Display.ModBossTierDisplay_T_.md 'BTD_Mod_Helper.Api.Display.ModBossTierDisplay<T>')
### Properties

<a name='BTD_Mod_Helper.Api.Display.ModBossTierDisplay.Bloon'></a>

## ModBossTierDisplay.Bloon Property

The ModBloon that this ModDisplay is used for

```csharp
public sealed override BTD_Mod_Helper.Api.Bloons.ModBloon Bloon { get; }
```

#### Property Value
[ModBloon](BTD_Mod_Helper.Api.Bloons.ModBloon.md 'BTD_Mod_Helper.Api.Bloons.ModBloon')

<a name='BTD_Mod_Helper.Api.Display.ModBossTierDisplay.Boss'></a>

## ModBossTierDisplay.Boss Property

The ModBloon that this ModDisplay is used for, you can get it by doing ModContent.GetInstance();

```csharp
public abstract BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss Boss { get; }
```

#### Property Value
[ModBoss](BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.md 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss')

<a name='BTD_Mod_Helper.Api.Display.ModBossTierDisplay.Tiers'></a>

## ModBossTierDisplay.Tiers Property

The tiers of the boss that this display is used for

```csharp
public abstract System.Collections.Generic.IEnumerable<int> Tiers { get; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')