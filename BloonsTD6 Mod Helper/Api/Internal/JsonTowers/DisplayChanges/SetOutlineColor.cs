using System.Globalization;
using Il2CppAssets.Scripts.Unity.Display;
using Newtonsoft.Json;
using Color = UnityEngine.Color;
namespace BTD_Mod_Helper.Api.Internal.JsonTowers.DisplayChanges;

[JsonObject(MemberSerialization.OptOut)]
internal class SetOutlineColor : JsonDisplayChange
{
    public RendererType RendererType { get; init; }
    public int Index { get; init; }
    public string Color { get; init; }

    public override void Apply(UnityDisplayNode node)
    {
        if (TryParseColorToFloats(Color, out var r, out var g, out var b, out var a))
        {
            GetRenderer(node, RendererType, Index).SetOutlineColor(new Color(r, g, b, a));
        }
    }

    public static bool TryParseColorToFloats(string colorString, out float r, out float g, out float b, out float a)
    {
        r = g = b = a = 0f;

        if (colorString.StartsWith("#") && colorString.Length == 9) // Ensure it's in the format #RRGGBBAA
        {
            try
            {
                r = byte.Parse(colorString.Substring(1, 2), NumberStyles.HexNumber) / 255f;
                g = byte.Parse(colorString.Substring(3, 2), NumberStyles.HexNumber) / 255f;
                b = byte.Parse(colorString.Substring(5, 2), NumberStyles.HexNumber) / 255f;
                a = byte.Parse(colorString.Substring(7, 2), NumberStyles.HexNumber) / 255f;

                return true;
            }
            catch
            {
                // Parsing failed
                return false;
            }
        }

        return false;
    }

}