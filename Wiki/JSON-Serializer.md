
BTD Mod Helper contains ways to easily convert an object to a JSON string, and vice versa

# `BTD_Mod_Helper.Api.JsonSerializer`

## Serializing

### converting an Object to a JSON string

for `System.Object`
```cs
SerializeJson<T>((T objectToSerialize, bool shouldIndent = true, bool ignoreNulls = false)
```

same as above but allows you to put in a [`JsonSerializerSettings`](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonSerializerSettings.htm)
```cs
SerializeJson<T>(T objectToSerialize, JsonSerializerSettings serializerSettings, bool shouldIndent = true)
```

same as above, but this time instead of returning a string it logs it to a specified `savePath`
```cs
SaveToFile<T>(T jsonObject, string savePath, JsonSerializerSettings serializerSettings, bool shouldIndent = true, bool overwriteExisting = true)
```

for `Il2CppSystem.Object`
```cs
Il2CppSerializeJson<T>(T il2cppObject, bool shouldIndent = true)
```
does the above but instead of returning a string it logs it to a specified `savePath`
```cs
Il2CppSaveToFile<T>(T jsonObject, string savePath, bool shouldIndent = true, bool overwriteExisting = true)
```

you can also use Ninja Kiwi's own logger, using the `Assets.Scripts.Utils.FileIOUtil`.

```cs
FileIOUtil.LogToFile("filepath.json", obj);
```
(this will log it to `C:\Users\<username>\AppData\LocalLow\Ninja Kiwi\BloonsTD6`)

## Deserializing

doing the opposite of serializing, converting an JSON string to an Object

### **note: NOT GUARANTEED to work for `Il2CppSystem.Object`s that do not have a constructor or `[Serializable]` attribute**

`DeserializeJson<T>(string text)` - uses `Newtonsoft.Json` to deserialize non-Il2Cpp objects

`LoadFromFile<T>(string filePath)` - same as above, but uses a file stored locally for input instead

`Il2CppDeserializeJson<T>(string text)` - uses [Unity's JSON Deserialization thingy](https://docs.unity3d.com/Manual/JSONSerialization.html) to deserialize _some_ Il2Cpp Objects. Only official supports `MonoBehaviour` and `ScriptableObject` subclasses as well as plain structs and classes.

`Il2CppLoadFromFile<T>(string filePath)` - Il2Cpp version of `LoadFromFile`