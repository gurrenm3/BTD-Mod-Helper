// noinspection JSUnusedGlobalSymbols

import { Block } from "blockly";

export const ToggleHat = "toggle_hat";

export const ToggleHatMixin = {
  changeHat,
  onInit,
  postInit,
};

type ToggleHatBlock = Block & typeof ToggleHatMixin;

function changeHat(this: ToggleHatBlock, hat: boolean) {
  if (hat) {
    this.hat = "cap";
    this.setOutput(false);
    if (this["json"].nextStatement !== undefined) {
      this.setNextStatement(true, this["json"].nextStatement);
    }
  } else {
    this.hat = undefined;
    this.setNextStatement(false);
    if (this["json"].output !== undefined) {
      this.setOutput(true, this["json"].output);
    }
  }
}

function onInit(this: ToggleHatBlock) {
  if (!this.rendered) {
    this.changeHat(this.isInFlyout);
  }
}

function postInit(this: ToggleHatBlock) {
  const field = this.getField("isSubTower");
  if (field) {
    field.setValidator((isSubTower) =>
      this.changeHat(String(isSubTower) && String(isSubTower) !== "true")
    );
    field.setValue(field.getValue(), false);
  } else {
    this.changeHat(true);
  }
}
