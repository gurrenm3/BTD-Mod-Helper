using System.Collections.Generic;
using System.IO;
using System.Linq;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Api.Internal;

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
            using System.Collections.Generic;
            #pragma warning disable 1591
            namespace BTD_Mod_Helper.Api.Enums;

            public static class UpgradeType
            {
            """
        );


        var byName = new HashSet<string>();

        foreach (var upgrade in Game.instance.model.upgrades.Select(x => x.name))
        {
            var p = Overrides.TryGetValue(upgrade, out var overriden)
                ? overriden
                : upgrade.Replace(".", " ").ToTitleCase().Replace(" ", "").Replace("+", "I")
                    .Replace("Buccaneer-", "").Replace("-", "").Replace("'", "").Replace(":", "")
                    .RegexReplace(@"^(\d+)([A-Z][a-z]*)", "$2$1");

            upgradeTypesFile.WriteLine(
                $"""
                    public const string {p} = "{upgrade}";
                """
            );

            byName.Add(p);
        }

        upgradeTypesFile.WriteLine(
            """
                public static readonly Dictionary<string, string> ByName = new() 
                {
            """
        );
        foreach (var s in byName)
        {
            upgradeTypesFile.WriteLine(
                $$"""
                        { "{{s}}", {{s}} },
                """
            );
        }
        upgradeTypesFile.WriteLine(
            """
                };
            """
        );


        upgradeTypesFile.Write("}");
    }
}