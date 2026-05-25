namespace BTD_Mod_Helper.Api.Testing;

/// <summary>
/// Indicates this type has a default <see cref="ModTest"/> available for it
/// </summary>
public interface IHasDefaultTest
{
    /// <summary>
    /// Allow ModHelper to automatically register a default <see cref="ModTest"/> for this content
    /// </summary>
    bool UseDefaultTest => true;
}