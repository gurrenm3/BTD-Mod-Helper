using Assets.Scripts.Models.Map;
using Assets.Scripts.Models.Map.Spawners;
using Assets.Scripts.Simulation.SMath;
using System;
using System.Collections.Generic;

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
    }
}
