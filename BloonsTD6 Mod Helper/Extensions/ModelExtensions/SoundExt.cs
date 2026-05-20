using Il2CppAssets.Scripts.Models.Audio;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for settings the various repeated sound arguments with one property
/// </summary>
public static class SoundExt
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

}