import { BlockArgDef, BlockDef } from "./blockly-types";
import Blockly, { Block, WorkspaceSvg } from "blockly";
import { argsList, getBlockInfo, getBlockInputs } from "./blockly-utils";
import { merge } from "lodash";
import {
  audioSourceReferenceMap,
  prefabReferenceMap,
  spriteReferenceMap,
  towerIds,
  upgradeIds,
} from "./blockly-json";

const blocksByFullType: Record<string, string> = {};

export const unstringify = (value) => {
  try {
    return JSON.parse(value);
  } catch (_) {
    return value;
  }
};

export const addBlockToMap = (block: BlockDef) => {
  const fullType = block.args0?.find((arg) => arg.name === "$type")?.value;

  if (fullType && typeof fullType === "string") {
    if (!(fullType in blocksByFullType)) {
      blocksByFullType[fullType] = block.type;
    } else {
      // console.log("Duplicate ", fullType);
    }
  }
};

export const recursiveSetCollapsed = (
  block?: Block,
  collapsed: boolean = true,
  doAll = false
) => {
  if (!block) return;

  if (
    !block.isShadow() &&
    block.type !== "int[]" &&
    (doAll ||
      (block.inputList.some(
        (input) =>
          input.connection || input.fieldRow.some((field) => field.EDITABLE)
      ) &&
        !block.type.endsWith(".Model[]") &&
        !block.type.endsWith(".WeaponModel[]")))
  ) {
    Blockly.Events.setRecordUndo(false);
    block.setCollapsed(collapsed);
    Blockly.Events.setRecordUndo(true);
  }

  for (let input of block.inputList) {
    recursiveSetCollapsed(input.connection?.targetBlock(), collapsed, doAll);
  }
};

const arrayToBlockState = (
  value: any[],
  expectedType: string
): Blockly.serialization.blocks.ConnectionState => {
  if (!value) {
    return {
      shadow: {
        type: expectedType,
      },
    };
  }

  if (value.length <= 0) {
    return {
      shadow: {
        type: expectedType,
        extraState: {
          itemCount: 0,
        },
        fields: { $data: "[]" },
      },
    };
  }

  const blockDef = Blockly.Blocks[expectedType]?.json as BlockDef;
  const arg = argsList(blockDef).find((arg) => arg.name === "i");

  const arrayBlock = {
    type: expectedType,
    extraState: {
      itemCount: value.length,
    },
    inputs: {},
    fields: {},
  } as Blockly.serialization.blocks.State;

  const arrayInput = getBlockInputs(expectedType)["i"];
  for (let i = 0; i < value.length; i++) {
    if (arrayInput) {
      arrayBlock.inputs["i" + i] = getBlockInputs(expectedType)["i"];
    }
    handleArg(arrayBlock, arg, "i" + i, value[i]);
  }

  return {
    block: arrayBlock,
  };
};

const dictToBlockState = (
  value: object | null,
  expectedType: string
): Blockly.serialization.blocks.ConnectionState => {
  if (!value) {
    return {
      shadow: {
        type: expectedType,
      },
    };
  }

  // 1 and not 0 because of the $type
  if (Object.values(value).length === 1) {
    return {
      shadow: {
        type: expectedType,
        extraState: {
          itemCount: 0,
        },
        fields: { $data: "" },
      },
    };
  }

  const dictBlock = {
    type: expectedType,
    extraState: {
      itemCount: Object.values(value).length - 1,
    },
    inputs: {},
    fields: {},
  } as Blockly.serialization.blocks.State;

  const blockDef = Blockly.Blocks[expectedType]?.json as BlockDef;
  const arg = argsList(blockDef).find((arg) => arg.name === "value");

  const dictInput = getBlockInputs(expectedType)["value"];

  let i = 0;
  for (let [key, val] of Object.entries(value)) {
    if (key.startsWith("$type")) continue;
    dictBlock.fields["key" + i] = key;
    if (dictInput) {
      dictBlock.inputs["value" + i] = getBlockInputs(expectedType)["value"];
    }
    handleArg(dictBlock, arg, "value" + i, val);
    i++;
  }

  return { block: dictBlock };
};

