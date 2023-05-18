using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.UI.Menus;

internal class InGameButtonsHolder
{
    const int padding = 20;
    internal static ModHelperPanel subPanel;
    internal static void Init()
    {
        var rightPanel = InGame.instance.uiRect.transform.Find("RightPanel(Clone)").gameObject.AddModHelperScrollPanel(new Info("ButtonPanel", 1200, -1200, 960, 350), RectTransform.Axis.Horizontal, VanillaSprites.BrownInsertPanelDark);
        rightPanel.transform.SetAsFirstSibling();
        subPanel = rightPanel.AddPanel(new Info("SubPanel", InfoPreset.Flex));
        ContentSizeFitter contentSizeFitter = subPanel.AddComponent<ContentSizeFitter>();
        contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        rightPanel.ScrollContent.transform.position += new Vector3(padding, padding / 2);

        rightPanel.AddScrollContent(subPanel);

        GridLayoutGroup gridGroup = subPanel.AddComponent<GridLayoutGroup>();
        gridGroup.SetPadding(padding);
        gridGroup.constraint = GridLayoutGroup.Constraint.FixedRowCount;
        gridGroup.constraintCount = 2;

        subPanel.transform.localPosition = new Vector3(40, -150);

    }
}
