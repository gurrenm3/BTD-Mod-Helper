using System;

using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Utils;

using UnityEngine;

namespace BTD_Mod_Helper.Api.Display;

public abstract partial class ModDisplay {
    /// <summary>
    /// Sets the sprite texture to that of a named png
    /// </summary>
    /// <param name="node">The UnityDisplayNode</param>
    /// <param name="textureName">The name of the texture, without .png</param>
    protected void Set2DTexture(UnityDisplayNode node, string textureName) {
#pragma warning disable CS0618
        var sprite = GetSprite(textureName, PixelsPerUnit);
#pragma warning restore CS0618
        node.GetRenderer<SpriteRenderer>().sprite = sprite;
    }

    /// <summary>
    /// Gets a new DisplayModel based on this ModDisplay
    /// </summary>
    /// <returns></returns>
    public DisplayModel GetDisplayModel() {
        return new DisplayModel($"DisplayModel_{Name}", CreatePrefabReference(Id), 0, PositionOffset,
            Scale);
    }

    /// <summary>
    /// Gets the Display for a given tower, optionally for the given tiers
    /// </summary>
    /// <param name="tower">The tower base id</param>
    /// <param name="top">Path 1 tier</param>
    /// <param name="mid">Path 2 tier</param>
    /// <param name="bot">Path 3 tier</param>
    /// <returns>The display GUID</returns>
    protected string GetDisplay(string tower, int top = 0, int mid = 0, int bot = 0) {
        return Game.instance.model.GetTower(tower, top, mid, bot).display.GUID;
    }

    /// <summary>
    /// Gets a UnityDisplayNode for a different guid
    /// </summary>
    /// <param name="guid">The asset reference guid to get the node from</param>
    /// <param name="action">What to do with the node</param>
    protected void UseNode(string guid, Action<UnityDisplayNode> action) {
        Game.instance.GetDisplayFactory().FindAndSetupPrototypeAsync(CreatePrefabReference(guid),
            new Action<UnityDisplayNode>((udn) => {
                udn.RecalculateGenericRenderers();
                action(udn);
                udn.RecalculateGenericRenderers();
            }));
    }
}