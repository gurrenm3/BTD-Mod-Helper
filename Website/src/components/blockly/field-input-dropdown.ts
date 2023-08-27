import { FieldTextInput, renderManagement } from "blockly";

export class FieldInputDropdown extends FieldTextInput {
  static type = "field_input_dropdown";

  protected widgetCreate_(): HTMLElement {
    const result = super.widgetCreate_();

    renderManagement.finishQueuedRenders().then(() => {
      this.resizeEditor_();
    });

    return result;
  }
}
