﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BTD_Mod_Helper.Api.ModMenu;

/// <summary>
/// Http client used by the mod helper
/// </summary>
public class ModHelperHttp
{
    /// <summary>
    /// The HttpClient instance
    /// </summary>
    public static HttpClient Client { get; private set; } = null!;

    private const int TimeOutMS = 2000;

    /// <summary>
    /// Initializes the HttpClient
    /// </summary>
    public static void Init()
    {
        Client = new HttpClient();
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        Client.DefaultRequestHeaders.Add("user-agent",
            " Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0");
        Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        // Client.Timeout = TimeSpan.FromMilliseconds(TimeOutMS);
    }

    /// <summary>
    /// Asynchronously downloads from a url to the given file path, returning whether the operation was successful
    /// </summary>
    /// <param name="url">URL to download from</param>
    /// <param name="filePath">File path for the resulting file</param>
    /// <returns>Whether it was sucessful</returns>
    public static async Task<bool> DownloadFile(string url, string filePath)
    {
        try
        {
            var response = await Client.GetAsync(url);
            await using var fs = new FileStream(filePath, FileMode.Create);
            await response.Content.CopyToAsync(fs);

            return true;
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
        }

        return false;
    }

        
    /// <summary>
    /// Downloads and extracts the contents of a zip file into the Zip Temp directory, returning the file paths
    /// of the extracted files
    /// </summary>
    /// <param name="url">URL to download from</param>
    /// <param name="zipName">Name of the temporary zip file (will still be deleted at the end)</param>
    /// <returns>Enumeration of extracted file paths, or null</returns>
    public static async Task<IEnumerable<string>?> DownloadZip(string url, string zipName = "temp.zip")
    {
        try
        {
            var zipTempDir = ModHelper.ZipTempDirectory;
            if (Directory.Exists(zipTempDir))
            {
                Directory.Delete(zipTempDir, true);
            }
            Directory.CreateDirectory(zipTempDir);
            
            var response = await Client.GetAsync(url);
            await using var stream = await response.Content.ReadAsStreamAsync();
            using var zip = new ZipArchive(stream);
            zip.ExtractToDirectory(zipTempDir);

            return Directory.EnumerateFiles(zipTempDir);
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
        }

        return null;
    }
}