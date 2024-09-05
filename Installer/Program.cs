using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using WixSharp;
using WixSharp.Forms;
using WixSharp.Nsis;
using WixToolset.Dtf.WindowsInstaller;
using File = WixSharp.File;

namespace Installer;

internal static class Program
{
    private static void Main()
    {
        var version = GetVersion();

#if STEAM
        const string installLocation = @"%ProgramFiles%\Steam\steamapps\common\BloonsTD6";
#elif EPIC
        const string installLocation = @"%ProgramFiles%\Epic Games\BloonsTD6";
#endif

        var project = new ManagedProject("BloonsTD6 Mod Helper",
            new InstallDir(installLocation,
                new Dir("Mods", new File(@"BloonsTD6\Mods\Btd6ModHelper.dll")),
#if EPIC
                new Dir("Plugins", new File(@"BloonsTD6\Plugins\BTD6EpicGamesModCompat.dll")),
#endif
                new DirFiles(@"BloonsTD6\*.*"),
                new Dir("MelonLoader", AllDirFiles(@"BloonsTD6\MelonLoader")),
                new ExeFileShortcut("Fully Uninstall BTD6 Mods", "[System64Folder]msiexec.exe", "/x [ProductCode]")
            )
        )
        {
            GUID = new Guid("82400c22-86ab-4011-9f0b-2767a7ea7e68"),
            Version = version,
            UI = WUI.WixUI_InstallDir,
            BackgroundImage = "Background.png",
            BannerImage = "Banner.png",
            ManagedUI = new ManagedUI(),
        };
        
#if STEAM
        project.Platform = Platform.x86;
#elif EPIC
        project.Platform = Platform.x64;
#endif

        project.ResolveWildCards();

        project.AfterInstall += OnProjectOnAfterInstall;

        project.SetNetPrerequisite("6.0.0", "core", "latestMajor", "x64");

        project.ManagedUI.InstallDialogs.Add(Dialogs.Welcome)
            .Add(Dialogs.Licence)
            .Add(Dialogs.InstallDir)
            .Add(Dialogs.Progress)
            .Add(Dialogs.Exit);
        project.ManagedUI.ModifyDialogs.Add(Dialogs.MaintenanceType)
            .Add(Dialogs.Progress)
            .Add(Dialogs.Exit);

        var file = project.BuildMsi();


        // Bundle with dotNet 6.0 Installer
        // C:\Program Files\dotnet\

        Environment.SetEnvironmentVariable("WIXSHARP_NSISDIR",
            Path.Combine(PackageLocator.GetLatestVersionPath("NSIS-Tool"), "tools"));

        var setup = new NsisBootstrapper
        {
            DoNotPostVerifyPrerequisite = true,
            PrerequisiteFile = "windowsdesktop-runtime-6.0.29-win-x64.exe",
            PrimaryFile = file,
            PrerequisiteRegKeyValue = @"HKLM:SOFTWARE\dotnet\Setup\InstalledVersions\x64\sharedhost:Path",
            IconFile = "../Website/public/images/ModHelper.ico",
            VersionInfo = new VersionInformation(version.ToString()),
#if STEAM
            OutputFile = "InstallBtd6ModHelperSteam.exe",
#elif EPIC
            OutputFile = "InstallBtd6ModHelperEpic.exe",
#endif
        };

        setup.Build();
    }

    private static readonly string[] ExtraUninstall =
    [
        "MelonLoader",
        "Mods",
        "Plugins",
        "UserData",
        "UserLibs",
        "nfd.dll",
        "nfd_x86.dll"
    ];

    private static void OnProjectOnAfterInstall(SetupEventArgs args)
    {
        if (!args.IsUninstalling && !args.IsUpgradingInstalledVersion) return;

        foreach (var toUninstall in ExtraUninstall)
        {
            Path.Combine(args.InstallDir, toUninstall).DeleteIfExists();
        }
    }

    public static Project SetNetPrerequisite(this Project project, string version, string runtimeType, string rollForward,
        string platform, string errorMessage = null)
    {
        var condition = Condition.Create("Installed OR DotNetCheckResult = 0");
        var message = errorMessage ?? $"Please install .NET version {version} first.";

        project.LaunchConditions.Add(new LaunchCondition(condition, message));

        project.WixSourceGenerated += doc =>
            doc.FindFirst("Package").AddElement(
                WixExtension.NetFx.ToXName("DotNetCompatibilityCheck"),
                $"Property=DotNetCheckResult; RuntimeType={runtimeType}; Version={version}; RollForward={rollForward}; Platform={platform}");

        project.Include(WixExtension.NetFx);

        return project;
    }

    private static WixEntity[] AllDirFiles(string sourcePath, Feature feature = null) =>
    [
        new DirFiles(feature, Path.Combine(sourcePath, "*.*")),
        ..Directory.EnumerateDirectories(sourcePath)
            .Select(entry => new Dir(Path.GetFileName(entry), AllDirFiles(entry, feature)))
    ];

    private static Version GetVersion()
    {
        // From MelonLoader SemVersion
        const string semVerRegex = @"(?:\d+)" +
                                   @"(?>\.(?:\d+))?" +
                                   @"(?>\.(?:\d+))?" +
                                   @"(?>\-(?:[0-9A-Za-z\-\.]+))?" +
                                   @"(?>\+(?:[0-9A-Za-z\-\.]+))?";

        const string versionRegex = "\\bVersion\\s*=\\s*\"(" + semVerRegex + ")\";?[\n\r]+";

        var fileContents = System.IO.File.ReadAllText("../BloonsTD6 Mod Helper/ModHelper.cs");

        var match = Regex.Match(fileContents, versionRegex);

        var version = Version.Parse(match.Groups[1].Value);

        return version;
    }
}