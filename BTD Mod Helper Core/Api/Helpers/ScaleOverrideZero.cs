using System;
using MelonLoader;
using UnityEngine;

namespace BTD_Mod_Helper.Api.Components
{
    /// <summary>
    /// Custom component to keep the scale of a transform permanently at 0, even if an Animator tries to change it
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class ScaleOverrideZero : MonoBehaviour
    {
        
        /// <inheritdoc />
        public ScaleOverrideZero(IntPtr ptr) : base(ptr)
        {
        }
        
        private void LateUpdate()
        {
            transform.localScale = Vector3.zero;
        }
    }
}