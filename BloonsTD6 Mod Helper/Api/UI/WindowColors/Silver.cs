using BTD_Mod_Helper.Api.Enums;
namespace BTD_Mod_Helper.Api.UI.WindowColors;

internal class Silver : ModWindowColor
{
    public override string MainPanelSprite => VanillaSprites.MainBGPanelSilver;
    public override string InsertPanelSprite => VanillaSprites.MainBGPanelGrey;
    public override float InsertPanelPixelMult => 2;

    protected override int Order => -3;
}