import Blockly, {
  BlockSvg,
  CollapsibleToolboxCategory,
  ContextMenuRegistry,
  hasBubble,
  ISelectableToolboxItem,
  Toolbox,
  ToolboxCategory,
  WorkspaceSvg,
} from "blockly";
import { FieldMinus } from "../components/blockly/field-minus";
import { ToolboxSearchCategory } from "../components/blockly/toolbox-search-category";
import {
  OptionalRows,
  OptionalRowsFn,
  OptionalRowsMixin,
} from "../components/blockly/optional-rows";
import {
  PlusMinusRows,
  PlusMinusRowsFn,
  PlusMinusRowsMixin,
} from "../components/blockly/plus-minus-rows";
import { FieldPlus } from "../components/blockly/field-plus";
import { addBlock, getBlockInfo } from "./blockly-utils";
import { StaticCategoryInfo, ToolboxInfo } from "blockly/core/utils/toolbox";
import { orderBy } from "lodash";
import { FieldHidden } from "../components/blockly/field-hidden";
import CustomRenderer from "../components/blockly/custom-renderer";
import { FieldNumberFixed } from "../components/blockly/field-number-fixed";
import { FieldInputFixed } from "../components/blockly/field-input-fixed";
import { FieldMultiDropdown } from "../components/blockly/field-multi-dropdown";
import { CustomVerticalFlyout } from "../components/blockly/custom-vertical-flyout";
import { CustomHorizontalFlyout } from "../components/blockly/custom-horizontal-flyout";
import { allJsonBlocks, towerSetColors } from "./blockly-json";
import { CustomCollapsibleCategory } from "../components/blockly/custom-collapsible-category";
import { FieldData } from "../components/blockly/field-data";

import {
  collapseAll,
  loadFromJson,
  saveToJson,
  saveWorkspace,
  showInToolbox,
} from "./blockly-context-menu";
import {
  openJsonShortcut,
  saveWorkspaceShortcut,
  workspaceCopy,
  workspaceCut,
  workspacePaste,
} from "./blockly-shortcuts";
import { ToggleHat, ToggleHatMixin } from "../components/blockly/toggle-hat";

const allowCustomBlocks = process.env.NODE_ENV === "development";

export const initBlocks = () => {
  for (let block of allJsonBlocks) {
    if (allowCustomBlocks) {
      switch (block.type) {
        case "Il2CppAssets.Scripts.Models.Towers.TowerModel":
          block.nextStatement = "CustomTower";
          break;
        case "Il2CppAssets.Scripts.Models.Towers.Upgrades.UpgradeModel":
          block.nextStatement = "CustomUpgrade";
          break;
      }
    } else if (block.subcategory === "Custom") {
      continue;
    }

    addBlock(block);
  }
};

export const initToolbox = (toolbox: ToolboxInfo) => {
  const categories = {} as Record<string, StaticCategoryInfo>;

  const subcategories = {} as Record<
    string,
    Record<string, StaticCategoryInfo>
  >;

  for (let block of allJsonBlocks) {
    if (
      block.type.includes("[]") ||
      block.type.includes("<>") ||
      !block.category ||
      (block.subcategory === "Custom" && !allowCustomBlocks)
    )
      continue;

    let category = (categories[block.category] ??= {
      kind:
        block.category === "Upgrades"
          ? ToolboxSearchCategory.registrationName
          : "category",
      name: block.category,
      contents: [],
    } as StaticCategoryInfo);

    if (
      !category.colour ||
      parseInt(block.colour) < parseInt(category.colour)
    ) {
      category.colour = String(block.colour);
    }

    if (block.subcategory) {
      const subcategory = (subcategories[block.category] ??= {});
      category = subcategory[block.subcategory] ??= {
        kind: block.subcategory.endsWith("References")
          ? ToolboxSearchCategory.registrationName
          : "category",
        name: block.subcategory,
        contents: [],
      } as StaticCategoryInfo;
      category.colour ||= String(block.colour);
    }

    category.contents.push(getBlockInfo(block.type));
  }

  for (let [name, category] of Object.entries(categories)) {
    if (!(name in subcategories)) continue;

    category.kind = CollapsibleToolboxCategory.registrationName;

    orderBy(Object.values(subcategories[name]), (c) =>
      c.name in towerSetColors
        ? Object.keys(towerSetColors).indexOf(c.name)
        : parseInt(c.colour)
    ).forEach((c) => category.contents.push(c));
  }

  orderBy(Object.values(categories), (category) =>
    parseInt(category.colour)
  ).forEach((category) => toolbox.contents.push(category));
};

