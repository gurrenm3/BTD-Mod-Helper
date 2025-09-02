import Blockly, { FieldMultilineInput } from "blockly";

export class CustomFieldMultiline extends FieldMultilineInput {
  static type = "field_multilinetext";

  // No ellipsis, be actually multiline
  protected getDisplayText_(): string {
    let value = this.value_;
    if (!value) {
      // Prevent the field from disappearing if empty.
      return Blockly.Field.NBSP;
    }

    if (value.length < this.maxDisplayLength) {
      return value.replaceAll(/\s/g, Blockly.Field.NBSP);
    }

    let text = "";
    let words = value.replaceAll("\n", "").split(" ");
    let i = 0;
    for (let wordsKey of words) {
      if (i + wordsKey.length + 1 > this.maxDisplayLength) {
        text += "\n";
        text += wordsKey;
        text += Blockly.Field.NBSP;
        i = 0;
      } else {
        text += wordsKey;
        text += Blockly.Field.NBSP;
      }
      i += wordsKey.length + 1;
    }

    return text;
  }

  /*protected updateSize_() {
    super.updateSize_();

    if (this.size_.width === 10) {
      const fontSize = this.getConstants().FIELD_TEXT_FONTSIZE;
      const fontWeight = this.getConstants().FIELD_TEXT_FONTWEIGHT;
      const fontFamily = this.getConstants().FIELD_TEXT_FONTFAMILY;

      const nodes = this.textGroup_.childNodes;
      for (let i = 0; i < nodes.length; i++) {
        const tspan = nodes[i];
        const textWidth = Blockly.utils.dom.getFastTextWidth(
          tspan,
          fontSize,
          fontWeight,
          fontFamily
        );
        if (textWidth > this.size_.width) {
          this.size_.width = textWidth;
        }
      }
      if (this.borderRect_) {
        this.size_.width += this.getConstants().FIELD_BORDER_RECT_X_PADDING * 2;
        this.borderRect_.setAttribute("width", this.size_.width);
      }

      this.positionBorderRect_();
    }
  }*/
}
