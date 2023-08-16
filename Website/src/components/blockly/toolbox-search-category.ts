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
import { BlockSearcher } from "./block-searcher";
import { SearchCategory } from "./search-category";
import { BlockInfo, ToolboxItemInfo } from "blockly/core/utils/toolbox";

/* eslint-disable @typescript-eslint/naming-convention */

/**
 * A toolbox category that provides a search field and displays matching blocks
 * in its flyout.
 */
export class ToolboxSearchCategory extends SearchCategory {
  static readonly registrationName = "search";

  private blockSearcher = new BlockSearcher();

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
    this.initBlockSearcher();
    this.categoryKind = ToolboxSearchCategory.registrationName;
  }

  /**
   * Returns a list of block types that are present in the toolbox definition.
   * @param schema A toolbox item definition.
   * @param allBlocks The set of all available blocks that have been encountered
   *     so far.
   */
  private getAvailableBlocks(
    schema: Blockly.utils.toolbox.ToolboxItemInfo,
    allBlocks: Set<BlockInfo>
  ) {
    if (
      "contents" in schema &&
      schema.kind !== ToolboxSearchCategory.registrationName
    ) {
      schema.contents.forEach((contents) => {
        this.getAvailableBlocks(contents, allBlocks);
      });
    } else if (schema.kind === "block") {
      if ("type" in schema && schema.type) {
        allBlocks.add(schema);
      }
    }
  }

  /**
   * Builds the BlockSearcher index based on the available blocks.
   */
  private initBlockSearcher() {
    if (this.categoryDef.contents.length > 0) {
      this.blockSearcher.indexBlocks(this.categoryDef.contents);
    } else {
      const availableBlocks = new Set<BlockInfo>();
      this.workspace_.options.languageTree.contents.map((item) =>
        this.getAvailableBlocks(item, availableBlocks)
      );
      this.blockSearcher.indexBlocks([...availableBlocks]);
    }
  }

  protected async getBlocks(): Promise<ToolboxItemInfo[]> {
    const query = this.searchField.value;
    return query ? this.blockSearcher.blockTypesMatching(query.trim()) : [];
  }
}
