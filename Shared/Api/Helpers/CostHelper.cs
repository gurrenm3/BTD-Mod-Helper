using System;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Helper for scaling costs to difficulties
/// </summary>
public partial class CostHelper
{
    /// <summary>
    /// Scales a base (medium) cost to the given difficulty
    /// </summary>
    public static int CostForDifficulty(int cost, string difficulty)
    {
        switch (difficulty)
        {
            case "Easy":
                return CostForDifficulty(cost, .85f);
            case "Hard":
                return CostForDifficulty(cost, 1.08f);
            case "Impoppable":
                return CostForDifficulty(cost, 1.2f);
            default:
                return cost;
        }
    }

    /// <summary>
    /// Applies a multiplier to a cost and rounds it
    /// </summary>
    public static int CostForDifficulty(int cost, float multiplier)
    {
        var price = cost * multiplier;
        return (int) (5 * Math.Round(price / 5));
    }
}