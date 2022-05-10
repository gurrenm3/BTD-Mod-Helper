using Assets.Scripts.Models;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Models
/// </summary>
public static partial class ModelExt
{
    /// <summary>
    /// (Cross-Game compatible) Create a new and seperate copy of this object. Same as using:  .Clone().Cast();
    /// </summary>
    /// <typeparam name="T">Type of object you want to cast to when duplicating. Done automatically</typeparam>
    public static T Duplicate<T>(this T model) where T : Model
    {
        return model.Clone().Cast<T>();
    }
        
        
        
}