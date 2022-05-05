namespace BTD_Mod_Helper;

internal enum LoadEventType
{
    Warning,
    Error
}

internal record struct LoadEvent(LoadEventType Type, string Message);