import {Language} from "./lanugage";
import {GoogleTranslator} from "anylang/translators";

const translator = new GoogleTranslator();

export const translateLocalization = async (
  inputJson: Record<string, any>,
  sourceLanguage: string,
  targetLanguage: string
) => {
  const validEntries = Object.entries(inputJson).filter(
    ([_, v]) => typeof v === "string"
  ) as [string, string][];

  const resultValues = await translator.translateBatch(
    validEntries.map(([_, v]) => v),
    sourceLanguage,
    targetLanguage
  );

  const result = Object.fromEntries(
    validEntries.map(([k, _], i) => [k, resultValues[i]])
  );

  return JSON.stringify(result, null, 2);
};

export const translateAll = async (
  inputJson: Record<string, any>,
  sourceLanguage: string
): Promise<Record<keyof typeof Language, string>> =>
  Object.fromEntries(
    await Promise.all(
      Object.entries(Language)
        .filter(([_, langCode]) => langCode !== sourceLanguage)
        .map(([language, langCode]) =>
          translateLocalization(inputJson, sourceLanguage, langCode)
            .then(async (result) => [language, result] as const)
            .catch((e) => {
              console.error("Failed to translate localization", language);
              console.error(e);
              return [language, {}] as const;
            })
        )
    )
  ) as Record<keyof typeof Language, string>;
