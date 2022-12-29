#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperSlider Class

ModHelperComponent for a sliding input

```csharp
public class ModHelperSlider : BTD_Mod_Helper.Api.Components.ModHelperComponent
```

Inheritance [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; ModHelperSlider
### Fields

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.defaultValue'></a>

## ModHelperSlider.defaultValue Field

The Default value, not scaled to anything

```csharp
public float defaultValue;
```

#### Field Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')
### Properties

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.CurrentValue'></a>

## ModHelperSlider.CurrentValue Property

The real current value, scaled by the appropriate scale factor

```csharp
public float CurrentValue { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.DefaultNotch'></a>

## ModHelperSlider.DefaultNotch Property

The image showing where the default value is on the slider

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperImage DefaultNotch { get; }
```

#### Property Value
[ModHelperImage](BTD_Mod_Helper.Api.Components.ModHelperImage.md 'BTD_Mod_Helper.Api.Components.ModHelperImage')

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.Fill'></a>

## ModHelperSlider.Fill Property

The panel that's the filled up bar part of the slider

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperPanel Fill { get; }
```

#### Property Value
[ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel')

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.Label'></a>

## ModHelperSlider.Label Property

The text that's on the notch of the slider

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperText Label { get; }
```

#### Property Value
[ModHelperText](BTD_Mod_Helper.Api.Components.ModHelperText.md 'BTD_Mod_Helper.Api.Components.ModHelperText')

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.Slider'></a>

## ModHelperSlider.Slider Property

The actual Slider component

```csharp
public Slider Slider { get; }
```

#### Property Value
[UnityEngine.UI.Slider](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Slider 'UnityEngine.UI.Slider')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.Create(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,System.Nullable_float_)'></a>

## ModHelperSlider.Create(Info, float, float, float, float, Vector2, UnityAction<float>, float, string, Nullable<float>) Method

Creates a new ModHelperSlider

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperSlider Create(BTD_Mod_Helper.Api.Components.Info info, float defaultValue, float minValue, float maxValue, float stepSize, Vector2 handleSize, UnityAction<float> onValueChanged=null, float fontSize=42f, string labelSuffix="", System.Nullable<float> startingValue=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.Create(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,System.Nullable_float_).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: height must be a set value

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.Create(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,System.Nullable_float_).defaultValue'></a>

`defaultValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The default slider amount

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.Create(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,System.Nullable_float_).minValue'></a>

`minValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The minimum value of the slider

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.Create(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,System.Nullable_float_).maxValue'></a>

`maxValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The maximum value of the slider

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.Create(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,System.Nullable_float_).stepSize'></a>

`stepSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

What value the slider should increase by per tick

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.Create(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,System.Nullable_float_).handleSize'></a>

`handleSize` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

The height and width of the pip

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.Create(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,System.Nullable_float_).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action should happen when the slider changes value, or null

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.Create(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,System.Nullable_float_).fontSize'></a>

`fontSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The size of the label text

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.Create(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,System.Nullable_float_).labelSuffix'></a>

`labelSuffix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

String to add to the end of the label, e.g. "%"

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.Create(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,System.Nullable_float_).startingValue'></a>

`startingValue` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

If not null, the value that this should start as instead of the default

#### Returns
[ModHelperSlider](BTD_Mod_Helper.Api.Components.ModHelperSlider.md 'BTD_Mod_Helper.Api.Components.ModHelperSlider')

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.SetCurrentValue(float,bool)'></a>

## ModHelperSlider.SetCurrentValue(float, bool) Method

Sets the current value of this

```csharp
public void SetCurrentValue(float value, bool sendCallback=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.SetCurrentValue(float,bool).value'></a>

`value` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The new value

<a name='BTD_Mod_Helper.Api.Components.ModHelperSlider.SetCurrentValue(float,bool).sendCallback'></a>

`sendCallback` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether the onValueChanged listener should fire