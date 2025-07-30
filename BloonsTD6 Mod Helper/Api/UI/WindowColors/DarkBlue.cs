using BTD_Mod_Helper.Api.Enums;
namespace BTD_Mod_Helper.Api.UI.WindowColors;

internal class DarkBlue : ModWindowColor
{
    public override string MainPanelSprite => VanillaSprites.MainBgPanelJukebox;
    public override string InsertPanelSprite => VanillaSprites.BlueInsertPanel;

    protected override int Order => -5;
}