The Mod Helper contains hundreds of [Extension Methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods) to various BTD classes to help make modding easier and faster. Here are the ones that are most important for you to know about.

## Dealing with Models and Behaviors

`GetBehavior<T>()` is present on nearly all Models and Behaviors, and its use is to get the first behavior of the specified type `T` within the object you're calling it from.

`GetBehaviors<T>()` is the same, but it returns all the behaviors of that type and not just the first one.

`AddBehavior()` and `RemoveBehavior()` perform pretty obvious but useful functions.

## Dealing with Custom Displays

`ApplyDisplay<T>()` is present on `TowerModel`s, `ProjectileModel`s and `DisplayModel`s and can be used to directly apply your Custom Display with type `T` to the given model.

## Arrays

see [Array Extension Methods](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Array-extension-methods)