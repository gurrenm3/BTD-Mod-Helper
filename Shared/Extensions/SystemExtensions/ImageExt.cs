using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace BTD_Mod_Helper.Extensions
{
    /// <summary>
    /// Extension Methods for System.Image
    /// </summary>
    public static partial class ImageExt
    {
        /// <summary>
        /// (Cross-Game compatible) Returns the Bytes of this Image.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this Image image)
        {
            return image.GetBytes(ImageFormat.Png);
        }

        /// <summary>
        /// (Cross-Game compatible) Returns the Bytes of this Image.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this Image image, ImageFormat format)
        {
            using (var imageStream = new MemoryStream())
            {
                image.Save(imageStream, format);
                return imageStream.ToArray();
            }
        }

        /// <summary>
        /// (Cross-Game compatible) Returns a new image that is a resized version of this one.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap Resize(this Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
