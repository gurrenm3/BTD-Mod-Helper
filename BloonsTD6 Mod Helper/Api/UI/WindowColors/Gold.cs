using BTD_Mod_Helper.Api.Enums;
namespace BTD_Mod_Helper.Api.UI.WindowColors;

internal class Gold : ModWindowColor
{
    public override string MainPanelSprite => VanillaSprites.MainBGPanelGold;
    public override string InsertPanelSprite => VanillaSprites.MainBGPanelYellow;
    public override float InsertPanelPixelMult => 2;

    protected override int Order => -2;
}