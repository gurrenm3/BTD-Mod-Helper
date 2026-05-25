using System.Collections;
using System.Linq;
using BTD_Mod_Helper.Api.Legends;
using Il2CppAssets.Scripts.Data;
namespace BTD_Mod_Helper.Api.Internal;

internal class ArtifactDependantsTask : ModLoadTask
{
    public override bool ShowProgressBar => true;

    public override bool RunsPreRegistrationPhase => true;

    public override bool ShouldRun => ModHelper.Mods.Any(m => m.UsesArtifactDependants);

    public override string DisplayName => "Fixing vanilla artifact dependants";

    public override IEnumerator Coroutine()
    {
        var artifacts = GameData.Instance.artifactsData.artifactDatas.Values().ToArray();

        for (var i = 0; i < artifacts.Length; i++)
        {
            var artifact = artifacts[i];
            ModArtifact.FixDependants(artifact.ArtifactModel());
            if (i % 5 == 0)
            {
                yield return null;
            }
            Progress = i / (float) artifacts.Length;
        }
    }
}