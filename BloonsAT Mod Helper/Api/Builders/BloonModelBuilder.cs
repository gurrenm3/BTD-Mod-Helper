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
            BloonModel model = (baseModel is null) ? Game.instance.model.GetBloon("Red") : baseModel;
            BloonModel bloonModel = model.Clone().Cast<BloonModel>();
            bloonModel.name = name;
            bloonModel.id = name;

            return bloonModel;
        }
    }
}
