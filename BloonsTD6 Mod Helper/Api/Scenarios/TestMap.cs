using Assets.Scripts.Data.MapSets;
using Assets.Scripts.Models.Map;
using Assets.Scripts.Simulation.SMath;
using Assets.Scripts.Utils;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Api.Scenarios
{
    internal class TestMap : ModMap
    {
        public override string Name => "Test Map";
        public override MapDifficulty Difficulty => MapDifficulty.Beginner;
        public override SpriteReference MapSprite => GetSpriteReference<MelonMain>(Name);

        public TestMap()
        {
            AddPath(new List<Vector2>()
            {
                new Vector2(10, 5),
                new Vector2(10, 5),
                new Vector2(10, 5),
                new Vector2(10, 5),
                new Vector2(10, 5),
                new Vector2(10, 5),
            });

            AddPath(new List<Vector2>()
            {
                new Vector2(10, 5),
                new Vector2(10, 5),
                new Vector2(10, 5),
                new Vector2(10, 5),
                new Vector2(10, 5),
                new Vector2(10, 5),
            });

            AddPath(new List<Vector2>()
            {
                new Vector2(10, 5),
                new Vector2(10, 5),
                new Vector2(10, 5),
                new Vector2(10, 5),
                new Vector2(10, 5),
                new Vector2(10, 5),
            });

            AddPath(new List<Vector2>()
            {
                new Vector2(10, 10),
                new Vector2(10, 10),
                new Vector2(10, 10),
                new Vector2(10, 10),
                new Vector2(10, 10),
                new Vector2(10, 10),
                new Vector2(10, 10),
                new Vector2(10, 10),
            });

            AddAreaModel(AreaType.water, new List<Vector2>()
            {
                new Vector2(3, 5),
                new Vector2(3, 5),
                new Vector2(3, 5),
                new Vector2(3, 5),
            });
        }
    }
}
