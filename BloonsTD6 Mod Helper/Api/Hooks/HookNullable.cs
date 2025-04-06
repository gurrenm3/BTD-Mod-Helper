namespace BTD_Mod_Helper.Api.Hooks;

/// <summary>
/// Provides a simplified nullable type for unmanaged types, used as a replacement for Il2CPP's nullable implementation
/// </summary>
/// <typeparam name="T">The underlying unmanaged type</typeparam>
public struct HookNullable<T> where T : unmanaged {
    /// <summary>
    /// Indicates whether a value is present
    /// A non-zero value indicates that the <see cref="Value"/> is valid
    /// </summary>
    public byte HasValue;

    /// <summary>
    /// The underlying value of type <typeparamref name="T"/> if available
    /// Access this value only when <see cref="HasValue"/> indicates that a value is present
    /// </summary>
    public T Value;
}
