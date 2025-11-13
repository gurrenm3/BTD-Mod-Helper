#if DEBUG
using BTD_Mod_Helper.Api.Enums;
using CommandLine;
using Il2CppAssets.Scripts.Models.Effects;
using Il2CppAssets.Scripts.Simulation.SMath;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppNinjaKiwi.Common.ResourceUtils;
namespace BTD_Mod_Helper.Api.Commands;

internal class SpawnEffect : ModCommand
{
    public override string Command => "spawneffect";
    public override string Help => "Spawns an effect at your cursor";

    public override bool IsAvailable => InGame.instance != null;

    [Value(0, Default = null, HelpText = "Effect guid", MetaName = "EffectGUID")]
    public string Guid { get; set; }

    [Option('l', "lifespan", Default = 1, HelpText = "Lifespan of effect")]
    public float Lifespan { get; set; } = 1;

    [Option('s', "scale", Default = 1, HelpText = "Scale of effect")]
    public float Scale { get; set; } = 1;

    [Option('r', "rotation", Default = 0, HelpText = "Rotation of effect in degrees")]
    public float Rotation { get; set; } = 0;

    [Option('f', "fulscreen", Default = 0, HelpText = "Whether effect is fullscreen")]
    public int Fullscreen { get; set; } = 0;

    public override bool Execute(ref string resultText)
    {
        if (string.IsNullOrEmpty(Guid)) return false;

        var inputManager = InGame.instance.InputManager;

        var height = inputManager.Bridge.Simulation.Map.GetTerrainHeight(new(inputManager.CursorPositionWorld));

        var position = new Vector3(inputManager.CursorPositionWorld.x, inputManager.CursorPositionWorld.y, height);

        InGame.Bridge.Simulation.SpawnEffect(new PrefabReference(Guid), position, scale: Scale, lifespan: Lifespan,
            isFullscreen: (Fullscreen) Fullscreen, rotation: Rotation);

        return true;
    }
}

#endif