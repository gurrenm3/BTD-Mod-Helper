/**
 * @license
 * Copyright 2020 Google LLC
 * SPDX-License-Identifier: Apache-2.0
 */

/**
 * @fileoverview A field for a plus button used for mutation.
 */

import * as Blockly from "blockly/core";
import { getExtraBlockState } from "./mutators";
import { Block, FieldImage } from "blockly";
import { PlusMinusRowsMutator } from "./plus-minus-rows";

export class FieldMinus extends FieldImage {
  static type = "field_minus";

  constructor(options) {
    super(minusImage, 15, 15, "Minus", FieldMinus.onClick);
  }

  static fromJson(options) {
    return new FieldMinus(options);
  }

  getText(): string {
    return "";
  }

  static onClick(field: FieldMinus) {
    const block = field.getSourceBlock() as Block & PlusMinusRowsMutator;

    if (block.isInFlyout) return;
    Blockly.Events.setGroup(true);

    let row = block.inputList.findIndex((input) =>
      input.fieldRow.includes(field)
    );

    const oldExtraState = getExtraBlockState(block);
    block.minus(row);
    const newExtraState = getExtraBlockState(block);

    if (oldExtraState != newExtraState) {
      Blockly.Events.fire(
        new Blockly.Events.BlockChange(
          block,
          "mutation",
          null,
          oldExtraState,
          newExtraState
        )
      );
    }
    Blockly.Events.setGroup(false);
  }
}

const minusImage =
  "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAw" +
  "MC9zdmciIHZlcnNpb249IjEuMSIgd2lkdGg9IjI0IiBoZWlnaHQ9IjI0Ij48cGF0aCBkPS" +
  "JNMTggMTFoLTEyYy0xLjEwNCAwLTIgLjg5Ni0yIDJzLjg5NiAyIDIgMmgxMmMxLjEwNCAw" +
  "IDItLjg5NiAyLTJzLS44OTYtMi0yLTJ6IiBmaWxsPSJ3aGl0ZSIgLz48L3N2Zz4K";
