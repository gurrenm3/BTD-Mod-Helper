# Array Extension methods

## Conversion

When modding and dealing with Ninja Kiwi's code, it is often frustrating having to convert/read/edit all sorts of different Array/List-like _things_

Here are all the types of lists/arrays supported

| type of array/list                  | method                         |
| ----------------------------------- | ------------------------------ |
| `System.List<T>`                    | `.ToList<T>()`                 |
| `Il2CppSystem.List<T>`              | `.ToIl2CppList<T>()`           |
| `Assets.Scripts.Utils.LockList<T>`  | `.ToLockList<T>()`             |
| `Assets.Scripts.Utils.SizedList<T>` | `.ToSizedList<T>()`            |
| `Il2CppReferenceArray<T>`           | `.ToIl2CppReferenceArray<T>()` |

they can all be seamlessly converted to one another

e.g.

```cs
System.List<AbilityModel> list = new System.List<AbilityModel>();
Il2CppReferenceArray<AbilityModel> a = list.ToIl2CppReferenceArray<AbilityModel>();
```

## Other

The Mod helper also contains other methods for dealing with them

let `arr` denote the relevant Array/List, e.g. `LockList<BloonModel>` or `Il2CppReferenceArray<AbilityModel>`with type `TSource` or `T`, and `obj` an `Il2CppSystem.Object` of type `TCast`

remove `arr` if you are doing it like this

```cs
// e.g. instead of
var dup =RelevantExtClass.Duplicate(arr);
// do
var dup = arr.Duplicate<T>()
```

The above will be true for the rest of this page

| method                                   | explanation                                                                                       |
| ---------------------------------------- | ------------------------------------------------------------------------------------------------- |
| `AddTo<TSource, TCast>(arr, obj)`        | attempts to cast `obj` into relevant type and add it to `arr`                                     |
| `Duplicate<T>(arr)`                      | duplicates the `arr`                                                                              |
| `DuplicateAs<TSource, TCast>(arr)`       | returns a new `arr` where every item inside will be attempted to be casted to whatever `TCast` is |
| `GetItemOfType<TSource, TCast>(arr)`     | returns the first item of `arr` that can be casted to `TCast`                                     |
| `GetItemsOfType<TSource, TCast>(arr)`    | returns the every item of `arr` that can be casted to `TCast` in an `arr`                         |
| `HasItemsOfType<TSource, TCast>(arr)`    | returns whether `arr` has an object that can be casted to `TCast`                                 |
| `RemoveItem<TSource, TCast>(arr, obj)`   | returns an `arr` where one item is equal to `obj` is removed                                      |
| `RemoveItemOfType<TSource, TCast>(arr)`  | returns an `arr` where one item which can be type-casted to `TCast` is removed                    |
| `RemoveItemsOfType<TSource, TCast>(arr)` | returns an `arr` where every item which can be type-casted to `TCast` is removed                  |

# `IEnumerable`

`(System.Collections.Generic)`

The extension methods for this only allows for the following functions:

-   `Duplicate<T>(arr)`
-   `DuplicateAs<TSource, TCast>(arr)`

Conversion:

-   `.ToIl2CppList<T>()`
-   `.ToLockList<T>()`
-   `.ToIl2CppReferenceArray<T>()`

There is also an [`ArgMax<T, K>` function](https://stackoverflow.com/a/35462350)

```cs
public static T ArgMax<T, K>(this IEnumerable<T> source, Func<T, K> map, IComparer<K> comparer = null){
    //...
}
```

So you can put it simply

```cs
var itemWithMaxPropValue = collection.ArgMax(x => x.Property);
```

# `Il2CppGenericIEnumerable`

`(Il2CppSystem.Collections.Generic)`

The extension methods for this only allows for the following conversions:

-   `.ToIl2CppList<T>()`
-   `.ToList<T>()`
-   `.ToLockList<T>()`
-   `.ToIl2CppReferenceArray<T>()`

as well as other methods

| method                             | description                                                          |
| ---------------------------------- | -------------------------------------------------------------------- |
| `Count<T>(arr)`                    | Get the total number of elements                                     |
| `GetItem<T>(arr, int index)`       | Return the Item at a specific index                                  |
| `GetEnumeratorCollections<T>(arr)` | Get the `IEnumerator` as type `Il2CppSystem.Collections.IEnumerator` |

# `Il2CppGenericIEnumerator`

`(Il2CppSystem.Collections)`

eaxctly the same methods as `Il2CppGenericIEnumerable` without `GetEnumeratorCollections<T>(arr)`
