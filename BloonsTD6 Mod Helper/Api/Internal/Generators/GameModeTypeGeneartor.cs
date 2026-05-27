using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Data;

namespace BTD_Mod_Helper.Api.Internal.Generators;

internal sealed class GameModeTypeGenerator : EnumClassGenerator
{
    protected override IEnumerable<(string Name, string Value)> CollectEntries() =>
        GameData.Instance.mods.ToArray().Select(mode => (mode.name, mode.name))
            .Append(("None", ""));
}