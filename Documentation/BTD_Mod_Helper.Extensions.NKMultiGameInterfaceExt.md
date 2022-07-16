#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## NKMultiGameInterfaceExt Class

Extensions for sending and receiving data in coop

```csharp
public static class NKMultiGameInterfaceExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; NKMultiGameInterfaceExt
### Methods

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.IsCoOpHost(thisNinjaKiwi.NKMulti.NKMultiGameInterface)'></a>

## NKMultiGameInterfaceExt.IsCoOpHost(this NKMultiGameInterface) Method

Returns true if the player is a host in a co-op game.  
Works for both lobby and in-game.

```csharp
public static bool IsCoOpHost(this NinjaKiwi.NKMulti.NKMultiGameInterface nkGi);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.IsCoOpHost(thisNinjaKiwi.NKMulti.NKMultiGameInterface).nkGi'></a>

`nkGi` [NinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.NKMultiGameInterface 'NinjaKiwi.NKMulti.NKMultiGameInterface')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,NinjaKiwi.NKMulti.Message)'></a>

## NKMultiGameInterfaceExt.ReadMessage<T>(this NKMultiGameInterface, Message) Method

Convert a Message's bytes to an object of type T

```csharp
public static T ReadMessage<T>(this NinjaKiwi.NKMulti.NKMultiGameInterface nkGI, NinjaKiwi.NKMulti.Message message);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,NinjaKiwi.NKMulti.Message).T'></a>

`T`

Type to convert bytes to
#### Parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,NinjaKiwi.NKMulti.Message).nkGI'></a>

`nkGI` [NinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.NKMultiGameInterface 'NinjaKiwi.NKMulti.NKMultiGameInterface')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,NinjaKiwi.NKMulti.Message).message'></a>

`message` [NinjaKiwi.NKMulti.Message](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.Message 'NinjaKiwi.NKMulti.Message')

Message you want to read

#### Returns
[T](BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.md#BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,NinjaKiwi.NKMulti.Message).T 'BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage<T>(this NinjaKiwi.NKMulti.NKMultiGameInterface, NinjaKiwi.NKMulti.Message).T')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,UnhollowerBaseLib.Il2CppStructArray_byte_)'></a>

## NKMultiGameInterfaceExt.ReadMessage<T>(this NKMultiGameInterface, Il2CppStructArray<byte>) Method

Convert messageBytes to an object of type T

```csharp
public static T ReadMessage<T>(this NinjaKiwi.NKMulti.NKMultiGameInterface nkGI, UnhollowerBaseLib.Il2CppStructArray<byte> messageBytes);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,UnhollowerBaseLib.Il2CppStructArray_byte_).T'></a>

`T`

Type to convert bytes to
#### Parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,UnhollowerBaseLib.Il2CppStructArray_byte_).nkGI'></a>

`nkGI` [NinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.NKMultiGameInterface 'NinjaKiwi.NKMulti.NKMultiGameInterface')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,UnhollowerBaseLib.Il2CppStructArray_byte_).messageBytes'></a>

