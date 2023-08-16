import {
  Field,
  FieldDropdown,
  FieldDropdownConfig,
  FieldDropdownValidator,
  Menu,
  MenuGenerator,
  MenuItem,
} from "blockly";

export class FieldMultiDropdown extends FieldDropdown {
  static type = "field_multi_dropdown";

  private readonly delimiter = ",";

  private readonly bitmap = false;

  constructor(menuGenerator: typeof Field.SKIP_SETUP);
  constructor(
    menuGenerator: MenuGenerator,
    validator?: FieldDropdownValidator,
    config?: FieldDropdownConfig
  );
  constructor(
    menuGenerator: typeof Field.SKIP_SETUP | MenuGenerator,
    validator?: FieldDropdownValidator,
    config?: FieldDropdownConfig
  ) {
    // @ts-ignore
    super(menuGenerator, validator, config);

    this.bitmap = config?.["bitmap"] ?? false;
    this.delimiter = config?.["delimiter"] ?? ",";

    const dropdownCreate = this["dropdownCreate"] as (
      this: FieldMultiDropdown
    ) => void;
    this["dropdownCreate"] = function (this) {
      dropdownCreate.call(this);
      this.dropdownCreate_();
    };
  }

  static fromJson(options) {
    return new FieldMultiDropdown(options.options, undefined, options);
  }

  private getValues(this) {
    const values = Object.fromEntries(
      this.getOptions(false).map(([, value]) => [value.toString(), false])
    );

    const value = this.getValue();

    if (this.bitmap) {
      const bitmap = parseInt(value);

      for (let key of Object.keys(values)) {
        const mask = parseInt(key);
        values[key] = (bitmap & mask) !== 0;
      }
    } else {
      for (let key of value.split(this.delimiter)) {
        values[key] = true;
      }
    }

    return values;
  }

  private setValues(values: Record<string, boolean>, fireChangedEvent = true) {
    if (this.bitmap) {
      let bitmap = 0;

      for (let [value, enabled] of Object.entries(values)) {
        if (enabled) {
          bitmap |= parseInt(value);
        }
      }

      this.setValue(bitmap.toString(), fireChangedEvent);
    } else {
      this.setValue(
        Object.entries(values)
          .filter(([, enabled]) => enabled)
          .map(([value]) => value)
          .join(this.delimiter),
        fireChangedEvent
      );
    }
  }

  private dropdownCreate_() {
    const menu = this.menu_;
    const menuItems = menu["menuItems"] as MenuItem[];

    const values = this.getValues();

    for (const menuItem of menuItems) {
      const key = this.bitmap
        ? parseInt(menuItem.getValue())
        : menuItem.getValue();
      menuItem.setChecked(values[key]);
    }
  }

  protected onItemSelected_(menu: Menu, menuItem: MenuItem) {
    const values = this.getValues();

    if (this.bitmap && menuItem.getValue() == "0") {
      this.getOptions(false).forEach(([, value]) => {
        values[value] = false;
      });
    } else {
      values[menuItem.getValue()] = !values[menuItem.getValue()];
    }

    this.setValues(values);
  }

  protected doClassValidation_(newValue?: string): string | null {
    const options = this.getOptions(true);

    if (this.bitmap) {
      const bitmap = parseInt(newValue);

      return bitmap >= 0 ? newValue : null;
    } else {
      return options.some((value) => newValue.includes(value[1]))
        ? newValue
        : null;
    }
  }

  getText_(): string {
    const options = Object.fromEntries(
      this.getOptions(true).map(([label, value]) => [value, label])
    );

    if (
      this.bitmap &&
      !Object.values(this.getValues()).some((enabled) => enabled)
    ) {
      return options["0"].toString();
    }

    return Object.entries(this.getValues())
      .filter(([, enabled]) => enabled)
      .map(([value]) => options[String(value)])
      .join(this.delimiter);
  }
}
