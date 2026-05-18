using Il2CppAssets.Scripts.Models.Audio;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;

// ReSharper disable UnusedType.Global
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extra extensions on arguments
/// </summary>
public static class ExtraCreateModelExt
{
    extension(CreateSoundOnProjectileCreatedModel model)
    {
        /// <summary>
        /// Combined getter/setter for all the sound fields
        /// </summary>
        public SoundModel sound
        {
            get => model.sound1;
            set
            {
                model.sound1 = value;
                model.sound2 = value;
                model.sound3 = value;
                model.sound4 = value;
                model.sound5 = value;
            }
        }
    }

    extension(CreateCreateSoundOnProjectileCreatedModelExt.Args args)
    {
        /// <summary>
        /// Combined getter/setter for all the sound fields
        /// </summary>
        public SoundModel sound
        {
            get => args.sound1;
            set
            {
                args.sound1 = value;
                args.sound2 = value;
                args.sound3 = value;
                args.sound4 = value;
                args.sound5 = value;
            }
        }
    }

    extension(CreateSoundOnProjectileExhaustModel model)
    {
        /// <summary>
        /// Combined getter/setter for all the sound fields
        /// </summary>
        public SoundModel sound
        {
            get => model.sound1;
            set
            {
                model.sound1 = value;
                model.sound2 = value;
                model.sound3 = value;
                model.sound4 = value;
                model.sound5 = value;
            }
        }
    }

    extension(CreateCreateSoundOnProjectileExhaustModelExt.Args args)
    {
        /// <summary>
        /// Combined getter/setter for all the sound fields
        /// </summary>
        public SoundModel sound
        {
            get => args.sound1;
            set
            {
                args.sound1 = value;
                args.sound2 = value;
                args.sound3 = value;
                args.sound4 = value;
                args.sound5 = value;
            }
        }
    }

    extension(CreateSoundOnProjectileExpireModel model)
    {
        /// <summary>
        /// Combined getter/setter for all the sound fields
        /// </summary>
        public SoundModel sound
        {
            get => model.sound1;
            set
            {
                model.sound1 = value;
                model.sound2 = value;
                model.sound3 = value;
                model.sound4 = value;
                model.sound5 = value;
            }
        }
    }

    extension(CreateCreateSoundOnProjectileExpireModelExt.Args args)
    {
        /// <summary>
        /// Combined getter/setter for all the sound fields
        /// </summary>
        public SoundModel sound
        {
            get => args.sound1;
            set
            {
                args.sound1 = value;
                args.sound2 = value;
                args.sound3 = value;
                args.sound4 = value;
                args.sound5 = value;
            }
        }
    }

    extension(CreateCreateSoundOnProjectileCollisionModelExt.Args args)
    {
        /// <summary>
        /// Combined getter/setter for all the sound fields
        /// </summary>
        public SoundModel sound
        {
            get => args.sound1;
            set
            {
                args.sound1 = value;
                args.sound2 = value;
                args.sound3 = value;
                args.sound4 = value;
                args.sound5 = value;
            }
        }
    }

    extension(CreateDamageModelExt.Args args)
    {
        /// <summary>
        /// Combined getter/setter for both immuneBloonProperties and immuneBloonPropertiesOriginal
        /// </summary>
        public BloonProperties immuneBloons
        {
            get => args.immuneBloonProperties;
            set
            {
                args.immuneBloonProperties = value;
                args.immuneBloonPropertiesOriginal = value;
            }
        }
    }

}