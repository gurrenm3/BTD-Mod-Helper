namespace BTD_Mod_Helper.Api.Hooks;

/// <summary>
/// Provides a simplified nullable type for unmanaged types, used as a replacement for Il2CPP's nullable implementation
/// </summary>
/// <typeparam name="T">The underlying unmanaged type</typeparam>
public struct HookNullable<T> where T : unmanaged
{
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


    /// <summary>
    /// Adds a quick way to get whatever value is contained
    /// </summary>
    /// <returns>If <see cref="HasValue"/> is non-zero, <see cref="Value"/>, otherwise default</returns>
    public T GetValueOrDefault()
    {
        return HasValue > 0 ? Value : default;
    }

    /// <summary>
    /// Constructor that takes in the value set
    /// </summary>
    /// <param name="value">Value to contain</param>
    public HookNullable(T value)
    {
        Value = value;
        HasValue = 1;
    }
}