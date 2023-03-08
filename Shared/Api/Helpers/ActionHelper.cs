using System;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Class for converting actions and functions
/// </summary>
public static class ActionHelper
{
    /// <summary>
    /// Converts a nullable function into an action
    /// </summary>
    public static Action CreateFromOptionalFunction(Function funcToExecute)
    {
        return (funcToExecute is null) ? () => { } : new Action(() => { funcToExecute(); });
    }


    /// <summary>
    /// Converts a nullable function into an action
    /// </summary>
    public static Action<T> CreateFromOptionalFunction<T>(Function<T> funcToExecute)
    {
        return (funcToExecute is null) ? t => { } : new Action<T>(_ => { funcToExecute(); });
    }
}