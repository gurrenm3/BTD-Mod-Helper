import { use100vh } from "react-div-100vh";
import Layout, {
  ModHelperScrollBars,
  switchSize,
} from "../../components/layout";
import React, { useCallback, useEffect, useRef, useState } from "react";
import ModHelperHelmet from "../../components/helmet";
import { Button, Col, Container, Dropdown, Form, Row } from "react-bootstrap";
import { useDebounce } from "react-use";
import DropdownToggle from "react-bootstrap/DropdownToggle";
import DropdownMenu from "react-bootstrap/DropdownMenu";
import DropdownItem from "react-bootstrap/DropdownItem";
import { Language } from "../../lib/lanugage";
import { highlight, languages } from "prismjs/components/prism-core";
import Editor from "react-simple-code-editor"; //Example style, you can use another
import "prismjs/components/prism-json";
import "prismjs/themes/prism.css";
import { saveFile } from "../../lib/download";
import { translateAll, translateLocalization } from "../../lib/translation";
import JSZip from "jszip";

const LanguageDropdown = ({ language, setLanguage }) => {
  return (
    <Dropdown>
      <DropdownToggle
        className={"btd6-panel blue-insert-round"}
        variant={"outline-light"}
      >
        {language}
      </DropdownToggle>
      <DropdownMenu
        className={"non-main-panel bg-black btd6-panel blue-insert pe-0"}
      >
        <ModHelperScrollBars>
          {Object.keys(Language).map((name) => (
            <DropdownItem
              key={name}
              active={language == name}
              className={"p-0 me-3 w-auto text-white"}
              onClick={() => setLanguage(name)}
            >
              {name}
            </DropdownItem>
          ))}
        </ModHelperScrollBars>
      </DropdownMenu>
    </Dropdown>
  );
};

const Translate = () => {
  const height = use100vh() ?? 1000;

  const [inputText, setInputText] = useState("{}");
  const [inputJson, setInputJson] = useState<Record<string, any>>({});
  const [outputText, setOutputText] = useState("");
  const updateInputJson = () => {
    try {
      setInputJson(JSON.parse(inputText || "{}"));
    } catch (e) {}
  };
  const [sourceLanguage, setSourceLanguage] =
    useState<keyof typeof Language>("English");
  const [targetLanguage, setTargetLanguage] =
    useState<keyof typeof Language>("English");
  useDebounce(updateInputJson, 1000, [
    inputText,
    sourceLanguage,
    targetLanguage,
  ]);

  useEffect(() => {
    if (
      Object.keys(inputJson).length == 0 ||
      sourceLanguage === targetLanguage
    ) {
      setOutputText(JSON.stringify(inputJson, null, 4));
      return;
    }

    translateLocalization(
      inputJson,
      Language[sourceLanguage],
      Language[targetLanguage]
    )
      .then((result) => setOutputText(result))
      .catch((e) => {
        alert(`Translation Failed: ${e}`);
      });
  }, [inputJson, sourceLanguage]);

  const saveButton = useRef<HTMLButtonElement>(null);

  useEffect(() => {
    const handleSave = (event) => {
      if ((event.ctrlKey || event.metaKey) && event.key === "s") {
        event.preventDefault();
        saveButton.current?.click();
      }
    };

    window.addEventListener("keydown", handleSave);
    return () => window.removeEventListener("keydown", handleSave);
  }, [targetLanguage, outputText]);

  return (
    <Layout style={{ height }} footerClassName={`d-none`}>
      <ModHelperHelmet
        title={"Translate Tool"}
        description={"Auto translate localization files for BloonsTD6 Mods"}
      />
      <Container
        fluid={switchSize}
        className={`d-flex flex-column main-panel btd6-panel blue flex-1 gap-2`}
      >
        <Row className={"h-10"}>
          <Col xs={12} lg={6} className={"d-flex flex-column"}>
            <Row className={"g-2 mb-2"}>
              <Col xs={"auto"}>
                <LanguageDropdown
                  language={sourceLanguage}
                  setLanguage={setSourceLanguage}
                />
              </Col>
            </Row>
            <Editor
              className={"btd6-panel white-insert"}
              value={inputText}
              onValueChange={(code) => setInputText(code)}
              highlight={(code) => highlight(code, languages.json)}
              padding={10}
              style={{
                fontFamily: '"Fira code", "Fira Mono", monospace',
                fontSize: 12,
                minHeight: 400,
                outline: "none !important",
                color: "black",
              }}
            />
          </Col>
          <Col xs={12} lg={6} className={"d-flex flex-column"}>
            <Row className={"g-2 mb-2"}>
              <Col xs={"auto"}>
                <LanguageDropdown
                  language={targetLanguage}
                  setLanguage={setTargetLanguage}
                />
              </Col>
              <Col xs={"auto"}>
                <Button
                  className={
                    "btd6-button long blue h-100 luckiest-guy px-5 mx-1"
                  }
                  onClick={() =>
                    window.navigator.clipboard.writeText(outputText)
                  }
                >
                  Copy
                </Button>
              </Col>
              <Col xs={"auto"}>
                <Button
                  className={
                    "btd6-button long blue h-100 luckiest-guy px-5 mx-1"
                  }
                  ref={saveButton}
                  onClick={() =>
                    saveFile(
                      targetLanguage + ".json",
                      new Blob([outputText], { type: "text/plain" })
                    )
                  }
                >
                  Save
                </Button>
              </Col>
              <Col xs={"auto"} className={"ms-auto"}>
                <Button
                  className={
                    "btd6-button long blue h-100 luckiest-guy px-2 mx-1"
                  }
                  onClick={async () => {
                    const results = await translateAll(
                      inputJson,
                      Language[sourceLanguage]
                    );
                    const zip = new JSZip();
                    for (let [language, result] of Object.entries(results)) {
                      zip.file(language + ".json", result + "\n");
                    }

                    await zip
                      .generateAsync({ type: "blob" })
                      .then((content) => {
                        saveFile("Localization.zip", content);
                      });
                  }}
                >
                  Translate All
                </Button>
              </Col>
            </Row>
            <Editor
              className={"btd6-panel white-insert"}
              value={outputText}
              onValueChange={() => {}}
              highlight={(code) => highlight(code, languages.json)}
              padding={10}
              style={{
                fontFamily: '"Fira code", "Fira Mono", monospace',
                fontSize: 12,
                minHeight: 400,
              }}
              readOnly={true}
            />
          </Col>
        </Row>
      </Container>
    </Layout>
  );
};

export default Translate;
