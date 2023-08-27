using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Utils;
using Newtonsoft.Json;
namespace BTD_Mod_Helper.Api.Internal.JsonTowers;

[JsonObject(MemberSerialization.OptIn)]
internal class ModJsonDisplay : ModDisplay
{
    // ReSharper disable once ConvertToPrimaryConstructor
    public ModJsonDisplay
    (
        [JsonProperty] string name,
        [JsonProperty] PrefabReference baseDisplay,
        [JsonProperty] float scale,
        [JsonProperty] DisplayCategory displayCategory
    )
    {
        Name = name;
        BaseDisplayReference = baseDisplay;
        Scale = scale;
        DisplayCategory = displayCategory;
    }

    [JsonProperty]
    public JsonDisplayChange[] Changes { get; init; }

    [JsonProperty]
    public override PrefabReference BaseDisplayReference { get; }

    [JsonProperty]
    public override string Name { get; }

    [JsonProperty]
    public override float Scale { get; }

    [JsonProperty]
    public override DisplayCategory DisplayCategory { get; }

    private protected override string ID => Name;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        foreach (var change in Changes)
        {
            change.Apply(node);
        }
    }
}