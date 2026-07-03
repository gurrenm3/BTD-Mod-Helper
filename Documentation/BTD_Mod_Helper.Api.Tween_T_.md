#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api](README.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## Tween<T> Class

Helper for performing typed animation Tweens

```csharp
public sealed class Tween<T> : BTD_Mod_Helper.Api.Tween
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Tween_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween') &#129106; Tween<T>
### Methods

<a name='BTD_Mod_Helper.Api.Tween_T_.Reverse()'></a>

## Tween<T>.Reverse() Method

Swaps the start and end values of this tween. Works if called right after Tween creation to effectively do  
"tween from the specified value back to its current value"

```csharp
public override BTD_Mod_Helper.Api.Tween Reverse();
```

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')