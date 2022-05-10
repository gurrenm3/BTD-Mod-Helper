﻿using UnityEngine;

namespace BTD_Mod_Helper.Extensions
{
    public static class Vector3Ext
    {
        /// <summary>
        /// (Cross-Game compatible) Convert UnityEngine.Vector3 to NinjaKiwi's SMath.Vector3
        /// </summary>
        /// <param name="vector3"></param>
        /// <returns></returns>
        public static Assets.Scripts.Simulation.SMath.Vector3 ToSMathVector(this Vector3 vector3)
        {
            return new Assets.Scripts.Simulation.SMath.Vector3(vector3);
        }
    }
}