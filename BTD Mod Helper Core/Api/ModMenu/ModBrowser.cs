using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Octokit;

namespace BTD_Mod_Helper.Api.ModMenu
{
    internal static class ModBrowser
    {
        public const string Topic = "btd6-modding";

        public static List<ModHelperData> Mods { get; private set; }
        

        public static async Task PopulateMods()
        {
            var searchRepositoryResult =
                await ModHelperGithub.Client.Search.SearchRepo(new SearchRepositoriesRequest($"topic:{Topic}"));

            var rateLimits = await ModHelperGithub.Client.Miscellaneous.GetRateLimits();
            ModHelper.Msg($"Remaining searches: {rateLimits.Resources.Search.Remaining}");

            var mods = searchRepositoryResult.Items
                .OrderBy(repo => repo.CreatedAt)
                .Select(repo => new ModHelperData(repo))
                .ToArray();

            ModHelper.Msg("finished getting mods");

            Task.WhenAll(mods.Select(data => data.LoadDataFromRepoAsync())).Wait();

            Mods = mods/*.Where(mod => mod.Valid)*/.ToList();
            
            ModHelper.Msg("finished getting mod helper data");
        }
    }
}