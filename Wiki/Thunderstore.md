# Thunderstore

BloonsTD6 is now supported by [Thunderstore](https://thunderstore.io/) and [its mod manager](https://github.com/ebkr/r2modmanPlus).

When you download BTD6 Mod Helper from Thunderstore, it is a "Lite" build without the in game Mod Browser and functionality for enabling / disabling mods, as Thunderstore's Mod Manager takes care of that.
Mod Settings management and all other features are still fully present.

## Downloading Mods with Thunderstore

BTD6 modding with Thunderstore is very straightforward.

1. Download/install the Thunderstore Mod Manager from one of the official sources:
   - [r2modmanPlus GitHub](https://github.com/ebkr/r2modmanPlus/releases/latest)
     - For Windows, you can download either `r2modman-Setup-x.x.x.exe` if you want an Installer or `r2modman-x.x.x.exe` if you don't
   - [Thunderstore page](https://thunderstore.io/c/riskofrain2/p/ebkr/r2modman/)
   - [Overwolf](https://www.overwolf.com/app/thunderstore-thunderstore_mod_manager)
2. Run the Mod Manager and find BloonsTD6 within the list of Communities
   - You can click "Set Default" if you want to avoid having to find it again each time you open
3. Select the Default profile or customize one yourself
4. In the "Mods" section on the left, you can go to the "Online" tab to download mods, and the "Installed" tab to manage your local mods
   - Mods you download will have MelonLoader and Btd6ModHelper as dependencies, so those will be downloaded automatically with them
5. Press the "Start modded" button to start the game with your installed mods

## Uploading Mods to Thunderstore

Thunderstore packages are controlled by a `thunderstore.toml` file at the top level of your mod project. Recent mods created from the official mod template / Create Mod button will start out with one of these, otherwise you can see below for an example

### `thunderstore.toml`

```toml
[package]
name = "TemplateMod" # The Thunderstore package name. This should usually match your mod name (no spaces).
namespace = "" # The Thunderstore team that owns the package. Create this team on Thunderstore first.
description = "" # Short description shown on Thunderstore package listings. Max 256 characters
websiteUrl = "" # Optional project URL shown on Thunderstore. Your GitHub repository is a good default.

# Thunderstore package dependencies use the format Namespace-PackageName = "version".
# Versions listed are minimums, not exact requirements, so it's ok if you don't change these frequenty
[package.dependencies]
LavaGang-MelonLoader = "0.7.3"
doombubbles-Btd6ModHelper = "3.6.5"

[build]
icon = "./Icon.png"
readme = "./README.md"
outdir = "bin"

[[build.copy]] # Make sure this matches your mod's dll name
source = "./bin/Release/TemplateMod.dll"
target = "TemplateMod.dll"

[[build.copy]]
source = "./CHANGELOG.md"
target = "./CHANGELOG.md"

[[build.copy]]
source = "./LICENSE"
target = "./LICENSE"

[publish]
repository = "https://thunderstore.io"
communities = ["bloons-td-6"]
categories = ["mods"]
```

Note that this example does not include a `version` property, as that is intended to be set by the GitHub actions workflow. 

### Thunderstore setup

Before GitHub Actions can publish for you, you must 

1. [Sign in to Thunderstore via GitHub](https://auth.thunderstore.io/auth/login/github/?next=https%3A%2F%2Fthunderstore.io%2Fteams%2F)
2. Create a Team on [the Teams page](https://thunderstore.io/settings/teams/) (preferably with the same name as your GitHub account)
3. Use that Team name as the `namespace` in `thunderstore.toml`.
4. On the page for that team, go to the Service Accounts tab and click Add Service Account and name it "Github" (or whatever you'd like)
5. Copy the API token being displayed and store it in a secure location (NOT IN YOUR REPO!)
6. Now in your GitHub repository, go to `Settings > Secrets and variables > Actions` and add a repository secret named `TCLI_AUTH_TOKEN` with the Thunderstore API token as its value.
   - If you have [GitHub CLI](https://cli.github.com/), you could instead do `gh secret set TCLI_AUTH_TOKEN --body "THE_TOKEN_CONTENT_HERE"`

### GitHub Actions

Mod Helper's source generator keeps `.github/workflows/build.yml` in sync with your project.
When a `thunderstore.toml` file exists in your project, the workflow will include Thunderstore packaging and publishing steps.
This also includes ensuring your Icon is the right size and pre-processing your README for Thunderstore.

<details>
<summary>Full Workflow Details</summary>

On release builds, the workflow will:

- Install `tcli`, the Thunderstore CLI.
- Install Node and use `sharp` to resize your icon to Thunderstore's required `256x256` size.
- Prepare your `README.md` for Thunderstore by removing sections wrapped in `THUNDERSTORE EXCLUDE START` / `THUNDERSTORE EXCLUDE END`.
- Remove HTML download banners that link directly to `.dll` files.
- Rewrite relative README links and images to absolute GitHub URLs so they work on Thunderstore.
- Run `tcli build --package-version <release tag>`.
- Upload the built Thunderstore package as a GitHub Actions artifact.
- Publish the package with `tcli publish` using the `TCLI_AUTH_TOKEN` secret.

</details>

### Releasing

The GitHub actions workflow will run when you push a Git tag or simply when you run it manually from the Actions tab of your repository.

The release tag is also used as the Thunderstore package version, so keep it aligned with your `ModHelperData.Version` and changelog.

If you want specific text in your README to appear only on GitHub and not on Thunderstore, wrap it like this:

```md
<!-- THUNDERSTORE EXCLUDE START -->
GitHub-only content here.
<!-- THUNDERSTORE EXCLUDE END -->
```
