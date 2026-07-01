using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace BTD_Mod_Helper.Api;

/// <summary>
/// Easing functions supported by <see cref="Tween"/>.
/// </summary>
public enum Ease
{
    /// <summary>
    /// No easing.
    /// </summary>
    Linear,

    /// <summary>
    /// Starts slowly and accelerates using a sine curve.
    /// </summary>
    InSine,

    /// <summary>
    /// Starts quickly and decelerates using a sine curve.
    /// </summary>
    OutSine,

    /// <summary>
    /// Smooth sine easing in both directions.
    /// </summary>
    InOutSine,

    /// <summary>
    /// Starts slowly and accelerates using a quadratic curve.
    /// </summary>
    InQuad,

    /// <summary>
    /// Starts quickly and decelerates using a quadratic curve.
    /// </summary>
    OutQuad,

    /// <summary>
    /// Smooth quadratic easing in both directions.
    /// </summary>
    InOutQuad,

    /// <summary>
    /// Starts slowly and accelerates using a cubic curve.
    /// </summary>
    InCubic,

    /// <summary>
    /// Starts quickly and decelerates using a cubic curve.
    /// </summary>
    OutCubic,

    /// <summary>
    /// Smooth cubic easing in both directions.
    /// </summary>
    InOutCubic,

    /// <summary>
    /// Overshoots the destination before settling back.
    /// </summary>
    OutBack
}

/// <summary>
/// Helper for performing animation Tweens
/// </summary>
public abstract class Tween
{
    private static readonly Dictionary<int, Tween> Tweens = [];
    private static int nextId;

    internal enum TweenProperty
    {
        None,
        Position,
        LocalPosition,
        Scale,
        Rotation,
        LocalRotation,
        EulerAngles,
        AnchoredPosition,
        SizeDelta,
        GraphicColor,
        CanvasGroupAlpha
    }

    private protected readonly int id;
    private protected readonly Object target;
    private protected readonly float duration;
    private protected readonly Ease ease;
    private protected readonly bool useUnscaledTime;
    private protected readonly TweenProperty property;
    private readonly bool hasTarget;
    private float elapsedTime;

    // ReSharper disable once InconsistentNaming
    private event Action onComplete;

    // ReSharper disable once InconsistentNaming
    private event Action<Tween> onUpdate;

    private protected Tween
    (
        int id,
        Object target,
        float duration,
        Ease ease,
        bool useUnscaledTime,
        TweenProperty property
    )
    {
        this.id = id;
        this.target = target;
        hasTarget = target is not null;
        this.duration = duration;
        this.ease = ease;
        this.useUnscaledTime = useUnscaledTime;
        this.property = property;
    }

    #region State

    /// <summary>
    /// Whether this handle still points to a currently running tween.
    /// </summary>
    public bool IsAlive => Tweens.ContainsKey(id);

    /// <summary>
    /// The elapsed time, in seconds, for the current tween cycle.
    /// </summary>
    public float ElapsedTime
    {
        get => IsAlive ? elapsedTime : 0;
        set
        {
            if (IsAlive)
            {
                elapsedTime = Mathf.Clamp(value, 0, duration);
                Apply();
            }
        }
    }

    /// <summary>
    /// The normalized progress for the current tween cycle.
    /// </summary>
    public float Progress
    {
        get => IsAlive ? duration <= 0 ? 1 : Mathf.Clamp01(elapsedTime / duration) : 0;
        set
        {
            if (IsAlive)
            {
                elapsedTime = Mathf.Clamp01(value) * duration;
                Apply();
            }
        }
    }

    /// <summary>
    /// Whether this tween is currently paused.
    /// </summary>
    public bool IsPaused
    {
        get => IsAlive && field;
        set
        {
            if (IsAlive)
            {
                field = value;
            }
        }
    }

    #endregion

    #region Custom Tweens

    /// <summary>
    /// Creates a tween over a float value.
    /// </summary>
    public static Tween Custom
    (
        float startValue,
        float endValue,
        float duration,
        Action<float> onValueChange,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        return Create(null, startValue, endValue, duration, Mathf.LerpUnclamped, onValueChange, ease, useUnscaledTime);
    }

