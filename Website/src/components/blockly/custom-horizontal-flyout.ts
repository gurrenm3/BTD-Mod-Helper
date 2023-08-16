import Blockly, { HorizontalFlyout } from "blockly";
import { FlyoutItem } from "blockly/core/flyout_base";

export class CustomHorizontalFlyout extends HorizontalFlyout {
  getFlyoutScale(): number {
    return 1;
  }
}
