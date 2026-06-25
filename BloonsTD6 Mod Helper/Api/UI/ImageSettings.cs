using Newtonsoft.Json;
using UnityEngine;
namespace BTD_Mod_Helper.Api.UI;

/// <summary>
/// Settings to use when automatically creating unity Textures and Sprites for an image
/// </summary>
[JsonObject]
public record ImageSettings
{
    /// <summary>
    /// Default ImageSettings
    /// </summary>
    public static readonly ImageSettings Default = new();

    /// <summary>
    /// <see cref="Texture.filterMode"/>
    /// </summary>
    public FilterMode FilterMode { get; init; } = FilterMode.Bilinear;

    /// <summary>
    /// <see cref="Texture.mipMapBias"/>
    /// </summary>
    public float MipMapBias { get; init; } = -.5f;

    /// <summary>
    /// <see cref="Texture.wrapMode"/>
    /// </summary>
    public TextureWrapMode WrapMode {get; init; } = TextureWrapMode.Clamp;

    /// <summary>
    /// <see cref="Sprite.pivot"/>
    /// </summary>
    public Vector2 Pivot { get; init; } = new(0.5f, 0.5f);

    /// <summary>
    /// <see cref="Sprite.pixelsPerUnit"/>
    /// </summary>
    public float PixelsPerUnit { get; init; } = 10.8f;

    /// <summary>
    /// <see cref="Sprite.extrude"/>
    /// </summary>
    public uint Extrude { get; init; } = 0;

    /// <summary>
    /// <see cref="SpriteMeshType"/>
    /// </summary>
    public SpriteMeshType MeshType { get; init; } = SpriteMeshType.FullRect;

    /// <summary>
    /// <see cref="Sprite.border"/>
    /// </summary>
    public Vector4 Border { get; init; } = Vector4.zero;
}