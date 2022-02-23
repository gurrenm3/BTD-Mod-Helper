using Assets.Scripts.Models.Map;
using Assets.Scripts.Models.Map.Spawners;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using UnityEngine;
using Random = System.Random;
using Vector2 = Assets.Scripts.Simulation.SMath.Vector2;
using Vector3 = Assets.Scripts.Simulation.SMath.Vector3;


namespace BTD_Mod_Helper.Api.Helpers
{
    /// <summary>
    /// Contains helper methods for working with maps and custom maps.
    /// </summary>
    public class MapHelper
    {
        static Random rand = new Random();

        /// <summary>
        /// Create a <see cref="PointInfo"/> out of an X and Y coord.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static PointInfo CreatePointInfo(float x, float y)
        {
            return CreatePointInfo(new Vector3(x, y));
        }

        /// <summary>
        /// Create a <see cref="PointInfo"/> out of a Vector2.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static PointInfo CreatePointInfo(Vector2 point)
        {
            return CreatePointInfo(new Vector3(point.x, point.y));
        }

        /// <summary>
        /// Create a <see cref="PointInfo"/> out of X, Y, Z coords.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static PointInfo CreatePointInfo(float x, float y, float z)
        {
            return CreatePointInfo(new Vector3(x, y, z));
        }

        /// <summary>
        /// Create a <see cref="PointInfo"/> out of a Vector3.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static PointInfo CreatePointInfo(Vector3 point)
        {
            return new PointInfo
            {
                point = point,
                rotation = 0,
                distance = 1,
                bloonScale = 1,
                moabScale = 1,
                moabsInvulnerable = false,
                bloonsInvulnerable = false,
                id = rand.NextDouble().ToString()
            };
        }

        /// <summary>
        /// Creates a default PathModel out of list of Vector2 points
        /// </summary>
        /// <param name="pathName"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        public static PathModel CreatePathModel(string pathName, List<Vector2> points)
        {
            List<PointInfo> allPoints = new List<PointInfo>();
            points.ForEach(p => allPoints.Add(CreatePointInfo(p)));
            return CreatePathModel(pathName, allPoints);
        }

        /// <summary>
        /// Creates a default PathModel out of list of PointInfos
        /// </summary>
        /// <param name="pathName"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        public static PathModel CreatePathModel(string pathName, List<PointInfo> points)
        {
            var pathModel = new PathModel(pathName, points.ToArray(), true, false, new Vector3(), new Vector3(), null, null);
            return pathModel;
        }

        /// <summary>
        /// Create a SpawnerModel based off of an array of paths
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static PathSpawnerModel CreateSpawner(PathModel[] paths)
        {
            string[] pathNames = new string[paths.Length];
            for (int i = 0; i < paths.Length; i++)
                pathNames[i] = (paths[i].pathId);

            return new PathSpawnerModel("", new SplitterModel("", pathNames), new SplitterModel("", pathNames));
        }

        public static Texture2D ResizeForGame(Texture2D texture2D)
        {
            byte[] filedata = Resize(ImageConversion.EncodeToPNG(texture2D), 1652, 1064);
            float divx = 2;
            float divy = 1.21f;
            int marginx = 450;
            int marginy = 890;
            Bitmap old = new Bitmap(Image.FromStream(new MemoryStream(filedata)));
            Bitmap newImage = new Bitmap(old.Width + marginx, old.Height + marginy);
            using (var graphics = System.Drawing.Graphics.FromImage(newImage))
            {
                int x = (int)((newImage.Width - old.Width) / divx);
                int y = (int)((newImage.Height - old.Height) / divy);
                graphics.DrawImage(old, x, y);
                using (MemoryStream ms = new MemoryStream())
                {
                    newImage.Save(ms, ImageFormat.Png);
                    filedata = ms.ToArray();
                }
            }
            ImageConversion.LoadImage(texture2D, filedata);
            return texture2D;
        }


        private static byte[] Resize(byte[] data, int width, int height)
        {
            using (var stream = new MemoryStream(data))
            {
                var image = Image.FromStream(stream);

                Bitmap b = ResizeImage(image, width, height);

                using (var thumbnailStream = new MemoryStream())
                {
                    b.Save(thumbnailStream, ImageFormat.Png);
                    return thumbnailStream.ToArray();
                }
            }
        }

        private static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = System.Drawing.Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
