using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Internal.Generators;

internal sealed class VanillaAudioClipsGenerator : EnumClassGenerator
{
    protected override IEnumerable<(string Name, string Value)> CollectEntries() => GetAllAddressables<AudioClip>()
        .Select(t => (Path.GetFileNameWithoutExtension(t.Location.InternalId), t.Guid));
}