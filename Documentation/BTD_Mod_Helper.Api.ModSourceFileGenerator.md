#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api](README.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## ModSourceFileGenerator Class

ModContent class for code/data generators that write files into a mod project's source code.  
per output.

```csharp
public abstract class ModSourceFileGenerator : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; ModSourceFileGenerator
### Properties

<a name='BTD_Mod_Helper.Api.ModSourceFileGenerator.FileExt'></a>

## ModSourceFileGenerator.FileExt Property

File extension to use

```csharp
public virtual string FileExt { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModSourceFileGenerator.FileName'></a>

## ModSourceFileGenerator.FileName Property

C# class name of the generated file (and its base filename).

```csharp
public virtual string FileName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModSourceFileGenerator.FileNames'></a>

## ModSourceFileGenerator.FileNames Property

Multiple classes to generate, if applicable

```csharp
public virtual System.Collections.Generic.IEnumerable<string> FileNames { get; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Api.ModSourceFileGenerator.GeneratedComment'></a>

## ModSourceFileGenerator.GeneratedComment Property

Comment to include at the top of the file about it being a generated file

```csharp
public virtual string GeneratedComment { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModSourceFileGenerator.Namespace'></a>

## ModSourceFileGenerator.Namespace Property

C# namespace of the generated file.

```csharp
public virtual string Namespace { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModSourceFileGenerator.OutputPath'></a>

## ModSourceFileGenerator.OutputPath Property

Folder segments under the root project that the generated file lives in.

```csharp
public abstract string[] OutputPath { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Api.ModSourceFileGenerator.RootFolder'></a>

## ModSourceFileGenerator.RootFolder Property

`<ModHelperSourceFolder>/BloonsTD6 Mod Helper` — root for everything generators emit.

```csharp
public virtual string RootFolder { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModSourceFileGenerator.RootNamespace'></a>

## ModSourceFileGenerator.RootNamespace Property

Root Namespace for the class to be in before [OutputPath](BTD_Mod_Helper.Api.ModSourceFileGenerator.md#BTD_Mod_Helper.Api.ModSourceFileGenerator.OutputPath 'BTD_Mod_Helper.Api.ModSourceFileGenerator.OutputPath')

```csharp
public virtual string RootNamespace { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='BTD_Mod_Helper.Api.ModSourceFileGenerator.Generate()'></a>

## ModSourceFileGenerator.Generate() Method

Build the file contents into a fresh [System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder') and write them to [OutputPath](BTD_Mod_Helper.Api.ModSourceFileGenerator.md#BTD_Mod_Helper.Api.ModSourceFileGenerator.OutputPath 'BTD_Mod_Helper.Api.ModSourceFileGenerator.OutputPath')/[FileName](BTD_Mod_Helper.Api.ModSourceFileGenerator.md#BTD_Mod_Helper.Api.ModSourceFileGenerator.FileName 'BTD_Mod_Helper.Api.ModSourceFileGenerator.FileName').[FileExt](BTD_Mod_Helper.Api.ModSourceFileGenerator.md#BTD_Mod_Helper.Api.ModSourceFileGenerator.FileExt 'BTD_Mod_Helper.Api.ModSourceFileGenerator.FileExt').

```csharp
public virtual void Generate();
```

<a name='BTD_Mod_Helper.Api.ModSourceFileGenerator.Generate(System.Text.StringBuilder,string)'></a>

## ModSourceFileGenerator.Generate(StringBuilder, string) Method

Append the file's contents to [sb](BTD_Mod_Helper.Api.ModSourceFileGenerator.md#BTD_Mod_Helper.Api.ModSourceFileGenerator.Generate(System.Text.StringBuilder,string).sb 'BTD_Mod_Helper.Api.ModSourceFileGenerator.Generate(System.Text.StringBuilder, string).sb') for the class

```csharp
public virtual void Generate(System.Text.StringBuilder sb, ref string fileName);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModSourceFileGenerator.Generate(System.Text.StringBuilder,string).sb'></a>

`sb` [System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder')

<a name='BTD_Mod_Helper.Api.ModSourceFileGenerator.Generate(System.Text.StringBuilder,string).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModSourceFileGenerator.Generate(System.Text.StringBuilder)'></a>

## ModSourceFileGenerator.Generate(StringBuilder) Method

Append the file's contents to [sb](BTD_Mod_Helper.Api.ModSourceFileGenerator.md#BTD_Mod_Helper.Api.ModSourceFileGenerator.Generate(System.Text.StringBuilder).sb 'BTD_Mod_Helper.Api.ModSourceFileGenerator.Generate(System.Text.StringBuilder).sb')

```csharp
public virtual void Generate(System.Text.StringBuilder sb);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModSourceFileGenerator.Generate(System.Text.StringBuilder).sb'></a>

`sb` [System.Text.StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/System.Text.StringBuilder 'System.Text.StringBuilder')