#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.Components](index.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components').[Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

## Info.Preset Enum

Specific common preset setups of Info structs

```csharp
public enum Info.Preset
```
### Fields

<a name='BTD_Mod_Helper.Api.Components.Info.Preset.FillParent'></a>

`FillParent` 0

Will fill its parent component by matching its top left and bottom right with the parent's  
<br/>  
Equivalent to  
  
```csharp  
{  
    AnchorMin = new Vector2(0, 0),  
    AnchorMax = new Vector2(1, 1)  
}  
```  
Set alongside negative width/height to add padding around the edges, or positive to expand beyond

<a name='BTD_Mod_Helper.Api.Components.Info.Preset.Flex'></a>

`Flex` 1

Will fully flex horizontally and vertically,  
<br/>  
Equivalent to  
  
```csharp  
{  
    FlexWidth = 1,  
    FlexHeight = 1  
}  
```