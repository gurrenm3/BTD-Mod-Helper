using Il2CppAssets.Scripts.Unity.Display;
namespace BTD_Mod_Helper.Api.UI;

/// <summary>
/// The aspect ratios BTD6 runs at natively
/// </summary>
public enum AspectRatio
{
    /// <summary>
    /// 16 x 9
    /// </summary>
    Widescreen,
    /// <summary>
    /// 16 x 10
    /// </summary>
    TallWidescreen,
    /// <summary>
    /// 4 x 3
    /// </summary>
    NonWidescreen
}

/// <summary>
/// The aspect ratios BTD6 runs at natively
/// </summary>
public static class AspectRatios
{
    /// <summary>
    /// The current AspectRatio the game is running at
    /// </summary>
    public static AspectRatio Current =>
        From(ScreenResizeDetector.Instance.currentWidth, ScreenResizeDetector.Instance.currentHeight);

    /// <summary>
    /// Gets the BTD6 aspect ratio based on the screen width and height
    /// </summary>
    /// <param name="width">screen width</param>
    /// <param name="height">screen height</param>
    /// <returns>aspect ratio</returns>
    public static AspectRatio From(int width, int height) => ((float) width / height) switch
    {
        < 1.545f => AspectRatio.NonWidescreen,
        < 1.709f => AspectRatio.TallWidescreen,
        _ => AspectRatio.Widescreen
    };
}