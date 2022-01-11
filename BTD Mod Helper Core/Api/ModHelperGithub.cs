using BTD_Mod_Helper.Extensions;
using Octokit;

namespace BTD_Mod_Helper.Api
{
    internal static class ModHelperGithub
    {
        public const string RawUserContent = "https://raw.githubusercontent.com";
        public const string Name = "btd-mod-helper";
        
        public static GitHubClient Client { get; private set; }

        public static void Init()
        {
            Client = new GitHubClient(new ProductHeaderValue(Name));
        }
    }
}