3.0 helps with both the creation of new menu screens as well as just creating general new UI. This guide is about custom menu screens. For general UI, see [Custom UI](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Custom-UI%2C-Menus).

## ModGameMenu

`ModGameMenu`s integrate with the default game menus more smoothly by mimicking an existing menu and editing it rather than completely starting from scratch. For example, the Mod Helper Settings screen mimics the HotKeys screen, the Mods screen mimics the Extra Settings screen, and the Mod Browser mimics the Challenge Browser. This can be helpful because sometimes you may want to reuse those existing elements, but comes with the caveat that **your custom menu can't be opened if the menu its mimicking is already open**.

### Required Properties

`<T>`: The type parameter for your `ModGameMenu<T>` class must be the existing BloonsTD6 `GameMenu` class that you're using as a base. Because of some annoying Il2Cpp method in-lining, not every screen can be easily used as a base. 

<details>
<summary>List of definitely supported `GameMenu` classes</summary>

- `ExtraSettingsScreen`
- `SettingsScreen`
- `PowersSelectScreen`
- `HotkeysScreen`
- `JukeBoxScreen`
- `CollectionEventUI`
- `AchievementsScreen`
- `PlaySocialScreen`
- `GameEventsScreen`
- `HeroInGameScreen`
- `LevelUpScreen`
- `ContentBrowser`

</details>

`OnMenuOpened()`: This method must be overriden, and it's what lets you modify/remove the elements of your base screen and add all the custom elements you want. Use the `GameMenu` property as your entry point to the Unity scene. For more information about creating UI here, see [Custom UI](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Custom-UI%2C-Menus).

### Other Properties

`OnMenuClosed()`: Override if you want to perform effects when your menu gets closed

`OnMenuUpdate()`: Override if you want to perform effects every frame that your menu is open


## Opening your Menu

To open your custom menu, use the static method `ModGameMenu.Open<YourModGameMenuType>()`.

## Example