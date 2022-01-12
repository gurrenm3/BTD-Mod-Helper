using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Octokit;

namespace BTD_Mod_Helper.Api.ModMenu
{
    internal class ModBrowserMod
    {
        
        public ModBrowserMod(Repository repository)
        {
            Repository = repository;
        }

        public string Owner => Repository.Owner.Name;
        public string Name => ModHelperData?.Name ?? Repository.Name;
        public string Description => ModHelperData?.Description ?? Repository.Description;
        public string Branch => Repository.DefaultBranch;

        public string Version => ModHelperData?.Version;
        public byte[] Icon { get; private set; }

        public ModHelperData ModHelperData { get; private set; }

        public Repository Repository { get; }

        public async void GetIcon(string icon)
        {
            try
            {
                Icon = await ModHelperHttp.Client.GetByteArrayAsync(GetContentURL(icon));
            }
            catch (Exception)
            {
                ModHelper.Warning($"Failed to get Icon for mod {Name}");
            }
        }
    }
}