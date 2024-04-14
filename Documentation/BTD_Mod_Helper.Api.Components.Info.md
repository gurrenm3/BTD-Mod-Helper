#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## Info Struct

Struct used to represent the name, position and size information of a ModHelperComponent

```csharp
public readonly struct Info
```
### Constructors

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,BTD_Mod_Helper.Api.Components.InfoPreset)'></a>

## Info(string, InfoPreset) Constructor

Creates a new info struct representing the name, position and size of a ModHelperComponent

```csharp
public Info(string name, BTD_Mod_Helper.Api.Components.InfoPreset preset);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,BTD_Mod_Helper.Api.Components.InfoPreset).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of the ModHelperComponent's Unity GameObject

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,BTD_Mod_Helper.Api.Components.InfoPreset).preset'></a>

`preset` [InfoPreset](BTD_Mod_Helper.Api.Components.InfoPreset.md 'BTD_Mod_Helper.Api.Components.InfoPreset')

A preset to apply

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float,Vector2,Vector2)'></a>

## Info(string, float, float, float, float, Vector2, Vector2) Constructor

Creates a new info struct representing the name, position and size of a ModHelperComponent  
<param name="name">The name of the ModHelperComponent's Unity GameObject</param>

```csharp
public Info(string name, float x, float y, float width, float height, Vector2 anchor, Vector2 pivot);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float,Vector2,Vector2).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float,Vector2,Vector2).x'></a>

`x` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float,Vector2,Vector2).y'></a>

`y` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float,Vector2,Vector2).width'></a>

`width` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float,Vector2,Vector2).height'></a>

`height` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float,Vector2,Vector2).anchor'></a>

`anchor` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float,Vector2,Vector2).pivot'></a>

`pivot` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float,Vector2)'></a>

## Info(string, float, float, float, float, Vector2) Constructor

Creates a new info struct representing the name, position and size of a ModHelperComponent  
<param name="name">The name of the ModHelperComponent's Unity GameObject</param>

```csharp
public Info(string name, float x, float y, float width, float height, Vector2 anchor);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float,Vector2).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float,Vector2).x'></a>

`x` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float,Vector2).y'></a>

`y` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float,Vector2).width'></a>

`width` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float,Vector2).height'></a>

`height` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float,Vector2).anchor'></a>

`anchor` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float)'></a>

## Info(string, float, float, float, float) Constructor

Creates a new info struct representing the name, position and size of a ModHelperComponent  
<param name="name">The name of the ModHelperComponent's Unity GameObject</param>

```csharp
public Info(string name, float x, float y, float width, float height);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float).x'></a>

`x` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float).y'></a>

`y` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float).width'></a>

`width` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,float).height'></a>

`height` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,Vector2)'></a>

## Info(string, float, float, float, Vector2) Constructor

Creates a new info struct representing the name, position and size of a ModHelperComponent  
<param name="name">The name of the ModHelperComponent's Unity GameObject</param>

```csharp
public Info(string name, float x, float y, float size, Vector2 anchor);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,Vector2).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,Vector2).x'></a>

`x` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,Vector2).y'></a>

`y` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,Vector2).size'></a>

`size` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float,Vector2).anchor'></a>

`anchor` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float)'></a>

## Info(string, float, float, float) Constructor

Creates a new info struct representing the name, position and size of a ModHelperComponent  
<param name="name">The name of the ModHelperComponent's Unity GameObject</param>

```csharp
public Info(string name, float x, float y, float size);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float).x'></a>

`x` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float).y'></a>

`y` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,float).size'></a>

`size` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,Vector2)'></a>

## Info(string, float, float, Vector2) Constructor

Creates a new info struct representing the name, position and size of a ModHelperComponent  
<param name="name">The name of the ModHelperComponent's Unity GameObject</param>

```csharp
public Info(string name, float width, float height, Vector2 anchor);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,Vector2).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,Vector2).width'></a>

`width` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,Vector2).height'></a>

`height` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float,Vector2).anchor'></a>

`anchor` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float)'></a>

## Info(string, float, float) Constructor

Creates a new info struct representing the name, position and size of a ModHelperComponent  
<param name="name">The name of the ModHelperComponent's Unity GameObject</param>

```csharp
public Info(string name, float width, float height);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float).width'></a>

`width` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float,float).height'></a>

`height` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float)'></a>

## Info(string, float) Constructor

Creates a new info struct representing the name, position and size of a ModHelperComponent  
<param name="name">The name of the ModHelperComponent's Unity GameObject</param>

