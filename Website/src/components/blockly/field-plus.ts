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
import { Block, FieldImage, Input } from "blockly";
import { PlusMinusRowsMutator } from "./plus-minus-rows";

export class FieldPlus extends FieldImage {
  static type = "field_plus";

  constructor(options) {
    super(plusImage, 15, 15, "Plus", FieldPlus.onClick);
  }

  static fromJson(options) {
    return new FieldPlus(options);
  }

  getText(): string {
    const block = this.getSourceBlock() as Block & PlusMinusRowsMutator;

    return (
      "List of " +
      block.type.substring(block.type.lastIndexOf(".") + 1).replace("[]", "") +
      "               "
    );
  }

  static onClick(field: FieldPlus) {
    const block = field.getSourceBlock() as Block & PlusMinusRowsMutator;

    if (block.isInFlyout) return;
    Blockly.Events.setGroup(true);

    let row = block.inputList.findIndex((input) =>
      input.fieldRow.includes(field)
    );

    const oldExtraState = getExtraBlockState(block);
    block.plus(row);
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

const plusImage =
  "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC" +
  "9zdmciIHZlcnNpb249IjEuMSIgd2lkdGg9IjI0IiBoZWlnaHQ9IjI0Ij48cGF0aCBkPSJNMT" +
  "ggMTBoLTR2LTRjMC0xLjEwNC0uODk2LTItMi0ycy0yIC44OTYtMiAybC4wNzEgNGgtNC4wNz" +
  "FjLTEuMTA0IDAtMiAuODk2LTIgMnMuODk2IDIgMiAybDQuMDcxLS4wNzEtLjA3MSA0LjA3MW" +
  "MwIDEuMTA0Ljg5NiAyIDIgMnMyLS44OTYgMi0ydi00LjA3MWw0IC4wNzFjMS4xMDQgMCAyLS" +
  "44OTYgMi0ycy0uODk2LTItMi0yeiIgZmlsbD0id2hpdGUiIC8+PC9zdmc+Cg==";
