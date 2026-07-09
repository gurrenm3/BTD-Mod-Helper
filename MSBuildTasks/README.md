# Btd6ModHelper.MSBuildTasks

MSBuild tasks for BTD6 Mod Helper mod projects.

Projects that import `btd6.targets` automatically reference this package when a local `BTD-Mod-Helper/MSBuildTasks` checkout is not available. When the local repo is available, `btd6.targets` uses the local project output instead.

## ZipEmbeddedResources

Add files to the `ZipEmbeddedResources` item group to embed compressed `.zip` versions of those files instead of embedding the original files:

```xml
<ItemGroup>
    <ZipEmbeddedResources Include="Bytes\*.bytes"/>
</ItemGroup>
```

Files without `Name` metadata are zipped individually under `obj` as `File.ext.zip`, and the original files are removed from `EmbeddedResource`.

To use a custom embedded zip name, add `Name` metadata:

```xml
<ItemGroup>
    <ZipEmbeddedResources Include="Bytes\a.bytes" Name="Packed.bytes.zip"/>
    <ZipEmbeddedResources Include="Bytes\b.bytes" Name="Packed.bytes.zip"/>
</ItemGroup>
```

If `Name` does not end with `.zip`, `.zip` is appended automatically.
