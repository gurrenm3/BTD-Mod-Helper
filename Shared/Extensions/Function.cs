using System;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// 
/// </summary>
public delegate void Function();
    
/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public delegate T Function<out T>();
    
//public delegate void Function<T>(T t);


/// <summary>
/// Extensions for Functions
/// </summary>
public static class FunctionExt
{
    /// <summary>
    /// Convert a function to an action
    /// </summary>
    public static Action ToAction(this Function func)
    {
        return () => func();
    }
        
    /// <summary>
    /// Convert a function to an action
    /// </summary>
    public static Action<T> ToAction<T>(this Function<T> func)
    {
        return t => func();
    }
}