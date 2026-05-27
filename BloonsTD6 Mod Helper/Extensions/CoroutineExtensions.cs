using System;
using System.Collections;
using BTD_Mod_Helper.Api.Helpers;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions related to Coroutines
/// </summary>
public static class CoroutineExtensions
{
    /// <inheritdoc cref="MelonCoroutines.Start"/>
    public static object StartCoroutine(this System.Collections.IEnumerator enumerator) =>
        MelonCoroutines.Start(enumerator);

    /// <inheritdoc cref="MelonCoroutines.Start"/>
    public static object StartCoroutine(this Il2CppSystem.Collections.IEnumerator enumerator) =>
        MelonCoroutines.Start(new Il2CppEnumerator(enumerator));

    /// <summary>
    /// Catches errors on a coroutine and logs them
    /// </summary>
    public static IEnumerator CatchErrors(object coroutineOrYield)
    {
        switch (coroutineOrYield)
        {
            case IEnumerator coroutine:
            {
                while (true)
                {
                    try
                    {
                        if (!coroutine.MoveNext()) break;
                    }
                    catch (Exception e)
                    {
                        ModHelper.Error(e);
                        break;
                    }

                    yield return CatchErrors(coroutine.Current);
                }
                break;
            }
            case Il2CppSystem.Collections.IEnumerator il2cppCoroutine:
            {
                while (true)
                {
                    try
                    {
                        if (!il2cppCoroutine.MoveNext()) break;
                    }
                    catch (Exception e)
                    {
                        ModHelper.Error(e);
                        break;
                    }

                    yield return CatchErrors(il2cppCoroutine.Current);
                }
                break;
            }
            default:
                yield return coroutineOrYield;
                break;
        }
    }

    /// <inheritdoc cref="CatchErrors(object)" />
    public static IEnumerator CatchErrors(this IEnumerator enumerator) => CatchErrors((object) enumerator);

    /// <inheritdoc cref="CatchErrors(object)" />
    public static IEnumerator CatchErrors(this Il2CppSystem.Collections.IEnumerator enumerator) =>
        CatchErrors((object) enumerator);

    /// <inheritdoc cref="CatchErrors(object)" />
    public static IEnumerator CatchErrors(this Func<IEnumerator> createCoroutine)
    {
        IEnumerator coroutine = null;
        try
        {
            coroutine = createCoroutine().CatchErrors();
        }
        catch (Exception e)
        {
            ModHelper.Error(e);
        }

        if (coroutine != null)
        {
            yield return coroutine;
        }
    }

    /// <summary>
    /// Extensions for MelonCoroutines
    /// </summary>
    extension(MelonCoroutines)
    {
        /// <inheritdoc cref="MelonCoroutines.Start"/>
        public static object Start(Il2CppSystem.Collections.IEnumerator enumerator)
        {
            return MelonCoroutines.Start(new Il2CppEnumerator(enumerator));
        }
    }
}