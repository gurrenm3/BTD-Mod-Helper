using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BTD_Mod_Helper.Api.Updater
{
    public class UpdateChecker
    {
        private const string MelonInfoRegex = "MelonInfo\\(.*\"([\\d|\\.]+)\".*\\)";
        private const string DefaultVersion = "1.0.0";
        
        
        private static HttpClient client = null;
        public string ReleaseURL { get; set; }

        public UpdateChecker()
        {
            if (client is null)
                client = CreateHttpClient();
        }

        public UpdateChecker(string url) : this()
        {
            ReleaseURL = url;
        }


        private HttpClient CreateHttpClient()
        {
            client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            client.DefaultRequestHeaders.Add("user-agent", " Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0");
            return client;
        }


        public async Task<List<GithubReleaseInfo>> GetReleaseInfoAsync() => GetReleaseInfoAsync(ReleaseURL)?.Result;

        public async Task<List<GithubReleaseInfo>> GetReleaseInfoAsync(string url)
        {
            var releaseJson = await client.GetStringAsync(url);
            return GithubReleaseInfo.FromJson(releaseJson);
        }
        
        public async Task<string> GetMelonInfoAsync(string url)
        {
            var plainTextCS = await client.GetStringAsync(url);

            var match = Regex.Match(plainTextCS, MelonInfoRegex);

            return match.Success ? match.Value : DefaultVersion;
        }
        
        public async Task<string> GetMelonInfoAsync() => await GetMelonInfoAsync(ReleaseURL);


        public async Task<GithubReleaseInfo> GetLatestReleaseAsync() => GetLatestReleaseAsync(ReleaseURL).Result;

        public async Task<GithubReleaseInfo> GetLatestReleaseAsync(string url)
        {
            return GetReleaseInfoAsync(url).Result[0];
        }


        public bool IsUpdate(string currentVersion, GithubReleaseInfo latestReleaseInfo)
        {
            return IsUpdate(currentVersion, latestReleaseInfo?.TagName);
        }

        public bool IsUpdate(string currentVersion, string latestVersion)
        {
            if (string.IsNullOrEmpty(currentVersion) || string.IsNullOrEmpty(latestVersion))
                throw new ArgumentNullException();

            CleanVersionStrings(ref currentVersion, ref latestVersion);

            Int32.TryParse(currentVersion, out int currentVersionNum);
            Int32.TryParse(latestVersion, out int latestVersionNum);

            return latestVersionNum > currentVersionNum;
        }


        private void CleanVersionStrings(ref string string1, ref string string2)
        {
            RemoveAllNonNumeric(ref string1);
            RemoveAllNonNumeric(ref string2);
            MakeLengthEven(ref string1, ref string2);
        }

        private void RemoveAllNonNumeric(ref string str)
        {
            string cleanedStr = "";
            for (int i = 0; i < str.Length; i++)
            {
                var currentLetter = str[i].ToString();
                bool isNumber = Int32.TryParse(currentLetter, out int num);
                if (isNumber)
                    cleanedStr += currentLetter;
            }

            str = cleanedStr;
        }

        private void MakeLengthEven(ref string string1, ref string string2)
        {
            while (string1.Length != string2.Length)
            {
                bool isString1Bigger = string1.Length > string2.Length;

                string1 += isString1Bigger ? "" : "0";
                string2 += isString1Bigger ? "0" : "";
            }
        }
    }
}
