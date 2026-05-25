using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Unity;

namespace BTD_Mod_Helper.Api.Internal.Generators;

internal sealed class BloonTypeGenerator : EnumClassGenerator
{
    protected override IEnumerable<(string Name, string Value)> CollectEntries() =>
        Game.instance.model.bloons.OrderBy(bloon => bloon.name).Select(bloon => (bloon.name, bloon.name));
}