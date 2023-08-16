import Blockly, { BlockSvg } from "blockly";
import { Renderer } from "blockly/core/renderers/geras/renderer";
import { RenderInfo } from "blockly/core/renderers/geras/info";

class CustomRenderer extends Blockly.geras.Renderer {
  constructor() {
    super(CustomRenderer.name);
  }

  protected makeRenderInfo_(block: BlockSvg): RenderInfo {
    return new CustomRenderInfo(this, block);
  }
}

class CustomRenderInfo extends Blockly.geras.RenderInfo {
  constructor(renderer: Renderer, block: BlockSvg) {
    super(renderer, block);
  }

  // use 2 half-width spacing rows instead of 1 full-width for the inner rows of blocks
  protected addRowSpacing_() {
    let type = this.block_.type;

    let oldRows = this.rows;
    this.rows = [];

    for (let r = 0; r < oldRows.length; r++) {
      this.rows.push(oldRows[r]);
      if (r !== oldRows.length - 1) {
        let spacerRow = this.makeSpacerRow_(oldRows[r], oldRows[r + 1]);
        if (r !== oldRows.length - 2 && r !== 0) {
          spacerRow.height = spacerRow.height / 2;

          let spacerRow2 = this.makeSpacerRow_(oldRows[r], oldRows[r + 1]);
          spacerRow2.height = spacerRow2.height / 2;
          this.rows.push(spacerRow2);
        }
        this.rows.push(spacerRow);
      }
    }
  }

  // now every single important row has a spacer or equivalent both above and below
  alignRowElements_() {
    let block = Blockly.Blocks[this.block_.type];
    if (!(block.json && block.json.type)) {
      return super.alignRowElements_();
    }

    const Types = Blockly.blockRendering.Types;
    let maxWidth = 0;

    // align statement rows normally and align input rows to nearest 10 pixels
    for (let i = 0, row; (row = this.rows[i]); i++) {
      if (row.hasStatement) {
        this.alignStatementRow_(row);
      }
      if (row.hasExternalInput && row.width > 1) {
        let happyWidth;
        if (row.width < 50) {
          happyWidth = Math.ceil(row.width / 10) * 10;
        } else {
          happyWidth = Math.round(row.width / 10) * 10;
        }
        let missingSpace = happyWidth - row.width;
        this.addAlignmentPadding_(row, missingSpace);
      }
      if (
        (this.block_.hat || this.block_["json"]?.hat) &&
        i === 2 &&
        row.width < this.topRow.width
      ) {
        let missingSpace = this.topRow.width - row.width;
        this.addAlignmentPadding_(row, missingSpace);
      }
    }

    // rows with no inputs/statements still have full width
    for (let i = 0, row; (row = this.rows[i]); i++) {
      if (
        row.hasDummyInput &&
        !row.hasStatement &&
        !row.hasInlineInput &&
        !row.hasExternalInput
      ) {
        const currentWidth = row.width;
        const desiredWidth = this.getDesiredRowWidth_(row);
        const missingSpace = desiredWidth - currentWidth;
        if (missingSpace > 0) {
          this.addAlignmentPadding_(row, missingSpace);
        }
        if (Types.isTopOrBottomRow(row)) {
          row.widthWithConnectedBlocks = row.width;
        }
      }
    }

    // spacer/top/bottom rows take on the width of their adjacent non-spacer row
    for (let i = 0, row; (row = this.rows[i]); i++) {
      if (Types.isSpacer(row) || Types.isTopOrBottomRow(row)) {
        let currentWidth = row.width;
        let desiredWidth = 0;

        if (Types.isSpacer(row)) {
          let aboveRow = this.rows[i + 1];
          let belowRow = this.rows[i - 1];
          if (
            aboveRow &&
            !Types.isSpacer(aboveRow) &&
            !Types.isTopOrBottomRow(aboveRow)
          ) {
            desiredWidth = aboveRow.width;
          }
          if (
            belowRow &&
            !Types.isSpacer(belowRow) &&
            !Types.isTopOrBottomRow(belowRow)
          ) {
            desiredWidth = belowRow.width;
          }
        } else if (Types.isTopRow(row)) {
          desiredWidth = this.rows[2].width;
        } else if (Types.isBottomRow(row)) {
          desiredWidth = this.rows[i - 2].width;
        }

        let missingSpace = desiredWidth - currentWidth;
        if (missingSpace > 0) {
          this.addAlignmentPadding_(row, missingSpace);
        }
        if (Types.isTopOrBottomRow(row)) {
          row.widthWithConnectedBlocks = row.width;
        }
      } else if (
        row.hasStatement &&
        row.elements.length < 4 &&
        this.rows[i + 3] &&
        !Types.isBottomRow(this.rows[i + 3]) &&
        !Types.isSpacer(this.rows[i + 3])
      ) {
        row.width = this.rows[i + 3].width;
      }
    }
  }
}

export default CustomRenderer;
