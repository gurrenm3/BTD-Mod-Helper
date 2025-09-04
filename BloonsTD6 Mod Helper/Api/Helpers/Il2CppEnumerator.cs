using System;
using System.Collections;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Wrapper for il2cpp enumerator so that it actually extends the normal System enumerator
/// </summary>
public class Il2CppEnumerator<T> : IEnumerator<T>
{
    /// <summary>
    /// The internal il2cpp enumerator being wrapped
    /// </summary>
    public Il2CppSystem.Collections.Generic.IEnumerator<T> Enumerator { get; }

    /// <summary>
    /// Construction a wrapper for an il2cpp enumerator
    /// </summary>
    /// <param name="enumerator"></param>
    public Il2CppEnumerator(Il2CppSystem.Collections.Generic.IEnumerator<T> enumerator)
    {
        Enumerator = enumerator;
    }

    /// <summary>
    /// Construction a wrapper for an il2cpp enumerator
    /// </summary>
    /// <param name="enumerable"></param>
    public Il2CppEnumerator(Il2CppSystem.Collections.Generic.IEnumerable<T> enumerable)
    {
        // ReSharper disable once GenericEnumeratorNotDisposed
        Enumerator = enumerable.GetEnumerator();
    }

    /// <inheritdoc />
    public bool MoveNext() => Enumerator.Cast<Il2CppSystem.Collections.IEnumerator>().MoveNext();

    /// <inheritdoc />
    public void Reset() => Enumerator.Cast<Il2CppSystem.Collections.IEnumerator>().Reset();

    /// <inheritdoc />
    object IEnumerator.Current => Enumerator.Current;

    /// <inheritdoc />
    public T Current => Enumerator.Current;

    /// <inheritdoc />
    public void Dispose() => Enumerator.Cast<Il2CppSystem.IDisposable>().Dispose();

    /// <summary>
    /// Wraps an il2cpp enumerator
    /// </summary>
    /// <param name="enumerator"></param>
    /// <returns></returns>
    public static implicit operator Il2CppEnumerator<T>(Il2CppSystem.Collections.Generic.IEnumerator<T> enumerator) =>
        new(enumerator);

    /// <summary>
    /// Wraps an il2cpp enumerable
    /// </summary>
    /// <param name="enumerator"></param>
    /// <returns></returns>
    public static implicit operator Il2CppEnumerator<T>(Il2CppSystem.Collections.Generic.IEnumerable<T> enumerator) =>
        new(enumerator);
}

/// <summary>
/// Wrapper for il2cpp enumerator so that it actually extends the normal System enumerator
/// </summary>
public class Il2CppEnumerator : IEnumerator, IDisposable
{
    /// <summary>
    /// The internal il2cpp enumerator being wrapped
    /// </summary>
    public Il2CppSystem.Collections.IEnumerator Enumerator { get; }

    /// <summary>
    /// Construction a wrapper for an il2cpp enumerator
    /// </summary>
    /// <param name="enumerator"></param>
    public Il2CppEnumerator(Il2CppSystem.Collections.IEnumerator enumerator)
    {
        Enumerator = enumerator;
    }

    /// <summary>
    /// Construction a wrapper for an il2cpp enumerator
    /// </summary>
    /// <param name="enumerable"></param>
    public Il2CppEnumerator(Il2CppSystem.Collections.IEnumerable enumerable)
    {
        // ReSharper disable once GenericEnumeratorNotDisposed
        Enumerator = enumerable.GetEnumerator();
    }

    /// <inheritdoc />
    public bool MoveNext() => Enumerator.MoveNext();

    /// <inheritdoc />
    public void Reset() => Enumerator.Reset();

    /// <inheritdoc />
    object IEnumerator.Current => Enumerator.Current;

    /// <inheritdoc cref="IEnumerator{T}.Current" />
    public Il2CppSystem.Object Current => Enumerator.Current;

    /// <inheritdoc />
    public void Dispose() => Enumerator.Cast<Il2CppSystem.IDisposable>().Dispose();

    /// <summary>
    /// Wraps an il2cpp enumerator
    /// </summary>
    /// <param name="enumerator"></param>
    /// <returns></returns>
    public static implicit operator Il2CppEnumerator(Il2CppSystem.Collections.IEnumerator enumerator) => new(enumerator);

    /// <summary>
    /// Wraps an il2cpp enumerable
    /// </summary>
    /// <param name="enumerator"></param>
    /// <returns></returns>
    public static implicit operator Il2CppEnumerator(Il2CppSystem.Collections.IEnumerable enumerator) => new(enumerator);
}