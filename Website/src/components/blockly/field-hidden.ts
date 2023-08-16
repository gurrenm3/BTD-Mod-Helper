import { FieldLabelSerializable } from "blockly";

export class FieldHidden extends FieldLabelSerializable {
  static type = "field_hidden";

  constructor(opt_value: any, opt_class?: string, opt_config?: Object) {
    super(opt_value, opt_class, opt_config);
  }

  static fromJson(options) {
    return new FieldHidden(options.value);
  }

  getSize() {
    let size = super.getSize();
    size.width = -10;
    return size;
  }

  getDisplayText_() {
    return "";
  }

  getText(): string {
    return "";
  }
}
