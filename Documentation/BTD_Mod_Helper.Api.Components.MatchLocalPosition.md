#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## MatchLocalPosition Class

Component to make this transform continuously match the scale of another transform

```csharp
public class MatchLocalPosition : UnityEngine.MonoBehaviour
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [UnhollowerBaseLib.Il2CppObjectBase](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppObjectBase 'UnhollowerBaseLib.Il2CppObjectBase') &#129106; [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object') &#129106; [UnityEngine.Object](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Object 'UnityEngine.Object') &#129106; [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component') &#129106; [UnityEngine.Behaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Behaviour 'UnityEngine.Behaviour') &#129106; [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; MatchLocalPosition
### Fields

<a name='BTD_Mod_Helper.Api.Components.MatchLocalPosition.offset'></a>

## MatchLocalPosition.offset Field

Offset from the transform to stay

```csharp
public Vector3 offset;
```

#### Field Value
[UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')

<a name='BTD_Mod_Helper.Api.Components.MatchLocalPosition.scale'></a>

## MatchLocalPosition.scale Field

Scale for the original local position

```csharp
public Vector3 scale;
```

#### Field Value
[UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')

<a name='BTD_Mod_Helper.Api.Components.MatchLocalPosition.transformToCopy'></a>

## MatchLocalPosition.transformToCopy Field

Other transform to constantly copy the scale from

```csharp
public Transform transformToCopy;
```

#### Field Value
[UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')