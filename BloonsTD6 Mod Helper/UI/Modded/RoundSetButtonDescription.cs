using System;
using System.Collections;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using Il2CppInterop.Runtime.Attributes;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.EventSystems;
namespace BTD_Mod_Helper.UI.Modded;

[RegisterTypeInIl2Cpp(false)]
internal class RoundSetButtonDescription : EventTrigger
{
    /// <inheritdoc />
    public RoundSetButtonDescription(IntPtr ptr) : base(ptr)
    {
    }

    public ModHelperScrollPanel parent;
    public ModHelperPanel descriptionPanel;
    public string description;
    private const float delay = .2f;
    private bool shouldShow = true;

    private void Start()
    {
        const int width = 750;
        const int height = 300;
        const int padding = 50;
        descriptionPanel = gameObject.AddModHelperPanel(new Info("DescriptionPanel", -600, 0 , width, height), VanillaSprites.BrownInsertPanel);
        var text = descriptionPanel.AddText(new Info("DescriptionText", width - padding, height - padding), description, 50);
        text.Text.enableAutoSizing = true;
        text.Text.m_TextWrappingMode = text.Text.textWrappingMode = TextWrappingModes.PreserveWhitespace;
        text.Text.alignment = TextAlignmentOptions.TopLeft;
        descriptionPanel.gameObject.SetActive(false);
    }

    [HideFromIl2Cpp]
    private IEnumerator ShowPanel()
    {
        shouldShow = true;
        yield return new WaitForSecondsRealtime(delay);
        if (descriptionPanel != null)
            descriptionPanel.gameObject.SetActive(shouldShow);
    }

    [HideFromIl2Cpp]
    public IEnumerator HidePanel()
    {
        shouldShow = false;
        if (descriptionPanel != null)
            descriptionPanel.gameObject.SetActive(shouldShow);
        yield return null;
    }


    public override void OnPointerEnter(PointerEventData eventData)
    {
        MelonCoroutines.Start(ShowPanel());
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        MelonCoroutines.Start(HidePanel());
    }

    /// <inheritdoc />
    public override void OnScroll(PointerEventData eventData)
    {
        parent.ScrollRect.OnScroll(eventData);
    }

    /// <inheritdoc />
    public override void OnDrag(PointerEventData eventData)
    {
        parent.ScrollRect.OnDrag(eventData);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        parent.ScrollRect.OnBeginDrag(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        parent.ScrollRect.OnEndDrag(eventData);
    }

    public override void OnInitializePotentialDrag(PointerEventData eventData)
    {
        parent.ScrollRect.OnInitializePotentialDrag(eventData);
    }
}