// ******************************************************************************
// See issue https://github.com/google/blockly/issues/4369
// Blockly will not allow you to avoid printing out a bunch of useless
// localization warnings for messages we don't use.
// This clogs up unit testing logs, etc.
// The versions for both log and warn are because they keep changing which ones they are
// using across builds.
const tempConsoleLog = console.log;
const tempConsoleWarn = console.warn;
console.log = (message) => {
  if (message.startsWith("WARNING: No message string for %{")) return;
  else tempConsoleLog(message);
};
console.warn = (message) => {
  if (message.startsWith("No message string for %{")) return;
  else tempConsoleWarn(message);
};

import Blockly, { Workspace } from "blockly";
import { beforeAll, describe, test } from "@jest/globals";
import BlocklySetup from "../lib/blockly-setup";
import path from "path";
import * as fs from "fs";
import * as os from "os";
import { globSync } from "glob";
import {blockStateToModel, modelToBlockState} from "../lib/json-conversion-utils";

console.log = tempConsoleLog;
console.warn = tempConsoleWarn;

const inputPath = path.join(process.cwd(), "src", "__tests__");

const outputPath = path.join(process.cwd(), "out");

const localBTD6 = path.join(
  os.homedir(),
  "AppData",
  "LocalLow",
  "Ninja Kiwi",
  "BloonsTD6"
);

const towers = globSync(
  path.join(localBTD6, "Towers", "**", "*.json").replaceAll(path.sep, "/")
).map((towerPath) => [path.basename(towerPath), towerPath]);

const createDirectories = (folderPath: string) => {
  if (fs.existsSync(folderPath)) return;

  const parentFolder = path.resolve(folderPath, "..");

  if (!fs.existsSync(parentFolder)) {
    createDirectories(parentFolder);
  }

  fs.mkdirSync(folderPath);
};

const saveFile = async (filePath: string, contents: string) => {
  const folder = path.resolve(filePath, "..");

  createDirectories(folder);

  await fs.promises.writeFile(filePath, contents);
};

describe("JSON Conversion", () => {
  beforeAll(() => {
    BlocklySetup.registerAll();
    BlocklySetup.initBlocks();
  });

  test("conversion round trip", () => {
    const tower = JSON.parse(
      fs
        .readFileSync(
          path.join(localBTD6, "Towers", "PatFusty", "PatFusty 5.json")
        )
        .toString()
    );

    const blockState = modelToBlockState(tower);

    fs.writeFileSync(
      path.join(outputPath, "blockState.json"),
      JSON.stringify(blockState, null, 2)
    );

    const workspace = new Workspace();

    const block = Blockly.serialization.blocks.append(blockState, workspace);

    const json = blockStateToModel(
      Blockly.serialization.blocks.save(block)
    );

    fs.writeFileSync(
      path.join(outputPath, "output.json"),
      JSON.stringify(json, null, 2)
    );

    workspace.dispose();
  });

  test.each(towers)("conversion of %s", async (name, towerPath) => {
    const relativePath = path.relative(localBTD6, towerPath);

    const tower = JSON.parse(
      (await fs.promises.readFile(towerPath)).toString()
    );

    const blockState = modelToBlockState(tower);

    await saveFile(
      path.join(outputPath, relativePath.replace("Towers", "BlockStates")),
      JSON.stringify(blockState, null, 2)
    );

    const workspace = new Workspace();

    const block = Blockly.serialization.blocks.append(blockState, workspace);

    const json = blockStateToModel(
      Blockly.serialization.blocks.save(block)
    );

    await saveFile(
      path.join(outputPath, relativePath),
      JSON.stringify(json, null, 2)
    );

    workspace.dispose();
  });
});
