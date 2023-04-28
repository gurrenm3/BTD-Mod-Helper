﻿using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MelonLoader.Utils;
namespace BTD_Mod_Helper.Api.ModMenu;

/// <summary>
/// Http client used by the mod helper
/// </summary>
public class ModHelperHttp
{
    /// <summary>
    /// The HttpClient instance
    /// </summary>
    public static HttpClient Client { get; private set; }

    internal static Exception LastException { get; private set; }

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
        UpdateSettings();
    }

    /// <summary>
    /// Asynchronously downloads from a url to the given file path, returning whether the operation was successful
    /// </summary>
    /// <param name="url">URL to download from</param>
    /// <param name="filePath">File path for the resulting file</param>
    /// <returns>Whether it was sucessful</returns>
    public static async Task<bool> DownloadFile(string url, string filePath)
    {
        LastException = null;
        try
        {
            if (!ModHelper.IsNet6)
            {
                Client.MaxResponseContentBufferSize = (long) (MelonMain.ModRequestLimitMb * 1e6);
            }
            var response = await Client.GetAsync(url);
            using var fs = new FileStream(filePath, FileMode.Create);
            await response.Content.CopyToAsync(fs);

            return true;
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
            LastException = e;
        }
        finally
        {
            if (!ModHelper.IsNet6)
            {
                Client.MaxResponseContentBufferSize = (long) (MelonMain.NormalRequestLimit * 1e6);
            }
        }

        return false;
    }


    /// <summary>
    /// Downloads a zip file directly into a zip archive
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static async Task<ZipArchive> GetZip(string url)
    {
        try
        {
            if (!ModHelper.IsNet6)
            {
                Client.MaxResponseContentBufferSize = (long) (MelonMain.ModRequestLimitMb * 1e6);
            }
            var response = await Client.GetAsync(url);
            var stream = await response.Content.ReadAsStreamAsync();
            return new ZipArchive(stream);
        }
        finally
        {
            if (!ModHelper.IsNet6)
            {
                Client.MaxResponseContentBufferSize = (long) (MelonMain.NormalRequestLimit * 1e6);
            }
        }
    }


    /// <summary>
    /// Downloads and extracts the contents of a zip file into the Zip Temp directory, returning the file paths
    /// of the extracted files
    /// </summary>
    /// <param name="url">URL to download from</param>
    /// <param name="path">Path to unzip into, or null for using the zip temp directory</param>
    /// <returns>Enumeration of extracted file paths, or null</returns>
    public static async Task<DirectoryInfo> DownloadZip(string url, string path = null)
    {
        LastException = null;
        try
        {
            if (path == null)
            {
                var zipTempDir = ModHelper.ZipTempDirectory;
                if (Directory.Exists(zipTempDir))
                {
                    Directory.Delete(zipTempDir, true);
                }

                path = zipTempDir;
            }

            Directory.CreateDirectory(path);

            using var zip = await GetZip(url);
            zip.ExtractToDirectory(path);

            return new DirectoryInfo(path);
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
            LastException = e;
        }

        return null;
    }

    internal static void UpdateSettings()
    {
        try
        {
            Client.Timeout = TimeSpan.FromSeconds(MelonMain.RequestTimeout);

            if (ModHelper.IsNet6)
            {
                Client.MaxResponseContentBufferSize = (long) (MelonMain.ModRequestLimitMb * 1e6);
            }
            else
            {
                Client.MaxResponseContentBufferSize = (long) (MelonMain.NormalRequestLimit * 1e6);
            }
        }
        catch (Exception)
        {
            // ignored
        }
    }

    internal static void DownloadDocumentationXml()
    {
        const string url =
            $"https://github.com/{ModHelper.RepoOwner}/{ModHelper.RepoName}/releases/download/{ModHelper.Version}/{ModHelper.XmlName}";
        Task.Run(async () =>
        {
            try
            {
                await DownloadFile(url, Path.Combine(MelonEnvironment.ModsDirectory, ModHelper.XmlName));
                ModHelper.Msg($"Downloaded {ModHelper.XmlName} for v{ModHelper.Version}");
            }
            catch (Exception e)
            {
                ModHelper.Warning(e);
            }
        });
    }
}