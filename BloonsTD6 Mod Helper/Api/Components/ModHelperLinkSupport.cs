using System;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// Allows links created by rich text within TextMeshPro to be clicked and opened with <see cref="ProcessHelper.OpenURL"/>. Since this is not a ModHelperComponent, add it like any normal mono behaviour.
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModHelperLinkSupport : MonoBehaviour
{
    private TMP_Text textMeshPro;
    private EventTrigger trigger;
    private EventTrigger.Entry entry;

    private Action<BaseEventData> onClick;

    private void Awake()
    {
        textMeshPro = GetComponent<TMP_Text>();
        
        trigger = gameObject.GetComponent<EventTrigger>();
        if (!trigger)
        {
            trigger = gameObject.AddComponent<EventTrigger>();
        }
        entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerClick };
        onClick = data => OnClick(data);
        entry.callback.AddListener(onClick);
        trigger.triggers.Add(entry);
    }

    private void OnDisable()
    {
        if (trigger != null && entry != null)
        {
            trigger.triggers.Remove(entry);
            entry.callback.RemoveListener(onClick);
        }
    }
    
    private void OnClick(BaseEventData data)
    {
        var eventData = data.Cast<PointerEventData>();
        
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(textMeshPro, eventData.position, eventData.pressEventCamera);
        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = textMeshPro.textInfo.linkInfo[linkIndex];
            string link = linkInfo.GetLinkID();
            ProcessHelper.OpenURL(link);
        }
    }
}