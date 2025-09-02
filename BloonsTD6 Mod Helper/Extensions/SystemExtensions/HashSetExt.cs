using System.Collections.Generic;
using System.Linq;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for HashSets
/// </summary>
public static class HashSetExt
{

    /// <summary>
    /// Enumerates a HashSet without throwing if items are added mid-iteration.
    /// Yields each item exactly once (items added while iterating will be yielded in a later pass).
    /// Stops when a pass finds no unseen items.
    /// </summary>
    public static IEnumerable<T> EnumerateUntilStable<T>(this HashSet<T> set)
    {
        var seen = new HashSet<T>();

        while (true)
        {
            var progressed = false;
            foreach (var item in set.ToArray())
            {
                if (seen.Add(item))
                {
                    progressed = true;
                    yield return item; // process newly observed item
                }
            }
            if (!progressed)
                yield break; // no new items observed in this pass: we're done
        }
    }
}