    /// <summary>
    /// Creates a tween over a float value, associated with a target object for cancellation and lifetime checks.
    /// </summary>
    public static Tween Custom
    (
        Object target,
        float startValue,
        float endValue,
        float duration,
        Action<float> onValueChange,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        return Create(target, TweenProperty.None, startValue, endValue, duration, Mathf.LerpUnclamped, onValueChange,
            ease, useUnscaledTime);
    }

    /// <summary>
    /// Creates a tween over a <see cref="Vector2"/> value.
    /// </summary>
    public static Tween Custom
    (
        Vector2 startValue,
        Vector2 endValue,
        float duration,
        Action<Vector2> onValueChange,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        return Create(null, startValue, endValue, duration, Vector2.LerpUnclamped, onValueChange, ease, useUnscaledTime);
    }

    /// <summary>
    /// Creates a tween over a <see cref="Vector3"/> value.
    /// </summary>
    public static Tween Custom
    (
        Vector3 startValue,
        Vector3 endValue,
        float duration,
        Action<Vector3> onValueChange,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        return Create(null, startValue, endValue, duration, Vector3.LerpUnclamped, onValueChange, ease, useUnscaledTime);
    }

    /// <summary>
    /// Creates a tween over a <see cref="UnityEngine.Color"/> value.
    /// </summary>
    public static Tween Custom
    (
        Color startValue,
        Color endValue,
        float duration,
        Action<Color> onValueChange,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        return Create(null, startValue, endValue, duration, UnityEngine.Color.LerpUnclamped, onValueChange, ease,
            useUnscaledTime);
    }

    #endregion

    #region Transform Tweens

    /// <summary>
    /// Tweens a transform's world position.
    /// </summary>
    public static Tween Position
    (
        Transform target,
        Vector3 endValue,
        float duration,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        return Create(target, TweenProperty.Position, target.position, endValue, duration, Vector3.LerpUnclamped,
            value => target.position = value, ease, useUnscaledTime);
    }

    /// <summary>
    /// Tweens a transform's local position.
    /// </summary>
    public static Tween LocalPosition
    (
        Transform target,
        Vector3 endValue,
        float duration,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        return Create(target, TweenProperty.LocalPosition, target.localPosition, endValue, duration,
            Vector3.LerpUnclamped,
            value => target.localPosition = value, ease, useUnscaledTime);
    }

    /// <summary>
    /// Tweens a transform's local scale.
    /// </summary>
    public static Tween Scale
    (
        Transform target,
        Vector3 endValue,
        float duration,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        return Create(target, TweenProperty.Scale, target.localScale, endValue, duration, Vector3.LerpUnclamped,
            value => target.localScale = value, ease, useUnscaledTime);
    }

    /// <summary>
    /// Tweens a transform's rotation.
    /// </summary>
    public static Tween Rotation
    (
        Transform target,
        Quaternion endValue,
        float duration,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        return Create(target, TweenProperty.Rotation, target.rotation, endValue, duration, Quaternion.LerpUnclamped,
            value => target.rotation = value, ease, useUnscaledTime);
    }

    /// <summary>
    /// Tweens a transform's local rotation.
    /// </summary>
    public static Tween LocalRotation
    (
        Transform target,
        Quaternion endValue,
        float duration,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        return Create(target, TweenProperty.LocalRotation, target.localRotation, endValue, duration,
            Quaternion.LerpUnclamped,
            value => target.localRotation = value, ease, useUnscaledTime);
    }

    /// <summary>
    /// Tweens a transform's local Euler angles.
    /// </summary>
    public static Tween EulerAngles
    (
        Transform target,
        Vector3 endValue,
        float duration,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        return Create(target, TweenProperty.EulerAngles, target.localEulerAngles, endValue, duration,
            Vector3.LerpUnclamped,
            value => target.localEulerAngles = value, ease, useUnscaledTime);
    }

    #endregion

    #region UI Tweens

