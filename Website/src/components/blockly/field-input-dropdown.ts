import Blockly, {
  FieldTextInput,
  UnattachedFieldError,
  renderManagement,
  DropDownDiv,
  BlockSvg,
  Menu,
  MenuItem,
  MenuOption,
  FieldTextInputValidator,
  Field,
  WidgetDiv,
} from "blockly";
import { BlockArgDef } from "../../lib/blockly-types";
import { FieldInputFixed } from "./field-input-fixed";
import { KeyboardEvent } from "react";

export class FieldInputDropdown extends FieldInputFixed {
  static type = "field_input_dropdown";

  /** The dropdown menu. */
  protected menu_: Menu | null = null;

  private typesAndFields: Record<string, string>;

  /** A cache of the most recently generated options. */
  private generatedOptions: MenuOption[] | null = null;

  constructor(
    value: string | typeof Field.SKIP_SETUP,
    validator: FieldTextInputValidator | null,
    config: BlockArgDef
  ) {
    super(value, validator, config as any);
    this.typesAndFields = Object.fromEntries(config.options);
  }

  static fromJson(options: BlockArgDef): FieldInputDropdown {
    if (!options.options) {
      throw new Error("options are required for the dropdown field.");
    }

    return new this(options.text, null, options);
  }

  /**
   * Create a dropdown menu under the text.
   *
   * @param e Optional mouse event that triggered the field to open, or
   *     undefined if triggered programmatically.
   */
  protected override showEditor_(e?: MouseEvent) {
    super.showEditor_();

    const block = this.getSourceBlock();
    if (!block) {
      throw new UnattachedFieldError();
    }
    if (!this.dropdownCreate()) return;
    if (e && typeof e.clientX === "number") {
      this.menu_!.openingCoords = new Blockly.utils.Coordinate(
        e.clientX,
        e.clientY
      );
    } else {
      this.menu_!.openingCoords = null;
    }

    // Remove any pre-existing elements in the dropdown.
    DropDownDiv.clearContent();
    // Element gets created in render.
    const menuElement = this.menu_!.render(DropDownDiv.getContentDiv());
    Blockly.utils.dom.addClass(menuElement, "blocklyDropdownMenu");

    if (this.getConstants()!.FIELD_DROPDOWN_COLOURED_DIV) {
      const primaryColour = block.isShadow()
        ? block.getParent()!.getColour()
        : block.getColour();
      const borderColour = block.isShadow()
        ? (block.getParent() as BlockSvg).style.colourTertiary
        : (this.sourceBlock_ as BlockSvg).style.colourTertiary;
      DropDownDiv.setColour(primaryColour, borderColour);
    }

    DropDownDiv.showPositionedByField(this, this.dropdownDispose_.bind(this));

    // Focusing needs to be handled after the menu is rendered and positioned.
    // Otherwise it will cause a page scroll to get the misplaced menu in
    // view. See issue #1329.
    // this.menu_!.focus();

    /*if (this.selectedMenuItem) {
      this.menu_!.setHighlighted(this.selectedMenuItem);
      Blockly.utils.style.scrollIntoContainerView(
        this.selectedMenuItem.getElement()!,
        dropDownDiv.getContentDiv(),
        true
      );
    }*/

    for (let menuItem of this.menu_["menuItems"] as MenuItem[]) {
      menuItem.getElement().setAttribute("style", "padding-left: 15px;");
    }

    this.applyColour();
  }

  /** Create the dropdown editor. */
  private dropdownCreate() {
    const block = this.getSourceBlock();
    if (!block) {
      throw new UnattachedFieldError();
    }
    const options = this.getOptions(false);

    if (options.length === 0) {
      return false;
    }

    const menu = new Menu();
    menu.setRole(Blockly.utils.aria.Role.LISTBOX);
    this.menu_ = menu;

    // this.selectedMenuItem = null;
    for (let i = 0; i < options.length; i++) {
      const [label, value] = options[i];
      const content = (() => {
        if (typeof label === "object") {
          // Convert ImageProperties to an HTMLImageElement.
          const image = new Image(label["width"], label["height"]);
          image.src = label["src"];
          image.alt = label["alt"] || "";
          return image;
        }
        return label;
      })();
      const menuItem = new MenuItem(content, value);
      menuItem.setRole(Blockly.utils.aria.Role.OPTION);
      menuItem.setRightToLeft(block.RTL);
      menuItem.setCheckable(false);
      menu.addChild(menuItem);
      /*if (value === this.value_) {
        this.selectedMenuItem = menuItem;
      }*/
      menuItem.onAction(this.handleMenuActionEvent, this);
    }

    return true;
  }

  /**
   * Disposes of events and DOM-references belonging to the dropdown editor.
   */
  protected dropdownDispose_() {
    if (this.menu_) {
      this.menu_.dispose();
    }
    this.menu_ = null;
    // this.selectedMenuItem = null;
    this.applyColour();
  }

  /**
   * Handle an action in the dropdown menu.
   *
   * @param menuItem The MenuItem selected within menu.
   */
  private handleMenuActionEvent(menuItem: MenuItem) {
    DropDownDiv.hideIfOwner(this, true);
    this.onItemSelected_(this.menu_ as Menu, menuItem);
  }

  /**
   * Handle the selection of an item in the dropdown menu.
   *
   * @param menu The Menu component clicked.
   * @param menuItem The MenuItem selected within menu.
   */
  protected onItemSelected_(menu: Menu, menuItem: MenuItem) {
    this.setValue(menuItem.getValue());
    this.widgetDispose_();
    WidgetDiv.hide();
  }

  /**
   * Return a list of the options for this dropdown.
   *
   * @param useCache For dynamic options, whether or not to use the cached
   *     options or to re-generate them.
   * @returns A non-empty array of option tuples:
   *     (human-readable text or image, language-neutral name).
   * @throws {TypeError} If generated options are incorrectly structured.
   */
  getOptions(useCache?: boolean): MenuOption[] {
    if (useCache && this.generatedOptions) return this.generatedOptions;

    this.generatedOptions = this.getSourceBlock()
      .workspace.getTopBlocks(true)
      .filter((block) => block.type in this.typesAndFields)
      .map((block) => [
        block.getFieldValue(this.typesAndFields[block.type]),
        block.getFieldValue(this.typesAndFields[block.type]),
      ]);

    return this.generatedOptions;
  }
}
