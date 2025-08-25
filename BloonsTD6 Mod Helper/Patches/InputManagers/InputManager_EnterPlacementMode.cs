using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;

namespace BTD_Mod_Helper.Patches.InputManagers;

[HarmonyPatch(typeof(InputManager), nameof(InputManager.EnterPlacementMode), typeof(TowerModel),
    typeof(InputManager.PositionDelegate), typeof(ObjectId), typeof(bool), typeof(int))]
internal class InputManager_EnterPlacementMode
{
    [HarmonyPostfix]
    internal static void Postfix(TowerModel forTowerModel)
    {
        if (forTowerModel.GetModTower() is ModFakeTower fakeTower)
        {
            InGameObjects.instance.IconUpdate(new Vector2(-3000, 0), false);
            InGameObjects.instance.IconStart(fakeTower.PlacementSprite);
        }
    }
}