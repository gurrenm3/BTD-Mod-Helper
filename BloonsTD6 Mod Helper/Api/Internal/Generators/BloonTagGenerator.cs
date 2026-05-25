using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Api.Internal.Generators;

internal sealed class BloonTagGenerator : EnumClassGenerator
{
    protected override IEnumerable<(string Name, string Value)> CollectEntries() =>
        Game.instance.model.bloons.SelectMany(bloon => bloon.tags).Distinct().Select(tag => (tag, tag))
            .Append(("Regrow", "Grow"));
}