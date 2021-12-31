using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Api.Builders
{
    public class BloonModelBuilder
    {
        public static BloonModelBuilder Instance { get; set; }

        public void AddToGame(BloonModel bloonModel)
        {
            Game.instance.model.bloons = Game.instance.model.bloons.AddTo(bloonModel);
        }

        public void AddToGame(Il2CppReferenceArray<BloonModel> bloonModels)
        {
            Game.instance.model.bloons = Game.instance.model.bloons.AddTo(bloonModels);
        }

        public BloonModel Create(string name, BloonModel baseModel = null)
        {
            var model = (baseModel is null) ? Game.instance.model.GetBloon("Red") : baseModel;
            var bloonModel = model.Clone().Cast<BloonModel>();
            bloonModel.name = name;
            bloonModel.id = name;
            bloonModel.baseId = name;
            bloonModel.tags[0] = name;

            return bloonModel;
        }

        public BloonModel Create(string name, bool camo, bool regrow, bool fortified, BloonModel baseModel = null)
        {
            var bloonModel = Create(name, baseModel);
            bloonModel.isCamo = camo;
            bloonModel.isGrow = regrow;
            bloonModel.isFortified = fortified;
            return bloonModel;
        }

        public BloonModel Create(string name, string display, BloonModel baseModel = null)
        {
            var bloonModel = Create(name, baseModel);
            bloonModel.display = display;
            return bloonModel;
        }
    }
}