    /// <summary>
    /// Tweens a RectTransform's anchored position.
    /// </summary>
    public static Tween AnchoredPosition
    (
        RectTransform target,
        Vector2 endValue,
        float duration,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        return Create(target, TweenProperty.AnchoredPosition, target.anchoredPosition, endValue, duration,
            Vector2.LerpUnclamped,
            value => target.anchoredPosition = value, ease, useUnscaledTime);
    }

    /// <summary>
    /// Tweens a RectTransform's size delta.
    /// </summary>
    public static Tween SizeDelta
    (
        RectTransform target,
        Vector2 endValue,
        float duration,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        return Create(target, TweenProperty.SizeDelta, target.sizeDelta, endValue, duration, Vector2.LerpUnclamped,
            value => target.sizeDelta = value, ease, useUnscaledTime);
    }

    /// <summary>
    /// Tweens a UI graphic's color.
    /// </summary>
    public static Tween Color
    (
        Graphic target,
        Color endValue,
        float duration,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        return Create(target, TweenProperty.GraphicColor, target.color, endValue, duration,
            UnityEngine.Color.LerpUnclamped, value => target.color = value, ease, useUnscaledTime);
    }

    /// <summary>
    /// Tweens a CanvasGroup's alpha.
    /// </summary>
    public static Tween Alpha
    (
        CanvasGroup target,
        float endValue,
        float duration,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        return Create(target, TweenProperty.CanvasGroupAlpha, target.alpha, endValue, duration, Mathf.LerpUnclamped,
            value => target.alpha = value, ease, useUnscaledTime);
    }

    #endregion

    #region Controls

    /// <summary>
    /// Stops this tween, optionally completing it first.
    /// </summary>
    public void Stop(bool complete = false)
    {
        if (!IsAlive) return;

        if (complete)
        {
            Complete();
        }
        else
        {
            Remove(this);
        }
    }

    /// <summary>
    /// Completes this tween immediately.
    /// </summary>
    public void Complete()
    {
        if (!IsAlive) return;

        elapsedTime = duration;
        Apply();
        Remove(this);
        onComplete?.Invoke();
    }

    /// <summary>
    /// Adds a callback invoked when this tween completes naturally or via <see cref="Complete"/>.
    /// </summary>
    public Tween OnComplete(Action onComplete)
    {
        this.onComplete += onComplete;
        return this;
    }

    /// <summary>
    /// Adds a callback invoked every time this tween updates.
    /// </summary>
    public Tween OnUpdate(Action<Tween> onUpdate)
    {
        this.onUpdate += onUpdate;
        return this;
    }

    /// <summary>
    /// Stops every tween currently associated with a target.
    /// </summary>
    public static void StopAll(Object target, bool complete = false)
    {
        if (target == null) return;

        foreach (var state in Tweens.Values.ToArray())
        {
            if (!state.IsAlive) continue;
            if (state.target != target) continue;

            if (complete)
            {
                state.Complete();
            }
            else
            {
                Remove(state);
            }
        }
    }

    /// <summary>
    /// Stops all active tweens.
    /// </summary>
    public static void StopAll(bool complete = false)
    {
        if (complete)
        {
            foreach (var state in Tweens.Values.ToArray())
            {
                if (!state.IsAlive) continue;
                state.Complete();
            }
        }
        else
        {
            Tweens.Clear();
        }
    }

    /// <summary>
    /// Swaps the start and end values of this tween. Works if called right after Tween creation to effectively do
    /// "tween from the specified value back to its current value"
    /// </summary>
    public abstract Tween Reverse();

    #endregion

    #region Internal

    internal static void Update()
    {
        foreach (var state in Tweens.Values.ToArray())
        {
            if (!state.IsAlive) continue;

            if (state.hasTarget && !state.target)
            {
                Remove(state);
                continue;
            }

            if (state.IsPaused) continue;

            var deltaTime = state.useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
            if (deltaTime <= 0) continue;

            state.elapsedTime += deltaTime;
            state.Apply();

            if (state.elapsedTime >= state.duration)
            {
                state.Complete();
            }
        }

    }

