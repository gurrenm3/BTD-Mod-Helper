using System.Collections.Generic;
using Il2CppAssets.Scripts;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// ModContent for defining Custom Input that can be used in Tower Selection Menu Themes or via
/// <code>inputManager.PrimeCustomInput(ModContent.GetInstance&lt;ModCustomInput&gt;().Activate(inputManager));</code>
/// </summary>
public abstract class ModCustomInput : ModContent
{
    internal static readonly Dictionary<string, ModCustomInput> CustomInputById = [];

    /// <summary>
    /// The currently active Modded Custom Input, null if none are active
    /// </summary>
    public static ModCustomInput ActiveInput { get; private set; }

    /// <summary>
    /// Activates this Custom Input and returns the CustomInput that can be passed to <see cref="InputManager.PrimeCustomInput"/> or other places
    /// </summary>
    /// <param name="inputManager">InputManager</param>
    /// <param name="tower">tower, if relevant</param>
    /// <param name="buttonId">tsm buttonId, if relevant</param>
    /// <returns>CustomInput object</returns>
    public CustomInput Activate(InputManager inputManager, TowerToSimulation tower = null, string buttonId = null)
    {
        var customInput = new SelectPointInput
        {
            active = true,
            inputManager = inputManager,
            tower = tower ??
                    new TowerToSimulation(inputManager.Bridge, new Tower
                    {
                        Id = ObjectId.Invalid, towerModel = TowerModel.Create()
                    }),
            buttonId = buttonId
        };
        ActiveInput = this;
        return customInput;
    }

    /// <summary>
    /// Deactivates the specified CustomInput
    /// </summary>
    /// <param name="customInput">CustomInput</param>
    public static void Deactivate(CustomInput customInput)
    {
        customInput.active = false;
        ActiveInput = null;
    }

    /// <inheritdoc />
    public override void Register()
    {
        CustomInputById[Id] = this;
    }

    /// <summary>
    /// <seealso cref="CustomInput.EnterInputMode"/>
    /// </summary>
    public virtual void EnterInputMode(CustomInput customInput)
    {
    }

    /// <summary>
    /// <seealso cref="CustomInput.ExitInputMode"/>
    /// </summary>
    public virtual void ExitInputMode(CustomInput customInput)
    {
    }

    /// <summary>
    /// <seealso cref="CustomInput.Update"/>
    /// </summary>
    public virtual void Update(CustomInput customInput, Vector3 cursorPosUnityWorld, Vector2 cursorPosWorld,
        bool isCursorActive)
    {
    }

    /// <summary>
    /// <seealso cref="CustomInput.OnValidPositionCursorUp"/>
    /// </summary>
    public virtual void OnValidPositionCursorUp(CustomInput customInput, Vector2 cursorPosWorld, bool isCursorInWorld)
    {
        customInput.inputManager.ExitCustomMode();
    }

    /// <summary>
    /// <seealso cref="CustomInput.OnInvalidPositionCursorUp"/>
    /// </summary>
    public virtual void OnInvalidPositionCursorUp(CustomInput customInput, Vector2 cursorPosWorld, bool isCursorInWorld)
    {
    }

    /// <summary>
    /// <seealso cref="CustomInput.IsPositionValid"/>
    /// </summary>
    public virtual bool IsPositionValid(CustomInput customInput, Vector2 cursorPosWorld, bool isCursorInWorld)
    {
        return true;
    }

    /// <summary>
    /// <seealso cref="CustomInput.GetHelperMessage"/>
    /// </summary>
    public virtual string GetHelperMessage(CustomInput customInput)
    {
        return "";
    }

    /// <summary>
    /// <seealso cref="CustomInput.GetCantActivateMessage"/>
    /// </summary>
    public virtual string GetCantActivateMessage(CustomInput customInput)
    {
        return "";
    }
}