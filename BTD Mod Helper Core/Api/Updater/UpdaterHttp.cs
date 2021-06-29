using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using MelonLoader;
//using MelonLoader.ICSharpCode.SharpZipLib.Zip;

namespace BTD_Mod_Helper.Api.Updater
{
    internal class UpdaterHttp
    {
        private const string MelonInfoRegex = "MelonInfo\\(.*\"([\\d|\\.]+)\".*\\)";
        private const string DefaultVersion = "1.0.0";

        private static HttpClient client;
        private readonly UpdateInfo updateInfo;

        private UpdaterHttp()
        {
            if (client is null)
                client = CreateHttpClient();
        }

        internal UpdaterHttp(UpdateInfo updateInfo) : this()
        {
            this.updateInfo = updateInfo;
        }


        private static HttpClient CreateHttpClient()
        {
            client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            client.DefaultRequestHeaders.Add("user-agent", " Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0");
            return client;
        }

        internal async Task<List<GithubReleaseInfo>> GetReleaseInfoAsync(string url)
        {
            var tries = 0;
            while (tries < 3)
            {
                try
                {
                    var releaseJson = await client.GetStringAsync(url);
                    return GithubReleaseInfo.FromJson(releaseJson);
                }
                catch (Exception)
                {
                    Thread.Sleep(1000);
                }
                
                tries++;
            }

            throw new HttpRequestException("Failed to retrieve release info");
        }
        
        internal async Task<string> GetMelonInfoAsync(string url)
        {
            var plainTextCS = await client.GetStringAsync(url);

            var match = Regex.Match(plainTextCS, MelonInfoRegex);

            return match.Success ? match.Value : DefaultVersion;
        }
        
        internal async Task<string> GetMelonInfoAsync() => await GetMelonInfoAsync(updateInfo.MelonInfoCsURL);


        public Task<GithubReleaseInfo> GetLatestReleaseAsync() => Task.FromResult(GetLatestReleaseAsync(updateInfo.GithubReleaseURL).Result);

        public Task<GithubReleaseInfo> GetLatestReleaseAsync(string url)
        {
            return Task.FromResult(GetReleaseInfoAsync(url).Result[0]);
        }

        public async Task<bool> IsUpdate()
        {
            if (updateInfo.GithubReleaseURL != "")
            {
                var releaseInfo = await GetLatestReleaseAsync();
                return IsUpdate(updateInfo.CurrentVersion, releaseInfo);
            }
           
            if (updateInfo.MelonInfoCsURL != "")
            {
                var version = await GetMelonInfoAsync();
                return IsUpdate(updateInfo.CurrentVersion, version);
            }

            return false;
        }

        public bool IsUpdate(string currentVersion, GithubReleaseInfo latestReleaseInfo)
        {
            return IsUpdate(currentVersion, latestReleaseInfo?.TagName);
        }

        public bool IsUpdate(string currentVersion, string latestVersion)
        {
            if (string.IsNullOrEmpty(currentVersion) || string.IsNullOrEmpty(latestVersion))
                throw new ArgumentNullException();

            var currentParts = Regex.Split(Regex.Replace(currentVersion, @"\D", "."), @"\.+");
            var latestParts = Regex.Split(Regex.Replace(latestVersion, @"\D", "."), @"\.+");

            
            var length = Math.Max(currentParts.Length, latestParts.Length);
            
            for(var i = 0; i < length; i++)
            {
                int thisPart = 0, thatPart = 0;

                if (i < currentParts.Length)
                {
                    int.TryParse(currentParts[i], out thisPart);
                }
                
                if (i < latestParts.Length)
                {
                    int.TryParse(latestParts[i], out thatPart);
                }
                
                if(thisPart < thatPart)
                    return true;
                if(thisPart > thatPart)
                    return false;
            }

            return false;
        }
        
        public bool IsUpdateOld(string currentVersion, string latestVersion)
        {
            if (string.IsNullOrEmpty(currentVersion) || string.IsNullOrEmpty(latestVersion))
                throw new ArgumentNullException();

            CleanVersionStrings(ref currentVersion, ref latestVersion);

            int.TryParse(currentVersion, out int currentVersionNum);
            int.TryParse(latestVersion, out int latestVersionNum);

            return latestVersionNum > currentVersionNum;
        }
        
        private static void CleanVersionStrings(ref string string1, ref string string2)
        {
            RemoveAllNonNumeric(ref string1);
            RemoveAllNonNumeric(ref string2);
            MakeLengthEven(ref string1, ref string2);
        }

        private static void RemoveAllNonNumeric(ref string str)
        {
            string cleanedStr = "";
            for (int i = 0; i < str.Length; i++)
            {
                var currentLetter = str[i].ToString();
                bool isNumber = Int32.TryParse(currentLetter, out _);
                if (isNumber)
                    cleanedStr += currentLetter;
            }

            str = cleanedStr;
        }

        private static void MakeLengthEven(ref string string1, ref string string2)
        {
            while (string1.Length != string2.Length)
            {
                bool isString1Bigger = string1.Length > string2.Length;

                string1 += isString1Bigger ? "" : "0";
                string2 += isString1Bigger ? "0" : "";
            }
        }


        public async Task<bool> Download(string modDir)
        {
            if (updateInfo.Name == "BloonsTD6 Mod Helper")
            {
                Process.Start(updateInfo.LatestURL);
                MelonLogger.Msg("For the moment, the mod helper can't directly update itself");
                return false;
            }
            
            
            string downloadURL;
            if (updateInfo.GithubReleaseURL != "")
            {
                var releaseInfo = await GetLatestReleaseAsync();
                downloadURL = releaseInfo.Assets.Select(asset => asset.BrowserDownloadUrl.OriginalString)
                    .FirstOrDefault(s => s.EndsWith(".dll") || s.EndsWith(".zip"));
            } else
            {
                downloadURL = updateInfo.LatestURL;
            }

            if (downloadURL == "" || downloadURL == default)
            {
                return false;
            }


            if (!string.IsNullOrEmpty(updateInfo.Location))
            {
                try
                {
                    File.Delete(updateInfo.Location);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            
            var fileName = downloadURL.Substring(downloadURL.LastIndexOf("/", StringComparison.Ordinal));
            if (fileName.Contains("?"))
            {
                fileName = fileName.Substring(0, fileName.IndexOf("?", StringComparison.Ordinal));
            }

            var response = await client.GetAsync(downloadURL);
            var newFile = $"{modDir}\\{fileName}";
            using (var fs = new FileStream(newFile, FileMode.Create))
            {
                await response.Content.CopyToAsync(fs);
            }

            var helperDir = $"{modDir}\\{Assembly.GetExecutingAssembly().GetName().Name}";
            if (fileName.EndsWith(".zip"))
            {
                var zipTemp = $"{helperDir}\\Zip Temp";
                if (Directory.Exists(zipTemp))
                {
                    Directory.Delete(zipTemp, true);
                }
                Directory.CreateDirectory(zipTemp);
                ZipFile.ExtractToDirectory(newFile, zipTemp);

                foreach (var enumerateFile in Directory.EnumerateFiles(zipTemp))
                {
                    var name = Path.GetFileName(enumerateFile);
                    var targetFile = Path.Combine(modDir, name);
                    if (File.Exists(targetFile))
                    {
                        File.Delete(targetFile);
                    }
                    File.Copy(enumerateFile, targetFile);
                    File.Delete(enumerateFile);
                }
                File.Delete(newFile);
            }

            return true;
        }
    }
}
