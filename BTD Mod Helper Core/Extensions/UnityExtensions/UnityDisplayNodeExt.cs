using Assets.Scripts.Unity.Display;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class UnityDisplayNodeExt
    {
        /// <summary>
        /// (Cross-Game compatible) Get all 3D models attached to this UnityDisplayNode. 
        /// </summary>
        /// <param name="unityDisplayNode"></param>
        /// <returns></returns>
        public static List<Transform> Get3DModels(this UnityDisplayNode unityDisplayNode)
        {
            return unityDisplayNode.transform.parent.GetComponentsInChildren<Transform>().ToList();
        }
    }
}
