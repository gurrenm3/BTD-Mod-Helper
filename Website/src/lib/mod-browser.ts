import {
  getContentUrl,
  loadDataFromMonoRepo,
  loadDataFromRepo,
  ModHelperData,
  ModHelperRepoBranch,
  ModHelperRepoName,
  ModHelperRepoOwner,
} from "./mod-helper-data";
import { Octokit } from "octokit";
import { Release, Repository } from "@octokit/webhooks-types";
import { ReleaseWithMod } from "../components/mod-browser";

const RepoTopic = "btd6-mod";
const MonoRepoTopic = "btd6-mods";

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

  const [owner, repo, subpath] = selectedMod.split("/");
  const selectedRepo = await octokit.rest.repos.get({ owner, repo });
  if (selectedRepo.data) {
    return await loadDataFromRepo(
      selectedRepo.data as unknown as Repository,
      subpath
    );
  }

  return undefined;
};

const PerPage = 100;

export const populateMods = async (
  onModFound: (data: ModHelperData) => boolean,
  setTotalCount: (count: number) => void
) => {
  const octokit = new Octokit();

  let validMods = new Set();
  let invalidMods = 0;
  let page = 1;
  const repoSearch = octokit.rest.search.repos({
    q: `topic:${RepoTopic}`,
    per_page: PerPage,
    page: page,
    sort: "updated",
  });

  let searchResult = (await repoSearch).data;

  setTotalCount(searchResult.total_count);

  while (searchResult.items && searchResult.items.length > 0) {
    await Promise.all(
      searchResult.items.map(async (repo) => {
        const data = await loadDataFromRepo(repo as Repository);
        if (data && onModFound(data)) {
          validMods.add(data.Identifier);
        } else {
          invalidMods++;
        }
      })
    );
    page++;

    const result = await octokit.rest.search.repos({
      q: `topic:${RepoTopic}`,
      per_page: PerPage,
      page,
      sort: "updated",
    });

    searchResult = result.data;
  }

  const monoRepoSearchResult = (
    await octokit.rest.search.repos({
      q: `topic:${MonoRepoTopic}`,
      per_page: PerPage,
    })
  ).data;

  if (monoRepoSearchResult.items && monoRepoSearchResult.items.length > 0) {
    for (let repo of monoRepoSearchResult.items) {
      const datas = await loadDataFromMonoRepo(repo as Repository);
      setTotalCount(
        searchResult.total_count +
          monoRepoSearchResult.total_count +
          datas.length
      );
      for (let data of datas) {
        if (data && onModFound(data)) {
          validMods.add(data.Identifier);
        } else {
          invalidMods++;
        }
      }
    }
  }

  setTotalCount(validMods.size);
};

export const downloadMod = async (
  mod: ModHelperData,
  showRelease?: (release: ReleaseWithMod) => void,
  setSelectedMod?: (mod: ModHelperData) => void
) => {
  if (!mod.LatestRelease) {
    const octokit = new Octokit();
    mod.LatestRelease = octokit.rest.repos
      .getLatestRelease({
        owner: mod.RepoOwner,
        repo: mod.RepoName,
      })
      .then((value) => value.data as Release)
      .catch(() => null);
  }

  const release = (await mod.LatestRelease) as ReleaseWithMod;

  if (release) {
    release.mod = mod;
    if (showRelease) {
      showRelease(release);
    } else {
      downloadRelease(release);
      if (mod.Dependencies && setSelectedMod) {
        setSelectedMod(mod);
      }
    }
    return;
  }

  await downloadDllFromModHelperData(mod);

  if (mod.Dependencies && setSelectedMod) {
    setSelectedMod(mod);
  }

  /*if (!mod.LatestCommit) {
    const octokit = new Octokit();
    mod.LatestCommit = octokit.rest.repos
      .listCommits({
        path,
        owner: mod.RepoOwner,
        repo: mod.RepoName,
      })
      .then((value) => value.data[0] as Commit)
      .catch((reason) => null);
  }*/
};

const toPascalCaseDllName = (value?: string) => {
  const pascalCase = value
    ?.replace(/([a-z])([A-Z])/g, "$1 $2")
    .split(/[^a-zA-Z0-9]+/)
    .filter(Boolean)
    .map((part) => part[0].toUpperCase() + part.slice(1))
    .join("");

  return pascalCase ? `${pascalCase}.dll` : undefined;
};

const getLatestReleaseDownloadUrl = (mod: ModHelperData, dllName: string) =>
  `https://github.com/${mod.RepoOwner}/${
    mod.RepoName
  }/releases/latest/download/${encodeURIComponent(dllName)}`;

const downloadDllFromModHelperData = async (mod: ModHelperData) => {
  const dllName =
    mod.DllName ||
    toPascalCaseDllName(mod.Namespace) ||
    toPascalCaseDllName(mod.RepoName) ||
    toPascalCaseDllName(mod.Name);

  if (dllName) {
    window.open(getLatestReleaseDownloadUrl(mod, dllName), "_blank");
  }
};

export const downloadRelease = (release: ReleaseWithMod) => {
  if (!release) return;
  const mod = release.mod;

  const asset =
    release.assets.find(
      (asset) => asset.name === mod.DllName || asset.name === mod.ZipName
    ) ?? release.assets[0];

  if (asset) {
    window.open(asset.browser_download_url, "_blank");
  } else {
    void downloadDllFromModHelperData(mod);
  }
};
