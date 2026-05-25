using System;
using System.Linq;

namespace BTD_Mod_Helper.Api.Testing;

/// <summary>
/// A default <see cref="ModTest"/> for a particular kind of <see cref="ModContent"/>
/// </summary>
/// <typeparam name="T">ModContent type</typeparam>
public abstract class ModContentDefaultTest<T> : ModTest where T : ModContent, IHasDefaultTest
{
    /// <inheritdoc />
    public override string Name => Content == null ? base.Name : Content.Name + "Test";

    /// <summary>
    /// The ModContent that this is a test for
    /// </summary>
    public T Content { get; protected set; }

    /// <summary>
    /// All the ModContent of this type to test
    /// </summary>
    public T[] AllContent { get; protected set; }

    /// <summary>
    /// Tests all the ModContent of this type within a single test instead of individually
    /// </summary>
    public virtual bool OneTestToRuleThemAll => false;

    /// <inheritdoc />
    public override bool IsAvailable => OneTestToRuleThemAll || Content is not null;

    /// <inheritdoc />
    public override void Register()
    {
        if (AllContent is not null)
        {
            base.Register();
            return;
        }

        foreach (var bloonsMod in ModHelper.Mods)
        {
            if (bloonsMod is MelonMain) continue;

            var allContent = bloonsMod.Content.OfType<T>().Where(t => t.UseDefaultTest).ToArray();

            if (OneTestToRuleThemAll && allContent.Any())
            {
                CreateTest(bloonsMod, null, allContent);
            }
            else
            {
                foreach (var content in allContent)
                {
                    CreateTest(bloonsMod, content, allContent);
                }
            }
        }
    }

    private void CreateTest(BloonsMod bloonsMod, T content, T[] allContent)
    {
        var test = (ModContentDefaultTest<T>) Activator.CreateInstance(GetType())!;
        test.Content = content;
        test.AllContent = allContent;
        bloonsMod.AddContent(test);
    }
}