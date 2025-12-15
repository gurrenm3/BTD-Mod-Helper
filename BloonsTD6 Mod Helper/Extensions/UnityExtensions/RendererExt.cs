using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for unity renderers
/// </summary>
public static class RendererExt
{
    private const string DefaultShader = "NinjaKiwi/SimpleUnlitOutline";
    private static readonly int OutlineColor = Shader.PropertyToID("_OutlineColor");

    /// <summary>
    /// Set the texture for this renderer. Equivalent to "render.material.mainTexture = texture2D"
    /// </summary>
    /// <param name="renderer"></param>
    /// <param name="texture2D"></param>
    public static void SetMainTexture(this Renderer renderer, Texture2D texture2D)
    {
        renderer.material.mainTexture = texture2D;
    }

    /// <summary>
    /// Sets the outline color for this renderer
    /// </summary>
    public static void SetOutlineColor(this Renderer renderer, Color color)
    {
        renderer.material.SetColor(OutlineColor, color);
        renderer.material.SetShaderKeywords(Array.Empty<string>());
    }

    /// <summary>
    /// Set the texture for all renderers in this collection. Equivalent to a "ForEach(render.material.mainTexture =
    /// texture2D)"
    /// </summary>
    /// <param name="renderers"></param>
    /// <param name="texture2D"></param>
    public static void SetMainTexture(this Il2CppReferenceArray<Renderer> renderers, Texture2D texture2D)
    {
        renderers.ForEach(renderer => renderer.material.mainTexture = texture2D);
    }

    /// <summary>
    /// Unbinds the renderer's sharedMesh, so that changes you make to it don't change the original
    /// </summary>
    /// <param name="skinnedMeshRenderer"></param>
    /// <returns></returns>
    public static Mesh UnbindMesh(this SkinnedMeshRenderer skinnedMeshRenderer)
    {
        return skinnedMeshRenderer.sharedMesh = Object.Instantiate(skinnedMeshRenderer.sharedMesh);
    }

    /// <summary>
    /// </summary>
    /// <param name="skinnedMeshRenderer"></param>
    /// <returns></returns>
    public static Mesh BakedMesh(this SkinnedMeshRenderer skinnedMeshRenderer)
    {
        var mesh = new Mesh();
        skinnedMeshRenderer.BakeMesh(mesh);
        return mesh;
    }

    /// <summary>
    /// </summary>
    /// <param name="skinnedMeshRenderer"></param>
    /// <returns></returns>
    public static List<Vector3> GetVertices(this SkinnedMeshRenderer skinnedMeshRenderer) =>
        skinnedMeshRenderer.sharedMesh.isReadable
            ? skinnedMeshRenderer.sharedMesh.vertices.ToList()
            : skinnedMeshRenderer.BakedMesh().vertices.ToList();

    /// <summary>
    /// Gets the list of triangles for a Mesh, even if its not marked as isReadable
    /// <br />
    /// Each "triangle" is a set of 3 consecutive ints in the list, where the number is the index in the vertices
    /// </summary>
    /// <param name="skinnedMeshRenderer"></param>
    /// <param name="submesh"></param>
    /// <returns></returns>
    public static List<int> GetTriangles(this SkinnedMeshRenderer skinnedMeshRenderer, int submesh = 0) =>
        skinnedMeshRenderer.sharedMesh.GetTrianglesImpl(submesh, false).ToList();

    /// <summary>
    /// </summary>
    /// <param name="skinnedMeshRenderer"></param>
    /// <param name="submesh"></param>
    /// <returns></returns>
    public static List<int[]> GetTrianglesAsArrays(this SkinnedMeshRenderer skinnedMeshRenderer, int submesh = 0)
    {
        var triangles = skinnedMeshRenderer.GetTriangles();
        var trianglesAsVectors = new List<int[]>();
        for (var i = 0; i < triangles.Count; i += 3)
        {
            trianglesAsVectors.Add(new[] {triangles[i], triangles[i + 1], triangles[i + 2]});
        }

        return trianglesAsVectors;
    }

    /// <summary>
    /// </summary>
    /// <param name="skinnedMeshRenderer"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static int GetBoneIndex(this SkinnedMeshRenderer skinnedMeshRenderer, string name)
    {
        for (var i = 0; i < skinnedMeshRenderer.bones.Count; i++)
        {
            if (skinnedMeshRenderer.bones[i].name == name)
            {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// Gives this renderer the default outline for towers, also making them glow white when selected
    /// <seealso cref="SetOutlineColor"/>
    /// </summary>
    public static void ApplyOutlineShader(this Renderer renderer)
    {
        var shader = Resources.FindObjectsOfTypeAll<Shader>().FirstOrDefault(shader => shader.name == DefaultShader);
        if (shader == null)
        {
            var dummyDisplay = Game.instance.model.GetTowerWithName(TowerType.DartMonkey).display;
            Game.instance.GetDisplayFactory().FindAndSetupPrototypeAsync(dummyDisplay, DisplayCategory.Default,
                new Action<UnityDisplayNode>(udn => renderer.material.shader = udn.GetRenderers().First().material.shader));
        }
        else
        {
            renderer.material.shader = shader;
        }
        renderer.gameObject.layer = LayerMask.NameToLayer("Towers");
    }

    /// <inheritdoc cref="Texture2DExt.ApplyCustomShader(Texture,CustomShader,Action{Material})"/>
    public static void ApplyCustomShader(this Renderer renderer, CustomShader customShader,
        Action<Material> modifyMaterial = null)
    {
        if (renderer.material?.mainTexture == null)
        {
            ModHelper.Warning("Can't ApplyCustomShader, renderer has no material texture");
            return;
        }
        renderer.material.mainTexture = renderer.material.mainTexture.ApplyCustomShader(customShader, modifyMaterial);
    }

    /// <inheritdoc cref="Texture2DExt.ApplyCustomShader(Texture,Shader,Action{Material})"/>
    public static void ApplyCustomShader(this Renderer renderer, Shader shader,
        Action<Material> modifyMaterial = null)
    {
        if (renderer.material?.mainTexture == null)
        {
            ModHelper.Warning("Can't ApplyCustomShader, renderer has no material texture");
            return;
        }
        renderer.material.mainTexture = renderer.material.mainTexture.ApplyCustomShader(shader, modifyMaterial);
    }

    /// <inheritdoc cref="Texture2DExt.ReplaceColor"/>
    public static void ReplaceColor(this Renderer renderer, Color targetColor, Color replacementColor,
        float threshold = 0.05f)
    {
        if (renderer.material?.mainTexture == null)
        {
            ModHelper.Warning("Can't ReplaceColor, renderer has no material texture");
            return;
        }
        renderer.material.mainTexture = renderer.material.mainTexture.ReplaceColor(targetColor, replacementColor, threshold);
    }

    /// <inheritdoc cref="Texture2DExt.AdjustHSV"/>
    public static void AdjustHSV(this Renderer renderer, float hueAdjust, float saturationAdjust, float valueAdjust,
        Color? targetColor = null, float threshold = 0.05f)
    {
        if (renderer.material?.mainTexture == null)
        {
            ModHelper.Warning("Can't AdjustHSV, renderer has no material texture");
            return;
        }
        renderer.material.mainTexture =
            renderer.material.mainTexture.AdjustHSV(hueAdjust, saturationAdjust, valueAdjust, targetColor, threshold);
    }

}