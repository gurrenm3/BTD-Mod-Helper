﻿using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.TowerSets;

namespace BTD_Mod_Helper.Api.Towers;

public abstract partial class ModTowerSet
{
    /// <summary>
    /// The position to start placing ModTowers of this ModTowerSet in relation to other towers
    /// <br/>
    /// By default, will determine the position based on GetTowerSetIndex
    /// <br/>
    /// </summary>
    /// <param name="towerSet">The set of all current tower details</param>
    /// <returns></returns>
    public virtual int GetTowerStartIndex(List<TowerDetailsModel> towerSet)
    {
        var towerSets = towerSet.Select(model => model.GetTower().towerSet);

        // Group the towers into chunks of the same tower set
        var towerSetChunks = new List<Tuple<string, int>>();
        foreach (var set in towerSets)
        {
            if (towerSetChunks.LastOrDefault() is Tuple<string, int> last && last.Item1 == set)
            {
                towerSetChunks[towerSetChunks.Count - 1] = new Tuple<string, int>(set, last.Item2 + 1);
            }
            else
            {
                towerSetChunks.Add(new Tuple<string, int>(set, 1));
            }
        }

        // Get the tower set index in relation to the chunks
        var start = GetTowerSetIndex(towerSetChunks.Select(tuple => tuple.Item1).ToList());

        return towerSetChunks.Take(start).Sum(tuple => tuple.Item2);
    }
}