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