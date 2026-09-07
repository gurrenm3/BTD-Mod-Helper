---
title: Saving Persistent Data
---
**This guide assumes that you already have at least a basic knowledge of C#, and have set up a modding environment as explained on this wiki.**

Mod Helper has a system to save data that should be persistent between sessions inside of a match. There's not a very obvious way to do this, which is why this exists. There may be a few things you'd like to save between sessions, such as a currency, something related to a custom behavior you have made, etc.

# [ModSaveData](/docs/BTD_Mod_Helper.Api.ModSaveData)

This is the class you want to inherit from when you want to easily save and load data. It's very simple to create a ModSaveData class. All you need to do is override the `Save()` and `Load(string)` methods. All saved data are strings. You should use this when you want to save something not specific to a tower. Here is a basic, generic, example:

```cs
public class MySaveData : ModSaveData
{
    public override string Save()
    {
        return Some.String.Somewhere;
    }

    public override void Load(string data)
    {
        Some.String.Somewhere = data;
    }
}
```

A common way to save any data as a string is using JSON. Mod Helper comes with Newtonsoft's Json.NET. This library has an easy to use way to convert anything to JSON. The `Newtonsoft.Json.JsonConvert` static class. This class comes with a few helper methods. The main two you'll use are `SerializeObject(object?)` and `DeserializeObject<T>(string)`

Json.NET also comes with an alternative way to serialize objects to JSON, JObjects and JTokens. These are much more convuluted than using JsonConvert. If you want to save an object from IL2CPP then use Mod Helper's [Il2CppJsonConvert](/docs/BTD_Mod_Helper.Api.Internal.Il2CppJsonConvert)

Using JSON allows you to save more complicated values without needing to make your own parsers. However, **any recurssion can cause freezing or an exception to be thrown, meaning your data won't be saved or loaded.** To prevent this from happening, you'll want a custom `Newtonsoft.Json.JsonSerializerSettings`. When serializing, you want to create a new one of these with `ReferenceLoopHandling` set to `Newtonsoft.Json.ReferenceLoopHandling.Ignore`.

By default all public fields and properties are serialized. To prevent a public field/property from getting serialized give it the `Newtonsoft.Json.JsonIgnoreAttribute`. To serialize a non-public field/property give it the `Newtonsoft.Json.JsonPropertyAttribute`.

Don't worry about catching exceptions during saving and loading unless you want to do something after an exception is thrown. Mod Helper will catch any thrown exceptions for you.

Here's an example using `Newtonsoft.Json.JsonConvert` and a custom save data class.

```cs
using System.Collections.Generic;
using BTD_Mod_Helper.Api;
using Newstonsoft.Json;

public class Save
{
    // Add whatever fields you need here
    public Dictionary<string, int> CustomDictionary = [];
    public double SomeNumber = 0;
}

public class MyMod : BloonsTD6Mod
{
    // Modify SaveData somewhere in your mod.
    public static Save SaveData = new Save();

    public override void OnMatchEnd()
    {
        SaveData = new Save();
    }

    public override void OnRestart()
    {
        SaveData = new Save();
    }
}

public class MySaveData : ModSaveData
{
    public override string Save()
    {
        return JsonConvert.SerializeObject(MyMod.SaveData);
    }

    public override void Load(string data)
    {
        MyMod.Savedata = JsonConvert.DeserializeObject<Save>(data);
        // Handle applying the save here
    }
}
```

# [ModTowerSaveData](/docs/BTD_Mod_Helper.Api.ModTowerSaveData)

You want to inherit from this class every time you are saving something related to towers if each tower will have it's own thing. There are two methods you must override. `Save(Il2CppAssets.Scripts.Simulation.Towers.Tower)` and `Load(string, Il2CppAssets.Scripts.Simulation.Towers.Tower)`. There is also one property you must override, `TowerBaseId`.

If you are saving this for a [ModTower](/docs/BTD_Mod_Helper.Api.Towers.ModTower), then you can use `ModTowerSaveData<T>` where `T` is a `ModTower`. This sets `TowerBaseId` to the base id of the provided `ModTower` If you want to learn how to use ModTowers, you can do so [here.](/wiki/Making-a-Custom-Tower)

You can also optionally (and probably should) override the `ShouldSave(Il2CppAssets.Scripts.Simulation.Towers.Tower)` method. This returns a bool and tells mod helper whether or not it should save the tower. By default all it does is check if the tower's tower model base id is the same as the `TowerBaseId` property. If only towers with certain tiers, or some other condition should be saved then you should override this to change that. Do be aware that without checking the base id (`base.ShouldSave(tower)`) every tower fitting the condition you provide will be saved.

Each tower has an ObjectId. You can use this to store data for each tower easily using a dictionary. Make sure you remove the tower's object id from the dictionary when they are sold though. If you forget then you will have invalid data in your dictionary.

An example using this built off of the previous example is:

```cs
using System.Collections.Generic;
using BTD_Mod_Helper.Api;
using Newstonsoft.Json;

public class TowerSpecificSave
{
    // Add whatever poperties you need here
    public Dictionary<string, int> TowerSpecificCustomDictionary = [];
    public double SomeTowerSpecificValue = 0;
}

public class MyMod : BloonsTD6Mod
{
    // Modify this somewhere in your mod.
    public static Dictionary<ObjectId, TowerSpecificSave> SaveByTowerId = [];
    public double SomeValue = 0;

    public override void OnMatchEnd()
    {
        SaveByTowerId.Clear();
        SomeValue = 0;
    }

    public override void OnRestart()
    {
        SaveByTowerId.Clear();
        SomeValue = 0;
    }
}


public class MySaveData : ModSaveData
{
    public override string Save()
    {
        return JsonConvert.SerializeObject(MyMod.SomeValue);
    }

    public override void Load(string data)
    {
        MyMod.SomeValue = JsonConvert.DeserializeObject<double>(data);
    }
}
public class MyTowerSaveData : ModTowerSaveData<MyTower>
{
    public override bool ShouldSave(Tower tower) => base.ShouldSave(tower) && MyMod.SaveByTowerId.ContainsKey(tower.Id);

    public override string Save(Tower tower)
    {
        TowerSpecificSave save = MyMod.SaveByTowerId[tower.Id]
        return JsonConvert.SerializeObject(save);
    }

    public override void Load(string data, Tower tower)
    {
        TowerSpecificSave save = JsonConvert.DeserializeObject<TowerSpecificSave>(data);
        MyMod.SaveByTowerId[tower.Id] = save;
        // Handle applying the save here
    }
}
```

This uses an ObjectId to store the Save object we had before. When saving we get the save data using the tower's Id to search through the dictionary. When we load, we set the value with the key (the tower's Id) to the loaded save object. To make sure we don't serialize null values we override ShouldSave to also check that the dictionary containing our saves contains the key (the tower's Id)

We can't directly save the dictionary here as ObjectIds are not persistent between sessions. We also cannot save references to the towers directly as those will also be invalid upon reloading the match. This is why this must use a ModTowerSaveData instead of a standard ModSaveData.

An alternative to this are the `OnTowerSaved(Tower, TowerSaveDataModel)` and `OnTowerLoaded(Tower, TowerSaveDataModel)` hooks found in the BloonsTD6Mod class.