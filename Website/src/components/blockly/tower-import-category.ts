/**
 * @license
 * Copyright 2023 Google LLC
 * SPDX-License-Identifier: Apache-2.0
 */

/**
 * A toolbox category that provides a search field and displays matching blocks
 * in its flyout.
 */
import * as Blockly from "blockly/core";
import { FlyoutButton } from "blockly/core";
import { SearchCategory } from "./search-category";
import { ToolboxItemInfo } from "blockly/core/utils/toolbox";
import allTowers from "../../data/all-towers.json";
import { getString } from "../../lib/util";
import { RawUserContent } from "../../lib/mod-helper-data";
import { pasteBlockFromText } from "../../lib/json-conversion-utils";
import { towerSetColors } from "../../lib/blockly-json";

/* eslint-disable @typescript-eslint/naming-convention */

/**
 * A toolbox category that provides a search field and displays matching blocks
 * in its flyout.
 */
export class TowerImportCategory extends SearchCategory {
  static readonly registrationName = "importtowers";

  /**
   * Initializes a ToolboxSearchCategory.
   * @param categoryDef The information needed to create a category in the
   *     toolbox.
   * @param parentToolbox The parent toolbox for the category.
   * @param opt_parent The parent category or null if the category does not have
   *     a parent.
   */
  constructor(
    categoryDef: Blockly.utils.toolbox.StaticCategoryInfo,
    parentToolbox: Blockly.IToolbox,
    opt_parent?: Blockly.ICollapsibleToolboxItem
  ) {
    super(categoryDef, parentToolbox, opt_parent);
    this.categoryKind = TowerImportCategory.registrationName;
    this.defaultMessage = "Type to search for Towers";
    this.noResultsMessage = "No matching towers found";
  }

  protected async getBlocks(): Promise<ToolboxItemInfo[]> {
    const query = this.searchField.value;

    return Object.entries(allTowers)
      .slice(0, query ? undefined : 21)
      .filter(
        ([towerId, { appliedUpgrades }]) =>
          !query ||
          !query
            .toLowerCase()
            .split(/[ -]/)
            .some(
              (text) =>
                !(
                  towerId.toLowerCase().includes(text.toLowerCase()) ||
                  appliedUpgrades.some(
                    (upgrade) =>
                      upgrade.toLowerCase().includes(text) ||
                      upgrade
                        .toLowerCase()
                        .replaceAll(new RegExp(/[ -.]/, "g"), "")
                        .includes(text)
                  )
                )
            )
      )
      .map(([towerId, { towerSet }]) => ({
        kind: "button",
        text: "Import " + towerId,
        callbackKey: importTower.name,
        colour: towerSetColors[towerSet],
      }));
  }
}

export const importTower = async (button: FlyoutButton) => {
  const towerId = button.getButtonText().replace("Import ", "");

  if (!(towerId in allTowers)) return;

  button.getTargetWorkspace().getToolbox().clearSelection();

  const text = await getString(
    `${RawUserContent}/Btd6ModHelper/btd6-game-data/main/Towers/${allTowers[towerId].path}`
  );

  if (text) {
    pasteBlockFromText(button.getTargetWorkspace(), text);
  }
};
