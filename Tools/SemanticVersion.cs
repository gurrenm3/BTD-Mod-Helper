using System;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;

namespace BTD_Mod_Helper.Tools;

internal sealed partial class SemanticVersion : IComparable<SemanticVersion>
{
    private SemanticVersion(BigInteger major, BigInteger minor, BigInteger patch, string[] prerelease)
    {
        Major = major;
        Minor = minor;
        Patch = patch;
        Prerelease = prerelease;
    }

    public BigInteger Major { get; }
    public BigInteger Minor { get; }
    public BigInteger Patch { get; }
    public string[] Prerelease { get; }

    public static bool TryParse(string value, out SemanticVersion? version)
    {
        var match = VersionPattern().Match(value);
        if (!match.Success)
        {
            version = null;
            return false;
        }

        version = new SemanticVersion(
            BigInteger.Parse(match.Groups["major"].Value, CultureInfo.InvariantCulture),
            ParseOrZero(match.Groups["minor"].Value),
            ParseOrZero(match.Groups["patch"].Value),
            match.Groups["pre"].Success ? match.Groups["pre"].Value.Split('.') : []);
        return true;
    }

    public static SemanticVersion Parse(string value)
    {
        if (!TryParse(value, out var version)) throw new FormatException($"Invalid semantic version '{value}'.");
        return version!;
    }

    public int CompareTo(SemanticVersion? other)
    {
        if (other is null) return 1;
        var result = Major.CompareTo(other.Major);
        if (result != 0) return result;
        result = Minor.CompareTo(other.Minor);
        if (result != 0) return result;
        result = Patch.CompareTo(other.Patch);
        if (result != 0) return result;
        if (Prerelease.Length == 0) return other.Prerelease.Length == 0 ? 0 : 1;
        if (other.Prerelease.Length == 0) return -1;

        for (var i = 0; i < Math.Min(Prerelease.Length, other.Prerelease.Length); i++)
        {
            result = CompareIdentifier(Prerelease[i], other.Prerelease[i]);
            if (result != 0) return result;
        }
        return Prerelease.Length.CompareTo(other.Prerelease.Length);
    }

    private static BigInteger ParseOrZero(string value) =>
        string.IsNullOrEmpty(value) ? BigInteger.Zero : BigInteger.Parse(value, CultureInfo.InvariantCulture);

    private static int CompareIdentifier(string left, string right)
    {
        var leftNumeric = BigInteger.TryParse(left, NumberStyles.None, CultureInfo.InvariantCulture, out var leftNumber);
        var rightNumeric = BigInteger.TryParse(right, NumberStyles.None, CultureInfo.InvariantCulture,
            out var rightNumber);
        if (leftNumeric && rightNumeric) return leftNumber.CompareTo(rightNumber);
        if (leftNumeric) return -1;
        if (rightNumeric) return 1;
        return string.CompareOrdinal(left, right);
    }

    [GeneratedRegex(
        "^(?<major>0|[1-9]\\d*)(?:\\.(?<minor>0|[1-9]\\d*))?(?:\\.(?<patch>0|[1-9]\\d*))?" +
        "(?:-(?<pre>[0-9A-Za-z-]+(?:\\.[0-9A-Za-z-]+)*))?(?:\\+[0-9A-Za-z-]+(?:\\.[0-9A-Za-z-]+)*)?$")]
    private static partial Regex VersionPattern();
}
