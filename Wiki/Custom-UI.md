---
title: Custom UI (ModHelperComponents)
---
3.0 helps with both the creation of new menu screens as well as just creating general new UI. This guide is about general UI. For creating custom menu screens, see [Custom Menus](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Custom-Menu-Screens).

For creating custom UI, it's highly recommended that you use the [UnityExplorer](https://github.com/sinai-dev/UnityExplorer/releases) mod to help whenever you have to edit the Unity objects directly.

## ModHelperComponents

`ModHelperComponent`s are custom Unity components that wrap / control base Unity components like Buttons, Scroll Panels, Dropdowns etc. Using them alongside the new `VanillaSprites` list lets you create UI elements just like default BloonsTD6 ones much more easily.

`ModHelperComponent`s can easily add other ModHelperComponents as a child using their `AddX(...)` methods like `AddPanel(...)`.

## The Info struct

All methods of creating a ModHelper Component involve creating an `Info` object for it that defines the properties of it's Unity `RectTransform` like it's positions, scale, anchor, pivot etc. To make best use of these objects, it helps to have at least a basic understanding of [Unity UI Layout](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/UIBasicLayout.html)

### Some tips about creating Info objects:
- Sometimes it'll be easier to create an `Info` struct with the C# object initialization syntax
```
new Info("Name") 
{
    Width = 500, Height = 200, Anchor = new Vector2(0, 1)
}
```
- You can use the `new Info(string name, InfoPreset preset)` constructor to use a common preset pattern like `FillParent` or `Flex` (more will be added over time)
- The `Size` property is really the "sizeDelta" field. The delta comes from the fact that the width and height values really refer to the *difference* in size between your component and the rectangle formed by `AnchorMin` and `AnchorMax`. It's just that the default for both anchors is right in the middle at (.5, .5) so expanding from that ends up being the final width and height. But, when you have an anchor set up like `FillParent`, a width and height of 0 really means "change the width and height by 0", and negative values then become margins.
- The `Pivot` property defines the point between (0, 0) and (1, 1) that scaling and rotation should happen around.