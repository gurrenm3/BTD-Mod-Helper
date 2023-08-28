using System.Linq;
using Il2CppAssets.Scripts.Unity.Display;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Internal.JsonTowers;

internal abstract class JsonDisplayChange
{
    public abstract void Apply(UnityDisplayNode node);

    protected static Renderer GetRenderer(UnityDisplayNode node, RendererType rendererType, int index) =>
        node.GetRenderers().Where(renderer => rendererType switch
        {
            RendererType.SkinnedMeshRenderer => renderer.Is<SkinnedMeshRenderer>(),
            RendererType.MeshRenderer => renderer.Is<MeshRenderer>(),
            RendererType.SpriteRenderer => renderer.Is<SpriteRenderer>(),
            RendererType.ParticleSystemRenderer => renderer.Is<ParticleSystemRenderer>(),
            _ => false
        }).Skip(index).First();

}

internal enum RendererType
{
    SkinnedMeshRenderer,
    MeshRenderer,
    SpriteRenderer,
    ParticleSystemRenderer
}