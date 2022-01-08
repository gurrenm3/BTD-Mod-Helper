using System;
using MelonLoader;
using UnityEngine;

namespace BTD_Mod_Helper.Api.Components
{
    /// <summary>
    /// Component to make this transform continuously match the scale of another transform
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class MatchPosition : MonoBehaviour
    {
        /// <summary>
        /// Other transform to constantly copy the scale from
        /// </summary>
        public Transform transformToCopy;

        /// <summary>
        /// Offset from the transform to stay
        /// </summary>
        public Vector3 offset;

        /// <inheritdoc />
        public MatchPosition(IntPtr ptr) : base(ptr)
        {
        }

        private void LateUpdate()
        {
            transform.localPosition = transformToCopy.localPosition + offset;
        }
    }
}