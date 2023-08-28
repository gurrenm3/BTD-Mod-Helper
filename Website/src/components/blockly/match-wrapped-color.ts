import Blockly, { Block } from "blockly";

export const MatchWrappedColor = "match_wrapped_color";

export const MatchWrappedColorExtension = function (this: Block) {
  this.setOnChange((e) => {
    if (
      e["blockId"] !== this.id &&
      e["oldParentId"] !== this.id &&
      e["newParentId"] !== this.id &&
      !e["ids"]?.includes(this.id)
    )
      return;

    const wrapped = this.getChildren(true)[0];
    if (wrapped && !wrapped.isShadow()) {
      this.setColour(wrapped.getColour());
    } else {
      this.setColour(Blockly.Blocks[this.type].json?.colour);
    }
  });
};
