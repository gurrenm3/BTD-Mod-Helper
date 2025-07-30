using BTD_Mod_Helper.Api.Enums;

namespace BTD_Mod_Helper.Api.UI.WindowColors;

internal class Blue : ModWindowColor
{
    public override string MainPanelSprite => VanillaSprites.MainBGPanelBlue;
    public override string InsertPanelSprite => VanillaSprites.BlueInsertPanelRound;

    protected override int Order => -5;
}