import { getJson, getString, parseBool } from "./util";
import { Commit, Release, Repository } from "@octokit/webhooks-types";
import semver from "semver/preload";

const SemVerRegex =
  `(?:\\d+)` +
  `(?>\\.(?:\\d+))?` +
  `(?>\\.(?:\\d+))?` +
  `(?>\\-(?:[0-9A-Za-z\\-\\.]+))?` +
  `(?>\\+(?:[0-9A-Za-z\\-\\.]+))?`;

const VersionRegex = '\\bVersion\\s*=\\s*"(' + ".*" + ')";?[\n\r]+';
const NameRegex = '\\bName\\s*=\\s*"(.+)";?[\n\r]+';
const DescRegex =
  '\\bDescription\\s*=(?:[\\s+]*"(.+)")(?:[\\s+]*"(.+)")?(?:[\\s+]*"(.+)")?(?:[\\s+]*"(.+)")?(?:[\\s+]*"(.+)")?(?:[\\s+]*"(.+)")?(?:[\\s+]*"(.+)")?;?[\n\r]+';
const IconRegex = '\\bIcon\\s*=\\s*"(.+\\.png)";?[\n\r]+';
const DllRegex = '\\bDllName\\s*=\\s*"(.+\\.dll)";?[\n\r]+';
const RepoNameRegex = '\\bRepoName\\s*=\\s*"(.+)";?[\n\r]+';
const RepoOwnerRegex = '\\bRepoOwner\\s*=\\s*"(.+)";?[\n\r]+';
const ManualDownloadRegex = "\\bManualDownload\\s*=\\s*(false|true);?[\n\r]+";
const ZipRegex = '\\bZipName\\s*=\\s*"(.+\\.zip)";?[\n\r]+';
const AuthorRegex = '\\bAuthor\\s*=\\s*"(.+)";?[\n\r]+';
const SubPathRegex = '\\bSubPath\\s*=\\s*"(.+)";?[\n\r]+';
const SquareIconRegex = "\\SquareIcon\\s*=\\s*(false|true);?[\n\r]+";
const ExtraTopicsRegex = '\\bExtraTopics\\s*=\\s*"(.+)";?[\n\r]+';
const WorksOnVersionRegex = '\\bWorksOnVersion\\s*=\\s*"(.+)";?[\n\r]+';
const DependenciesRegex = '\\bDependencies\\s*=\\s*"(.+)";?[\n\r]+';

const ModHelperDataCs = "ModHelperData.cs";
const ModHelperDataJson = "ModHelperData.json";
const ModHelperDataTxt = "ModHelperData.txt";
const ModHelperModsJson = "ModHelperMods.json";

const DescriptionBranchRegex =
  'Mod\\s+Browser\\s+Branch\\s*:\\s*"([a-zA-Z0-9\\.\\-_\\/]+)"';
const DescriptionDataPathRegex =
  'Mod\\s*Helper\\s*Data\\s*:\\s*"([a-zA-Z0-9\\.\\-_\\/ ]+)"';

export const ModHelperRepoOwner = "gurrenm3";
export const ModHelperRepoName = "BTD-Mod-Helper";
export const ModHelperRepoBranch = "master";

export const StoppedWorkingVersion = 34;
export const LatestVersion = 49;

export type ModHelperData = {
  // Serialized
  Version: string;
  Name?: string;
  Description?: string;
  Icon?: string;
  DllName?: string;
  RepoName: string;
  RepoOwner: string;
  ManualDownload?: boolean;
  ZipName?: string;
  Author?: string;
  SubPath?: string;
  SquareIcon?: boolean;
  ExtraTopics?: string;
  WorksOnVersion?: string;
  Dependencies?: string;
  // Not Serialized
  Repository: Repository;
  LatestRelease?: Promise<Release | null> | null;
  LatestCommit?: Promise<Commit | null> | null;
  Branch: string;
  DataPath?: string;
  Topics: string[];
  Identifier: string;
  CountOfMonoRepo?: number;
};

type Types = {
  string: string;
  boolean: boolean;
};

