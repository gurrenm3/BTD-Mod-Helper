import { CollapsibleToolboxCategory, Toolbox, utils } from "blockly";

export class CustomCollapsibleCategory extends CollapsibleToolboxCategory {
  canCollapse = false;

  onClick(_e: Event) {
    if (this.flyoutItems_.length === 0) {
      super.onClick(_e);
    }
    this.canCollapse = true;
  }

  setSelected(isSelected: boolean) {
    super.setSelected(isSelected);
    if (isSelected && this.flyoutItems_.length > 0) {
      this.setExpanded(true);
    }
    this.canCollapse = false;
  }

  setExpanded(isExpanded: boolean) {
    super.setExpanded(isExpanded);

    const category = this as CollapsibleToolboxCategory;
    const toolbox = category["parentToolbox_"] as Toolbox;
    const htmlDiv = toolbox.HtmlDiv;
    utils.style.scrollIntoContainerView(
      category.getDiv(),
      htmlDiv,
      !isExpanded
    );
  }
}
