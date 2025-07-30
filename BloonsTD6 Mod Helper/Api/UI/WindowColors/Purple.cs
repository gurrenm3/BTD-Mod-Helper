using BTD_Mod_Helper.Api.Enums;
namespace BTD_Mod_Helper.Api.UI.WindowColors;

internal class Purple : ModWindowColor
{
    public override string MainPanelSprite => VanillaSprites.MainPanelStorePurple;
    public override string InsertPanelSprite => VanillaSprites.MainPanelStorePurpleIn;

    protected override int Order => -5;
}