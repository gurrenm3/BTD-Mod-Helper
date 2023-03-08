using System;
using System.IO;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for streams
/// </summary>
public static class StreamExt
{
    /// <summary>
    /// Synchronously gets the full array of bytes from any stream, disposing with the Stream afterwards
    /// </summary>
    public static byte[] GetByteArray(this Stream stream)
    {
        if (stream == null)
        {
            return null;
        }
            
        try
        {
            using (stream)
            {
                if (stream is MemoryStream memoryStream)
                {
                    return memoryStream.ToArray();
                }

                using (memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
}