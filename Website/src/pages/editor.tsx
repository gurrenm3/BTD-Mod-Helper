import Layout, { switchSize } from "../components/layout";
import ModHelperHelmet from "../components/helmet";
import React, { useContext, useEffect, useRef, useState } from "react";
import { Container } from "react-bootstrap";
import SimpleReactBlockly, {
  SimpleReactBlocklyRef,
} from "../components/simple-react-blockly";
import cx from "classnames";
import { ToolboxInfo } from "blockly/core/utils/toolbox";
import useComponentDidMount from "../hooks/use-component-did-mount";
import Blockly, { getMainWorkspace, WorkspaceSvg } from "blockly";
import { ToolboxSearchCategory } from "../components/blockly/toolbox-search-category";
import BlocklySetup, {
  initWorkspace,
  pasteBlockFromText,
  plugins,
} from "../lib/blockly-setup";
import DarkTheme from "@blockly/theme-dark";
import { use100vh } from "react-div-100vh";
import { ThemeContext } from "./_app";
import CustomRenderer from "../components/blockly/custom-renderer";
import { useDrop } from "react-use";

const defaultToolbox = {
  kind: "categoryToolbox",
  contents: [
    {
      kind: ToolboxSearchCategory.registrationName,
      name: "Search All Blocks",
      colour: "rgb(85, 119, 238)",
      contents: [],
    },
  ],
} as ToolboxInfo;

export default () => {
  const height = use100vh() ?? 1000;
  const blocklyEditor = useRef<SimpleReactBlocklyRef>(null);
  const onWorkspaceChanged = () => {};

  const toolbox = useRef<ToolboxInfo>(defaultToolbox);

  useComponentDidMount(() => {
    if (Blockly["inited"] || typeof window === "undefined") return;

    BlocklySetup.registerAll();
    BlocklySetup.initBlocks();
    BlocklySetup.initToolbox(toolbox.current);

    Blockly["inited"] = true;
  });

  const [ready, setReady] = useState(false);

  useEffect(() => {
    setReady(true);
  }, []);

  const { theme } = useContext(ThemeContext);

  const onText = (text: string, e) => {
    e.preventDefault();
    e.stopPropagation();
    pasteBlockFromText(getMainWorkspace() as WorkspaceSvg, text);
  };

  useDrop({
    onText,
    onFiles: async (files, event) => {
      for (const file of files) {
        const text = await file.text();
        onText(text, event);
      }
    },
  });

  return (
    <Layout style={{ height }}>
      <ModHelperHelmet
        title={"BTD6 Tower Editor"}
        description={"Edit BTD6 towers using Blockly."}
      />
      <Container fluid={switchSize} className={`h-100 p-0`}>
        {ready ? (
          <SimpleReactBlockly
            workspaceDidChange={onWorkspaceChanged}
            wrapperDivClassName={cx("h-100")}
            workspaceConfiguration={{
              disable: false,
              zoom: {
                controls: true,
                minScale: 0.5,
                maxScale: 2.0,
                pinch: true,
                startScale: 0.8,
              },
              move: {
                wheel: true,
              },
              oneBasedIndex: false,
              toolbox: toolbox.current,
              renderer: CustomRenderer.name,
              theme: theme === "light" ? Blockly.Themes.Classic : DarkTheme,
              plugins,
            }}
            ref={blocklyEditor}
            init={initWorkspace}
          />
        ) : (
          <div className={"h-100"} />
        )}
      </Container>
    </Layout>
  );
};
