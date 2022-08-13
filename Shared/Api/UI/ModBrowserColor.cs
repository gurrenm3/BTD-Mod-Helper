using UnityEngine;

namespace BTD_Mod_Helper.Api;

internal class BlatantFavoritism
{
    public static Color32 GetColor(string repoOwner) => repoOwner switch
    {
        
        "doombubbles" => new Color32(200, 0, 255, 255),
        "gurrenm3" => new Color32(200, 150, 255, 255),
        "Commander-Cat101" => new Color32(255, 215, 0, 255),
        "BowDown097" => new Color32(0, 128, 0, 255),
        "Timotheeee" => new Color32(0, 128, 0, 255),
        "KosmicShovel" => new Color32(0, 128, 0, 255),
        "DatJaneDoe" => new Color32(0, 128, 0, 255),
        "Baydock" => new Color32(0, 128, 0, 255),
        "Onixiya" => new Color32(0, 128, 0, 255),
        "MagicGonads" => new Color32(0, 128, 0, 255),
        "Greenphx9" => new Color32(0, 128, 0, 255),
        "Sewer56" => new Color32(0, 128, 0, 255),
        "Ymerald" => new Color32(0, 128, 0, 255),
        "DepletedNova" => new Color32(0, 128, 0, 255),
        "Void-n-Null" => new Color32(0, 128, 0, 255),
        "GrahamKracker" => new Color32(0, 128, 0, 255),
    
            _ => Color.white
    };
}