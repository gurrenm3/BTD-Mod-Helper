using UnityEngine;
namespace BTD_Mod_Helper.Api;

internal class BlatantFavoritism
{
    public static Color32 GetColor(string repoOwner) => repoOwner switch
    {
        "doombubbles" => new Color32(200, 0, 255, 255),
        "gurrenm3" => new Color32(200, 150, 255, 255),
        _ => Color.white
    };
}