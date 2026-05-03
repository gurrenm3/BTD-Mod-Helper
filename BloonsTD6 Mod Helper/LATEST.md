<!--Mod Browser Message Start-->

- TrySaveToPNG and related methods will now export the full original size of the texture rather than the packed size
  - This affects the `export assets` and `export display` commands
- Updated SetName extension and ModTowerHelper.FinalizeTowerModel to account for the new modelName field
- Fixed another edge case where custom sprites could fail to load and instead just show a white square
- Moved Mod Helper's ILRepack setup into `btd6.targets`, allowing any mod to easily bundle any nuget / library dlls using the `IncludeLibs` property
  - Example in a mod csproj (using IncludeLibs will automatically add ILRepack as a nuget dependency)
    ```csproj
    <ItemGroup>
      <PackageReference Include="Octokit" Version="4.0.3"/>
      <PackageReference Include="FuzzySharp" Version="2.0.2"/>
    </ItemGroup>
    
    <PropertyGroup>
      <IncludeLibs>Octokit,FuzzySharp</IncludeLibs>
    </PropertyGroup>
    ```