using System;
using System.IO;
using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Internal;
using UnityEngine;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Texture2Ds
/// </summary>
public static class Texture2DExt
{
    private static readonly int MainTex = Shader.PropertyToID("_MainTex");
    private static readonly int TargetColor = Shader.PropertyToID("_TargetColor");
    private static readonly int ReplacementColor = Shader.PropertyToID("_ReplacementColor");
    private static readonly int Threshold = Shader.PropertyToID("_Threshold");
    private static readonly int HueAdjust = Shader.PropertyToID("_HueAdjust");
    private static readonly int SaturationAdjust = Shader.PropertyToID("_SaturationAdjust");
    private static readonly int ValueAdjust = Shader.PropertyToID("_ValueAdjust");

    /// <summary>
    /// Create Texture2D from a unity Color. Texture will only be this color
    /// </summary>
    /// <param name="texture2D"></param>
    /// <param name="color">Color to make new texture</param>
    public static Texture2D CreateFromColor(this Texture2D texture2D, Color color)
    {
        var texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, color);
        texture.Apply();
        return texture;
    }

    /// <summary>
    /// Save Texture2D as a png to file.
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="filePath">File path to save texture to</param>
    public static void SaveToPNG(this Texture2D texture, string filePath)
    {
        var bytes = ImageConversion.EncodeToPNG(texture).ToArray();
        File.Create(filePath).Write(bytes, 0, bytes.Length);
    }

    /// <summary>
    /// Attempts to save a Texture to a png at the given filePath, even if it isn't marked as readable
    /// </summary>
    public static void TrySaveToPNG(this Texture texture, string filePath)
    {
        try
        {
            var tmp = RenderTexture.GetTemporary(texture.width, texture.height, 0, RenderTextureFormat.Default,
                RenderTextureReadWrite.Linear);
            Graphics.Blit(texture, tmp);
            var previous = RenderTexture.active;
            RenderTexture.active = tmp;
            var myTexture2D = new Texture2D(texture.width, texture.height);
            myTexture2D.ReadPixels(new Rect(0, 0, tmp.width, tmp.height), 0, 0);
            myTexture2D.Apply();
            RenderTexture.active = previous;
            RenderTexture.ReleaseTemporary(tmp);
            var bytes = ImageConversion.EncodeToPNG(myTexture2D);
            File.WriteAllBytes(filePath, bytes);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Create Texture2D from a file on local PC
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="filePath">path of file on PC</param>
    public static Texture2D LoadFromFile(this Texture2D texture, string filePath)
    {
        ImageConversion.LoadImage(texture, File.ReadAllBytes(filePath));
        return texture;
    }

    /// <summary>
    /// Create a Sprite from this Texture2D
    /// </summary>
    /// <param name="texture2D"></param>
    /// <param name="pixelsPerUnit">Number of pixels you want in each unit. More pixels means bigger sprite in game</param>
    public static Sprite CreateSpriteFromTexture(this Texture2D texture2D, float pixelsPerUnit) =>
        texture2D.CreateSpriteFromTexture(pixelsPerUnit, new Vector2(0.5f, 0.5f));

    /// <summary>
    /// Create a Sprite from this Texture2D
    /// </summary>
    /// <param name="texture2D"></param>
    /// <param name="pixelsPerUnit">Number of pixels you want in each unit. More pixels means bigger sprite in game</param>
    /// <param name="pivot"></param>
    public static Sprite CreateSpriteFromTexture(this Texture2D texture2D, float pixelsPerUnit, Vector2 pivot) =>
        Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), pivot, pixelsPerUnit);


    /// <summary>
    /// Applies a custom Mod Helper shader, creating a new Texture with its effects baked in
    /// </summary>
    /// <param name="texture">this</param>
    /// <param name="customShader">Mod Helper custom shader</param>
    /// <param name="modifyMaterial">changes to make to the material</param>
    public static RenderTexture ApplyCustomShader(this Texture texture, CustomShader customShader,
        Action<Material> modifyMaterial = null)
    {
        var shader = ModContent.GetBundle<MelonMain>("unity_assets").LoadAsset(customShader.ToString()).Cast<Shader>();

        var material = new Material(shader);
        modifyMaterial?.Invoke(material);

        material.SetTexture(MainTex, texture);

        var renderTexture = new RenderTexture(texture.width, texture.height, 0, RenderTextureFormat.ARGB32);
        renderTexture.Create();
        ResourceHandler.RenderTexturesToRelease.Add(renderTexture);

        Graphics.Blit(texture, renderTexture, material);

        return renderTexture;
    }

    /// <summary>
    /// Replaces all the usage of a target color (within a certain threshold) with a replacement color
    /// </summary>
    /// <param name="texture">this</param>
    /// <param name="targetColor">The color to find</param>
    /// <param name="replacementColor">The new color</param>
    /// <param name="threshold">The threshold for matching the target color, 0 is exact, 1 will match anything</param>
    public static RenderTexture ReplaceColor(this Texture texture, Color targetColor, Color replacementColor,
        float threshold = 0.05f) => texture.ApplyCustomShader(CustomShader.ColorReplace, material =>
    {
        material.SetColor(TargetColor, targetColor);
        material.SetColor(ReplacementColor, replacementColor);
        material.SetFloat(Threshold, threshold);
    });

    /// <summary>
    /// Applies a HSV adjustment, shifting its Hue/Saturation/Value(light)
    /// </summary>
    /// <param name="texture">this</param>
    /// <param name="hueAdjust">Amount between -180 and 180 to add to Hue</param>
    /// <param name="saturationAdjust">Amount between -1 and 1 to add to the saturation</param>
    /// <param name="valueAdjust">Amount between -1 and 1 to add to the value (light)</param>
    /// <param name="targetColor">If specified, only affect this color within the image</param>
    /// <param name="threshold">If specified, only match the color within this threshold, 0 is exact, 1 will match anything</param>
    public static RenderTexture AdjustHSV(this Texture texture, float hueAdjust, float saturationAdjust, float valueAdjust,
        Color? targetColor = null, float threshold = 0.05f) => texture.ApplyCustomShader(CustomShader.HSVAdjust, material =>
    {
        material.SetFloat(HueAdjust, hueAdjust);
        material.SetFloat(SaturationAdjust, saturationAdjust);
        material.SetFloat(ValueAdjust, valueAdjust);
        material.SetColor(TargetColor, targetColor ?? Color.white);
        material.SetFloat(Threshold, threshold);
    });

}