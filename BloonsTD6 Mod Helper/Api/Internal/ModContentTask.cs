using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BTD_Mod_Helper.Api.Attributes;
namespace BTD_Mod_Helper.Api.Internal;

/// <summary>
/// Initial task to register ModContent from other mods
/// </summary>
[DontLoad]
internal class ModContentTask : ModLoadTask
{
    private float? total;

    /// <inheritdoc />
    public override string DisplayName => $"Registering ModContent for {mod.Info.Name}...";

    public override bool ShowProgressBar => Total > 5;

    public float Total => total ??= mod.Content.Sum(content => 1f / content.RegisterPerFrame);

    /// <summary>
    /// Registers ModContent from other mods
    /// </summary>
    public override IEnumerator Coroutine()
    {
        if (ModHelper.FallbackToOldLoading)
        {
            ModHelper.Log(DisplayName);
        }
        var current = 0f;
        foreach (var modContent in mod.Content.ToArray())
        {
            if (modContent.GetType().GetCustomAttribute<DontRegisterAttribute>() != null) continue;

            var weight = 1f / modContent.RegisterPerFrame;
            current += weight;
            if (current >= 1f)
            {
                current = 0;
                yield return null;
            }

            try
            {
                modContent.Register();
            }
            catch (Exception e)
            {
                mod.LoadError($"Failed to register {modContent.Name}");
                ModHelper.Error(e);

                foreach (var rollbackAction in modContent.rollbackActions)
                {
                    try
                    {
                        rollbackAction();
                    }
                    catch (Exception e2)
                    {
                        ModHelper.Error($"Error while rolling back failed addition of {Id}");
                        ModHelper.Error(e2);
                        break;
                    }
                }
            }
            finally
            {
                modContent.rollbackActions.Clear();
            }
            Progress += weight / Total;
        }
    }
}