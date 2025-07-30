using BTD_Mod_Helper.Api.Enums;
namespace BTD_Mod_Helper.Api.UI.WindowColors;

internal class Glass : ModWindowColor
{
    public override string MainPanelSprite => VanillaSprites.MainBGPanelHighlightTab;
    public override string InsertPanelSprite => VanillaSprites.InsertPanelWhiteRound;
    public override float InsertPanelPixelMult => 2;

    protected override int Order => -1;
}