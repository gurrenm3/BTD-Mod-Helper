#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## NKMultiGameInterfaceExt Class

Extensions for sending and receiving data in coop

```csharp
public static class NKMultiGameInterfaceExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; NKMultiGameInterfaceExt
### Methods

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.IsCoOpHost(thisNKMultiGameInterface)'></a>

## NKMultiGameInterfaceExt.IsCoOpHost(this NKMultiGameInterface) Method

Returns true if the player is a host in a co-op game.  
Works for both lobby and in-game.

```csharp
public static bool IsCoOpHost(this NKMultiGameInterface nkGi);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.IsCoOpHost(thisNKMultiGameInterface).nkGi'></a>

`nkGi` [Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface 'Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNKMultiGameInterface,Il2CppStructArray_byte_)'></a>

## NKMultiGameInterfaceExt.ReadMessage<T>(this NKMultiGameInterface, Il2CppStructArray<byte>) Method

Convert messageBytes to an object of type T

```csharp
public static T ReadMessage<T>(this NKMultiGameInterface nkGI, Il2CppStructArray<byte> messageBytes);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNKMultiGameInterface,Il2CppStructArray_byte_).T'></a>

`T`

Type to convert bytes to
#### Parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNKMultiGameInterface,Il2CppStructArray_byte_).nkGI'></a>

`nkGI` [Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface 'Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNKMultiGameInterface,Il2CppStructArray_byte_).messageBytes'></a>

`messageBytes` [Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray')

messageBytes

#### Returns
[T](BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.md#BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNKMultiGameInterface,Il2CppStructArray_byte_).T 'BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage<T>(this NKMultiGameInterface, Il2CppStructArray<byte>).T')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNKMultiGameInterface,Message)'></a>

## NKMultiGameInterfaceExt.ReadMessage<T>(this NKMultiGameInterface, Message) Method

Convert a Message's bytes to an object of type T

```csharp
public static T ReadMessage<T>(this NKMultiGameInterface nkGI, Message message);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNKMultiGameInterface,Message).T'></a>

`T`

Type to convert bytes to
#### Parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNKMultiGameInterface,Message).nkGI'></a>

`nkGI` [Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface 'Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNKMultiGameInterface,Message).message'></a>

`message` [Il2CppNinjaKiwi.NKMulti.Message](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.Message 'Il2CppNinjaKiwi.NKMulti.Message')

Message you want to read

#### Returns
[T](BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.md#BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage_T_(thisNKMultiGameInterface,Message).T 'BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.ReadMessage<T>(this NKMultiGameInterface, Message).T')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage(thisNKMultiGameInterface,Message)'></a>

## NKMultiGameInterfaceExt.SendMessage(this NKMultiGameInterface, Message) Method

Send a Message to all players in the lobby

```csharp
public static void SendMessage(this NKMultiGameInterface nkGI, Message message);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage(thisNKMultiGameInterface,Message).nkGI'></a>

`nkGI` [Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface 'Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage(thisNKMultiGameInterface,Message).message'></a>

`message` [Il2CppNinjaKiwi.NKMulti.Message](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.Message 'Il2CppNinjaKiwi.NKMulti.Message')

Message to send

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage(thisNKMultiGameInterface,String,System.Nullable_byte_,string)'></a>

## NKMultiGameInterfaceExt.SendMessage(this NKMultiGameInterface, String, Nullable<byte>, string) Method

Send a string to players or a player in the lobby

```csharp
public static void SendMessage(this NKMultiGameInterface nkGI, String objectToSend, System.Nullable<byte> peerId=null, string code="");
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage(thisNKMultiGameInterface,String,System.Nullable_byte_,string).nkGI'></a>

`nkGI` [Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface 'Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage(thisNKMultiGameInterface,String,System.Nullable_byte_,string).objectToSend'></a>

`objectToSend` [Il2CppSystem.String](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.String 'Il2CppSystem.String')

string message to send. Can be JSON

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage(thisNKMultiGameInterface,String,System.Nullable_byte_,string).peerId'></a>

`peerId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The id of the peer you want the message to go to. Leave null if you want to send to all players

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage(thisNKMultiGameInterface,String,System.Nullable_byte_,string).code'></a>

`code` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Coop code used to distinguish this message from others. Like a lock and key for reading messages

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage_T_(thisNKMultiGameInterface,T,System.Nullable_byte_,string)'></a>

## NKMultiGameInterfaceExt.SendMessage<T>(this NKMultiGameInterface, T, Nullable<byte>, string) Method

Convert an object to json and send it players or a player in the lobby

```csharp
public static void SendMessage<T>(this NKMultiGameInterface nkGI, T objectToSend, System.Nullable<byte> peerId=null, string code="")
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage_T_(thisNKMultiGameInterface,T,System.Nullable_byte_,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage_T_(thisNKMultiGameInterface,T,System.Nullable_byte_,string).nkGI'></a>

`nkGI` [Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface 'Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage_T_(thisNKMultiGameInterface,T,System.Nullable_byte_,string).objectToSend'></a>

`objectToSend` [T](BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.md#BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage_T_(thisNKMultiGameInterface,T,System.Nullable_byte_,string).T 'BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage<T>(this NKMultiGameInterface, T, System.Nullable<byte>, string).T')

Object you want to send. The properties of the object will be serialised as JSON.

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage_T_(thisNKMultiGameInterface,T,System.Nullable_byte_,string).peerId'></a>

`peerId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The id of the peer you want the message to go to. Leave null if you want to send to all players

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessage_T_(thisNKMultiGameInterface,T,System.Nullable_byte_,string).code'></a>

`code` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Coop code used to distinguish this message from others. Like a lock and key for reading messages

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessageEx_T_(thisNKMultiGameInterface,T,System.Nullable_byte_,string)'></a>

## NKMultiGameInterfaceExt.SendMessageEx<T>(this NKMultiGameInterface, T, Nullable<byte>, string) Method

Convert an object to json and send it players or a player in the lobby

```csharp
public static void SendMessageEx<T>(this NKMultiGameInterface nkGI, T objectToSend, System.Nullable<byte> peerId=null, string code="");
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessageEx_T_(thisNKMultiGameInterface,T,System.Nullable_byte_,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessageEx_T_(thisNKMultiGameInterface,T,System.Nullable_byte_,string).nkGI'></a>

`nkGI` [Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface 'Il2CppNinjaKiwi.NKMulti.NKMultiGameInterface')

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessageEx_T_(thisNKMultiGameInterface,T,System.Nullable_byte_,string).objectToSend'></a>

`objectToSend` [T](BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.md#BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessageEx_T_(thisNKMultiGameInterface,T,System.Nullable_byte_,string).T 'BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessageEx<T>(this NKMultiGameInterface, T, System.Nullable<byte>, string).T')

Object you want to send. The properties of the object will be serialised as JSON.

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessageEx_T_(thisNKMultiGameInterface,T,System.Nullable_byte_,string).peerId'></a>

`peerId` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The id of the peer you want the message to go to. Leave null if you want to send to all players

<a name='BTD_Mod_Helper.Extensions.NKMultiGameInterfaceExt.SendMessageEx_T_(thisNKMultiGameInterface,T,System.Nullable_byte_,string).code'></a>

`code` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Coop code used to distinguish this message from others. Like a lock and key for reading messages