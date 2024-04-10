import * as fs from "fs";
import path from "path";
import { globSync } from "glob";
import { chain } from "lodash";
import wiki from "../pages/wiki";

// Create maps list

const dataFolder = path.join(process.cwd(), "src", "data");
const mapsFolder = path.join(process.cwd(), "public", "images", "BTD6", "Maps");

const mapFiles = globSync(
  path.join(mapsFolder, "**", "*.png").replaceAll(path.sep, "/")
);

const maps = chain(mapFiles)
  .map((file) => path.relative(mapsFolder, file).replace(/\.png$/, ""))
  .orderBy((value) => value)
  .keyBy((value) =>
    value
      .replaceAll("#", "")
      .replace(/([a-z0–9])([A-Z])/g, "$1-$2")
      .toLowerCase()
  );

fs.writeFileSync(
  path.join(dataFolder, "maps.json"),
  JSON.stringify(maps, null, 2)
);

console.log("Created maps.json");

// Copy wiki images

const wikiFolder = path.join(process.cwd(), "..", "Wiki");
const publicFolder = path.join(process.cwd(), "public", "wiki", "images");

const publicImages = globSync(
  path.join(publicFolder, "**", "*.png").replaceAll(path.sep, "/")
);

publicImages.forEach((value) => fs.rmSync(value));

const wikiImages = globSync(
  path.join(wikiFolder, "**", "*.png").replaceAll(path.sep, "/")
);

wikiImages.forEach((value) =>
  fs.copyFileSync(value, path.join(publicFolder, path.basename(value)))
);

console.log("Copied wiki images");
