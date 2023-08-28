import Blockly, { Block } from "blockly";

export const MatchDataColor = "match_data_color";

const colorCache = {
  Model: 210,
  "Model Changes": 280,
  "Display Changes": 80,
} as Record<string, number | string | undefined>;

export const MatchDataColorExtension = function (this: Block) {
  this.setOnChange((e) => {
    if (
      e["blockId"] !== this.id &&
      e["oldParentId"] !== this.id &&
      e["newParentId"] !== this.id &&
      !e["ids"]?.includes(this.id)
    )
      return;

    const data = this.data;
    if (!data) return;

    if (data in colorCache) {
      if (colorCache[data] !== undefined) {
        this.setColour(colorCache[data]);
      }
      return;
    }

    for (let blocksKey in Blockly.Blocks) {
      if (blocksKey.endsWith("." + data)) {
        const block = Blockly.Blocks[blocksKey].json;
        colorCache[data] = block.colour;
        this.setColour(block.colour);
        return;
      }
    }

    colorCache[data] = undefined;
  });
};
