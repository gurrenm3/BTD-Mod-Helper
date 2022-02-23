using Assets.Scripts.Data;
using Assets.Scripts.Data.MapSets;
using Assets.Scripts.Models.Map;
using Assets.Scripts.Models.Map.Spawners;
using Assets.Scripts.Simulation.SMath;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Api
{
    /// <summary>
    /// Class for creating custom Maps easier. 
    /// </summary>
    public abstract class ModMap : NamedModContent
    {
        private static List<string> customMapNames = new List<string>();

        /// <summary>
        /// The name of the Image file that would be the actual map. By default
        /// this will be set to be the same as <see cref="Name"/>. Change this
        /// if your map has a different file name than the name of the map itself.
        /// <br/><br/>Example: Castle.png
        /// </summary>
        protected virtual string MapImageName { get; }

        /// <summary>
        /// The name of this map.
        /// </summary>
        public abstract new string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        public abstract SpriteReference MapSprite { get; }

        /// <summary>
        /// The difficulty of this map.
        /// </summary>
        public abstract MapDifficulty Difficulty { get; }

        /// <summary>
        /// 
        /// </summary>
        public virtual CoopDivision CoopDivision { get; } = CoopDivision.DEFAULT;

        /// <summary>
        /// 
        /// </summary>
        public virtual string MapMusic { get; } = "MusicBTD5JazzA";

        public virtual bool AutoUnlockMap { get; } = true;

        public virtual float MapWideBloonSpeed { get; } = 1;


        internal List<AreaModel> areaModels = new List<AreaModel>();
        internal List<PathModel> paths = new List<PathModel>();

        /// <summary>
        /// Creates an instance of this <see cref="ModMap"/>.
        /// </summary>
        public ModMap()
        {
            customMapNames.Add(Name);

            if (string.IsNullOrEmpty(MapImageName))
                MapImageName = Name;
        }

        /// <summary>
        /// Get's the map details for this map. Override this method if you want extra customization.
        /// </summary>
        /// <returns></returns>
        protected virtual MapDetails GetMapDetails()
        {
            return new MapDetails()
            {
                id = Name,
                isBrowserOnly = false,
                isDebug = false,
                difficulty = Difficulty,
                coopMapDivisionType = CoopDivision,
                mapMusic = MapMusic,
                mapSprite = MapSprite
            };
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public sealed override void Register()
        {
            GameData.Instance.mapSet.Maps.items = 
                GameData.Instance.mapSet.Maps.items.AddTo(GetMapDetails());

            if (AutoUnlockMap)
            {
                Game.instance.ScheduleTask(
                    () => Game.instance.GetBtd6Player().UnlockMap(Name),
                    () => Game.instance.GetBtd6Player() != null);
            }

            MelonLogger.Msg($"Registered ModMap {Name}");
        }

        /// <summary>
        /// Use this to add a path to your map.
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        protected PathModel AddPath(List<Vector2> points)
        {
            //string pathName = $"PathModel_Path";
            //pathName += paths.Count > 0 ? $" {paths.Count + 1}" : "";
            string pathName = $"Path{paths.Count + 1}";
            var pathModel = MapHelper.CreatePathModel(pathName, points);
            paths.Add(pathModel);
            return pathModel;
        }

        /// <summary>
        /// Add an area model to this path.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        protected AreaModel AddAreaModel(AreaType type, List<Vector2> points)
        {
            string areaName = $"AreaModel{areaModels.Count}"; // others called it lol instead of AreaModel
            var polygon = new Polygon(points.ToIl2CppList());
            var areaModel = new AreaModel(areaName, polygon, 100, type, 0);
            areaModels.Add(areaModel);
            return areaModel;
        }

        /// <summary>
        /// Returns whether or not a map is a custom map, based off of it's name.
        /// </summary>
        /// <param name="mapName"></param>
        /// <returns></returns>
        public static bool IsCustomMap(string mapName)
        {
            return customMapNames.Contains(mapName);
        }
    }
}