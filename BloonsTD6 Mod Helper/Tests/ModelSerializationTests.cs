using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Powers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using Il2CppNewtonsoft.Json.Utilities;
namespace BTD_Mod_Helper.Tests;

#if DEBUG

internal static class ModelSerializationTests
{
    public static void SaveLoadTest()
    {
        var tower = TowerSelectionMenu.instance.selectedTower.tower;

        var model = tower.rootModel;

        var text = ModelSerializer.SerializeModel(model);
        FileIOHelper.SaveFile("text.json", text);

        var result = ModelSerializer.DeserializeModel<TowerModel>(text);

        if (result != null)
        {
            FileIOHelper.SaveFile("result.json", ModelSerializer.SerializeModel(result));
            tower.UpdateRootModel(result);
        }
    }

    public static bool TestSerialization(TowerModel towerModel)
    {
        var expected = ModelSerializer.SerializeModel(towerModel);
        var result = ModelSerializer.DeserializeModel<TowerModel>(expected);
        var actual = ModelSerializer.SerializeModel(result);

        var success = actual == expected;

        if (!success)
        {
            FileIOHelper.SaveFile($"Test/{towerModel.name}.expected.json", expected);
            FileIOHelper.SaveFile($"Test/{towerModel.name}.actual.json", actual);
        }

        return success;
    }


    public static void TestTowerSerialization(GameModel gameModel)
    {
        var results = new Dictionary<string, bool>();

        var towers = gameModel.towers
            // .Where(model => model.towerSet == TowerSet.Hero)
            .ToArray();

        foreach (var towerModel in towers)
        {
            results[towerModel.name] = TestSerialization(towerModel);
        }

        var fail = results.Values.Count(b => !b);

        ModHelper.Msg($"Results: {fail} fails out of {towers.Length}");

        if (fail > 0)
        {
            foreach (var (name, success) in results)
            {
                if (!success)
                {
                    ModHelper.Msg(name);
                }
            }
        }
    }

    public static bool TestSerialization(GameModel gameModel)
    {
        var model = gameModel.Duplicate();
        // model.RemoveChildDependants(model.towers);
        // model.towers = new Il2CppReferenceArray<TowerModel>(0);
        // model.RemoveChildDependants(model.upgrades);
        // model.upgrades = new Il2CppReferenceArray<UpgradeModel>(0);
        // model.upgradesByName = new Il2CppSystem.Collections.Generic.Dictionary<string, UpgradeModel>();
        // model.RemoveChildDependants(model.powers);
        // model.powers = new Il2CppReferenceArray<PowerModel>(0);
        // model.RemoveChildDependants(model.bloons);
        // model.bloons = new Il2CppReferenceArray<BloonModel>(0);
        // model.bloonsByName = new Il2CppSystem.Collections.Generic.Dictionary<string, BloonModel>();

        var entireGameModelText = ModelSerializer.SerializeModel(model);

        FileIOHelper.SaveFile("Tests/game_model.json", entireGameModelText);

        var recreatedGameModel = ModelSerializer.DeserializeModel<GameModel>(entireGameModelText);

        var recreatedGameModelText = ModelSerializer.SerializeModel(recreatedGameModel);

        FileIOHelper.SaveFile("Tests/recreated_game_model.json", recreatedGameModelText);

        ModHelper.Msg(entireGameModelText == recreatedGameModelText ? "matched" : "not matched");
        
        return entireGameModelText.Trim() == recreatedGameModelText.Trim();
    }
}

#endif