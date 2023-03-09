using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Data.MapSets;
using Il2CppAssets.Scripts.Models.Map;
using Il2CppAssets.Scripts.Simulation.SMath;
using Il2CppAssets.Scripts.Utils;
using UnityEngine;
using Vector2 = Il2CppAssets.Scripts.Simulation.SMath.Vector2;
namespace BTD_Mod_Helper.Api.Scenarios;

/// <summary>
/// Class for creating custom Maps easier. 
/// </summary>
public abstract class ModMap : NamedModContent
{
    /// <summary>
    /// The name of the Image file that would be the actual map. By default
    /// this will be set to be the same as <see cref="ModContent.Name"/>. Change this
    /// if your map has a different file name than the name of the map itself.
    /// <br/><br/>Example: Castle.png
    /// </summary>
    protected virtual string MapImageName => Name;

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
    public virtual string MapMusic { get; set; } = "MusicBTD5JazzA";

    /// <summary>
    /// Set to true if you want this map to be unlocked by default.
    /// </summary>
    protected virtual bool AutoUnlockMap { get; } = true;

    /// <summary>
    /// The map-wide modifier for all Bloons' speed
    /// </summary>
    public virtual float MapWideBloonSpeed { get; } = 1;

    /// <summary>
    /// Set to true if you want Rain enabled in this map.
    /// </summary>
    public bool EnableRain { get; set; }


    internal List<AreaModel> areaModels = new();
    internal List<PathModel> paths = new();
#pragma warning disable CS0649
    private SpriteReference mapSprite;
#pragma warning restore CS0649
    private Texture2D mapTexture;

    /// <summary>
    /// Get's the map details for this map. Override this method if you want extra customization.
    /// </summary>
    /// <returns></returns>
    protected virtual MapDetails GetMapDetails()
    {
        return new MapDetails
        {
            id = Name,
            isBrowserOnly = false,
            isDebug = false,
            difficulty = Difficulty,
            coopMapDivisionType = CoopDivision,
            mapMusic = MapMusic,
            mapSprite = mapSprite
        };
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public sealed override void Register()
    {
        /*
        GameData.Instance.mapSet.Maps.items =
            GameData.Instance.mapSet.Maps.items.AddTo(GetMapDetails());

        if (AutoUnlockMap)
        {
            Game.instance.ScheduleTask(
                () => Game.instance.GetBtd6Player().UnlockMap(Name),
                () => Game.instance && Game.instance.GetBtd6Player() != null);
        }

        mapSprite = GetSpriteReference(MapImageName);

        MelonLogger.Msg($"Registered Map: {Name}");
        */
    }

    /// <summary>
    /// Returns the sprite reference of this map.
    /// </summary>
    /// <returns></returns>
    public virtual SpriteReference GetSpriteReference()
    {
        return mapSprite;
    }

    /// <summary>
    /// Returns the texture of this map. The first time it's loaded it will automatically resize to fit the game.
    /// </summary>
    /// <returns></returns>
    public virtual Texture2D GetTexture()
    {
        return (mapTexture != null
            ? mapTexture
            : mapTexture = GetTexture(MapImageName)); // returns unresized version of texture;
        //return mapTexture != null ? mapTexture : mapTexture = MapHelper.ResizeForGame();
    }

    /// <summary>
    /// Use this to add a path to your map. 
    /// </summary>
    /// <param name="points"></param>
    /// <returns></returns>
    protected PathModel AddPath(List<Vector2> points)
    {
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
        var areaModel =
            new AreaModel(areaName, polygon, new Il2CppReferenceArray<Polygon>(0), 100, type); // TODO is an empty holes array correct?
        areaModels.Add(areaModel);
        return areaModel;
    }

    internal byte[] GetMapBytes()
    {
        return ResourceHandler.GetTextureBytes(GetMapGUID());
    }

    internal string GetMapGUID()
    {
        return GetTextureGUID(MapImageName);
    }

    /// <summary>
    /// Returns whether or not a map is a custom map, based off of it's name.
    /// </summary>
    /// <param name="mapName"></param>
    /// <returns></returns>
    public static bool IsCustomMap(string mapName)
    {
        return GetContent<ModMap>().Any(map => map.Name == mapName);
    }

    /// <summary>
    /// Returns whether or not a map is a custom map, based off of it's name.
    /// </summary>
    /// <param name="mapName"></param>
    /// <param name="map">The custom map, if found</param>
    /// <returns></returns>
    public static bool IsCustomMap(string mapName, out ModMap map)
    {
        map = GetContent<ModMap>().FirstOrDefault(map => map.Name == mapName);
        return map != null;
    }
}