The Mod Helper contains a simple way to let your mod update automatically.

Your primary decision is whether you're going to use GitHub Releases for your mod or not.

## Using Github Releases

All you have to do is override the `GithubReleaseURL` Property of your Main mod class that extends BloonsTD6 Mod to be a URL that points directly to the API link for your GitHub releases.

For instance, the Mod Helper does:

```public override string GithubReleaseURL => "https://api.github.com/repos/gurrenm3/BTD-Mod-Helper/releases";```

To get the link for your mod, just replace "gurrenm3" with your GitHub username and "BTD-Mod-Helper" with your repository name.

And that's it. Whenever someone launches the game, it will check the tagged version of your latest release to see if the player's version of the mod is up to date, and if not, ask if they want to download the mod that was included with that release.

Note: When using this route, it's very important that your GitHub release versions match up the actual versions of your mods.

## Not Using Github Releases

If you're someone like me (doombubbles) who just has one big GitHub repo for all your mods, then this will be the option for you.

The two things you need to do for this option are: 

First, override the `MelonInfoCsURL` Property of your Main mod class that extends BloonsTD6 Mod to be a URL that points directly to a web-hosted cs file that contains the `MelonInfo` Attribute that has your mod's current version.

For instance, my AutoEscape mod does:

 ```public override string MelonInfoCsURL => "https://raw.githubusercontent.com/doombubbles/BTD6-Mods/main/AutoEscape/Main.cs";```

Because my Main.cs file has the `MelonInfo` attribute with my mod's current version. To get this link, I simply clicked on the Main.cs file in GitHub and clicked the "Raw" button.

Second, override the `LatestURL` Property of your Main mod class to be a URL that points directly to the .dll file of your mod or a .zip file that contains your mod.

For instance, AutoEscape does:

 ```public override string LatestURL => "https://github.com/doombubbles/BTD6-Mods/blob/main/AutoEscape/AutoEscape.dll?raw=true";```

To get this link, I clicked on AutoEscape.dll in GitHub and right clicked on "View raw" and did "Copy Link Address".

And that's it. Whenever someone launches the game, it will check the first URL to see if the player's version of the mod is up to date, and if not, ask if they want to download the mod from the second URL.

