using System.Linq;
using Il2CppAssets.Scripts.Models.Audio;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Simulation.SMath;

namespace BTD_Mod_Helper.Extensions;

// ReSharper disable InconsistentNaming
// ReSharper disable LocalVariableHidesMember
// ReSharper disable RedundantExtendsListEntry
// ReSharper disable UnusedType.Global
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

public class ModelArgs<T> where T : Il2CppAssets.Scripts.Models.Model
{
    public string name { get; set; } = "";

    internal virtual void OnCreate(T result)
    {
    }
}

public partial class CreateDamageModelExt
{
    public partial class Args : ModelArgs<DamageModel>
    {
        public BloonProperties? immuneBloons { get; set; } = null;

        internal override void OnCreate(DamageModel result)
        {
            if (immuneBloons != null)
            {
                result.immuneBloonProperties = immuneBloons.Value;
                result.immuneBloonPropertiesOriginal = immuneBloons.Value;
            }
        }
    }
}

public partial class CreateAttackModelExt
{
    public partial class Args : ModelArgs<AttackModel>
    {
        public bool CanSeeCamo { get; set; } = false;
        public WeaponModel weapon { get; set; } = null;
        public FilterModel[] filters { get; set; } = null;

        internal override void OnCreate(AttackModel result)
        {
            CreateAttackModelExt.OnCreate(result, CanSeeCamo, weapon, filters);
        }
    }

    internal static void OnCreate(AttackModel result, bool canSeeCamo, WeaponModel weapon, FilterModel[] filters)
    {
        if (!result.HasBehavior(out AttackFilterModel filter))
        {
            filter = new AttackFilterModel("", null);
            result.AddBehavior(filter);
        }
        filter.filters ??= filters ?? new Il2CppReferenceArray<FilterModel>(0);

        var camoFilter = filter.filters.OfIl2CppType<FilterInvisibleModel>().FirstOrDefault();

        if (camoFilter == null)
        {
            camoFilter = new FilterInvisibleModel("", !canSeeCamo, false);
            filter.AddChildDependant(camoFilter);
        }
        else
        {
            camoFilter.isActive = canSeeCamo;
        }

        if (weapon != null)
        {
            var weapons = result.weapons ?? new Il2CppReferenceArray<WeaponModel>(0);
            weapons = weapons.AddTo(weapon);
            result.weapons = weapons;
            result.AddChildDependant(weapon);
        }
    }
}

public partial class CreateAttackAirUnitModelExt
{
    public partial class Args : ModelArgs<AttackAirUnitModel>
    {
        public bool CanSeeCamo { get; set; } = false;
        public WeaponModel weapon { get; set; } = null;
        public FilterModel[] filters { get; set; } = null;

        internal override void OnCreate(AttackAirUnitModel result)
        {
            CreateAttackModelExt.OnCreate(result, CanSeeCamo, weapon, filters);
        }
    }
}

public partial class CreateWeaponModelExt
{
    public partial class Args : ModelArgs<WeaponModel>
    {
        public Vector3? eject { get; set; } = null;

        internal override void OnCreate(WeaponModel result)
        {
            if (eject.HasValue)
            {
                result.ejectX = eject.Value.x;
                result.ejectY = eject.Value.y;
                result.ejectZ = eject.Value.z;
            }

            if (result.emission == null)
            {
                result.SetEmission(new SingleEmissionModel("", null));
            }
        }
    }
}

public partial class CreateProjectileModelExt
{
    public partial class Args : ModelArgs<ProjectileModel>
    {
        public bool CanHitCamo { get; set; } = false;

        internal override void OnCreate(ProjectileModel result)
        {
            result.displayModel ??= new DisplayModel("ProjectileDisplay", result.display, 0, DisplayCategory.Projectile);

            if (!result.HasBehavior<DisplayModel>())
            {
                result.AddBehavior(result.displayModel);
            }

            if (!result.HasBehavior(out ProjectileFilterModel filter))
            {
                filter = new ProjectileFilterModel("", null);
                result.AddBehavior(filter);
            }
            filter.filters ??= result.filters ?? new Il2CppReferenceArray<FilterModel>(0);

            var camoFilter = filter.filters.OfIl2CppType<FilterInvisibleModel>().FirstOrDefault();

            if (camoFilter == null)
            {
                camoFilter = new FilterInvisibleModel("", !CanHitCamo, false);
                filter.AddChildDependant(camoFilter);
            }
            else
            {
                camoFilter.isActive = CanHitCamo;
            }

            result.filters = filter.filters;
            result.AddChildDependants(result.filters);

            result.UpdateCollisionPassList();

            if (string.IsNullOrEmpty(result.id))
            {
                result.id = result.name.Replace(nameof(ProjectileModel) + "_", "");
            }
        }
    }
}

public partial class CreateTowerModelExt
{
    public partial class Args : ModelArgs<TowerModel>
    {
        internal override void OnCreate(TowerModel result)
        {
            result.UpdateTargetProviders();
        }
    }
}

public partial class CreateCreateSoundOnProjectileExhaustModelExt
{
    public partial class Args : ModelArgs<CreateSoundOnProjectileExhaustModel>
    {
        public SoundModel sound { get; set; } = null;

        internal override void OnCreate(CreateSoundOnProjectileExhaustModel result)
        {
            if (sound != null)
            {
                result.sound1 = sound;
                result.sound2 = sound;
                result.sound3 = sound;
                result.sound4 = sound;
                result.sound5 = sound;
            }
        }
    }
}

public partial class CreateCreateSoundOnProjectileCreatedModelExt
{
    public partial class Args : ModelArgs<CreateSoundOnProjectileCreatedModel>
    {
        public SoundModel sound { get; set; } = null;

        internal override void OnCreate(CreateSoundOnProjectileCreatedModel result)
        {
            if (sound != null)
            {
                result.sound1 = sound;
                result.sound2 = sound;
                result.sound3 = sound;
                result.sound4 = sound;
                result.sound5 = sound;
            }
        }
    }
}

public partial class CreateCreateSoundOnProjectileExpireModelExt
{
    public partial class Args : ModelArgs<CreateSoundOnProjectileExpireModel>
    {
        public SoundModel sound { get; set; } = null;

        internal override void OnCreate(CreateSoundOnProjectileExpireModel result)
        {
            if (sound != null)
            {
                result.sound1 = sound;
                result.sound2 = sound;
                result.sound3 = sound;
                result.sound4 = sound;
                result.sound5 = sound;
            }
        }
    }
}

public partial class CreateCreateSoundOnProjectileCollisionModelExt
{
    public partial class Args : ModelArgs<CreateSoundOnProjectileCollisionModel>
    {
        public SoundModel sound { get; set; } = null;

        internal override void OnCreate(CreateSoundOnProjectileCollisionModel result)
        {
            if (sound != null)
            {
                result.sound1 = sound;
                result.sound2 = sound;
                result.sound3 = sound;
                result.sound4 = sound;
                result.sound5 = sound;
            }
        }
    }
}