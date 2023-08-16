using System;
using System.IO;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using NfdSharp;
namespace BTD_Mod_Helper.Tests;

internal class BlocklyTests
{
    private static string BlocklyOut => Path.Combine(MelonMain.ModHelperSourceFolder, "Website", "out");

    public static void TestChoose()
    {
        FileDialogHelper.PrepareNativeDlls();
        if (Nfd.OpenDialog("", BlocklyOut, out var path) == Nfd.NfdResult.NFD_OKAY)
        {
            ModHelper.Msg(Test(path) ? "Succeeded" : "Failed");
        }
    }
    
    public static void TestAll()
    {
        var success = 0;
        var fail = 0;
        TestAll(Path.Combine(BlocklyOut, "Towers"), ref success, ref fail);

        ModHelper.Msg($"Results: {success} success and {fail} fails");
    }

    private static void TestAll(string folder, ref int success, ref int fail)
    {
        foreach (var file in Directory.EnumerateFiles(folder))
        {
            if (Test(file))
            {
                success++;
            }
            else
            {
                fail++;
            }
        }

        foreach (var directory in Directory.EnumerateDirectories(folder))
        {
            TestAll(directory, ref success, ref fail);
        }
    }

    private static bool Test(string file)
    {
        try
        {
            var text = File.ReadAllText(file);

            var actualModel = ModelSerializer.DeserializeModel<TowerModel>(text).Duplicate();
            var actual = ModelSerializer.SerializeModel(actualModel);

            var expectedModel = Game.instance.model.GetTowerWithName(actualModel.name).Duplicate();
            var expected = ModelSerializer.SerializeModel(expectedModel);

            var success = actual == expected;

            if (!success)
            {
                FileIOHelper.SaveFile($"Test/{actualModel.name}.json", actual);
            }

            return success;
        }
        catch (Exception e)
        {
            ModHelper.Error("While testing " + Path.GetFileName(file));
            ModHelper.Error(e);
            return false;
        }
    }
}