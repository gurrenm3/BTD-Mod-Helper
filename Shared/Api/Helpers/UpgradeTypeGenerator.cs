using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Api.Helpers;

internal static class UpgradeTypeGenerator
{
    private static readonly Dictionary<string, string> Overrides = new()
    {
        {"Soulbind", "PrinceOfDarkness"},
        {"Metal Freeze", "ColdSnap"},
        {"Buccaneer-Faster Shooting", "FasterShootingBuccaneer"},
        {"Buccaneer-Double Shot", "DoubleShotBuccaneer"}
    };

    public static void GenerateVanillaUpgradeTypes(string upgradeTypesCs)
    {
        using var upgradeTypesFile = new StreamWriter(upgradeTypesCs);

        upgradeTypesFile.WriteLine(
            """
            #pragma warning disable 1591
            namespace BTD_Mod_Helper.Api.Enums;

            public static class UpgradeType
            {
            """
        );


        foreach (var upgrade in Game.instance.model.upgrades)
        {
            var p = Overrides.TryGetValue(upgrade.name, out var overriden)
                ? overriden
                : upgrade.name.Replace(".", " ").ToTitleCase().Replace(" ", "").Replace("+", "I")
                    .Replace("Buccaneer-", "").Replace("-", "").Replace("'", "").Replace(":", "")
                    .RegexReplace(@"^(\d+)([A-Z][a-z]*)", "$2$1");

            upgradeTypesFile.WriteLine(
                $"""
                    public const string {p} = "{upgrade.name}";
                """
            );
        }

        upgradeTypesFile.Write("}");
    }
}