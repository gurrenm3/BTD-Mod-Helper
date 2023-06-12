using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
namespace BTD_Mod_Helper.Api.Display;

/// <summary>
/// Class used internally to represent displays for <see cref="ModTower" />s using <see cref="ModTower.Use2DModel" />
/// and <see cref="ModBloon" />s using <see cref="ModBloon.UseIconAsDisplay" />
/// </summary>
internal sealed class ModDisplay2DImpl : ModDisplay2D
{

    /// <summary>
    /// Creates a new Mod
    /// </summary>
    /// <param name="bloonsMod">The mod this is for</param>
    /// <param name="id">Id for the display to use</param>
    /// <param name="textureName">Texture name, not a guid</param>
    /// <param name="scale">Scale to use</param>
    /// <param name="baseDisplay"></param>
    /// <param name="displayCategory"></param>
    public ModDisplay2DImpl(BloonsMod bloonsMod, string id, string textureName, float scale = 10f,
        string baseDisplay = Generic2dDisplay, DisplayCategory displayCategory = DisplayCategory.Default)
    {
        mod = bloonsMod;
        ID = id;
        TextureName = textureName;
        Scale = scale;
        BaseDisplay = baseDisplay;
        DisplayCategory = displayCategory;

        Register();
    }

    public override string BaseDisplay { get; }

    public override DisplayCategory DisplayCategory { get; }

    private protected override string ID { get; }
    protected override string TextureName { get; }

    public override float Scale { get; }
}