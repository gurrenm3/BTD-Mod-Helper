import { Language } from "../lib/lanugage";
import * as fs from "node:fs";
import path from "path";
import { translateAll } from "../lib/translation";

const sourcePath =
  "C:/Program Files (x86)/Steam/steamapps/common/BloonsTD6/Mods/BloonsTD6 Mod Helper/Localization/English/BloonsTD6 Mod Helper.json";

const resultFolder = path.join(
  process.cwd(),
  "..",
  "BloonsTD6 Mod Helper",
  "Localization"
);

const sourceJson = JSON.parse(fs.readFileSync(sourcePath).toString());

(async () => {
  await translateAll(sourceJson, Language.English).then(async (result) =>
    Promise.all(
      Object.entries(result).map(([language, result]) => {
        const resultPath = path.join(resultFolder, language + ".json");

        return fs.promises.writeFile(resultPath, result);
      })
    )
  );
})();
