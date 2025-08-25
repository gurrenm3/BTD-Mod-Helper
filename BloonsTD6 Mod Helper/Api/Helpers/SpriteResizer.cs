using System.Collections.Generic;
using BTD_Mod_Helper.Api.Internal;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Helper class for getting resized versions of Sprites
/// </summary>
public static class SpriteResizer
{
    internal static readonly Dictionary<string, Sprite> SpriteCache = new();
    internal static readonly Dictionary<string, Texture2D> TextureCache = new();

    internal static readonly Dictionary<string, (string, Vector2, bool)> GUIDs = new();


    /// <inheritdoc cref="Scaled(string,float,float,bool)"/>
    public static string Scaled(string spriteGuid, float scale, bool square = true) =>
        Scaled(spriteGuid, scale, scale, square);

    /// <summary>
    /// Returns a modified Sprite GUID that will create a reference to a resized version of this Vanilla Sprite.
    /// <br/>
    /// </summary>
    /// <param name="spriteGuid">Vanilla Sprite guid</param>
    /// <param name="scaleX">scale</param>
    /// <param name="scaleY">scale</param>
    /// <param name="square">also make the final image a square shape</param>
    /// <returns>new sprite guid</returns>
    public static string Scaled(string spriteGuid, float scaleX, float scaleY, bool square = true)
    {
        var scale = new Vector2(scaleX, scaleY);
        var guid = $"{spriteGuid}-{scaleX}-{scaleY}";

        GUIDs[guid] = (spriteGuid, scale, square);

        var result = $"{ModContent.HijackSpriteAtlas}[{guid}]";

        if (PreLoadResourcesTask.Complete)
        {
            // late setup the resized sprite for the cache
            TaskScheduler.ScheduleTask(() => PreLoadResourcesTask.PreloadResizedSprite(guid, spriteGuid, scale, square));
        }


        return result;
    }


    /// <summary>
    /// Create a new Sprite that appears scaled by (scaleX, scaleY) inside a fixed UI rect
    /// by adding transparent padding around the original sprite.
    /// Works even if src.texture is not readable.
    /// </summary>
    public static Sprite PadSpriteToScale(this Sprite src, float scaleX, float scaleY)
    {
        if (!src) return null;

        var readable = src.GetReadableTexture();
        if (!readable) return src;

        var sw = readable.width;
        var sh = readable.height;

        var targetW = Mathf.Max(1, Mathf.RoundToInt(sw / scaleX));
        var targetH = Mathf.Max(1, Mathf.RoundToInt(sh / scaleY));

        var padX = Mathf.Max(0, targetW - sw);
        var padY = Mathf.Max(0, targetH - sh);

        var left = padX / 2;
        var right = padX - left;
        var bottom = padY / 2;
        var top = padY - bottom;

        if (padX == 0 && padY == 0)
            return src;

        var outTex = new Texture2D(targetW, targetH, TextureFormat.RGBA32, false, false);
        outTex.SetPixels32(new Color32[targetW * targetH]);

        if (targetW >= sw && targetH >= sh)
        {
            outTex.SetPixels(left, bottom, sw, sh, readable.GetPixels(0, 0, sw, sh));
        }
        else
        {
            outTex.SetPixels(0, 0, targetW, targetH,
                readable.GetPixels((sw - targetW) / 2, (sh - targetH) / 2, targetW, targetH));
        }

        outTex.Apply(false, true);

        var srcTex = src.texture;
        if (srcTex)
        {
            outTex.filterMode = srcTex.filterMode;
            outTex.wrapMode = srcTex.wrapMode;
        }
        outTex.name = $"{src.name}-{scaleX:0.###}-{scaleY:0.###}";

        var newPivotPx = src.pivot + new Vector2(left, bottom);
        var newPivot = new Vector2(newPivotPx.x / targetW, newPivotPx.y / targetH);

        var border = src.border;
        if (border != Vector4.zero)
        {
            border = new Vector4(border.x + left, border.y + bottom, border.z + right, border.w + top);
        }

        return Sprite.Create(
            outTex,
            new Rect(0, 0, targetW, targetH),
            newPivot,
            src.pixelsPerUnit,
            0,
            SpriteMeshType.FullRect,
            border
        );
    }

    /// <inheritdoc cref="PadSpriteToScale(UnityEngine.Sprite,float,float)"/>
    public static Sprite PadSpriteToScale(this Sprite src, float uniformScale)
        => PadSpriteToScale(src, uniformScale, uniformScale);

    /// <summary>
    /// Returns a new Sprite with a square texture by padding the shorter axis
    /// with transparent pixels so that width and height are equal.
    /// </summary>
    /// <param name="src">The source sprite to pad.</param>
    /// <returns>A new square Sprite instance if padding was needed, or the original sprite if already square.</returns>
    public static Sprite PadSpriteToSquare(this Sprite src)
    {
        if (!src) return null;

        var readable = src.GetReadableTexture();
        if (!readable) return src;

        var sw = readable.width;
        var sh = readable.height;

        if (sw == sh)
            return src; // already square

        var size = Mathf.Max(sw, sh);

        // How much padding each axis needs
        var padX = size - sw;
        var padY = size - sh;

        // Split padding symmetrically (handle odd pixels)
        var left = padX / 2;
        var right = padX - left;
        var bottom = padY / 2;
        var top = padY - bottom;

        // Build square texture and clear to transparent
        var outTex = new Texture2D(size, size, TextureFormat.RGBA32, false, false);
        outTex.SetPixels32(new Color32[size * size]);

        // Copy original block into the padded square
        var block = readable.GetPixels(0, 0, sw, sh);
        outTex.SetPixels(left, bottom, sw, sh, block);
        outTex.Apply(false, true); // makeNoLongerReadable = true (optional)

        // Preserve sampling modes from source texture
        var srcTex = src.texture;
        if (srcTex)
        {
            outTex.filterMode = srcTex.filterMode;
            outTex.wrapMode = srcTex.wrapMode;
        }
        outTex.name = $"{src.name}-square";

        // Adjust pivot by the padding (pivot is in pixels)
        var newPivotPx = src.pivot + new Vector2(left, bottom);
        var newPivot = new Vector2(newPivotPx.x / size, newPivotPx.y / size);

        // Expand 9-slice borders by the padding
        var border = src.border;
        if (border != Vector4.zero)
        {
            border = new Vector4(
                border.x + left, // L
                border.y + bottom, // B
                border.z + right, // R
                border.w + top // T
            );
        }

        return Sprite.Create(
            outTex,
            new Rect(0, 0, size, size),
            newPivot,
            src.pixelsPerUnit,
            0,
            SpriteMeshType.FullRect,
            border
        );
    }

}