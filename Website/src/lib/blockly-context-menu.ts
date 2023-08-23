import Blockly, { ContextMenuRegistry } from "blockly";
import {
  blockStateToModel,
  modelToBlockState,
  recursiveSetCollapsed,
} from "./json-conversion-utils";
import { searchToolbox } from "./blockly-utils";
import { OptionalRows } from "../components/blockly/optional-rows";
import { openFile, saveFile } from "./file-dialogs";
import ScopeType = ContextMenuRegistry.ScopeType;
import { LatestVersion } from "./mod-helper-data";

export const collapseAll: ContextMenuRegistry.RegistryItem = {
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
    block!.workspace.options.collapse &&
    block.inputList.some((input) => input.connection?.targetBlock())
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
      true
    );
    block.setCollapsed(collapsed);
  },
};

export const showInToolbox: ContextMenuRegistry.RegistryItem = {
  id: "showInToolbox",
  displayText: "Show In Toolbox",
  weight: 6,
  scopeType: ContextMenuRegistry.ScopeType.BLOCK,
  preconditionFn: () => "enabled",
  callback: ({ block }) => {
    searchToolbox(
      block.type,
      block.workspace.targetWorkspace || block.workspace
    );
  },
};

export const loadFromJson: ContextMenuRegistry.RegistryItem = {
  id: "loadFromJson",
  displayText: "Load Model/Workspace",
  weight: 7,
  scopeType: ContextMenuRegistry.ScopeType.WORKSPACE,
  preconditionFn: () => "enabled",
  callback: ({ workspace }) =>
    openFile(".json", (result) => {
      const json = JSON.parse(result);

      if ("$type" in json) {
        const blockState = modelToBlockState(json);

        const block = Blockly.serialization.blocks.append(
          blockState,
          workspace
        );

        recursiveSetCollapsed(block, true, false);

        block.setCollapsed(false);
      } else if (
        "blocks" in json &&
        (workspace.getTopBlocks(false).length == 0 ||
          confirm(
            "NOTE: You are loading a workspace. This replaces your current workspace and everything unsaved here will be lost. Continue?"
          ))
      ) {
        Blockly.serialization.workspaces.load(json, workspace, {
          recordUndo: true,
        });
      }
    }),
};

export const saveToJson: ContextMenuRegistry.RegistryItem = {
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

    const modelJson = blockStateToModel(blockState);
    modelJson["$version"] = LatestVersion;

    saveFile(
      JSON.stringify(modelJson, null, 2),
      "application/json",
      modelJson.name + ".json"
    );
  },
};

export const saveWorkspace: ContextMenuRegistry.RegistryItem = {
  id: "save",
  displayText: "Save Workspace",
  weight: 6,
  scopeType: ScopeType.WORKSPACE,
  preconditionFn: ({ workspace }) =>
    workspace.getTopBlocks(false).length > 0 ? "enabled" : "disabled",
  callback: ({ workspace }) => {
    if (workspace.getTopBlocks(false).length === 0) return false;

    const json = Blockly.serialization.workspaces.save(workspace);

    saveFile(
      JSON.stringify(json, null, 2),
      "json",
      `workspace ${new Date().toISOString()}.json`
    );

    return true;
  },
};