export const registerAll = () => {
  Blockly.utils.colour.setHsvSaturation(0.66);
  ToolboxCategory.nestedPadding = 10;

  Blockly.fieldRegistry.register(FieldHidden.type, FieldHidden);
  Blockly.fieldRegistry.register(FieldPlus.type, FieldPlus);
  Blockly.fieldRegistry.register(FieldMinus.type, FieldMinus);
  Blockly.fieldRegistry.register(FieldMultiDropdown.type, FieldMultiDropdown);
  Blockly.fieldRegistry.register(FieldData.type, FieldData);

  Blockly.fieldRegistry.unregister("field_input");
  Blockly.fieldRegistry.unregister("field_number");
  Blockly.fieldRegistry.register(FieldInputFixed.type, FieldInputFixed);
  Blockly.fieldRegistry.register(FieldNumberFixed.type, FieldNumberFixed);

  Blockly.registry.register(
    Blockly.registry.Type.TOOLBOX_ITEM,
    ToolboxSearchCategory.registrationName,
    ToolboxSearchCategory
  );
  Blockly.registry.register(
    Blockly.registry.Type.FLYOUTS_HORIZONTAL_TOOLBOX,
    CustomHorizontalFlyout.name,
    CustomHorizontalFlyout
  );
  Blockly.registry.register(
    Blockly.registry.Type.FLYOUTS_VERTICAL_TOOLBOX,
    CustomVerticalFlyout.name,
    CustomVerticalFlyout
  );
  Blockly.registry.unregister(
    Blockly.registry.Type.TOOLBOX_ITEM,
    CollapsibleToolboxCategory.registrationName
  );
  Blockly.registry.register(
    Blockly.registry.Type.TOOLBOX_ITEM,
    CollapsibleToolboxCategory.registrationName,
    CustomCollapsibleCategory
  );

  Blockly.Extensions.registerMutator(
    OptionalRows,
    OptionalRowsMixin,
    OptionalRowsFn
  );
  Blockly.Extensions.registerMutator(
    PlusMinusRows,
    PlusMinusRowsMixin,
    PlusMinusRowsFn
  );
  Blockly.Extensions.registerMixin(ToggleHat, ToggleHatMixin);

  Blockly.blockRendering.register(CustomRenderer.name, CustomRenderer);

  ContextMenuRegistry.registry.unregister("blockInline");
  ContextMenuRegistry.registry.unregister("blockComment");
  ContextMenuRegistry.registry.register(collapseAll);
  ContextMenuRegistry.registry.register(showInToolbox);
  ContextMenuRegistry.registry.register(loadFromJson);
  ContextMenuRegistry.registry.register(saveToJson);
  Blockly.ContextMenuRegistry.registry.register(saveWorkspace);

  Blockly.ShortcutRegistry.registry.unregister(
    Blockly.ShortcutItems.names.PASTE
  );
  Blockly.ShortcutRegistry.registry.register(workspacePaste);
  const ctrlV = Blockly.ShortcutRegistry.registry.createSerializedKey(
    Blockly.utils.KeyCodes.V,
    [Blockly.utils.KeyCodes.CTRL]
  );
  Blockly.ShortcutRegistry.registry.addKeyMapping(
    ctrlV,
    Blockly.ShortcutItems.names.PASTE
  );
  const altV = Blockly.ShortcutRegistry.registry.createSerializedKey(
    Blockly.utils.KeyCodes.V,
    [Blockly.utils.KeyCodes.ALT]
  );
  Blockly.ShortcutRegistry.registry.addKeyMapping(
    altV,
    Blockly.ShortcutItems.names.PASTE
  );

  Blockly.ShortcutRegistry.registry.unregister(
    Blockly.ShortcutItems.names.COPY
  );
  Blockly.ShortcutRegistry.registry.register(workspaceCopy);
  const ctrlC = Blockly.ShortcutRegistry.registry.createSerializedKey(
    Blockly.utils.KeyCodes.C,
    [Blockly.utils.KeyCodes.CTRL]
  );
  Blockly.ShortcutRegistry.registry.addKeyMapping(
    ctrlC,
    Blockly.ShortcutItems.names.COPY
  );
  const altC = Blockly.ShortcutRegistry.registry.createSerializedKey(
    Blockly.utils.KeyCodes.C,
    [Blockly.utils.KeyCodes.ALT]
  );
  Blockly.ShortcutRegistry.registry.addKeyMapping(
    altC,
    Blockly.ShortcutItems.names.COPY
  );

  Blockly.ShortcutRegistry.registry.unregister(Blockly.ShortcutItems.names.CUT);
  Blockly.ShortcutRegistry.registry.register(workspaceCut);
  const ctrlX = Blockly.ShortcutRegistry.registry.createSerializedKey(
    Blockly.utils.KeyCodes.X,
    [Blockly.utils.KeyCodes.CTRL]
  );
  Blockly.ShortcutRegistry.registry.addKeyMapping(
    ctrlX,
    Blockly.ShortcutItems.names.CUT
  );

  Blockly.ShortcutRegistry.registry.register(saveWorkspaceShortcut);
  const ctrlS = Blockly.ShortcutRegistry.registry.createSerializedKey(
    Blockly.utils.KeyCodes.S,
    [Blockly.utils.KeyCodes.CTRL]
  );
  Blockly.ShortcutRegistry.registry.addKeyMapping(ctrlS, "save");

  Blockly.ShortcutRegistry.registry.register(openJsonShortcut);
  const ctrlO = Blockly.ShortcutRegistry.registry.createSerializedKey(
    Blockly.utils.KeyCodes.O,
    [Blockly.utils.KeyCodes.CTRL]
  );
  Blockly.ShortcutRegistry.registry.addKeyMapping(ctrlO, "open");

  ToolboxCategory.prototype["addColourBorder_"] = function (colour) {
    const style = this.rowDiv_.style;
    style.border =
      ToolboxCategory.borderWidth + "px solid " + (colour || "#ddd");
  };
};

