import { KeyboardShortcut } from "blockly/core/shortcut_registry";
import Blockly, { Block, BlockSvg, WorkspaceSvg } from "blockly";
import { blockStateToModel, pasteBlockFromText } from "./json-conversion-utils";
import { loadFromJson, saveWorkspace } from "./blockly-context-menu";
import { LatestVersion } from "./mod-helper-data";

export const workspacePaste: KeyboardShortcut = {
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

export const workspaceCopy: KeyboardShortcut = {
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
      const model = blockStateToModel(blockState);

      model["$x"] = blockState.x;
      model["$y"] = blockState.y;
      model["$version"] = LatestVersion;

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

export const workspaceCut: KeyboardShortcut = {
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

export const saveWorkspaceShortcut: KeyboardShortcut = {
  name: "save",
  callback(workspace: WorkspaceSvg, event) {
    event.preventDefault();
    event.stopPropagation();
    saveWorkspace.callback({ workspace });
    return true;
  },
};

export const openJsonShortcut: KeyboardShortcut = {
  name: "open",
  callback(workspace: WorkspaceSvg, event) {
    event.preventDefault();
    event.stopPropagation();

    loadFromJson.callback({ workspace });

    return true;
  },
};
