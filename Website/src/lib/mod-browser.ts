import {
  loadDataFromRepo,
  ModHelperData,
  ModHelperRepoBranch,
  ModHelperRepoName,
  ModHelperRepoOwner,
} from "./mod-helper-data";
import { Octokit } from "octokit";
import { Repository } from "@octokit/webhooks-types";

const RepoTopic = "btd6-mod";
const MonoRepoTopic = "btd6-mods";
const ProductName = "btd-mod-helper";

export type ModdersData = {
  forceVerifiedOnly: boolean;
  verified: string[];
  banned: string[];
  topics: string[];
  bannedMods: string[];
};

const ModdersURL = `https://raw.githubusercontent.com/${ModHelperRepoOwner}/${ModHelperRepoName}/${ModHelperRepoBranch}/modders.json`;

export const getModdersData = async () =>
  (await fetch(ModdersURL).then((response) => response.json())) as ModdersData;

export const populateSpecificMod = async (selectedMod: string) => {
  const octokit = new Octokit();

  const [owner, repo] = selectedMod.split("/");
  const selectedRepo = await octokit.rest.repos.get({ owner, repo });
  if (selectedRepo.data) {
    return await loadDataFromRepo(selectedRepo.data as Repository);
  }

  return undefined;
};

export const populateMods = async (
  onModFound: (data: ModHelperData) => void,
  setTotalCount: (count: number) => void
) => {
  const octokit = new Octokit();

  let goodRepos = 0;
  let badRepos = 0;
  let page = 1;
  let start = Date.now();
  const repoSearch = octokit.rest.search.repos({
    q: `topic:${RepoTopic}`,
    per_page: 100,
    page: page,
  });

  let searchResult = (await repoSearch).data;

  setTotalCount(searchResult.total_count);

  while (searchResult.items && searchResult.items.length > 0) {
    await Promise.all(
      searchResult.items.map(async (repo) => {
        const data = await loadDataFromRepo(repo as Repository);
        if (data) {
          onModFound(data);
          goodRepos++;
        } else {
          badRepos++;
          setTotalCount(searchResult.total_count - badRepos);
        }
      })
    );
    page++;

    const result = await octokit.rest.search.repos({
      q: `topic:${RepoTopic}`,
      per_page: 100,
      page,
    });

    console.log(result.headers);
    console.log(result.status);

    searchResult = result.data;
  }

  setTotalCount(goodRepos);
};