export const plugins = {
  [Blockly.registry.Type.FLYOUTS_HORIZONTAL_TOOLBOX.toString()]:
    CustomHorizontalFlyout.name,
  [Blockly.registry.Type.FLYOUTS_VERTICAL_TOOLBOX.toString()]:
    CustomVerticalFlyout.name,
};

export const initWorkspace = (workspace: WorkspaceSvg) => {
  // This is better than the MIT one because it ignores clicks on block icons, shadow blocks, etc
  workspace.addChangeListener((event: Blockly.Events.Click) => {
    if (event.type !== Blockly.Events.CLICK || event.targetType !== "block")
      return;

    const workspace = Blockly.Workspace.getById(event.workspaceId);
    const block = workspace.getBlockById(event.blockId) as BlockSvg;

    if (block.isInFlyout || !block.isMovable() || !workspace.options.collapse)
      return;

    const now = Date.now();

    if (now - (block["_lastClickTime"] ?? 0) < 300) {
      block.setCollapsed(!block.isCollapsed());
    }

    block["_lastClickTime"] = now;
  });

  // Click on workspace to close mutator bubbles
  workspace.addChangeListener((event: Blockly.Events.Click) => {
    if (event.type !== Blockly.Events.CLICK || event.targetType !== "workspace")
      return;

    const workspace = Blockly.Workspace.getById(
      event.workspaceId
    ) as WorkspaceSvg;

    if (workspace.isMutator) return;

    workspace.getAllBlocks(false).forEach((block) => {
      for (let icon of block.getIcons()) {
        if (hasBubble(icon) && icon.bubbleIsVisible()) {
          icon.setBubbleVisible(false);
        }
      }
    });
  });

  // Improved behavior of collapsible categories with content as well
  workspace.addChangeListener((event: Blockly.Events.ToolboxItemSelect) => {
    if (event.type !== Blockly.Events.TOOLBOX_ITEM_SELECT) return;

    const workspace = Blockly.Workspace.getById(
      event.workspaceId
    ) as WorkspaceSvg;
    const toolbox = workspace.getToolbox() as Toolbox;
    const oldItem = toolbox
      .getToolboxItems()
      .find((item: ISelectableToolboxItem) => item.getName() == event.oldItem);
    const newItem = toolbox
      .getToolboxItems()
      .find((item: ISelectableToolboxItem) => item.getName() == event.newItem);

    if (
      !newItem &&
      oldItem instanceof CustomCollapsibleCategory &&
      oldItem.canCollapse
    ) {
      oldItem.setExpanded(false);
      toolbox.clearSelection();
    }
  });

  workspace.addChangeListener((event: Blockly.Events.BlockCreate) => {
    if (event.type !== Blockly.Events.BLOCK_CREATE) return;

    const workspace = Blockly.Workspace.getById(event.workspaceId);
    const block = workspace.getBlockById(event.blockId);

    block?.["onCreate"]?.();
  });
};

export default { registerAll, initBlocks, initToolbox };
