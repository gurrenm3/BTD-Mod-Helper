# Btd6ModHelper.Tools

Git hook support for BTD6 Mod Helper projects.

## Optional installation

```powershell
dotnet tool install --global Btd6ModHelper.Tools
```

Mod Helper's source generators create a managed post-commit hook for Git projects and also create a pre-commit hook
when the project has a `CHANGELOG.md`. They use the installed command when available, otherwise .NET 10 downloads and
runs the pinned package version with `dotnet tool exec`. Installing globally avoids that resolution overhead but is not
required.
The fallback requires .NET 10 and access to a NuGet source containing the package.

## Commands

```powershell
btd6mh pre-commit
btd6mh post-commit
```

`pre-commit` compares the staged `ModHelperData.cs`, `.json`, or `.txt` with `HEAD`. If its semantic version increased,
it rotates `## [Unreleased]` to a dated section, updates Keep a Changelog comparison links, stages the changelog, and
allows the commit to continue. Repositories without a changelog are left unchanged.

`post-commit` compares the completed commit with its parent and creates an annotated local version tag when
`ModHelperData.Version` increased. Existing tags are never moved. Push a generated tag explicitly with
`git push origin TAG`.
