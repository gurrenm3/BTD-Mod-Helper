import * as fs from "fs";
import path from "path";
import { globSync } from "glob";

/*const wikiDirectory = path
  .join(process.cwd(), "..", "Wiki")
  .replaceAll(path.sep, "/");
const dataFile = path
  .join(process.cwd(), "src", "data", "wiki-pages.json")
  .replaceAll(path.sep, "/");

const paths = globSync(
  path.join(wikiDirectory, "**", "*.md").replaceAll(path.sep, "/")
);

const files = paths
  .map((file) => path.relative(wikiDirectory, file).replace(/\.md$/, ""))
  .filter((file) => !file.startsWith("_"));

fs.writeFileSync(dataFile, JSON.stringify(files, null, 2));*/
