using System;
namespace BTD_Mod_Helper.Api.Attributes;

/// <summary>
/// Signals that this ModContent should not be automatically loaded by Mod Helper.
/// Will also skip the Registration phase unless it's loaded manually
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class DontLoadAttribute : Attribute;