using System;
using System.Reflection;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Harmony stuff
/// </summary>
public static class HarmonyExt
{
    /// <summary>
    /// Add a prefix patch
    /// </summary>
    public static void PatchPrefix<TClassToPatch, TMyPatchClass>(this HarmonyLib.Harmony harmonyInstance,
        int constructorIndex, string myPatchMethod)
    {
        var classToPatch = typeof(TClassToPatch);
        var myPatchClass = typeof(TMyPatchClass);
        var constructor = classToPatch.GetConstructors()[constructorIndex];
        harmonyInstance.Patch(constructor,
            prefix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
    }

    /// <inheritdoc cref="PatchPrefix{TClassToPatch,TMyPatchClass}(HarmonyLib.Harmony,int,string)"/>
    public static void PatchPrefix(this HarmonyLib.Harmony harmonyInstance, Type classToPatch, int constructorIndex,
        Type myPatchClass, string myPatchMethod)
    {
        var constructor = classToPatch.GetConstructors()[constructorIndex];
        harmonyInstance.Patch(constructor,
            prefix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
    }

    /// <inheritdoc cref="PatchPrefix{TClassToPatch,TMyPatchClass}(HarmonyLib.Harmony,int,string)"/>
    public static void PatchPrefix<TClassToPatch, TMyPatchClass>(this HarmonyLib.Harmony harmonyInstance,
        string methodToPatch, string myPatchMethod)
    {
        var classToPatch = typeof(TClassToPatch);
        var myPatchClass = typeof(TMyPatchClass);
        var methodInfo = classToPatch.GetMethod(methodToPatch);
        harmonyInstance.Patch(methodInfo,
            prefix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
    }

    /// <inheritdoc cref="PatchPrefix{TClassToPatch,TMyPatchClass}(HarmonyLib.Harmony,int,string)"/>
    public static void PatchPrefix(this HarmonyLib.Harmony harmonyInstance, Type classToPatch, string methodToPatch,
        Type myPatchClass, string myPatchMethod)
    {
        var methodInfo = classToPatch.GetMethod(methodToPatch);
        harmonyInstance.Patch(methodInfo,
            prefix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
    }

    /// <inheritdoc cref="PatchPrefix{TClassToPatch,TMyPatchClass}(HarmonyLib.Harmony,int,string)"/>
    public static void PatchPrefix<TClassToPatch, TMyPatchClass>(this HarmonyLib.Harmony harmonyInstance,
        string methodToPatch, int methodOverloadIndex, string myPatchMethod)
    {
        var classToPatch = typeof(TClassToPatch);
        var myPatchClass = typeof(TMyPatchClass);
        var methodInfo = classToPatch.GetMethods(methodToPatch)[methodOverloadIndex];
        harmonyInstance.Patch(methodInfo,
            prefix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
    }

    /// <inheritdoc cref="PatchPrefix{TClassToPatch,TMyPatchClass}(HarmonyLib.Harmony,int,string)"/>
    public static void PatchPrefix(this HarmonyLib.Harmony harmonyInstance, Type classToPatch, string methodToPatch,
        int methodOverloadIndex, Type myPatchClass, string myPatchMethod)
    {
        var methodInfo = classToPatch.GetMethods(methodToPatch)[methodOverloadIndex];
        harmonyInstance.Patch(methodInfo,
            prefix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
    }

    /// <inheritdoc cref="PatchPrefix{TClassToPatch,TMyPatchClass}(HarmonyLib.Harmony,int,string)"/>
    public static void PatchPrefix(this HarmonyLib.Harmony harmonyInstance, MethodInfo methodToPatch,
        Type myPatchClass, string myPatchMethod)
    {
        harmonyInstance.Patch(methodToPatch,
            prefix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
    }

    /// <inheritdoc cref="PatchPrefix{TClassToPatch,TMyPatchClass}(HarmonyLib.Harmony,int,string)"/>
    public static void PatchPrefix(this HarmonyLib.Harmony harmonyInstance, MethodInfo methodToPatch,
        MethodInfo myPatchMethod)
    {
        harmonyInstance.Patch(methodToPatch, prefix: new HarmonyMethod(myPatchMethod));
    }


    /// <summary>
    /// Add a postfix patch
    /// </summary>
    public static void PatchPostfix<TClassToPatch, TMyPatchClass>(this HarmonyLib.Harmony harmonyInstance,
        int constructorIndex, string myPatchMethod)
    {
        var classToPatch = typeof(TClassToPatch);
        var myPatchClass = typeof(TMyPatchClass);
        var constructor = classToPatch.GetConstructors()[constructorIndex];
        harmonyInstance.Patch(constructor,
            postfix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
    }

    /// <inheritdoc cref="PatchPostfix{TClassToPatch,TMyPatchClass}(HarmonyLib.Harmony,int,string)"/>
    public static void PatchPostfix(this HarmonyLib.Harmony harmonyInstance, Type classToPatch,
        int constructorIndex, Type myPatchClass, string myPatchMethod)
    {
        var constructor = classToPatch.GetConstructors()[constructorIndex];
        harmonyInstance.Patch(constructor,
            postfix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
    }

    /// <inheritdoc cref="PatchPostfix{TClassToPatch,TMyPatchClass}(HarmonyLib.Harmony,int,string)"/>
    public static void PatchPostfix<TClassToPatch, TMyPatchClass>(this HarmonyLib.Harmony harmonyInstance,
        string methodToPatch, string myPatchMethod)
    {
        var classToPatch = typeof(TClassToPatch);
        var myPatchClass = typeof(TMyPatchClass);
        var methodInfo = classToPatch.GetMethod(methodToPatch);
        harmonyInstance.Patch(methodInfo,
            postfix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
    }

    /// <inheritdoc cref="PatchPostfix{TClassToPatch,TMyPatchClass}(HarmonyLib.Harmony,int,string)"/>
    public static void PatchPostfix(this HarmonyLib.Harmony harmonyInstance, Type classToPatch,
        string methodToPatch, Type myPatchClass, string myPatchMethod)
    {
        var methodInfo = classToPatch.GetMethod(methodToPatch);
        harmonyInstance.Patch(methodInfo,
            postfix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
    }

    /// <inheritdoc cref="PatchPostfix{TClassToPatch,TMyPatchClass}(HarmonyLib.Harmony,int,string)"/>
    public static void PatchPostfix<TClassToPatch, TMyPatchClass>(this HarmonyLib.Harmony harmonyInstance,
        string methodToPatch, int methodOverloadIndex, string myPatchMethod)
    {
        var classToPatch = typeof(TClassToPatch);
        var myPatchClass = typeof(TMyPatchClass);
        var methodInfo = classToPatch.GetMethods(methodToPatch)[methodOverloadIndex];
        harmonyInstance.Patch(methodInfo,
            postfix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
    }

    /// <inheritdoc cref="PatchPostfix{TClassToPatch,TMyPatchClass}(HarmonyLib.Harmony,int,string)"/>
    public static void PatchPostfix(this HarmonyLib.Harmony harmonyInstance, Type classToPatch,
        string methodToPatch, int methodOverloadIndex, Type myPatchClass, string myPatchMethod)
    {
        var methodInfo = classToPatch.GetMethods(methodToPatch)[methodOverloadIndex];
        harmonyInstance.Patch(methodInfo,
            postfix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
    }

    /// <inheritdoc cref="PatchPostfix{TClassToPatch,TMyPatchClass}(HarmonyLib.Harmony,int,string)"/>
    public static void PatchPostfix(this HarmonyLib.Harmony harmonyInstance, MethodInfo methodToPatch,
        Type myPatchClass, string myPatchMethod)
    {
        harmonyInstance.Patch(methodToPatch,
            postfix: new HarmonyMethod(AccessTools.Method(myPatchClass, myPatchMethod)));
    }

    /// <inheritdoc cref="PatchPostfix{TClassToPatch,TMyPatchClass}(HarmonyLib.Harmony,int,string)"/>
    public static void PatchPostfix(this HarmonyLib.Harmony harmonyInstance, MethodInfo methodToPatch,
        MethodInfo myPatchMethod)
    {
        harmonyInstance.Patch(methodToPatch, postfix: new HarmonyMethod(myPatchMethod));
    }
}