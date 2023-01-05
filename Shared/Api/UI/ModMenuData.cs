using System;
using Il2CppInterop.Runtime.Injection;
using Object = Il2CppSystem.Object;

namespace BTD_Mod_Helper.Api;

/// <summary>
/// Class to be passed in to the Open methods of Screens
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModMenuData : Object
{
    /// <summary>
    /// The id of the ModGameMenu this is for
    /// </summary>
    public string id;

    /// <summary>
    /// The data that the ModGameMenu receives
    /// </summary>
    public Object modData;

    /// <summary>
    /// The data that the base menu receives, if the Open code is still run
    /// </summary>
    public Object baseData;

    /// <inheritdoc />
    public ModMenuData(IntPtr ptr) : base(ptr)
    {
    }

    /// <summary>
    /// Creates a ModMenuData object with the given Id and data
    /// </summary>
    public ModMenuData(string id, Object modData, Object baseData) : base(ClassInjector
        .DerivedConstructorPointer<ModMenuData>())
    {
        ClassInjector.DerivedConstructorBody(this);
        this.id = id;
        this.modData = modData;
        this.baseData = baseData;
    }

}