const getRegexMatch = <T extends keyof Types>(
  type: T,
  data: string,
  regex: string | RegExp,
  allowMultiline = false
): Types[T] | undefined => {
  const matches = new RegExp(regex, allowMultiline ? "mg" : "").exec(data);
  if (matches) {
    const match = allowMultiline ? matches.slice(1).join("") : matches["1"];

    if (type === "string") {
      return match as Types[T];
    }

    if (type === "boolean") {
      return parseBool(match) as Types[T];
    }
  }

  return undefined;
};

const readValuesFromString = (
  result: Partial<ModHelperData>,
  data: string,
  allowRepo = false
) => {
  result.Name = getRegexMatch("string", data, NameRegex);
  result.Description = getRegexMatch("string", data, DescRegex, true);
  result.Icon = getRegexMatch("string", data, IconRegex);
  result.DllName = getRegexMatch("string", data, DllRegex);
  result.ManualDownload = getRegexMatch("boolean", data, ManualDownloadRegex);
  result.ZipName = getRegexMatch("string", data, ZipRegex);
  result.Author = getRegexMatch("string", data, AuthorRegex);
  result.SubPath = getRegexMatch("string", data, SubPathRegex);
  if (allowRepo) {
    result.RepoName = getRegexMatch("string", data, RepoNameRegex);
    result.RepoOwner = getRegexMatch("string", data, RepoOwnerRegex);
  }
  result.SquareIcon = getRegexMatch("boolean", data, SquareIconRegex);
  result.ExtraTopics = getRegexMatch("string", data, ExtraTopicsRegex);
  result.WorksOnVersion = getRegexMatch("string", data, WorksOnVersionRegex);
  result.Dependencies = getRegexMatch("string", data, DependenciesRegex);
  result.Version = getRegexMatch("string", data, VersionRegex);
};

const readValuesFromJson = (
  result: Partial<ModHelperData>,
  data: any,
  allowRepo = false
) => {
  const json = JSON.parse(data) || {};
  for (let key in json) {
    if (allowRepo || (key !== "RepoName" && key !== "RepoValue")) {
      result[key] = json[key];
    }
  }
};

export const modDisplayName = (data?: ModHelperData) =>
  data?.Name || data?.RepoName || "";

export const modDisplayAuthor = (data?: ModHelperData) =>
  data?.Author || data?.RepoOwner || "";

export const modDisplayDescription = (data?: ModHelperData) =>
  data?.Description || data?.RepoName || "No Description Provided";

export const modDisplayVersion = (data?: ModHelperData) =>
  data
    ? (data?.Version.toLowerCase().startsWith("v") ? "" : "v") + data?.Version
    : "";

export const modIsOld = (
  data?: ModHelperData,
  cutoff = StoppedWorkingVersion
) => (semver.coerce(data?.WorksOnVersion)?.major ?? 0) < cutoff;

export const getGithubUrl = (data: ModHelperData, path: string = "") => {
  if (
    data.SubPath &&
    !data.SubPath.endsWith(".txt") &&
    !data.SubPath.endsWith(".json")
  ) {
    path = data.SubPath + "/" + path;
  }

  return `https://github.com/${data.RepoOwner}/${data.RepoName}/tree/${data.Branch}/${path}`;
};

export const getStarsUrl = (data?: ModHelperData) =>
  `https://www.github.com/${data?.RepoOwner}/${data?.RepoName}/stargazers`;

export const getStarCount = (data?: ModHelperData) =>
  Math.ceil(
    (data?.Repository?.stargazers_count ?? 0) /
      Math.max(1, data?.CountOfMonoRepo ?? 0)
  );

const hasMissingRepoData = (data: ModHelperData) => {
  if (!semver.coerce(data.Version ?? ""))
    return `${data.Version} is not a valid SemVer`;
  if (!data.RepoName) return `RepoName is null/empty`;
  if (!data.RepoOwner) return "RepoOwner is null/empty";
  if (data.SubPath && !data.DllName && !data.ZipName)
    return "SubPath used without DllName/ZipName";

  return null;
};

export const RawUserContent = "https://raw.githubusercontent.com";

export const getContentUrl = (
  data: Pick<ModHelperData, "SubPath" | "RepoOwner" | "RepoName" | "Branch">,
  name?: string
) => {
  let path = name ? encodeURIComponent(name) : "";

  if (
    data.SubPath &&
    !data.SubPath.endsWith(".json") &&
    !data.SubPath.endsWith(".cs") &&
    !data.SubPath.endsWith(".txt")
  ) {
    path = `${data.SubPath}/${path}`;
  }

  return `${RawUserContent}/${data.RepoOwner}/${data.RepoName}/${data.Branch}/${path}`;
};