`messageBytes` [UnhollowerBaseLib.Il2CppStructArray&lt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppStructArray-1 'UnhollowerBaseLib.Il2CppStructArray`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppStructArray-1 'UnhollowerBaseLib.Il2CppStructArray`1')

messageBytes

#### Returns
[T](BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.md#BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,UnhollowerBaseLib.Il2CppStructArray_byte_).T 'BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage<T>(this NinjaKiwi.NKMulti.NKMultiGameInterface, UnhollowerBaseLib.Il2CppStructArray<byte>).T')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage(thisNinjaKiwi.NKMulti.NKMultiGameInterface,Il2CppSystem.String,System.Nullable_byte_,string)'></a>

## NKMultiGameInterfaceExt.SendMessage(this NKMultiGameInterface, String, Nullable<byte>, string) Method

Send a string to players or a player in the lobby

```csharp
public static void SendMessage(this NinjaKiwi.NKMulti.NKMultiGameInterface nkGI, Il2CppSystem.String objectToSend, System.Nullable<byte> peerId=null, string code="");
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage(thisNinjaKiwi.NKMulti.NKMultiGameInterface,Il2CppSystem.String,System.Nullable_byte_,string).nkGI'></a>

`nkGI` [NinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.NKMultiGameInterface 'NinjaKiwi.NKMulti.NKMultiGameInterface')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage(thisNinjaKiwi.NKMulti.NKMultiGameInterface,Il2CppSystem.String,System.Nullable_byte_,string).objectToSend'></a>

`objectToSend` [Il2CppSystem.String](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.String 'Il2CppSystem.String')

string message to send. Can be JSON

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage(thisNinjaKiwi.NKMulti.NKMultiGameInterface,Il2CppSystem.String,System.Nullable_byte_,string).peerId'></a>

`peerId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The id of the peer you want the message to go to. Leave null if you want to send to all players

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage(thisNinjaKiwi.NKMulti.NKMultiGameInterface,Il2CppSystem.String,System.Nullable_byte_,string).code'></a>

`code` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Coop code used to distinguish this message from others. Like a lock and key for reading messages

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage(thisNinjaKiwi.NKMulti.NKMultiGameInterface,NinjaKiwi.NKMulti.Message)'></a>

## NKMultiGameInterfaceExt.SendMessage(this NKMultiGameInterface, Message) Method

Send a Message to all players in the lobby

```csharp
public static void SendMessage(this NinjaKiwi.NKMulti.NKMultiGameInterface nkGI, NinjaKiwi.NKMulti.Message message);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage(thisNinjaKiwi.NKMulti.NKMultiGameInterface,NinjaKiwi.NKMulti.Message).nkGI'></a>

`nkGI` [NinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.NKMultiGameInterface 'NinjaKiwi.NKMulti.NKMultiGameInterface')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage(thisNinjaKiwi.NKMulti.NKMultiGameInterface,NinjaKiwi.NKMulti.Message).message'></a>

`message` [NinjaKiwi.NKMulti.Message](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.Message 'NinjaKiwi.NKMulti.Message')

Message to send

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,T,System.Nullable_byte_,string)'></a>

## NKMultiGameInterfaceExt.SendMessage<T>(this NKMultiGameInterface, T, Nullable<byte>, string) Method

Convert an object to json and send it players or a player in the lobby

```csharp
public static void SendMessage<T>(this NinjaKiwi.NKMulti.NKMultiGameInterface nkGI, T objectToSend, System.Nullable<byte> peerId=null, string code="")
    where T : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,T,System.Nullable_byte_,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,T,System.Nullable_byte_,string).nkGI'></a>

`nkGI` [NinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.NKMultiGameInterface 'NinjaKiwi.NKMulti.NKMultiGameInterface')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,T,System.Nullable_byte_,string).objectToSend'></a>

`objectToSend` [T](BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.md#BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,T,System.Nullable_byte_,string).T 'BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage<T>(this NinjaKiwi.NKMulti.NKMultiGameInterface, T, System.Nullable<byte>, string).T')

Object you want to send. The properties of the object will be serialised as JSON.

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,T,System.Nullable_byte_,string).peerId'></a>

`peerId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The id of the peer you want the message to go to. Leave null if you want to send to all players

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,T,System.Nullable_byte_,string).code'></a>

`code` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Coop code used to distinguish this message from others. Like a lock and key for reading messages

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessageEx_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,T,System.Nullable_byte_,string)'></a>

## NKMultiGameInterfaceExt.SendMessageEx<T>(this NKMultiGameInterface, T, Nullable<byte>, string) Method

Convert an object to json and send it players or a player in the lobby

```csharp
public static void SendMessageEx<T>(this NinjaKiwi.NKMulti.NKMultiGameInterface nkGI, T objectToSend, System.Nullable<byte> peerId=null, string code="");
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessageEx_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,T,System.Nullable_byte_,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessageEx_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,T,System.Nullable_byte_,string).nkGI'></a>

`nkGI` [NinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/NinjaKiwi.NKMulti.NKMultiGameInterface 'NinjaKiwi.NKMulti.NKMultiGameInterface')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessageEx_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,T,System.Nullable_byte_,string).objectToSend'></a>

`objectToSend` [T](BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.md#BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessageEx_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,T,System.Nullable_byte_,string).T 'BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessageEx<T>(this NinjaKiwi.NKMulti.NKMultiGameInterface, T, System.Nullable<byte>, string).T')

Object you want to send. The properties of the object will be serialised as JSON.

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessageEx_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,T,System.Nullable_byte_,string).peerId'></a>

`peerId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The id of the peer you want the message to go to. Leave null if you want to send to all players

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessageEx_T_(thisNinjaKiwi.NKMulti.NKMultiGameInterface,T,System.Nullable_byte_,string).code'></a>

`code` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Coop code used to distinguish this message from others. Like a lock and key for reading messages