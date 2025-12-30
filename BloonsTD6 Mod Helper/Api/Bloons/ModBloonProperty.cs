using System;
using System.Collections.Generic;
using System.Linq;
namespace BTD_Mod_Helper.Api.Bloons;

/// <summary>
/// Mod content class for creating <see cref="Il2Cpp.BloonProperties"/>
/// </summary>
public abstract class ModBloonProperty : ModContent
{
    /// <summary>
    /// Integer value used internally as the enum value
    /// </summary>
    public int BloonPropertyInt { get; private set; }
    
    /// <summary>
    /// Enum value for this ModBloonProperty
    /// </summary>
    public BloonProperties Property => (BloonProperties)BloonPropertyInt;

    internal static int NextBloonProperty { get; private set; } = 2 * (int) Enum.GetValues<BloonProperties>().Max();

    /// <summary>
    /// ModBloonProperties should load before ModBloons so no errors occur.
    /// </summary>
    protected override float RegistrationPriority => 5;

    /// <inheritdoc/>
    public override void Register()
    {
        BloonPropertyInt = NextBloonProperty;
        NextBloonProperty *= 2;
    }

    /// <summary>
    /// ModBloonProperties should only be loaded once
    /// </summary>
    public sealed override IEnumerable<ModContent> Load() => base.Load();
}