const towerIdToBlockState = (
  value: string
): Blockly.serialization.blocks.ConnectionState => {
  if (value in towerIds) {
    return {
      block: { type: `Tower_${value}` },
    };
  }

  const towerWithTiers = value.match(/(\w+)-(\d)(\d)(\d)/);

  if (towerWithTiers) {
    const [, baseId, top, mid, bot] = towerWithTiers;

    const inputs = getBlockInputs("TowerWithTiers");

    merge(inputs.baseId, towerIdToBlockState(baseId));

    return {
      block: {
        type: "TowerWithTiers",
        inputs,
        fields: {
          top,
          mid,
          bot,
        },
      },
    };
  }

  const heroWithLevel = value.match(/(\w+) (\d\d?)/);

  if (heroWithLevel) {
    const [, baseId, level] = heroWithLevel;

    const inputs = getBlockInputs("HeroWithLevel");

    merge(inputs.baseId, towerIdToBlockState(baseId));

    return {
      block: {
        type: "HeroWithLevel",
        inputs,
        fields: {
          level,
        },
      },
    };
  }

  return { shadow: { type: "string_shadow", fields: { $data: value } } };
};

const upgradeIdToBlockState = (
  value: string
): Blockly.serialization.blocks.ConnectionState => {
  if (value in upgradeIds) {
    return {
      block: { type: `Upgrade_${value}` },
    };
  }

  return { shadow: { type: "string_shadow", fields: { $data: value } } };
};

const handleArg = (
  block: Blockly.serialization.blocks.State,
  arg: BlockArgDef,
  key: string,
  value: any
) => {
  const blockDef = Blockly.Blocks[block.type]?.json as BlockDef;

  const isOptional = Object.values(
    blockDef.mutatorOptions?.optional ?? {}
  ).includes(key);

  const defaultValue = arg["value"] ?? arg["text"] ?? arg["options"]?.[0][1];

  if (arg.type.startsWith("field")) {
    value = String(value);
    const isNotDefault = value !== defaultValue;
    if (isOptional) {
      block.extraState[key] = isNotDefault;
    }
    if (isNotDefault || !isOptional) {
      block.fields[key] = value;
    }
  } else if (arg.type.startsWith("input")) {
    const input = block.inputs[key];
    handleInput(input, arg, value);
    if (isOptional) {
      block.extraState[key] = true;
    }
  } else {
    console.warn(
      `Don't know how to handle arg type ${arg.type} for ${block.type}.${key}`
    );
  }
};

const handleInput = (
  input: Blockly.serialization.blocks.ConnectionState,
  arg: BlockArgDef,
  value: any
) => {
  const expectedType = input.shadow.type;
  if (expectedType.endsWith("[]")) {
    delete input.shadow;
    merge(input, arrayToBlockState(value, expectedType));
  } else if (expectedType.includes("<>")) {
    delete input.shadow;
    merge(input, dictToBlockState(value, expectedType));
  } else if (value) {
    if (typeof value === "string") {
      if (arg.check.includes("Tower")) {
        merge(input, towerIdToBlockState(value));
      } else if (arg.check.includes("Upgrade")) {
        merge(input, upgradeIdToBlockState(value));
      } else {
        console.error("Did not expect string ", value);
        return null;
      }
    } else {
      input.block = modelToBlockState(value);
    }
  }
};