    private static Tween Create<T>
    (
        Object target,
        T startValue,
        T endValue,
        float duration,
        Func<T, T, float, T> lerp,
        Action<T> onValueChange,
        Ease ease,
        bool useUnscaledTime
    )
    {
        return Create(target, TweenProperty.None, startValue, endValue, duration, lerp, onValueChange, ease,
            useUnscaledTime);
    }

    private static Tween Create<T>
    (
        Object target,
        TweenProperty property,
        T startValue,
        T endValue,
        float duration,
        Func<T, T, float, T> lerp,
        Action<T> onValueChange,
        Ease ease,
        bool useUnscaledTime
    )
    {
        if (onValueChange == null)
        {
            throw new ArgumentNullException(nameof(onValueChange));
        }

        StopConflicting(target, property);

        var id = nextId++;
        var state = new Tween<T>(id, target, startValue, endValue, Mathf.Max(0, duration), lerp, onValueChange,
            ease, useUnscaledTime, property);

        Tweens[id] = state;
        state.Apply();

        if (state.duration == 0)
        {
            state.Complete();
        }

        return state;
    }

    private static void Remove(Tween state)
    {
        Tweens.Remove(state.id);
    }

    private static void StopConflicting(Object target, TweenProperty property)
    {
        if (target == null || property == TweenProperty.None) return;

        foreach (var tween in Tweens.Values.ToArray())
        {
            if (!tween.IsAlive) continue;
            if (tween.target == target && tween.property == property)
            {
                Remove(tween);
            }
        }
    }

    // Easing formulas are based on common Robert Penner easing equations, using the standard 1.70158 back overshoot.
    private protected static float Evaluate(Ease ease, float value)
    {
        value = Mathf.Clamp01(value);

        return ease switch
        {
            Ease.InSine => 1 - Mathf.Cos(value * Mathf.PI / 2),
            Ease.OutSine => Mathf.Sin(value * Mathf.PI / 2),
            Ease.InOutSine => -(Mathf.Cos(Mathf.PI * value) - 1) / 2,
            Ease.InQuad => value * value,
            Ease.OutQuad => 1 - (1 - value) * (1 - value),
            Ease.InOutQuad => value < .5f ? 2 * value * value : 1 - Mathf.Pow(-2 * value + 2, 2) / 2,
            Ease.InCubic => value * value * value,
            Ease.OutCubic => 1 - Mathf.Pow(1 - value, 3),
            Ease.InOutCubic => value < .5f ? 4 * value * value * value : 1 - Mathf.Pow(-2 * value + 2, 3) / 2,
            Ease.OutBack => 1 + 2.70158f * Mathf.Pow(value - 1, 3) + 1.70158f * Mathf.Pow(value - 1, 2),
            _ => value
        };
    }

    private protected abstract void Apply();

    private protected void InvokeOnUpdate()
    {
        onUpdate?.Invoke(this);
    }

    #endregion
}

/// <summary>
/// Helper for performing typed animation Tweens
/// </summary>
public sealed class Tween<T> : Tween
{
    private T startValue;
    private T endValue;
    private readonly Func<T, T, float, T> lerp;
    private readonly Action<T> onValueChange;

    internal Tween
    (
        int id,
        Object target,
        T startValue,
        T endValue,
        float duration,
        Func<T, T, float, T> lerp,
        Action<T> onValueChange,
        Ease ease,
        bool useUnscaledTime,
        TweenProperty property
    ) : base(id, target, duration, ease, useUnscaledTime, property)
    {
        this.startValue = startValue;
        this.endValue = endValue;
        this.lerp = lerp;
        this.onValueChange = onValueChange;
    }

    private protected override void Apply()
    {
        if (!IsAlive) return;

        onValueChange(lerp(startValue, endValue, Evaluate(ease, Progress)));
        InvokeOnUpdate();
    }

    /// <inheritdoc />
    public override Tween Reverse()
    {
        var newEnd = startValue;
        var newStart = endValue;
        onValueChange(newStart);
        startValue = newStart;
        endValue = newEnd;

        return this;
    }
}
