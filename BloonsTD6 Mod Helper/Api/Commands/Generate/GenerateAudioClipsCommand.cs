#if DEBUG
using BTD_Mod_Helper.Api.Internal;
namespace BTD_Mod_Helper.Api.Commands;

internal class GenerateAudioClipsCommand : ModCommand<GenerateCommand>
{
    public override string Command => "audioclips";
    public override string Help => "Generates the Mod Helper audioclips list files";

    public override bool Execute(ref string resultText)
    {
        if (string.IsNullOrWhiteSpace(MelonMain.ModHelperSourceFolder))
        {
            resultText = "Mod Helper Source Folder has not been set";
            return false;
        }

        VanillaAudioClipsGenerator.GenerateVanillaAudioClips();

        return true;
    }
}
#endif