export const modelToBlockState = (
  model: object
): Blockly.serialization.blocks.State => {
  const fullType = model["$type"];
  if (!fullType) {
    console.error("Not a valid model ", model);
    return null;
  }

  const type = blocksByFullType[fullType];
  const blockDef = Blockly.Blocks[type]?.json as BlockDef;
  if (!type || !blockDef) {
    console.error("Couldn't find block with type", type);
    return null;
  }

  // Special cases
  if (
    (type.endsWith("PrefabReference") &&
      model["guidRef"] in prefabReferenceMap) ||
    (type.endsWith("AudioSourceReference") &&
      model["guidRef"] in audioSourceReferenceMap) ||
    (type.endsWith("SpriteReference") && model["guidRef"] in spriteReferenceMap)
  ) {
    return getBlockInfo(`${type}_${model["guidRef"]}`);
  }

  const argsByKey = Object.fromEntries(
    argsList(blockDef).map((arg) => [arg.name, arg])
  );

  const block: Blockly.serialization.blocks.State = {
    type,
    fields: {},
    inputs: getBlockInputs(type, false),
    extraState: {},
  };

  // Handle args
  for (let [key, value] of Object.entries(model)) {
    if (key.startsWith("$")) continue;
    if (!(key in argsByKey)) {
      key = Object.keys(argsByKey).find(
        (k) => k.toLowerCase() == key.toLowerCase()
      );
      if (!key) continue;
    }
    const arg = argsByKey[key];

    if (key === "name" && typeof value === "string") {
      value = value.replace(
        type.substring(type.lastIndexOf(".") + 1) + "_",
        ""
      );
    }

    handleArg(block, arg, key, value);
  }

  if ("$x" in model) {
    block.x = parseInt(String(model["$x"]));
  }
  if ("$y" in model) {
    block.y = parseInt(String(model["$y"]));
  }

  return block;
};

export const blockStateToModel = (
  block: Blockly.serialization.blocks.State
) => {
  let model = {} as any;

  // Add the fields
  for (let [name, value] of Object.entries(block.fields ?? {})) {
    if (
      name === "name" &&
      !block.type.endsWith(".TowerModel") &&
      !block.type.endsWith(".ApplyModModel")
    ) {
      value =
        block.type.substring(block.type.lastIndexOf(".") + 1) + "_" + value;
    }
    model[name] = unstringify(value);
  }

  // Add the inputs
  for (let [name, input] of Object.entries(block.inputs ?? {})) {
    const childBlock = input.block ?? input.shadow;

    model[name] = blockStateToModel(childBlock);
  }

  // Handle custom block data
  if ("$data" in model) {
    return unstringify(model["$data"]);
  }

  if (
    block.data &&
    !(typeof block.data === "string" && block.data.startsWith("BLOCKLY_"))
  ) {
    return block.data === "null" ? null : unstringify(block.data);
  }

  if (block.data === "BLOCKLY_ARRAY") {
    model = Object.values(model);
  }

  if (block.data === "BLOCKLY_DICTIONARY") {
    for (
      let i = 0, key, value;
      (key = model["key" + i]) && (value = model["value" + i]);
      i++
    ) {
      model[key] = value;
      delete model["key" + i];
      delete model["value" + i];
    }
  }

  if (block.data === "BLOCKLY_TOWER_TIERS") {
    const { baseId, top, mid, bot } = model;
    if (top + mid + bot > 0) {
      model = `${baseId}-${top}${mid}${bot}`;
    } else {
      model = baseId;
    }
  }

  if (block.data === "BLOCKLY_HERO_LEVEL") {
    const { baseId, level } = model;
    if (level > 1) {
      model = `${baseId} ${level}`;
    } else {
      model = baseId;
    }
  }

  return model;
};

export const pasteBlockFromText = (workspace: WorkspaceSvg, text: string) => {
  try {
    const json = JSON.parse(text);
    const blockState = modelToBlockState(json);
    const block = workspace.paste(blockState) as unknown as Block;
    recursiveSetCollapsed(block, true);
    block.setCollapsed(false);
    return true;
  } catch (e) {
    if (process.env.NODE_ENV !== "production") {
      console.warn(e);
    }
  }
  return false;
};

export const extraBlockInfo = (type) => ({
  ...(Blockly.Blocks[type].json?.comment
    ? {
        icons: {
          comment: {
            text: Blockly.Blocks[type].json?.comment,
            height: 50,
            width: 300,
          },
        },
      }
    : {}),
});
