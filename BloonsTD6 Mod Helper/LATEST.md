- Fixed a crash that could happen on Linux (thanks @GrahamKracker)
- 
- Fixed SteamWebView usage on the Epic Games version
  - Reminder: You still need https://github.com/GrahamKracker/BTD6EpicGamesModCompat for Epic Games
- Added new `AttackHelper`, `WeaponHelper` and `ProjectileHelper` that can be used to more easily create those models
  from scratch
    - The classes will implicitly convert themselves to their respective models
    - Make easy use of the object initialization syntax
      ```csharp
      var effect = ability.GetBehavior<CreateEffectOnAbilityModel>().effectModel;
      var buff = ability.GetBehavior<ActivateTowerDamageSupportZoneModel>();
      model.AddBehavior(new AttackHelper("WeakeningRoar")
      {
          Range = buff.range,
          AttackThroughWalls = true,
          CanSeeCamo = true,
          Weapon = new WeaponHelper("WeakeningRoar")
          {
              Animation = 3,
              Rate = ability.Cooldown / Factor,
              Behaviors = new WeaponBehaviorModel[]
              {
                  new EjectEffectModel("", effect.assetId, effect, effect.lifespan, effect.fullscreen, false, false,
                      false, false)
              },
              Projectile = new ProjectileHelper("WeakeningRoar")
              {
                  Radius = buff.range,
                  Pierce = 1000,
                  CanHitCamo = true,
                  Behaviors = new Model[]
                  {
                      new AgeModel("", .05f, 0, false, null),
                      new AddBonusDamagePerHitToBloonModel("", "WeakeningRoar", buff.lifespan / Factor,
                          buff.damageIncrease, 99999, true, false, false)
                  }
              }
          }
      });
      ```
    - Don't need to specific a bunch of extra fields, will use sensible defaults