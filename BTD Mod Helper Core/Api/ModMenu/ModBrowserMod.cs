using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Octokit;

namespace BTD_Mod_Helper.Api.ModMenu
{
    internal class ModBrowserMod
    {
        private const string DefaultIcon = "Icon.png";
        private const string ModHelperData = "ModHelperData.cs";
        
        private const string VersionRegex = "string Version = \"([.0-9]+)\";\n";
        private const string NameRegex = "string Name = \"(.+)\";\n";
        private const string DescriptionRegex = "string Description = \"(.+)\";\n";
        private const string IconRegex = "string Icon = \"(.+)\\.png\";\n";

        private string descriptionOverride;
        private string nameOverride;
        private string iconOverride;

        public ModBrowserMod(Repository repository)
        {
            Repository = repository;
        }

        public string Owner => Repository.Owner.Name;
        public string Name => nameOverride ?? Repository.Name;
        public string Description => descriptionOverride ?? Repository.Description;
        public string Branch => Repository.DefaultBranch;

        public string Version { get; private set; }
        public byte[] Icon { get; private set; }
        public bool Valid { get; private set; }


        public Repository Repository { get; }

        private string GetContentURL(string name)
        {
            return $"{ModHelperGithub.RawUserContent}/{Owner}/{Name}/{Branch}/{name}";
        }

        public async Task GetModHelperData()
        {
            try
            {
                var modHelperData = await ModHelperHttp.Client.GetStringAsync(GetContentURL(ModHelperData));

                if (Regex.Match(modHelperData, VersionRegex) is Match versionMatch)
                {
                    Version = versionMatch.Groups[0].Value;
                }

                if (Regex.Match(modHelperData, NameRegex) is Match nameMatch)
                {
                    nameOverride = nameMatch.Groups[0].Value;
                }

                if (Regex.Match(modHelperData, DescriptionRegex) is Match descriptionMatch)
                {
                    descriptionOverride = descriptionMatch.Groups[0].Value;
                }

                if (Regex.Match(modHelperData, DescriptionRegex) is Match iconMatch)
                {
                    iconOverride = iconMatch.Groups[0].Value;
                }
                
                Valid = true;
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        public async void GetIcon(string icon)
        {
            try
            {
                Icon = await ModHelperHttp.Client.GetByteArrayAsync(GetContentURL(icon));
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Failed to get Icon for mod {Name}");
            }
        }
    }
}