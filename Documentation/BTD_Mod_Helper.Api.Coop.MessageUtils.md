#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Coop](README.md#BTD_Mod_Helper.Api.Coop 'BTD_Mod_Helper.Api.Coop')

## MessageUtils Class

Utility functions used for sending messages over the network.

```csharp
public class MessageUtils
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; MessageUtils
### Methods

<a name='BTD_Mod_Helper.Api.Coop.MessageUtils.CreateMessage_T_(T,string)'></a>

## MessageUtils.CreateMessage<T>(T, string) Method

Old way to send a message

```csharp
public static Message CreateMessage<T>(T objectToSend, string code="")
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Coop.MessageUtils.CreateMessage_T_(T,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.Coop.MessageUtils.CreateMessage_T_(T,string).objectToSend'></a>

`objectToSend` [T](BTD_Mod_Helper.Api.Coop.MessageUtils.md#BTD_Mod_Helper.Api.Coop.MessageUtils.CreateMessage_T_(T,string).T 'BTD_Mod_Helper.Api.Coop.MessageUtils.CreateMessage<T>(T, string).T')

<a name='BTD_Mod_Helper.Api.Coop.MessageUtils.CreateMessage_T_(T,string).code'></a>

`code` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[Il2CppNinjaKiwi.NKMulti.Message](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.Message 'Il2CppNinjaKiwi.NKMulti.Message')

<a name='BTD_Mod_Helper.Api.Coop.MessageUtils.CreateMessageEx_T_(T,string)'></a>

## MessageUtils.CreateMessageEx<T>(T, string) Method

Creates a message to be sent over the network.  
The message will be serialized as JSON.

```csharp
public static Message CreateMessageEx<T>(T objectToSend, string code="");
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Coop.MessageUtils.CreateMessageEx_T_(T,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.Coop.MessageUtils.CreateMessageEx_T_(T,string).objectToSend'></a>

`objectToSend` [T](BTD_Mod_Helper.Api.Coop.MessageUtils.md#BTD_Mod_Helper.Api.Coop.MessageUtils.CreateMessageEx_T_(T,string).T 'BTD_Mod_Helper.Api.Coop.MessageUtils.CreateMessageEx<T>(T, string).T')

The object to be sent. The object's properties will be serialized.

<a name='BTD_Mod_Helper.Api.Coop.MessageUtils.CreateMessageEx_T_(T,string).code'></a>

`code` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Unique code for your specific message.

#### Returns
[Il2CppNinjaKiwi.NKMulti.Message](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.Message 'Il2CppNinjaKiwi.NKMulti.Message')

<a name='BTD_Mod_Helper.Api.Coop.MessageUtils.ReadMessage_T_(Il2CppStructArray_byte_)'></a>

## MessageUtils.ReadMessage<T>(Il2CppStructArray<byte>) Method

Reads a message sent from the network.  
Assumes message is sent as JSON. (via [CreateMessageEx&lt;T&gt;(T, string)](BTD_Mod_Helper.Api.Coop.MessageUtils.md#BTD_Mod_Helper.Api.Coop.MessageUtils.CreateMessageEx_T_(T,string) 'BTD_Mod_Helper.Api.Coop.MessageUtils.CreateMessageEx<T>(T, string)'))

```csharp
public static T ReadMessage<T>(Il2CppStructArray<byte> serializedMessage);
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Coop.MessageUtils.ReadMessage_T_(Il2CppStructArray_byte_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.Coop.MessageUtils.ReadMessage_T_(Il2CppStructArray_byte_).serializedMessage'></a>

`serializedMessage` [Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray')

Raw bytes received from the network.

#### Returns
[T](BTD_Mod_Helper.Api.Coop.MessageUtils.md#BTD_Mod_Helper.Api.Coop.MessageUtils.ReadMessage_T_(Il2CppStructArray_byte_).T 'BTD_Mod_Helper.Api.Coop.MessageUtils.ReadMessage<T>(Il2CppStructArray<byte>).T')

<a name='BTD_Mod_Helper.Api.Coop.MessageUtils.ReadMessage_T_(Message)'></a>

## MessageUtils.ReadMessage<T>(Message) Method

Reads a message sent from the network.  
Assumes message is sent as JSON. (via [CreateMessageEx&lt;T&gt;(T, string)](BTD_Mod_Helper.Api.Coop.MessageUtils.md#BTD_Mod_Helper.Api.Coop.MessageUtils.CreateMessageEx_T_(T,string) 'BTD_Mod_Helper.Api.Coop.MessageUtils.CreateMessageEx<T>(T, string)'))

```csharp
public static T ReadMessage<T>(Message message);
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Coop.MessageUtils.ReadMessage_T_(Message).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.Coop.MessageUtils.ReadMessage_T_(Message).message'></a>

`message` [Il2CppNinjaKiwi.NKMulti.Message](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.Message 'Il2CppNinjaKiwi.NKMulti.Message')

Message received from the network.

#### Returns
[T](BTD_Mod_Helper.Api.Coop.MessageUtils.md#BTD_Mod_Helper.Api.Coop.MessageUtils.ReadMessage_T_(Message).T 'BTD_Mod_Helper.Api.Coop.MessageUtils.ReadMessage<T>(Message).T')