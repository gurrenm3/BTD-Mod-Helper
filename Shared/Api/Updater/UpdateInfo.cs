using Newtonsoft.Json;

namespace BTD_Mod_Helper.Api.Updater
{
    internal class UpdateInfo
    {
        [JsonProperty] internal string Name { get; set; }

        [JsonProperty] internal string GithubReleaseURL { get; set; }

        [JsonProperty] internal string MelonInfoCsURL { get; set; }

        [JsonProperty] internal string LatestURL { get; set; }

        [JsonProperty] internal string CurrentVersion { get; set; }
        
        [JsonProperty] internal string Location { get; set; }

        public UpdateInfo()
        {
        }

        public UpdateInfo(BloonsMod mod)
        {
#pragma warning disable CS0618
            GithubReleaseURL = mod.GithubReleaseURL;
            MelonInfoCsURL = mod.MelonInfoCsURL;
            LatestURL = mod.LatestURL;
#pragma warning restore CS0618
            Name = mod.Info.Name;
            CurrentVersion = mod.Info.Version;
            Location = mod.Location;
        }
    }
}