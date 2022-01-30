using UnityEngine;

namespace BTD_Mod_Helper.Api
{
    internal class BlatantFavoritism
    {
        public static Color32 GetColor(string repoOwner)
        {
            switch (repoOwner)
            {
                case "doombubbles":
                    return new Color32(200, 0, 255, 255);
                case "gurrenm3":
                    return new Color32(255, 215, 0, 255);
                default:
                    return Color.white;
            }
        }
        
    }
}