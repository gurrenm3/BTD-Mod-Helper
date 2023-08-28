using Il2CppAssets.Scripts.Unity.Display;
using Newtonsoft.Json;
namespace BTD_Mod_Helper.Api.Internal.JsonTowers.DisplayChanges;

[JsonObject(MemberSerialization.OptOut)]
internal class RemoveBone : JsonDisplayChange
{
    public string Bone { get; set; }

    public override void Apply(UnityDisplayNode node) => node.RemoveBone(Bone);
}