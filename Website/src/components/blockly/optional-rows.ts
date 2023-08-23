import Blockly, { Block, BlockSvg, icons } from "blockly";
import { MutatorFn, MutatorMixin } from "./mutators";
import { BlockArgDef, BlockDef } from "../../lib/blockly-types";
import {
  addBlock,
  newBlock,
  reInitBlock,
  rowsList,
} from "../../lib/blockly-utils";

export interface OptionalRowsOptions {
  optional: Record<`${number}`, string>;
  defaults?: Record<string, boolean>;
}

interface OptionalRowsMutator
  extends MutatorMixin<OptionalRowsMutator, Record<string, boolean>> {
  args: Record<string, boolean>;

  initMutator(this: OptionalRowsMutator & Block): void;
}

export const OptionalRows = "optional_rows";

const defaultShow = false;

export const OptionalRowsMixin: OptionalRowsMutator = {
  args: undefined,
  saveExtraState() {
    return this.args;
  },
  loadExtraState(state) {
    this.args = state;
    this.rebuildShape_();
  },
  decompose(workspace): Block {
    const block = newBlock(workspace, this.type + "_container");
    (block as BlockSvg).initSvg();

    for (let [arg, enabled] of Object.entries(this.args)) {
      if (block.getField(arg)) {
        block.setFieldValue(enabled, arg);
      }
    }

    return block;
  },
  compose(block): void {
    const json = Blockly.Blocks[this.type].json as BlockDef;
    const options = json.mutatorOptions as OptionalRowsOptions;
    options.defaults ??= {};

    for (let arg of Object.values(options.optional)) {
      this.args[arg] = block.getFieldValue(arg)?.toUpperCase() == "TRUE";
    }

    this.rebuildShape_();
  },
  rebuildShape_() {
    const block = JSON.parse(
      JSON.stringify(Blockly.Blocks[this.type].json)
    ) as BlockDef;

    // Rebuild block with only toggled args
    const options = block.mutatorOptions as OptionalRowsOptions;
    const rows = [] as [string, BlockArgDef[]][];
    rowsList(block).forEach((row, i) => {
      const key = options.optional[i.toString()];
      if (!key || typeof key !== "string" || this.args[key]) {
        rows.push(row);
      }
      delete block[`message${i}`];
      delete block[`args${i}`];
    });
    rows.forEach(([message, args], i) => {
      block[`message${i}`] = message;
      block[`args${i}`] = args;
    });

    reInitBlock(this, block);
  },
  initMutator() {
    if (this.args) return;

    this.args = {};

    const block = Blockly.Blocks[this.type].json as BlockDef;

    const options = block.mutatorOptions as OptionalRowsOptions;
    options.defaults ??= {};

    for (let value of Object.values(options?.optional ?? {})) {
      this.args[value] = options.defaults[value] ??= defaultShow;
    }

    // It's an error to try to add shadow blocks to non-existent connections in the toolbox
    const inputs = Blockly.Blocks[this.type].toolboxInfo?.inputs;
    if (inputs) {
      rowsList(block).forEach(([, args], index) => {
        const optional = options.optional[index.toString()];
        if (!optional) return;

        for (let arg of args) {
          if (arg.type.startsWith("input") && !options.defaults[optional]) {
            delete inputs[arg.name];
          }
        }
      });
    }
  },
};

export const OptionalRowsFn: MutatorFn<OptionalRowsMutator> = function (this) {
  this.initMutator();
  this.setMutator(new icons.MutatorIcon([], this as BlockSvg));
  this.rebuildShape_();
};

export const addMutatorBlock = (block: BlockDef) => {
  const options = block.mutatorOptions as OptionalRowsOptions;

  const args = {} as Record<string, boolean>;

  for (let [key, value] of Object.entries(options.optional)) {
    if (block[`message${key}`]?.trim() && block[`args${key}`]) {
      args[value] = options.defaults?.[value] ?? defaultShow;
    }
  }

  const argLength = Object.values(args).length;
  const columns = Math.ceil(argLength / 15);

  if (columns == 0) {
    return;
  }
  const newBlock: BlockDef = {
    type: block.type + "_container",
    inputsInline: false,
    message0: Blockly.utils.parsing
      .tokenizeInterpolation(block.message0)
      .filter((value) => typeof value === "string")
      .join(""),
    args0: [],
    colour: block.colour,
    nextStatement: null,
  };

  let messageI = "";
  let argsI = [];
  let row = 1;

  Object.entries(args).forEach(([name, checked], index) => {
    messageI += `${name}: %${(index % columns) + 1} `;
    argsI.push({
      type: "field_checkbox",
      name,
      checked,
    });

    if ((index + 1) % columns === 0 || index === argLength - 1) {
      newBlock[`message${row}`] = messageI;
      newBlock[`args${row}`] = argsI;
      messageI = "";
      argsI = [];
      row++;
    }
  });

  addBlock(newBlock);
};
