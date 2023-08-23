import Blockly, { HorizontalFlyout } from "blockly";
import { FlyoutItem } from "blockly/core/flyout_base";

export class CustomHorizontalFlyout extends HorizontalFlyout {
  constructor(workspaceOptions: Blockly.Options) {
    super(workspaceOptions);
    this.getWorkspace().addChangeListener(
      (event: Blockly.Events.BlockCreate) => {
        if (event.type !== Blockly.Events.BLOCK_CREATE) return;

        const workspace = Blockly.Workspace.getById(event.workspaceId);
        const block = workspace.getBlockById(event.blockId);

        block?.["onCreate"]?.();
      }
    );
  }

  getFlyoutScale(): number {
    return 1;
  }

  protected layout_(contents: FlyoutItem[], gaps: number[]) {
    super.layout_(contents, gaps);

    for (let content of contents) {
      const block = content?.block;
      if (!block) continue;

      for (let icon of block.icons) {
        const clone = icon["svgRoot"].cloneNode(true);
        icon["svgRoot"].parentNode.replaceChild(clone, icon["svgRoot"]);
        // @ts-ignore
        icon["svgRoot"] = clone;
      }
    }
  }
}
