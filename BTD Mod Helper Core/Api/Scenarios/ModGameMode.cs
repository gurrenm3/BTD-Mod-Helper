using System;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Api.Scenarios
{
    public abstract class ModGameMode : NamedModContent
    {
        protected override float RegistrationPriority => 10;
        
        public sealed override string DisplayNamePlural { get; }

        /// <summary>
        /// Where this Mode should show up within the Mode Select screen. Use DifficultyType.[name]
        /// </summary>
        public abstract string Difficulty { get; }

        /// <summary>
        /// The id of the existing GameMode to use as a base. Use GameModeType.[name]
        /// If this GameModeType.None, empty, or null, then an empty base will be used
        /// </summary>
        public abstract string BaseGameMode { get; }

        /// <summary>
        /// Whether this GameMode ...
        /// </summary>
        protected virtual bool PreApplies => false;

        /// <summary>
        /// The Icon for the Button for this Mode within the UI, by default looking for the same name as the file
        /// </summary>
        public virtual string Icon => GetType().Name;

        /// <summary>
        /// If you're not going to use a custom .png for your Icon, use this to directly control its SpriteReference
        /// </summary>
        public virtual SpriteReference IconReference => GetSpriteReference(Icon);

        public override void RegisterText(Dictionary<string, string> textTable)
        {
            textTable["Mode " + Id] = DisplayName;
        }

        public abstract void ModifyBaseGameModeModel(ModModel gameModeModel);

        /// <inheritdoc />
        public override void Register()
        {
            model = GetDefaultGameModeModel();

            ModifyBaseGameModeModel(model);

            Game.instance.model.mods = Game.instance.model.mods.AddTo(model);
            Game.instance.model.AddChildDependant(model);
        }

        internal ModModel model;

        internal ModModel GetDefaultGameModeModel()
        {
            ModModel modModel;
            if (string.IsNullOrEmpty(BaseGameMode))
            {
                modModel = new ModModel(Id, new[] {Id}, new Il2CppReferenceArray<MutatorModModel>(0), PreApplies);
            }
            else
            {
                modModel = Game.instance.model.GetModModel(BaseGameMode).Duplicate();
                modModel.toggles = new[] {Id};
                modModel.preApplies = PreApplies;
                
                foreach (var mutator in modModel.mutatorMods)
                {
                    mutator.name = mutator.name = mutator.name.Replace(modModel.name, Id);
                }
            }

            modModel.name = modModel._name = Id;

            return modModel;
        }
    }
}