Creating your own in-game mod options is very simple. All it involves is creating fields using `ModSetting`(thing) classes in your Main `BloonsMod` class instead of regular data types, and just using them as values like normal in your code.

## All ModSettings

Any `ModSetting`(thing) class is created with a default value to use. They also all have a `displayName` that you can set, which by default will just be the name of the Field that you're assigning it to.

Also, all mod setting classes use a cool C# feature called Implicit Operators. This means that C# will be able to automatically convert them into the types they represent without you having to do anything.

But, in the couple situations where that won't work, you can always use their `GetValue()` method.

**New with 3.0**, `ModSetting`s can also be given an `icon` and a `description` that will be shown. You can also specify `requiresRestart` to make it visually apparent that a setting's affect only applies after a restart.

For further customization, there's also a `modifyOption` parameter you can pass a function in to that will let you manually change the visuals, maybe with the new [custom UI](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Custom-UI%2C-Menus/_edit) features.

The `onValueChanged` field can be used to cause side effects while the setting is being edited in the menu, or `onSave` for when the value is saved upon leaving the menu. `customValidation` can be provided to prevent the saving of invalid values.

## ModSettingInt

A `ModSettingInt` represents a setting for a whole number. You can specify the `minValue` and `maxValue` if you like. 

You can also set `isSlider` to true to have the setting display as a slider instead of a text entry. If you do this, you must set the `minValue` and `maxValue` options.

## ModSettingDouble

The exact same as `ModSettingInt` but allowing for non-whole numbers like `float`s and `double`s.

## ModSettingBool

A `ModSettingBool` can just be either `true` or `false`. You can use `button` bool to make it display as an enable/disable button instead of a checkbox.

## ModSettingString

A `ModSettingString` holds a string, obviously. You can use `characterValidation` to make the input box only accept certain characters.

## ModSettingButton

A `ModSettingButton` defines an action that will be run when you press it. You can set the `buttonText` to be whatever you want.

## ModSettingEnum

A `ModSettingEnum` displays a dropdown of all the different values of an Enum type you provide it. A `labelFunction` can be provided to change how each enum name is displayed.

## ModSettingHotkey

A `ModSettingHotkey` creates a customizable hotkey. You create it with a default `KeyCode` and optionally a modifier to go with it. The methods `IsPressed()`, `JustPressed()` and `JustReleased()` can be used elsewhere in your code to check if/how the hotkey is currently being activated.

## ModSettingFile and ModSettingFolder

`ModSetting`s that let users open a Dialog Popup to select a file/folder on their computer. 

## ModSettingCategory

A special type of `ModSetting` that you can define and then sat as the `category` property of other `ModSetting`s. You can decided whether it should be `collapsed` by default or not, and can still give it a `displayName` and `icon` like all others. The `order` field can help you position the category in relation to other settings and categories.

## Examples

```cs
public class Main : BloonsTD6Mod
{
    public static readonly ModSettingInt Cost = 500;  // implict operator in action

    public static readonly ModSettingDouble Range = new(50.0)
    {
        displayName = "Tower Range",
        minValue = 0.0,
        maxValue = 100.0,
        isSlider = true
    };

    public static readonly ModSettingBool SuperSecretSetting = false;

    public static readonly ModSettingString Message = new("hey")
    {
        characterValidation = TMP_InputField.CharacterValidation.Alphanumeric
    };

    public static readonly ModSettingCategory Version3Features = new("Version 3.0 Features")
    {
        collapsed = true
    };

    public static readonly ModSettingButton PushMe = new(() => ModHelper.Msg<Main>("The button was pushed!"))
    {
        category = Version3Features,
        buttonSprite = VanillaSprites.YellowBtnLong
    };

    public static readonly ModSettingEnum<MapDifficulty> Difficulty = new(MapDifficulty.Advanced)
    {
        category = Version3Features,
        labelFunction = difficulty => difficulty.ToString().ToUpper() + "!"
    };

    public static readonly ModSettingHotkey SomethingSpecial = new(KeyCode.F4, HotkeyModifier.Alt)
    {
        category = Version3Features,
        requiresRestart = true,
        icon = VanillaSprites.DangerSoonIcon
    };

    public static readonly ModSettingFolder HomeworkFolder = new("")
    {
        category = Version3Features,
        onSave = folder => DoSomeResearch(folder)
    };

    /* Can just use these values like normal in the code */
}
```


