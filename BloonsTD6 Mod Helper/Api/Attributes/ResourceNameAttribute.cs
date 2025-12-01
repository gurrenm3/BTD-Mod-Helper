using System;
namespace BTD_Mod_Helper.Api.Attributes;

/// <summary>
/// Marks that this string is the name of an embedded resource
/// </summary>
[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
public class ResourceNameAttribute : Attribute;

/// <summary>
/// Marks that this string is the name of an embedded sprite resource
/// </summary>
[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
public class SpriteNameAttribute : ResourceNameAttribute;

/// <summary>
/// Marks that this string is the name of an embedded audio resource
/// </summary>
[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
public class AudioNameAttribute : ResourceNameAttribute;

/// <summary>
/// Marks that this string is the name of an embedded bundle resource
/// </summary>
[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
public class BundleNameAttribute : ResourceNameAttribute;