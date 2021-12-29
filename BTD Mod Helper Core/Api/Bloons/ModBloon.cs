using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Bloons.Behaviors;
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.Bloons
{
    /// <summary>
    /// Class for adding in a new Bloon to the game
    /// </summary>
    public abstract class ModBloon : NamedModContent
    {
        internal static readonly Dictionary<string, BloonModel> BloonCache = new Dictionary<string, BloonModel>();

        /// <inheritdoc />
        public override void Register()
        {
            var bloonModel = GetDefaultBloonModel();
            
            ModifyBaseBloonModel(bloonModel);

            Game.instance.model.bloons = Game.instance.model.bloons.AddTo(bloonModel);
            Game.instance.model.AddChildDependant(bloonModel);
            Game.instance.model.bloonsByName[bloonModel.name] = bloonModel;
            BloonCache[bloonModel.name] = bloonModel;
        }


        /// <summary>
        /// The Bloon in the game that this should copy from as a base. Use BloonType.[Name]
        /// </summary>
        public abstract string BaseBloon { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bloonModel"></param>
        public abstract void ModifyBaseBloonModel(BloonModel bloonModel);


        /// <summary>
        /// Set this to false if you're making another version of the BaseBloon, like a Fortified Red Bloon
        /// </summary>
        public virtual bool IsSeparateFromBase => true;

        /// <summary>
        /// The Icon for the Bloon within the UI, by default looking for the same name as the file
        /// </summary>
        public virtual string Icon => GetType().Name;

        /// <summary>
        /// If you're not going to use a custom .png for your Icon, use this to directly control its SpriteReference
        /// </summary>
        public virtual SpriteReference IconReference => GetSpriteReference(Icon);

        /// <summary>
        /// Add the necessary properties to make this a Fortified Bloon
        /// </summary>
        public virtual bool Fortified => false;

        /// <summary>
        /// Add the necessary properties to make this a Regrow Bloon
        /// </summary>
        public virtual bool Regrow => false;

        /// <summary>
        /// The ID of the bloon that this should regrow into
        /// </summary>
        public virtual string RegrowsTo => null;

        /// <summary>
        /// The regrow rate
        /// </summary>
        public virtual float RegrowRate => 3;

        /// <summary>
        /// Add the necessary properties to make this a Camo Bloon
        /// </summary>
        public virtual bool Camo => false;

        /// <summary>
        /// How many different DamageStates does this Bloon have
        /// </summary>
        public virtual IEnumerable<string> DamageStates => null;

        /// <summary>
        /// Whether this Bloon should use its Icon as its display
        /// </summary>
        public virtual bool UseIconAsDisplay => !BaseBloonModel.isMoab;
        
        /// <summary>
        /// For 2D bloons, the ratio between pixels and display units. Higher number -> smaller Bloon.
        /// </summary>
        public virtual float PixelsPerUnit => 10f;


        internal BloonModel BaseBloonModel => Game.instance.model.GetBloon(BaseBloon);

        internal virtual BloonModel GetDefaultBloonModel()
        {
            var bloonModel = BaseBloonModel.Duplicate();
            if (IsSeparateFromBase)
            {
                bloonModel.baseId = bloonModel.id = bloonModel.name = Id;
            }
            else
            {
                bloonModel.id = bloonModel.name = bloonModel.baseId +
                                                  (Regrow ? "Regrow" : "") +
                                                  (Fortified ? "Fortified" : "") +
                                                  (Camo ? "Camo" : "");
            }

            bloonModel.icon = IconReference;

            var tags = bloonModel.tags.ToList();
            if (Fortified)
            {
                if (!tags.Contains(BloonTag.Fortified))
                {
                    tags.Add(BloonTag.Fortified);
                }

                bloonModel.isFortified = true;
            }

            if (Regrow)
            {
                if (!tags.Contains(BloonTag.Regrow))
                {
                    tags.Add(BloonTag.Regrow);
                }

                if (!bloonModel.HasBehavior<GrowModel>())
                {
                    bloonModel.AddBehavior(new GrowModel("GrowModel_", RegrowRate, RegrowsTo));
                }

                bloonModel.isGrow = true;
            }

            if (Camo)
            {
                if (!tags.Contains(BloonTag.Camo))
                {
                    tags.Add(BloonTag.Camo);
                }

                bloonModel.isCamo = true;
            }

            bloonModel.tags = tags.ToArray();

            if (DamageStates != null)
            {
                bloonModel.RemoveBehaviors<DamageStateModel>();

                var count = DamageStates.Count();
                var i = 1f;
                foreach (var damageState in DamageStates)
                {
                    bloonModel.AddBehavior(new DamageStateModel($"DamageStateModel_damage_state_{i}",
                        damageState, 1 - i / count));
                    i++;
                }
            }

            if (UseIconAsDisplay)
            {
                var guid = IconReference.GUID;
                bloonModel.display = bloonModel.GetBehavior<DisplayModel>().display = guid;
                ResourceHandler.ScalesFor2dModels[guid] = PixelsPerUnit;
            }

            return bloonModel;
        }
    }

    public abstract class ModBloon<TDisplay> : ModBloon where TDisplay : ModDisplay
    {
    }
}