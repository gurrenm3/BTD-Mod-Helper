using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Data;
namespace BTD_Mod_Helper.Api.Internal.Generators;

internal sealed class RoundSetTypeGenerator : EnumClassGenerator
{
    protected override IEnumerable<(string Name, string Value)> CollectEntries() =>
        GameData.Instance.roundSets.Select(roundSet => (roundSet.name.Replace("RoundSet", ""), roundSet.name))
            .Append(("ABR", "AlternateRoundSet"))
            .Append(("Empty", ""));
}