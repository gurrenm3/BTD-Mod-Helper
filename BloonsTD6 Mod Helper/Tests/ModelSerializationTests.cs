using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
namespace BTD_Mod_Helper.Tests;

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


    public static void TestSerialization(GameModel gameModel)
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
}