export const getIconUrl = (data: ModHelperData) =>
  getContentUrl(data, data.Icon || "Icon.png");

export const loadDataFromRepo = async (
  repo: Repository,
  subPath?: string
): Promise<ModHelperData | undefined> => {
  const modHelperData = {
    RepoName: repo.name,
    RepoOwner: repo.owner.login,
    Repository: repo,
    SubPath: subPath,
    Branch: repo.default_branch,
  } as ModHelperData;

  const branch = getRegexMatch(
    "string",
    repo.description ?? "",
    DescriptionBranchRegex
  );
  if (branch) {
    modHelperData.Branch = branch;
  }

  const dataPath = getRegexMatch(
    "string",
    repo.description ?? "",
    DescriptionDataPathRegex
  );
  if (dataPath) {
    modHelperData.DataPath = dataPath;
  }

  let data: string | undefined;

  if (
    modHelperData.SubPath &&
    (modHelperData.SubPath.endsWith(".txt") ||
      modHelperData.SubPath.endsWith(".json") ||
      modHelperData.SubPath.endsWith(".cs"))
  ) {
    data = await getString(getContentUrl(modHelperData, modHelperData.SubPath));
  } else if (modHelperData.DataPath) {
    data = await getString(
      getContentUrl(modHelperData, modHelperData.DataPath)
    );
  }

  if (!data) {
    try {
      data = await Promise.any([
        getString(getContentUrl(modHelperData, ModHelperDataCs)),
        getString(getContentUrl(modHelperData, ModHelperDataJson)),
        getString(getContentUrl(modHelperData, ModHelperDataTxt)),
      ]);
    } catch (e) {}
  }

  if (!data) {
    console.warn(
      `Didn't find any ModHelperData for ${modHelperData.RepoOwner}/${modHelperData.RepoName}`
    );
    return undefined;
  }

  const json = data.trimStart().startsWith("{");

  if (json) readValuesFromJson(modHelperData, data);
  else readValuesFromString(modHelperData, data);

  const missingRepoData = hasMissingRepoData(modHelperData);
  if (missingRepoData) {
    console.warn(missingRepoData);
    console.warn(modHelperData);
    return undefined;
  }
  if (subPath && modHelperData.SubPath !== subPath) {
    modHelperData.SubPath = subPath;
    console.log(
      `Had to fix SubPath for ${modHelperData.RepoOwner}/${modHelperData.RepoName}/${modHelperData.SubPath}`
    );
  }

  modHelperData.Topics = [
    ...repo.topics,
    ...(modHelperData.ExtraTopics ? modHelperData.ExtraTopics.split(",") : []),
  ];

  modHelperData.Identifier =
    `${modHelperData.RepoOwner}/${modHelperData.RepoName}` +
    (modHelperData.SubPath ? "/" + modHelperData.SubPath : "");

  return modHelperData;
};

export const loadDataFromMonoRepo = async (
  repo: Repository
): Promise<(ModHelperData | undefined)[]> => {
  const modsJsonUrl = getContentUrl(
    {
      RepoOwner: repo.owner.login,
      RepoName: repo.name,
      Branch: repo.default_branch,
    },
    ModHelperModsJson
  );

  let modsJson: string[];

  try {
    modsJson = (await getJson(modsJsonUrl)) as string[];
  } catch (e) {
    return [];
  }

  if (!modsJson) return [];

  return await Promise.all(
    modsJson.map(async (subPath) => {
      const data = await loadDataFromRepo(repo, subPath);
      if (data) {
        data.CountOfMonoRepo = modsJson.length;
      }
      return data;
    })
  );
};

export const findDependencies = (
  mod: ModHelperData,
  modsById: Record<string, ModHelperData>,
  found?: string[]
) => {
  const results: string[] = [];
  if (mod.Dependencies) {
    for (let id of mod.Dependencies.split(",")) {
      if (id in modsById && !found?.includes(id)) {
        results.push(id);
        results.push(...findDependencies(modsById[id], modsById, results));
      }
    }
  }
  return results;
};
