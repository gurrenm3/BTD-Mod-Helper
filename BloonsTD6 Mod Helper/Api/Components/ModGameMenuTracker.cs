using System;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// Component to track that a instance of a GameMenu's gameObject actually is the same ModGameMenu as was opened,
/// as direct comparison on the Unity Objects does not work reliably
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModGameMenuTracker : MonoBehaviour
{
    /// <summary>
    /// The Id of the ModGameMenu that this is for
    /// </summary>
    public string modGameMenuId;
        
    /// <inheritdoc />
    public ModGameMenuTracker(IntPtr ptr) : base(ptr)
    {
    }

    private void Update()
    {
        if (ModGameMenu.Cache.TryGetValue(modGameMenuId ?? "", out var modGameMenu))
        {
            modGameMenu.OnMenuUpdate();
        }
    }

    private void OnDestroy()
    {
        if (ModGameMenu.Cache.TryGetValue(modGameMenuId ?? "", out var modGameMenu))
        {
            modGameMenu.IsOpen = false;
        }
    }
}