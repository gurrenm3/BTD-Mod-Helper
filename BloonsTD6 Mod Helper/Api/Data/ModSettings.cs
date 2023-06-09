using System.Collections.Generic;
using BTD_Mod_Helper.Api.ModOptions;
namespace BTD_Mod_Helper.Api.Data;

/// <summary>
/// Another class outside of the main BloonsTD6Mod class that ModSettings can be defined in. Rules other work the same way
/// </summary>
public abstract class ModSettings : ModContent
{
    /// <inheritdoc />
    protected override float RegistrationPriority => 0;

    /// <inheritdoc />
    public override IEnumerable<ModContent> Load()
    {
        yield return this;
        ModSettingsHandler.GetModSettings(this, mod);
    }

    /// <inheritdoc />
    public sealed override void Register()
    {
    }
}