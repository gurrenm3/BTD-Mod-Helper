Creating your own in-game mod options is very simple. All it involves is using certain `ModSetting`(thing) classes in your Main `BloonsMod` extending class instead of regular data types, and just using them as values like normal in your code.

## All ModSettings

Any `ModSetting`(thing) class is created with a default value to use. They also all have a `displayName` that you can set, which by default will just be the name of the Field that you're assigning it to.

Also, all mod setting classes use a cool C# feature called Implicit Operators. This means that C# will be able to automatically convert them into the types they represent without you having to do anything.

But, in the couple situations where that won't work, you can always use their `GetValue()` method.

## ModSettingInt

A `ModSettingInt` represents a setting for a whole number. You can specify the `minValue` and `maxValue` if you like. 

You can also set `isSlider` to true to have the setting display as a slider instead of a text entry. If you do this, you must set the `minValue` and `maxValue` options.

## ModSettingDouble

The exact same as `ModSettingInt` but allowing for non-whole numbers like `float`s and `double`s.

## ModSettingBool

A `ModSettingBool` can just be either `true` or `false`. You can use `isButton` to make it display as a button instead of a checkbox.

## ModSettingString

A `ModSettingString` holds a string, obviously. You can use `validation` to make the input box only accept certain characters.

## Examples

```cs
public class Main : BloonsTD6Mod
{
    private static readonly ModSettingInt Cost = 500;  // implict operator in action

    private static readonly ModSettingDouble Range = new ModSettingDouble(50.0)
    {
        displayName = "Tower Range",
        minValue = 0.0,
        maxValue = 100.0,
        isSlider = true
    };

    private static readonly ModSettingBool SuperSecretSetting = false;

    private static readonly ModSettingString Message = new ModSettingString("hey")
    {
        validation = ModSettingString.Alphanumeric
    };

    /* Can just use these values like normal in the code */
}
```


