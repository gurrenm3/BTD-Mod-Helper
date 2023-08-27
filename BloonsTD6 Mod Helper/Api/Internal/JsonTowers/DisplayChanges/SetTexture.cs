using Il2CppAssets.Scripts.Unity.Display;
using Newtonsoft.Json;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Internal.JsonTowers.DisplayChanges;

[JsonObject(MemberSerialization.OptOut)]
internal class SetTexture : JsonDisplayChange
{
    public RendererType RendererType { get; init; }
    public int Index { get; init; }
    public string Texture { get; init; }

    public override void Apply(UnityDisplayNode node)
    {
        var renderer = GetRenderer(node, RendererType, Index);
        var texture = ResourceHandler.GetTexture(Texture);
        switch (RendererType)
        {
            case RendererType.MeshRenderer:
                renderer.Cast<MeshRenderer>().SetMainTexture(texture);
                break;
            case RendererType.SpriteRenderer:
                renderer.Cast<SpriteRenderer>().sprite.SetTexture(texture);
                break;
        }
    }

}