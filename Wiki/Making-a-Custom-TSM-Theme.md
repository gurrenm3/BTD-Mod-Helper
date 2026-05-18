**This guide assumes that you already have at least a basic knowledge of C#, and have set up a modding environment as explained on this wiki.**

The Tower Selection Menu (TSM) Theme is the part of the tower selection menu that controls custom buttons in the top section around the tower's portrait, such as the "Camo" theme for adding the Camo Prioritization button.

A custom TSM Theme lets you add a new variant of that menu for your towers to use, or modify an existing vanilla theme to add/change elements on it.

# [ModTsmTheme](/docs/BTD_Mod_Helper.Api.Towers.ModTsmTheme)

Use this when you want to create a brand-new theme that a tower can opt into by setting its `TowerModel.towerSelectionMenuThemeId` to the Id of your `ModTsmTheme`.

```cs
public override void ModifyBaseTowerModel(TowerModel towerModel)
{
    towerModel.towerSelectionMenuThemeId = ModContent.GetId<MyModTsmTheme>();
}
```

## Common Overrides

`BaseTheme`: The Id of the vanilla TSM Theme that yours will be cloned from. Defaults to `"Default"` (the regular `TSMThemeDefault` used by most towers). Other useful values include `"Camo"`, `"SelectPointInput"`, `"ActionButton"`, etc. Check vanilla TowerModels for more types.

## Required Methods

`SetupTheme(BaseTSMTheme theme)`: Called once the first time the theme is shown, usually the first time a tower using it is selected. This is where you'll do any one-time setup of buttons, images, or other UI elements on the theme. You can use the `AddTSMButton` extension method to add `TSMButton`s, and the `LeftArrowX` / `RightArrowX` / `AboveArrowsY` / `DefaultButtonSize` / `DefaultIconSize` / `DefaultButtonSpacing` constants on `ModBaseTsmTheme` to keep your placements consistent with vanilla.

## Optional Methods

`TowerChanged(BaseTSMTheme theme, TowerToSimulation tower)`: Called whenever the selected tower changes, or that tower's info is updated (e.g. after an upgrade). Use this to refresh anything on the theme that depends on the tower's current state.

`OnButtonPressed(BaseTSMTheme theme, TowerToSimulation tower, string buttonId)`: Called when a `TSMButton` on this theme is pressed. The `buttonId` matches the one you passed to `AddTSMButton`.

`OnEnable` / `OnDisable` / `Update` / `OnDestroy`: Hooks for the corresponding Unity lifecycle events on the theme component, in case you need them.

## Example

A custom theme that adds a single button above the target arrows, which prints a message when pressed.

```cs
public class MyModTsmTheme : ModTsmTheme
{
    public override string BaseTheme => "Default";

    public override void SetupTheme(BaseTSMTheme theme)
    {
        theme.gameObject.AddTSMButton(
            new Info("MyButton", RightArrowX, AboveArrowsY, DefaultButtonSize),
            VanillaSprites.GreenBtnSquare,
            "MyButtonId"
        );
    }

    public override void OnButtonPressed(BaseTSMTheme theme, TowerToSimulation tower, string buttonId)
    {
        if (buttonId == "MyButtonId")
        {
            ModHelper.Msg<MyMod>($"Pressed my button on tower {tower.Def.name}!");
        }
    }
}
```

Then on your `ModTower`:

```cs
public override void ModifyBaseTowerModel(TowerModel towerModel)
{
    towerModel.towerSelectionMenuThemeId = ModContent.GetId<MyModTsmTheme>();
}
```

# [ModVanillaTsmTheme](/docs/BTD_Mod_Helper.Api.Towers.ModVanillaTsmTheme)

Use this when you want to modify one or more *existing* themes rather than creating a new one. The same `SetupTheme` / `TowerChanged` / `OnButtonPressed` / lifecycle methods are available; the difference is that they will run on the vanilla theme(s) you target.

## Required Methods

`SetupTheme(BaseTSMTheme theme)`: Same as `ModTsmTheme`. Note that this runs once per vanilla theme that you apply to, so any buttons or modifications you add will live on that vanilla theme.

## Common Overrides

`AppliesTo(string themeId)`: Decides which existing themes your changes apply to. Defaults to applying to every theme, so you'll usually want to override this to target a specific theme (or set of themes) by Id.

# Pairing with a Custom Input

A common use case for a TSM Button is to put the player into a custom cursor. The `AddTSMButton` extension method has an optional `customInputId` parameter for exactly this; pass the Id of a [ModCustomInput](/wiki/Making-a-Custom-Input) and pressing the button will automatically activate it with the current tower attached.

```cs
public override void SetupTheme(BaseTSMTheme theme)
{
    theme.gameObject.AddTSMButton(
        new("MyButton", RightArrowX, AboveArrowsY, DefaultButtonSize),
        VanillaSprites.GreenBtnSquare,
        "MyButton",
        GetId<MyCustomInput>()
    );
}
```

When the custom input is active, your TSM Theme's `Update` method still fires, so it's a convenient place to draw previews/indicators that respond to where the player is hovering. Check `ModCustomInput.ActiveInput is MyCustomInput` to tell whether your input is the one currently being used.

# Tips

- Use the constants on `ModBaseTsmTheme` (`LeftArrowX`, `RightArrowX`, `AboveArrowsY`, `DefaultButtonSize`, `DefaultIconSize`, `DefaultButtonSpacing`) when positioning/sizing your buttons so they line up with vanilla UI.
- `AddTSMButton(this GameObject, Info, string sprite, string buttonId, string customInputId = null)` is the easiest way to attach a new `TSMButton`. The `buttonId` you pass here is what gets routed back to your `OnButtonPressed` method.
- A fresh copy of your `ModBaseTsmTheme` is made for each theme instance internally, so it's safe to cache state on `this` (e.g. references to buttons you've created) inside `SetupTheme` and read it back in `TowerChanged` / `OnButtonPressed`.
