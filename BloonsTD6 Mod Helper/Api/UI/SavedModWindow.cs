using Newtonsoft.Json.Linq;

namespace BTD_Mod_Helper.Api.UI;

internal readonly record struct SavedModWindow(
    string ID,
    string ModWindow,
    float X,
    float Y,
    float Width,
    float Height,
    string Color,
    bool Locked,
    float BackgroundOpacity,
    float ForegroundOpacity,
    JObject Data
);