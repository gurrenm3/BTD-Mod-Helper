import { CollapsibleToolboxCategory } from "blockly";

export class CustomCollapsibleCategory extends CollapsibleToolboxCategory {
  canCollapse = false;

  onClick(_e: Event) {
    this.canCollapse = true;
  }
  setSelected(isSelected: boolean) {
    super.setSelected(isSelected);
    if (isSelected) {
      this.setExpanded(true);
    }
    this.canCollapse = false;
  }
}
