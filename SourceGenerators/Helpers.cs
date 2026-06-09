using Microsoft.CodeAnalysis;
namespace BTD_Mod_Helper.SourceGenerators;

public static class Helpers
{
    public static IncrementalValueProvider<(T1, T2, T3)> Combine<T1, T2, T3>(
        this IncrementalValueProvider<T1> a,
        IncrementalValueProvider<T2> b,
        IncrementalValueProvider<T3> c) =>
        a.Combine(b).Combine(c).Select(static (x, _) =>
            (x.Left.Left, x.Left.Right, x.Right));

    public static IncrementalValueProvider<(T1, T2, T3, T4)> Combine<T1, T2, T3, T4>(
        this IncrementalValueProvider<T1> a,
        IncrementalValueProvider<T2> b,
        IncrementalValueProvider<T3> c,
        IncrementalValueProvider<T4> d) =>
        a.Combine(b).Combine(c).Combine(d).Select(static (x, _) =>
            (x.Left.Left.Left, x.Left.Left.Right, x.Left.Right, x.Right));

    public static IncrementalValueProvider<(T1, T2, T3, T4, T5)> Combine<T1, T2, T3, T4, T5>(
        this IncrementalValueProvider<T1> a,
        IncrementalValueProvider<T2> b,
        IncrementalValueProvider<T3> c,
        IncrementalValueProvider<T4> d,
        IncrementalValueProvider<T5> e) =>
        a.Combine(b).Combine(c).Combine(d).Combine(e).Select(static (x, _) =>
            (x.Left.Left.Left.Left, x.Left.Left.Left.Right, x.Left.Left.Right, x.Left.Right, x.Right));
}