```csharp
public Info(string name, float size);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string,float).size'></a>

`size` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string)'></a>

## Info(string) Constructor

Creates a new info struct representing the name, position and size of a ModHelperComponent  
<param name="name">The name of the ModHelperComponent's Unity GameObject</param>

```csharp
public Info(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.Info.Info(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Properties

<a name='BTD_Mod_Helper.Api.Components.Info.Anchor'></a>

## Info.Anchor Property

Sets both AnchorMin and AnchorMax to the given value

```csharp
public Vector2 Anchor { set; }
```

#### Property Value
[UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Components.Info.AnchorMax'></a>

## Info.AnchorMax Property

The upper anchor. (0, 0) is the parent's lower left while (1,1) is the parent's upper right. Default (0.5, 0.5)

```csharp
public Vector2 AnchorMax { get; set; }
```

#### Property Value
[UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Components.Info.AnchorMaxX'></a>

## Info.AnchorMaxX Property

Sets the X coordinate of the AnchorMax to be the specified value, leaving the Y coordinate unchanged (0.5)

```csharp
public float AnchorMaxX { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.AnchorMaxY'></a>

## Info.AnchorMaxY Property

Sets the Y coordinate of the AnchorMax to be the specified value, leaving the X coordinate unchanged (0.5)

```csharp
public float AnchorMaxY { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.AnchorMin'></a>

## Info.AnchorMin Property

The lower anchor. (0, 0) is the parent's lower left while (1,1) is the parent's upper right. Default (0.5, 0.5)

```csharp
public Vector2 AnchorMin { get; set; }
```

#### Property Value
[UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Components.Info.AnchorMinX'></a>

## Info.AnchorMinX Property

Sets the X coordinate of the AnchorMin to be the specified value, leaving the Y coordinate unchanged (0.5)

```csharp
public float AnchorMinX { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.AnchorMinY'></a>

## Info.AnchorMinY Property

Sets the Y coordinate of the AnchorMin to be the specified value, leaving the X coordinate unchanged (0.5)

```csharp
public float AnchorMinY { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Flex'></a>

## Info.Flex Property

Sets both FlexWidth and FlexHeight to be a certain value

```csharp
public int Flex { set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Components.Info.FlexHeight'></a>

## Info.FlexHeight Property

If this is part of a layout group, then the relative flexible height of this component.

```csharp
public int FlexHeight { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Components.Info.FlexWidth'></a>

## Info.FlexWidth Property

If this is part of a layout group, then the relative flexible width of this component.

```csharp
public int FlexWidth { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Components.Info.Height'></a>

## Info.Height Property

The sizeDelta y field. This technically is how much the width should change compared to (anchorMax.x - anchorMin.x)

```csharp
public float Height { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Name'></a>

## Info.Name Property

The name of the ModHelperComponent's Unity GameObject

```csharp
public string Name { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Components.Info.Pivot'></a>

## Info.Pivot Property

The point between (0, 0) and (1, 1) that this object rotates around and expands out from, by default (0.5, 0.5)

```csharp
public Vector2 Pivot { get; set; }
```

#### Property Value
[UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Components.Info.PivotX'></a>

## Info.PivotX Property

The x component of the pivot

```csharp
public float PivotX { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.PivotY'></a>

## Info.PivotY Property

The y component of the pivot

```csharp
public float PivotY { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Position'></a>

## Info.Position Property

The localPosition field, by default relative to the parent's center unless anchors are changed

```csharp
public Vector2 Position { get; set; }
```

#### Property Value
[UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Components.Info.Scale'></a>

## Info.Scale Property

The local scale field to initialize width

```csharp
public Vector3 Scale { get; set; }
```

#### Property Value
[UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')

<a name='BTD_Mod_Helper.Api.Components.Info.Size'></a>

## Info.Size Property

Sets both the width and the height to be a certain value

```csharp
public float Size { set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.SizeDelta'></a>

## Info.SizeDelta Property

The sizeDelta field. This technically is how much the size should change compared to (anchorMax - anchorMin)

```csharp
public Vector2 SizeDelta { get; set; }
```

#### Property Value
[UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Components.Info.Width'></a>

## Info.Width Property

The sizeDelta x field. This technically is how much the width should change compared to (anchorMax.x - anchorMin.x)

```csharp
public float Width { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.X'></a>

## Info.X Property

The localPosition x field, by default relative to the parent's center unless anchors are changed

```csharp
public float X { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.Info.Y'></a>

## Info.Y Property

The localPosition y field, by default relative to the parent's center unless anchors are changed

```csharp
public float Y { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')
### Methods

<a name='BTD_Mod_Helper.Api.Components.Info.Apply(RectTransform)'></a>

## Info.Apply(RectTransform) Method

Sets the properties of the RectTransform based on this Info object

```csharp
public void Apply(RectTransform rectTransform);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.Info.Apply(RectTransform).rectTransform'></a>

`rectTransform` [UnityEngine.RectTransform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform 'UnityEngine.RectTransform')

<a name='BTD_Mod_Helper.Api.Components.Info.Duplicate(string)'></a>

## Info.Duplicate(string) Method

Creates a new Info with all the same properties as this

```csharp
public BTD_Mod_Helper.Api.Components.Info Duplicate(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.Info.Duplicate(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')