import * as fs from "fs";
import path from "path";
import { globSync } from "glob";
import { chain } from "lodash";

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
