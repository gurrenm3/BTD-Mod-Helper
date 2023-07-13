using UnityEngine;
namespace BTD_Mod_Helper.UI.Menus;

internal class BlatantFavoritism
{
    public static Color32 GetColor(string repoOwner)
    {
        return repoOwner switch
        {
            "doombubbles" => new Color32(200, 0, 255, 255),
            "Btd6ModHelper" => new Color32(200, 75, 255, 255),
            "gurrenm3" => new Color32(200, 150, 255, 255),
            "Anakinskywalker066 & Jonylovespie" => new Color32(255,200,200,255),
            "Anakinskywalker066" => new Color32(200, 0, 255, 255),
            _ => Color.white
        };
    }
}
