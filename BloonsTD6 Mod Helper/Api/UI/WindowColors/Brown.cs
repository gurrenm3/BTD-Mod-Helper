using BTD_Mod_Helper.Api.Enums;
namespace BTD_Mod_Helper.Api.UI.WindowColors;

internal class Brown : ModWindowColor
{
    public override string MainPanelSprite => VanillaSprites.MainBgPanel;
    public override string InsertPanelSprite => VanillaSprites.BrownInsertPanel;

    protected override int Order => -4;
}