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
import {
  FlyoutItemInfoArray,
  ToolboxItemInfo,
} from "blockly/core/utils/toolbox";

/* eslint-disable @typescript-eslint/naming-convention */

/**
 * A toolbox category that provides a search field and displays matching blocks
 * in its flyout.
 */
export abstract class SearchCategory extends Blockly.ToolboxCategory {
  protected searchField?: HTMLInputElement;
  protected categoryKind: string;
  protected categoryDef: Blockly.utils.toolbox.StaticCategoryInfo;
  protected defaultMessage: string;
  protected noResultsMessage: string;
  protected hasQueried = false;

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
    this.categoryDef = categoryDef;
    this.defaultMessage = "Type to search for blocks";
    this.noResultsMessage = "No matching blocks found";
  }

  /**
   * Initializes the search field toolbox category.
   * @returns The <div> that will be displayed in the toolbox.
   */
  protected override createDom_(): HTMLDivElement {
    const dom = super.createDom_();
    this.searchField = document.createElement("input");
    this.searchField.type = "search";
    this.searchField.placeholder = this.categoryDef.name;
    this.workspace_.RTL
      ? (this.searchField.style.marginRight = "8px")
      : (this.searchField.style.marginLeft = "8px");
    this.searchField.addEventListener("keyup", (event) => {
      if (event.key === "Escape") {
        this.parentToolbox_.clearSelection();
        return true;
      }

      this.matchBlocks();
    });
    this.rowContents_.innerHTML = "";
    this.rowContents_.appendChild(this.searchField);
    return dom;
  }

  setSearchQuery(query: string) {
    this.searchField.value = query;
  }

  /**
   * Returns the numerical position of this category in its parent toolbox.
   * @returns The zero-based index of this category in its parent toolbox, or -1
   *    if it cannot be determined, e.g. if this is a nested category.
   */
  private getPosition() {
    const categories = this.workspace_.options.languageTree.contents;
    for (let i = 0; i < categories.length; i++) {
      if (categories[i].kind === this.categoryKind) {
        return i;
      }
    }

    return -1;
  }

  /**
   * Handles a click on this toolbox category.
   * @param e The click event.
   */
  override onClick(e: Event) {
    super.onClick(e);
    e.preventDefault();
    e.stopPropagation();
    this.setSelected(this.parentToolbox_.getSelectedItem() === this);
  }

  /**
   * Handles changes in the selection state of this category.
   * @param isSelected Whether or not the category is now selected.
   */
  override setSelected(isSelected: boolean) {
    super.setSelected(isSelected);
    if (isSelected) {
      this.searchField.focus();
      this.matchBlocks();
    } else {
      this.searchField.value = "";
      this.searchField.blur();
    }
  }

  protected abstract getBlocks(): Promise<ToolboxItemInfo[]>;

  getAllContents(): FlyoutItemInfoArray | string {
    return super.getContents();
  }

  getContents(): FlyoutItemInfoArray | string {
    if (!this.hasQueried) {
      return [];
    }
    return super.getContents();
  }

  /**
   * Filters the available blocks based on the current query string.
   */
  private matchBlocks() {
    const query = this.searchField.value;
    const hasQuery = query.length >= 3;

    this.getBlocks().then((blocks) => {
      {
        this.hasQueried = true;
        this.flyoutItems_ = blocks ?? [];
        if (!this.flyoutItems_.length) {
          this.flyoutItems_.push({
            kind: "label",
            text: hasQuery ? this.noResultsMessage : this.defaultMessage,
          });
          if (!hasQuery) {
            this.flyoutItems_.push(...this.categoryDef.contents.slice(0, 20));
          }
        }

        if (this.flyoutItems_.length > 20) {
          this.flyoutItems_ = this.flyoutItems_.slice(0, 20);

          this.flyoutItems_.push({
            kind: "label",
            text: "...",
          });
        }

        this.parentToolbox_.refreshSelection();
      }
    });
  }
}
