Certain mods that generate a lot of new TowerModels or other GameModel information (e.g. such as Ultimate Crosspathing) would rather generate all taht information once, export it, and load it each time the game starts rather than generating it new each time. This is where ModByteLoaders come in. They wrap the native BloonsTD6 FlatFileCodeGen system that the game itself uses to save and load the actual GameModel.

## [ModByteLoader](/docs/BTD_Mod_Helper.Api.ModByteLoader)

Unlike every other `Mod____` class, you don't just go create ModByteLoaders from scratch. Instead, you use the [ModByteLoader.Generate](/docs/BTD_Mod_Helper.Api.ModByteLoader#modbyteloadergeneratet-string-string-method) method dynamically while your Mod is running and it will generate the file for you, along with a .bytes file for you to include in your project for it to load from.

### Arguments

`T model` The il2cpp model that you want to save. NO non-il2cpp types work here.

`string loaderFilePath` The absolute path in your file system to generate the loader .cs file to

`string bytesFilePath` The absolute path in your file system to generate the data .bytes file to

For the two path properties, it's recommended to make use of the standardized Mod Sources folder location by doing
```cs
Path.Combine(ModContent.GetInstance<YourModName>().ModSourcesPath, "Relative", "Path", "Loader.cs")
```

### Limitations

Directly importing and exporting types like lists and arrays has proved buggy. To save and load multiple things at once, Ultimate Crosspathing simply creates a dummy TowerModel object and stores all its TowerModels in the behaviors list of the dummy tower, and that works.