namespace BTD_Mod_Helper.Api.Data;

/// <summary>
/// Another class outside of the main BloonsTD6Mod class that ModSettings can be defined in. Rules otherwise work the same
/// way
/// </summary>
public abstract class ModSettings : ModContent, IModSettings
{
    /// <inheritdoc />
    protected override float RegistrationPriority => 0;

    /// <inheritdoc />
    public sealed override void Register()
    {
    }
}