using System;
namespace BTD_Mod_Helper.Api;

internal class Guard
{
    public static void ThrowIfArgumentIsNull(object argumentObject, string argumentName, string message = "")
    {
        if (argumentObject != null)
            return;

        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException(argumentName);
        
        throw new ArgumentNullException(argumentName, message);
    }


    public static void ThrowIfStringIsNull(string stringToCheck, string message)
    {
        if (string.IsNullOrEmpty(stringToCheck))
            throw new ArgumentNullException(message);
    }
}