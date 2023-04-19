# Disclaimers

**There will be a 0 strike policy for inappropriate content on the Mod Browser. This includes but is not limited to:**
- Content that violates Ninja Kiwi's terms of service
- Content whose only purpose is hacking / cheating progression within the game
- Content not appropriate for all ages
- Content promoting hatred / discrimination

_This is the Monkey vs Balloon game we're talking about here people_

An unverified modder that posts this content will have their GitHub account blacklisted. A verified modder will lose their verification status and possibly get blacklisted depending on severity.

If too many violations occur to be reasonably dealt with, the option for users to see unverified content at all will be removed.

# Requirements

**Showing up in the Mod Browser requires two major things on your end, and one thing on the user's end**
- Having your mod in a public GitHub Repository that has the `btd6-mod` topic applied to it
- Having a correctly formatted `ModHelperData` file accessible at the top level of your repository 
- If you're not a verified modder on either of the two major BTD6 modding Discord servers, the user will need to have manually enabled the "Show Unverified Mod Browser Content" setting

For it to be a valid `ModHelperData` file, it must either:
1. Be `ModHelperData.json` a json file (optionally embedded in your project) that defined the `ModHelperData` fields in a standard one level json object like
```json5
{
    "Name": "Template Mod",
    "Description": "An empty mod",
    // ...
}
```
2. Be `ModHelperData.cs`, a source code file you compile with your mod that defines the `ModHelperData` fields as `const`s like
```cs
namespace TemplateMod;

public static class ModHelperData
{
    public const string Name = "Template Mod";
    public const string Description = "An empty mod";
    ...
}
```
3. Be `ModHelperData.txt`, using the same parsing as *.cs but not pretending to be a source code file if you're not using it as one. You can even simplify the fields to be like
```
Name = "Template Mod"
Description = "An empty mod"
...
```

<details><summary>Regex Parsings for *.cs and *.txt if you want to manually check</summary>

```
SemVerRegex = "(?:\\d+)(?>\\.(?:\\d+))?(?>\\.(?:\\d+))?(?>\\-(?:[0-9A-Za-z\\-\\.]+))?(?>\\+(?:[0-9A-Za-z\\-\\.]+))?";
VersionRegex = "\\bVersion\\s*=\\s*\"(" + SemVerRegex + ")\";?[\n\r]+";
NameRegex = "\\bName\\s*=\\s*\"(.+)\";?[\n\r]+";
DescRegex = "\\bDescription\\s*=(?:[\\s+]*\"(.+)\")+;?[\n\r]+";
IconRegex = "\\bIcon\\s*=\\s*\"(.+\\.png)\";?[\n\r]+";
DllRegex = "\\bDllName\\s*=\\s*\"(.+\\.dll)\";?[\n\r]+";
RepoNameRegex = "\\bRepoName\\s*=\\s*\"(.+)\";?[\n\r]+";
RepoOwnerRegex = "\\bRepoOwner\\s*=\\s*\"(.+)\";?[\n\r]+";
ManualDownloadRegex = "\\bManualDownload\\s*=\\s*(false|true);?[\n\r]+";
ZipRegex = "\\bZipName\\s*=\\s*\"(.+)\\.zip\";?[\n\r]+";
AuthorRegex = "\\bAuthor\\s*=\\s*\"(.+)\";?[\n\r]+";
SubPathRegex = "\\bSubPath\\s*=\\s*\"(.+)\";?[\n\r]+";
```

</details/>


If you do use the *.cs way, you can also then directly use the values in your MelonInfoAttribute, so you only have to keep track of them in one place
```cs
[assembly: MelonInfo(typeof(YourMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
```

## ModHelperData fields

### Required

`Name` (string): The displayed name of your mod, as you'd like it to appear in screens like the Mod Menu and Mod Browser

`Version` (string): The current version of your mod. Must follow proper [semantic versioning](https://semver.org/) guidelines for updating to work.

`RepoName` (string) and `RepoOwner` (string): Must match the GitHub repo that your hosting the mod at, and are used in game to determine mod updates through the GitHub API.

`WorksOnVersion` (string): As of BTD6 v34 and the switch to MelonLoader 6.0, a string value is required here that's semantically at/above "34" to signify that your mod is compatible with the latest versions of the game. Usage of this field may expand in the future, so it's recommended to keep it relatively up to date it alongside your ModHelperData.


### Optional

`Description` (string): The description of your mod. If not included, the GitHub repo's description will be used.

`Icon` (string): Icon to use for your mod, including the file extension and any /s needed to find the icon from the top level of your repository. File must be under .5 MB. If not set, will check for "Icon.png" at the top level of the repository.

`DllName` (string): If your .dll file is a different name than your Assembly name, include that information here (extension included).

`Author` (string): If you want something different to show up as the Author of your mod than the `RepoOwner`, define that here.

`ManualDownload` (bool): If your release asset to be downloaded through users' browser rather than trying to download the release asset in game.

`ZipName` (string): If you want to upload your mod DLL inside a zip file, specify the correct name of the zip file (extension included) here. NOTE: If you do not include a DllName to look for inside the zip, it will override to being `ManualDownload`. If you have multiple files / folders needing to be downloaded in your Zip, it will need to be a `ManualDownload` one way or another based on current Mod Helper capability.

`SquareIcon` (bool): Makes your icon draw as constrained within panels rather than being allowed to slightly overflow.

`SubPath` (string): See Experimental: MonoRepo support below 

## Updating

If an installed mod has `ModHelperData.cs` in their code or `ModHelperData.json / `ModHelperData.txt` included as an embedded resource, it will be used to populate that mods information in the Mods Screen.

If it has both a valid `RepoOwner` and `RepoName`, it will check the mod's current version against the version specified in that Repo's `ModHelperData`. If it's an update, this will be indicated to the user and they will then have the option to fetch the latest GitHub release for the repository. The title and message of this release will be shown to the user and, if they accept, they'll download the release artifact specified by `DllName` or `ZipName` or just the first dll file included.

Users will be warned if the Tag used for release does not match the version you specified. This may happen during the hopefully brief window of time between you making the commit that edits your `ModHelperData` and the release of your new version.

## Experimental: [Monorepo](https://en.wikipedia.org/wiki/Monorepo) support

Many modders have ended up making a ton of mods and host all of them within one GitHub repository. I, doombubbles, did this myself to start out with and have since regretted it, as I was just doing it to mimic what others were doing and I no longer think the monorepo structure makes sense all things considered for multiple independent mods. Still, I wanted to add rudimentary support for existing monorepos, even though I myself am migrating my mods out of one.

To set up a Mono Repo:
- Use the `btd6-mods` GitHub topic instead of `btd6-mod`
- Have a `ModHelperMods.json` at the top of your repository that is simply an array of strings which are either the exact names of valid `ModHelperData` files at the top level of the repo, or names of folders that contain a `ModHelperData`.

All the `ModHelperData` files must then:
- Include a `SubPath` field that exactly matches the entry in `ModHelperMods.json` that points at it
- Include the `DllName` field to specify the exact file name to look for at the same level as the `ModHelperData`

See [here](https://github.com/doombubbles/test-btd6-monorepo) for an example of both methods at once

Instead of showing users the latest release message when downloading a new version, it will show the commit message of the most recent commit which changed the DLL file.

The GitHub stars that a monorepo has will be split among the mods it holds, with a "+" indicator afterward in the Mod Browser. No, this isn't fully fair, but neither is giving all the mods all of the stars, and at this point I'd rather incentivize separate repos over monorepos.
