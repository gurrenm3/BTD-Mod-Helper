using System;
using System.Collections.Generic;
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
public readonly struct Tween
{
    private static readonly List<TweenState> Tweens = [];
    private static int nextId;

    private enum TweenProperty
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

    private readonly int id;

    private Tween(int id)
    {
        this.id = id;
    }

    #region State

    /// <summary>
    /// Whether this handle still points to a currently running tween.
    /// </summary>
    public bool IsAlive => TryGetState(out _);

    /// <summary>
    /// The elapsed time, in seconds, for the current tween cycle.
    /// </summary>
    public float ElapsedTime
    {
        get => TryGetState(out var state) ? state.ElapsedTime : 0;
        set
        {
            if (TryGetState(out var state))
            {
                state.ElapsedTime = Mathf.Clamp(value, 0, state.Duration);
                state.Apply();
            }
        }
    }

    /// <summary>
    /// The normalized progress for the current tween cycle.
    /// </summary>
    public float Progress
    {
        get => TryGetState(out var state) ? state.Progress : 0;
        set
        {
            if (TryGetState(out var state))
            {
                state.ElapsedTime = Mathf.Clamp01(value) * state.Duration;
                state.Apply();
            }
        }
    }

    /// <summary>
    /// Whether this tween is currently paused.
    /// </summary>
    public bool IsPaused
    {
        get => TryGetState(out var state) && state.IsPaused;
        set
        {
            if (TryGetState(out var state))
            {
                state.IsPaused = value;
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
    /// Sets a transform's local position to a starting value, then tweens back to its current local position.
    /// </summary>
    public static Tween FromLocalPosition
    (
        Transform target,
        Vector3 startValue,
        float duration,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        var endValue = target.localPosition;
        target.localPosition = startValue;
        return LocalPosition(target, endValue, duration, ease, useUnscaledTime);
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
    /// Sets a transform's local scale to a starting value, then tweens back to its current local scale.
    /// </summary>
    public static Tween FromScale
    (
        Transform target,
        Vector3 startValue,
        float duration,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        var endValue = target.localScale;
        target.localScale = startValue;
        return Scale(target, endValue, duration, ease, useUnscaledTime);
    }

    /// <inheritdoc cref="FromScale(Transform, Vector3, float, Ease, bool)" />
    public static Tween FromScale
    (
        Transform target,
        float startValue,
        float duration,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        return FromScale(target, Vector3.one * startValue, duration, ease, useUnscaledTime);
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
    /// Sets a RectTransform's anchored position to a starting value, then tweens back to its current anchored position.
    /// </summary>
    public static Tween FromAnchoredPosition
    (
        RectTransform target,
        Vector2 startValue,
        float duration,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        var endValue = target.anchoredPosition;
        target.anchoredPosition = startValue;
        return AnchoredPosition(target, endValue, duration, ease, useUnscaledTime);
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
            UnityEngine.Color.LerpUnclamped,
            value => target.color = value, ease, useUnscaledTime);
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

    /// <summary>
    /// Sets a CanvasGroup's alpha to a starting value, then tweens back to its current alpha.
    /// </summary>
    public static Tween FromAlpha
    (
        CanvasGroup target,
        float startValue,
        float duration,
        Ease ease = Ease.Linear,
        bool useUnscaledTime = false
    )
    {
        var endValue = target.alpha;
        target.alpha = startValue;
        return Alpha(target, endValue, duration, ease, useUnscaledTime);
    }

    #endregion

    #region Controls

    /// <summary>
    /// Stops this tween without applying the end value.
    /// </summary>
    public void Stop()
    {
        Stop(false);
    }

    /// <summary>
    /// Stops this tween, optionally completing it first.
    /// </summary>
    public void Stop(bool complete)
    {
        if (!TryGetState(out var state)) return;

        if (complete)
        {
            state.Complete();
        }
        else
        {
            Remove(state);
        }
    }

    /// <summary>
    /// Completes this tween immediately.
    /// </summary>
    public void Complete()
    {
        Stop(true);
    }

    /// <summary>
    /// Adds a callback invoked when this tween completes naturally or via <see cref="Complete"/>.
    /// </summary>
    public Tween OnComplete(Action onComplete)
    {
        if (TryGetState(out var state))
        {
            state.OnComplete += onComplete;
        }

        return this;
    }

    /// <summary>
    /// Adds a callback invoked every time this tween updates.
    /// </summary>
    public Tween OnUpdate(Action<Tween> onUpdate)
    {
        if (TryGetState(out var state))
        {
            state.OnUpdate += onUpdate;
        }

        return this;
    }

    /// <summary>
    /// Stops every tween currently associated with a target.
    /// </summary>
    public static void StopAll(Object target, bool complete = false)
    {
        if (target == null) return;

        for (var i = Tweens.Count - 1; i >= 0; i--)
        {
            var state = Tweens[i];
            if (state.Target != target) continue;

            if (complete)
            {
                state.Complete();
            }
            else
            {
                RemoveAt(i);
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
            for (var i = Tweens.Count - 1; i >= 0; i--)
            {
                Tweens[i].Complete();
            }
        }
        else
        {
            Tweens.Clear();
        }
    }

    #endregion

    #region Internal

    internal static void Update()
    {
        for (var i = Tweens.Count - 1; i >= 0; i--)
        {
            var state = Tweens[i];

            if (state.TargetWasDestroyed)
            {
                RemoveAt(i);
                continue;
            }

            if (state.IsPaused) continue;

            var deltaTime = state.UseUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
            if (deltaTime <= 0) continue;

            state.ElapsedTime += deltaTime;
            state.Apply();

            if (state.ElapsedTime >= state.Duration)
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
        var state = new TweenState<T>(id, target, startValue, endValue, Mathf.Max(0, duration), lerp, onValueChange,
            ease, useUnscaledTime, property);

        Tweens.Add(state);
        state.Apply();

        if (state.Duration == 0)
        {
            state.Complete();
        }

        return new Tween(id);
    }

    private bool TryGetState(out TweenState state)
    {
        foreach (var tween in Tweens)
        {
            if (tween.Id != id) continue;

            state = tween;
            return true;
        }

        state = null;
        return false;
    }

    private static void Remove(TweenState state)
    {
        Tweens.Remove(state);
    }

    private static void RemoveAt(int index)
    {
        Tweens.RemoveAt(index);
    }

    private static void StopConflicting(Object target, TweenProperty property)
    {
        if (target == null || property == TweenProperty.None) return;

        for (var i = Tweens.Count - 1; i >= 0; i--)
        {
            var tween = Tweens[i];
            if (tween.Target == target && tween.Property == property)
            {
                RemoveAt(i);
            }
        }
    }

    // Easing formulas are based on common Robert Penner easing equations, using the standard 1.70158 back overshoot.
    private static float Evaluate(Ease ease, float value)
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

    private abstract class TweenState
    {
        protected TweenState
        (
            int id,
            Object target,
            float duration,
            Ease ease,
            bool useUnscaledTime,
            TweenProperty property
        )
        {
            Id = id;
            Target = target;
            HasTarget = target is not null;
            Duration = duration;
            Ease = ease;
            UseUnscaledTime = useUnscaledTime;
            Property = property;
        }

        public int Id { get; }

        public Object Target { get; }

        internal TweenProperty Property { get; }

        private bool HasTarget { get; }

        public float Duration { get; }

        public Ease Ease { get; }

        public bool UseUnscaledTime { get; }

        public bool IsPaused { get; set; }

        public float ElapsedTime { get; set; }

        public float Progress => Duration <= 0 ? 1 : Mathf.Clamp01(ElapsedTime / Duration);

        public bool TargetWasDestroyed => HasTarget && !Target;

        public event Action OnComplete;

        public event Action<Tween> OnUpdate;

        public abstract void Apply();

        public void Complete()
        {
            ElapsedTime = Duration;
            Apply();
            Remove(this);
            OnComplete?.Invoke();
        }

        protected void InvokeOnUpdate()
        {
            OnUpdate?.Invoke(new Tween(Id));
        }
    }

    private sealed class TweenState<T> : TweenState
    {
        private readonly T startValue;
        private readonly T endValue;
        private readonly Func<T, T, float, T> lerp;
        private readonly Action<T> onValueChange;

        public TweenState
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

        public override void Apply()
        {
            onValueChange(lerp(startValue, endValue, Evaluate(Ease, Progress)));
            InvokeOnUpdate();
        }
    }

    #endregion
}