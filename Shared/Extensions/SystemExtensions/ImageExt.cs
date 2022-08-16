using System.Drawing;
using System.IO;

#if !NET6_0
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
#endif

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extension Methods for System.Image
/// </summary>
public static partial class ImageExt {
#if !NET6_0
    /// <summary>
    /// Returns the Bytes of this Image.
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    // [SupportedOSPlatform("windows")]
    public static byte[] GetBytes(this Image image)
    {
        using var thumbnailStream = new MemoryStream();
        image.Save(thumbnailStream, ImageFormat.Png);
        return thumbnailStream.ToArray();
    }


    /// <summary>
    /// Returns a new image that is a resized version of this one.
    /// </summary>
    /// <param name="image"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    // [SupportedOSPlatform("windows")]
    public static Bitmap Resize(this Image image, int width, int height)
    {
        var destRect = new Rectangle(0, 0, width, height);
        var destImage = new Bitmap(width, height);

        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        using var graphics = Graphics.FromImage(destImage);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.SmoothingMode = SmoothingMode.HighQuality;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        using var wrapMode = new ImageAttributes();
        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);

        return destImage;
    }
#endif
}