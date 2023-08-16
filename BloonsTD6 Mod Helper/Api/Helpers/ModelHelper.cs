using Il2CppAssets.Scripts.Models;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// A wrapper class around a Model
/// </summary>
public abstract class ModelHelper
{
    /// <summary>
    /// The internal model
    /// </summary>
    public abstract Model Model { get; }
}

/// <inheritdoc />
public abstract class ModelHelper<T> : ModelHelper where T : Model
{
    /// <inheritdoc />
    public override T Model { get; }

    /// <summary>
    /// Creates a wrapper around an existing model
    /// </summary>
    protected ModelHelper(T model)
    {
        Model = model;
    }
}