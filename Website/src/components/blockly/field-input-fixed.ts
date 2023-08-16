import { FieldTextInput, renderManagement } from "blockly";

export class FieldInputFixed extends FieldTextInput {
  static type = "field_input";

  protected widgetCreate_(): HTMLElement {
    const result = super.widgetCreate_();

    renderManagement.finishQueuedRenders().then(() => {
      this.resizeEditor_();
    });

    return result;
  }
}
