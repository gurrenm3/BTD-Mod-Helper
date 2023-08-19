import Blockly, {
  Block,
  BlockSvg,
  clipboard,
  CollapsibleToolboxCategory,
  ContextMenuRegistry,
  ToolboxCategory,
  Workspace,
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
import { addBlock, getBlockInfo, searchToolbox } from "./blockly-utils";
import { StaticCategoryInfo, ToolboxInfo } from "blockly/core/utils/toolbox";
import { orderBy } from "lodash";
import { FieldHidden } from "../components/blockly/field-hidden";
import { openFile, saveFile } from "./file-dialogs";
import JsonConversionUtils, {
  recursiveSetCollapsed,
} from "./json-conversion-utils";
import CustomRenderer from "../components/blockly/custom-renderer";
import { FieldNumberFixed } from "../components/blockly/field-number-fixed";
import { FieldInputFixed } from "../components/blockly/field-input-fixed";
import { FieldMultiDropdown } from "../components/blockly/field-multi-dropdown";
import { CustomVerticalFlyout } from "../components/blockly/custom-vertical-flyout";
import { CustomHorizontalFlyout } from "../components/blockly/custom-horizontal-flyout";
import { allJsonBlocks, towerSetColors } from "./blockly-json";
import { KeyboardShortcut } from "blockly/core/shortcut_registry";

export const initBlocks = () => {
  for (let block of allJsonBlocks) {
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
      !block.category
    )
      continue;

    console.log(block.category);

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

  Blockly.blockRendering.register(CustomRenderer.name, CustomRenderer);

  ContextMenuRegistry.registry.unregister("blockInline");
  ContextMenuRegistry.registry.unregister("blockComment");
  ContextMenuRegistry.registry.register(collapseAll);
  ContextMenuRegistry.registry.register(showInToolbox);
  ContextMenuRegistry.registry.register(loadFromJson);
  ContextMenuRegistry.registry.register(saveToJson);
  ContextMenuRegistry.registry.register(toggleHat);

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
};

export const plugins = {
  [Blockly.registry.Type.FLYOUTS_HORIZONTAL_TOOLBOX.toString()]:
    CustomHorizontalFlyout.name,
  [Blockly.registry.Type.FLYOUTS_VERTICAL_TOOLBOX.toString()]:
    CustomVerticalFlyout.name,
};

export const initWorkspace = (workspace: WorkspaceSvg) => {
  workspace.addChangeListener((event: Blockly.Events.Click) => {
    if (event.type !== Blockly.Events.CLICK || event.targetType !== "block")
      return;

    const workspace = Blockly.Workspace.getById(event.workspaceId);
    const block = workspace.getBlockById(event.blockId);

    if (block.isInFlyout || !block.isMovable() || !workspace.options.collapse)
      return;

    const now = Date.now();

    if (now - (block["_lastClickTime"] ?? 0) < 300) {
      block.setCollapsed(!block.isCollapsed());
    }

    block["_lastClickTime"] = now;
  });
};

export const pasteBlockFromText = (workspace: WorkspaceSvg, text: string) => {
  try {
    const json = JSON.parse(text);
    const blockState = JsonConversionUtils.modelToBlockState(json);
    if (blockState.type.endsWith(".TowerModel")) {
      blockState.extraState["$hat"] = true;
    }
    const block = workspace.paste(blockState) as unknown as Block;
    recursiveSetCollapsed(block, true, false);
    block.setCollapsed(false);
    return true;
  } catch (e) {
    if (process.env.NODE_ENV !== "production") {
      console.warn(e);
    }
  }
  return false;
};

const collapseAll: ContextMenuRegistry.RegistryItem = {
  id: "blockCollapseExpandAll",
  displayText: ({ block }) =>
    block.inputList.some(
      (input) =>
        !input.connection?.targetBlock()?.isCollapsed() &&
        input.connection?.targetBlock()?.isMovable()
    )
      ? "Collapse Children"
      : "Expand Children",
  weight: 5,
  scopeType: ContextMenuRegistry.ScopeType.BLOCK,
  preconditionFn: ({ block }) =>
    !block!.isInFlyout &&
    block!.isMovable() &&
    block!.workspace.options.collapse
      ? "enabled"
      : "hidden",
  callback: ({ block }) => {
    const collapsed = block.isCollapsed();
    recursiveSetCollapsed(
      block,
      block.inputList.some(
        (input) =>
          !input.connection?.targetBlock()?.isCollapsed() &&
          input.connection?.targetBlock()?.isMovable()
      ),
      true,
      true
    );
    block.setCollapsed(collapsed);
  },
};

const showInToolbox: ContextMenuRegistry.RegistryItem = {
  id: "showInToolbox",
  displayText: "Show In Toolbox",
  weight: 6,
  scopeType: ContextMenuRegistry.ScopeType.BLOCK,
  preconditionFn: ({ block }) => (!block.isInFlyout ? "enabled" : "hidden"),
  callback: ({ block }) => {
    searchToolbox(
      block.type,
      block.workspace.targetWorkspace || block.workspace
    );
  },
};

const loadFromJson: ContextMenuRegistry.RegistryItem = {
  id: "loadFromJson",
  displayText: "Load From Json",
  weight: 6,
  scopeType: ContextMenuRegistry.ScopeType.WORKSPACE,
  preconditionFn: () => "enabled",
  callback: ({ workspace }) => {
    openFile(".json", (result) => {
      const modelJson = JSON.parse(result);

      const blockState = JsonConversionUtils.modelToBlockState(modelJson);
      blockState.extraState["$hat"] = true;

      const block = Blockly.serialization.blocks.append(blockState, workspace);

      recursiveSetCollapsed(block, true, false);

      block.setCollapsed(false);
    });
  },
};

const saveToJson: ContextMenuRegistry.RegistryItem = {
  id: "saveToJson",
  displayText: "Save To Json",
  weight: 6,
  scopeType: ContextMenuRegistry.ScopeType.BLOCK,
  preconditionFn: ({ block }) =>
    !block.isInFlyout && block.type.endsWith(".TowerModel")
      ? "enabled"
      : "hidden",
  callback: ({ block }) => {
    const blockState = Blockly.serialization.blocks.save(block);

    const modelJson = JsonConversionUtils.blockStateToModel(blockState);

    saveFile(
      JSON.stringify(modelJson, null, 2),
      "application/json",
      modelJson.name + ".json"
    );
  },
};

const toggleHat: ContextMenuRegistry.RegistryItem = {
  id: "toggleHat",
  displayText: "Toggle Hat",
  weight: 5,
  scopeType: ContextMenuRegistry.ScopeType.BLOCK,
  preconditionFn: ({ block }) =>
    !block.isInFlyout &&
    Blockly.Blocks[block.type].json?.hat &&
    Blockly.Blocks[block.type].json?.mutator === OptionalRows
      ? "enabled"
      : "hidden",
  callback: ({ block }) => {
    if (block.hat) {
      block.hat = undefined;
    } else {
      block.hat = "cap";
    }
    block.loadExtraState(block.saveExtraState());
  },
};

const workspacePaste: KeyboardShortcut = {
  name: Blockly.ShortcutItems.names.PASTE,
  preconditionFn: (workspace) =>
    !workspace.options.readOnly && !Blockly.Gesture.inProgress(),
  callback: (workspace: WorkspaceSvg, event) => {
    event.preventDefault();

    navigator.clipboard
      .readText()
      .then((text) => {
        if (!pasteBlockFromText(workspace, text)) {
          Blockly.clipboard.paste();
        }
      })
      .catch(() => Blockly.clipboard.paste());

    return true;
  },
};

const workspaceCopy: KeyboardShortcut = {
  name: Blockly.ShortcutItems.names.COPY,
  preconditionFn(workspace) {
    const selected = Blockly.getSelected();
    return (
      !workspace.options.readOnly &&
      !Blockly.Gesture.inProgress() &&
      (!selected || (selected.isDeletable() && selected.isMovable()))
    );
  },
  callback(workspace: WorkspaceSvg, event) {
    event.preventDefault();
    workspace.hideChaff();

    let selected =
      Blockly.getSelected() ??
      workspace
        .getTopBlocks(true)
        .find((block) => block.type.endsWith(".TowerModel"));

    if (!selected) return false;

    Blockly.clipboard.copy(selected);

    if (!(selected instanceof Block)) return false;

    const blockState = Blockly.serialization.blocks.save(selected, {
      addCoordinates: true,
    });

    try {
      const model = JsonConversionUtils.blockStateToModel(blockState);

      model["$x"] = blockState.x;
      model["$y"] = blockState.y;

      navigator.clipboard.writeText(JSON.stringify(model, null, 2));
      return true;
    } catch (e) {
      if (process.env.NODE_ENV !== "production") {
        console.warn(e);
      }
      return false;
    }
  },
};

const workspaceCut: KeyboardShortcut = {
  name: Blockly.ShortcutItems.names.CUT,
  preconditionFn(workspace) {
    const selected = Blockly.getSelected();
    return (
      !workspace.options.readOnly &&
      !Blockly.Gesture.inProgress() &&
      selected != null &&
      selected instanceof BlockSvg &&
      selected.isDeletable() &&
      selected.isMovable() &&
      !selected.workspace!.isFlyout
    );
  },
  callback(workspace: WorkspaceSvg, event, shortcut) {
    if (!workspaceCopy.callback(workspace, event, shortcut)) return false;

    const selected = Blockly.getSelected();
    if (selected instanceof Block) {
      (selected as BlockSvg).checkAndDelete();
    }

    return true;
  },
};

export default { registerAll, initBlocks, initToolbox };
