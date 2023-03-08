using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace BTD_Mod_Helper.Api;

/// <summary>
/// Initial task to register ModContent from other mods
/// </summary>
internal class ModContentTask : ModLoadTask
{
    /// <inheritdoc />
    public override string DisplayName => $"Registering ModContent for {mod.Info.Name}...";

    /// <summary>
    /// Don't load this like a normal task
    /// </summary>
    /// <returns></returns>
    public override IEnumerable<ModContent> Load() => Enumerable.Empty<ModContent>();

    public override bool ShowProgressBar => Total > 5;

    private float? total;
    
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
        foreach (var modContent in mod.Content)
        {
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
                ModHelper.Error($"Failed to register {modContent.Id}");
                ModHelper.Error(e);
                mod.loadErrors.Add($"Failed to register {modContent.Name}");

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