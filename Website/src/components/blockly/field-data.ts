import { FieldLabel } from "blockly";

export class FieldData extends FieldLabel {
  static type = "field_data";

  constructor(opt_class?: string, opt_config?: Object) {
    super(null, opt_class, opt_config);
    this.EDITABLE = false;
    this.SERIALIZABLE = false;
  }

  static fromJson(options) {
    return new FieldData();
  }

  getDisplayText_() {
    return this.getSourceBlock().data;
  }

  getText(): string {
    return this.getSourceBlock().data;
  }

  getValue(): string | null {
    return this.getSourceBlock().data;
  }
}
