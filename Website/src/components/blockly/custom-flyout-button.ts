import { FlyoutButton } from "blockly/core";
import Blockly, { WorkspaceSvg } from "blockly";

export class CustomFlyoutButton extends FlyoutButton {
  // It is a gigantic performance hit to recompute these values each time when they are always the same
  static fontSize: ReturnType<typeof Blockly.utils.style.getComputedStyle>;
  static fontMetrics: ReturnType<typeof Blockly.utils.dom.measureFontMetrics>;

  constructor(
    workspace: WorkspaceSvg,
    targetWorkspace: WorkspaceSvg,
    json: Blockly.utils.toolbox.ButtonOrLabelInfo,
    isLabel_: boolean
  ) {
    super(workspace, targetWorkspace, json, isLabel_);
  }

  createDom(): SVGElement {
    let cssClass = this["isLabel_"]
      ? "blocklyFlyoutLabel"
      : "blocklyFlyoutButton";
    if (this["cssClass"]) {
      cssClass += " " + this["cssClass"];
    }

    this["svgGroup"] = Blockly.utils.dom.createSvgElement(
      Blockly.utils.Svg.G,
      { class: cssClass },
      this["workspace"].getCanvas()
    );

    let shadow;
    if (!this["isLabel_"]) {
      // Shadow rectangle (light source does not mirror in RTL).
      shadow = Blockly.utils.dom.createSvgElement(
        Blockly.utils.Svg.RECT,
        {
          class: "blocklyFlyoutButtonShadow",
          rx: FlyoutButton.BORDER_RADIUS,
          ry: FlyoutButton.BORDER_RADIUS,
          x: 1,
          y: 1,
        },
        this["svgGroup"]!
      );
    }
    // Background rectangle.
    const rect = Blockly.utils.dom.createSvgElement(
      Blockly.utils.Svg.RECT,
      {
        class: this["isLabel_"]
          ? "blocklyFlyoutLabelBackground"
          : "blocklyFlyoutButtonBackground",
        rx: FlyoutButton.BORDER_RADIUS,
        ry: FlyoutButton.BORDER_RADIUS,
      },
      this["svgGroup"]!
    );

    const svgText = Blockly.utils.dom.createSvgElement(
      Blockly.utils.Svg.TEXT,
      {
        class: this["isLabel_"] ? "blocklyFlyoutLabelText" : "blocklyText",
        x: 0,
        y: 0,
        "text-anchor": "middle",
      },
      this["svgGroup"]!
    );
    let text = Blockly.utils.parsing.replaceMessageReferences(this["text"]);
    if (this["workspace"].RTL) {
      // Force text to be RTL by adding an RLM.
      text += "\u200F";
    }
    svgText.textContent = text;
    if (this["isLabel_"]) {
      this["svgText"] = svgText;
      this["workspace"]
        .getThemeManager()
        .subscribe(this["svgText"], "flyoutForegroundColour", "fill");
    }

    const fontSize = (CustomFlyoutButton.fontSize ??=
      Blockly.utils.style.getComputedStyle(svgText, "fontSize"));
    const fontWeight = Blockly.utils.style.getComputedStyle(
      svgText,
      "fontWeight"
    );
    const fontFamily = Blockly.utils.style.getComputedStyle(
      svgText,
      "fontFamily"
    );
    this.width = Blockly.utils.dom.getFastTextWidthWithSizeString(
      svgText,
      fontSize,
      fontWeight,
      fontFamily
    );
    const fontMetrics = (CustomFlyoutButton.fontMetrics ??=
      Blockly.utils.dom.measureFontMetrics(
        text,
        fontSize,
        fontWeight,
        fontFamily
      ));
    this.height = fontMetrics.height;
    console.log(fontSize, fontMetrics);

    if (!this["isLabel_"]) {
      this.width += 2 * FlyoutButton.TEXT_MARGIN_X;
      this.height += 2 * FlyoutButton.TEXT_MARGIN_Y;
      shadow?.setAttribute("width", String(this.width));
      shadow?.setAttribute("height", String(this.height));
    }
    rect.setAttribute("width", String(this.width));
    rect.setAttribute("height", String(this.height));

    svgText.setAttribute("x", String(this.width / 2));
    svgText.setAttribute(
      "y",
      String(this.height / 2 - fontMetrics.height / 2 + fontMetrics.baseline)
    );

    this["updateTransform"]();

    // AnyDuringMigration because:  Argument of type 'SVGGElement | null' is not
    // assignable to parameter of type 'EventTarget'.
    this["onMouseUpWrapper"] = Blockly.browserEvents.conditionalBind(
      this["svgGroup"] as any,
      "pointerup",
      this,
      this["onMouseUp"]
    );

    return this["svgGroup"]!;
  }
}
