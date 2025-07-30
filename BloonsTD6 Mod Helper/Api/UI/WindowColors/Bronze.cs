using BTD_Mod_Helper.Api.Enums;
namespace BTD_Mod_Helper.Api.UI.WindowColors;

internal class Bronze : ModWindowColor
{
    public override string MainPanelSprite => VanillaSprites.MainBGPanelBronze;
    public override string InsertPanelSprite => VanillaSprites.BrownPanel;

    protected override int Order => -3;
}