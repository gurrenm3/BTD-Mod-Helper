using Il2CppAssets.Scripts.Models;
namespace BTD_Mod_Helper.Api.Helpers;

public abstract class ModelHelper
{
    public abstract Model Model { get; }
}

public abstract class ModelHelper<T> : ModelHelper where T : Model
{
    public override T Model { get; }

    protected ModelHelper(T model)
    {
        Model = model;
    }
}