using BTD_Mod_Helper;
using MelonLoader;

[assembly: MelonInfo(typeof(TemplateMod.TemplateMain), "Your Mod Name", "1.0.0", "Your Name")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace TemplateMod
{
	public class TemplateMain : BloonsTD6Mod
    {
		// Github API URL used to check if this mod is up to date. For example:
		// public override string GithubReleaseURL => "https://api.github.com/repos/gurrenm3/BTD-Mod-Helper/releases";

		// As an alternative to a GithubReleaseURL, a direct link to a web-hosted version of the .cs file
		// that has the "MelonInfo" attribute with the version of your mod
		//public override string MelonInfoCsURL => "https://raw.githubusercontent.com/doombubbles/BTD6-Mods/main/MegaKnowledge/Main.cs";

		// The link to your normal GitHub Releases page if you're using those, or a direct link to your dll file
		// public override string LatestURL => "https://github.com/gurrenm3/BTD-Mod-Helper/releases/latest ";


		public override void OnMainMenu()
		{
			base.OnMainMenu();
		}

		public override void OnApplicationStart()
        {
            MelonLogger.Msg("Template Mod Loaded!");
        }
    }
}
