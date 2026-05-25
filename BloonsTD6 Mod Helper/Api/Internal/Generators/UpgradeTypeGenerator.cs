using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Api.Internal.Generators;

internal sealed class UpgradeTypeGenerator : EnumClassGenerator
{
    private static readonly Dictionary<string, string> Overrides = new()
    {
        {"Soulbind", "PrinceOfDarkness"},
        {"Metal Freeze", "ColdSnap"},
        {"Buccaneer-Faster Shooting", "FasterShootingBuccaneer"},
        {"Buccaneer-Double Shot", "DoubleShotBuccaneer"},
    };

    protected override IEnumerable<(string Name, string Value)> CollectEntries() =>
        Game.instance.model.upgrades
            .Where(model => !ModHelper.Mods.Any(m => model.name.StartsWith(m.IDPrefix)))
            .Select(model => (model.name, model.name));

    protected override string FixName(string name) =>
        Overrides.TryGetValue(name, out var overriden)
            ? overriden
            : name.Replace(".", " ").ToTitleCase().Replace(" ", "").Replace("+", "I")
                .Replace("Buccaneer-", "").Replace("-", "").Replace("'", "").Replace(":", "")
                .RegexReplace(@"^(\d+)([A-Z][a-z]*)", "$2$1");
}