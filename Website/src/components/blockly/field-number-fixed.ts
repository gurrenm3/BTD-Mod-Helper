import { FieldNumber, renderManagement } from "blockly";

export class FieldNumberFixed extends FieldNumber {
  static type = "field_number";

  protected widgetCreate_(): HTMLInputElement {
    const result = super.widgetCreate_();

    renderManagement.finishQueuedRenders().then(() => {
      this.resizeEditor_();
    });

    return result;
  }
}
