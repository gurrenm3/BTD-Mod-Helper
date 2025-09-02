using System;
namespace BTD_Mod_Helper.Api.Attributes;

/// <summary>
/// Signals that this ModContent should not be automatically registered by Mod Helper.
/// Use <see cref="DontLoadAttribute"/> for skipping the loading phase as well
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class DontRegisterAttribute : Attribute
{
}