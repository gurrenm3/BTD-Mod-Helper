Things that people need to know about IL2CPP

## IL2CPP Overview

Moderns Bloons games are coded in C# (as you hopefully know at this point) yet are able to played cross-platform on Mac, IOS, Android etc despite that not being C#'s strong suit. This is accomplished by pretty much turning the C# Intermediary Language into C++, which is more compatible overall. Hence why it's called "IL2CPP".

## Why It Matters

When making a Bloons Mod, you'll notice that any Bloons methods or data structures you interact with don't actually use the same versions of standard C# objects as normal. Instead of using `System.Collections.Generic.List`, Bloons will use `Il2CppSystem.Collections.Generic.List`, which has basically all the same functionality, but is not the same thing.

Thus, you need to be careful with your imports, and be sure that you're using the version of a data structure that you think you are.

## Casting

IL2CPP Objects can't just be casted between each other using normal C# (parentheses) casting. Instead, you have to use the `.Cast<DesiredType>()` method. 

Also useful is the `.TryCast<DesiredType>()` variant, which will return null if it's an invalid cast rather than failing with an Exception.

## Reflection

If you want to do [Reflection](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/reflection) with Il2CppSystem Objects, then the main difference is that you need to use the `GetIl2CppType()` method instead of the `GetType()` method.

If you ever find yourself with an `Il2CppSystem.Object` that you know to be a primitive type like an integer, you won't be able to just (cast) or even `.Cast<>()` it. You'll have to "Unbox" it via `object.Unbox<int>()`.

Similarly, if you have a primitive type that needs to be converted to an IL2CPP object, you'll have to "Box" it by doing `new Int32 {m_value = integer}.BoxIl2CppObject();`

