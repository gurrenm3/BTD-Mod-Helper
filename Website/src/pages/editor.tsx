import Layout, { switchSize } from "../components/layout";
import ModHelperHelmet from "../components/helmet";
import React, { useContext, useEffect, useRef, useState } from "react";
import { Container, Modal } from "react-bootstrap";
import SimpleReactBlockly, {
  SimpleReactBlocklyRef,
} from "../components/simple-react-blockly";
import cx from "classnames";
import { ToolboxInfo } from "blockly/core/utils/toolbox";
import useComponentDidMount from "../hooks/use-component-did-mount";
import Blockly, {
  BlocklyOptions,
  getMainWorkspace,
  WorkspaceSvg,
} from "blockly";
import { ToolboxSearchCategory } from "../components/blockly/toolbox-search-category";
import BlocklySetup, { initWorkspace, plugins } from "../lib/blockly-setup";
import DarkTheme from "@blockly/theme-dark";
import { use100vh } from "react-div-100vh";
import { ThemeContext } from "./_app";
import CustomRenderer from "../components/blockly/custom-renderer";
import { useDrop } from "react-use";
import { pasteBlockFromText } from "../lib/json-conversion-utils";
import { useRouter } from "next/router";
import { useParamBool } from "../lib/routing";
import useDebouncedCallback from "@restart/hooks/useDebouncedCallback";
import { WorkspaceSearch } from "../components/blockly/workspace-search";
import { CustomWorkspaceControl } from "../components/blockly/custom-workspace-control";
import useBreakpoint from "@restart/hooks/useBreakpoint";

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

const fullscreenSvg =
  "data:image/svg+xml,%3C%3Fxml version='1.0' encoding='UTF-8'%3F%3E%3Csvg xmlns='http://www.w3.org/2000/svg' width='20'" +
  " height='20' viewBox='0 0 20 20'%3E%3Ctitle%3E fullscreen %3C/title%3E%3Cpath fill='%23888888' fill-rule='evenodd' " +
  "d='M1 1v6h2V3h4V1H1zm2 12H1v6h6v-2H3v-4zm14 4h-4v2h6v-6h-2v4zm0-16h-4v2h4v4h2V1h-2z'/%3E%3C/svg%3E%0A";

export default () => {
  const height = use100vh() ?? 1000;
  const blocklyEditor = useRef<SimpleReactBlocklyRef>(null);

  const debouncedSave = useDebouncedCallback(
    (workspace: WorkspaceSvg) =>
      localStorage.setItem(
        "workspace",
        JSON.stringify(Blockly.serialization.workspaces.save(workspace))
      ),
    5000
  );

  const toolbox = useRef<ToolboxInfo>(defaultToolbox);

  useComponentDidMount(() => {
    if (Blockly["inited"] || typeof window === "undefined") return;
    Blockly["inited"] = true;

    BlocklySetup.registerAll();
    BlocklySetup.initBlocks();
    BlocklySetup.initToolbox(toolbox.current);
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
  const router = useRouter();
  const [fullscreen, setFullscreen] = useParamBool(router, "fullscreen");
  const toggleFullscreen = () => {
    const params = new URL(window.location.href).searchParams;
    setFullscreen(
      !(params.get("fullscreen") && params.get("fullscreen") !== "false")
    );
  };

  useEffect(() => {
    const onResize = () =>
      setTimeout(
        () =>
          blocklyEditor.current?.workspace &&
          Blockly.svgResize(blocklyEditor.current.workspace),
        5
      );
    window.addEventListener("resize", onResize);
    onResize();

    return () => window.removeEventListener("resize", onResize);
  }, [fullscreen]);

  const [tips, showTips] = useState(false);

  const init = (workspace: WorkspaceSvg, isFirst: boolean) => {
    new WorkspaceSearch(workspace).init();
    new CustomWorkspaceControl(
      workspace,
      "fullscreen",
      toggleFullscreen,
      fullscreenSvg
    ).init();

    if (!Blockly["loaded"]) {
      Blockly["loaded"] = true;
      const savedWorkspace = localStorage.getItem("workspace");
      if (workspace && savedWorkspace) {
        try {
          Blockly.serialization.workspaces.load(
            JSON.parse(savedWorkspace),
            workspace
          );
        } catch (e) {
          console.warn(e);
        }
      }
    }
    workspace.addChangeListener(() => debouncedSave(workspace));

    initWorkspace(workspace, isFirst);
  };

  const xs = !useBreakpoint("sm", "up");

  const options: BlocklyOptions = {
    disable: false,
    zoom: {
      controls: true,
      minScale: 0.2,
      maxScale: 2.0,
      pinch: true,
      startScale: 0.8,
    },
    move: {
      wheel: true,
    },
    oneBasedIndex: false,
    horizontalLayout: xs,
    toolbox: toolbox.current,
    renderer: CustomRenderer.name,
    theme: theme === "light" ? Blockly.Themes.Classic : DarkTheme,
    plugins,
  };

  return (
    <Layout
      style={{ height }}
      headerClassName={cx(fullscreen && "d-none")}
      footerClassName={cx(fullscreen && "d-none")}
      bottomLeftButton={"Editor Tips"}
      bottomLeftOnClick={() => showTips(true)}
    >
      <ModHelperHelmet
        title={"BTD6 Tower Editor"}
        description={"Edit BTD6 towers using Blockly."}
      />
      <Container
        fluid={fullscreen ? true : switchSize}
        className={cx("h-100", "p-0")}
      >
        {ready ? (
          <SimpleReactBlockly
            wrapperDivClassName={cx("h-100")}
            workspaceConfiguration={options}
            ref={blocklyEditor}
            init={init}
          />
        ) : (
          <div className={"h-100"} />
        )}
      </Container>
      <Modal
        show={tips}
        onHide={() => showTips(false)}
        dialogClassName={cx("main-panel btd6-panel blue")}
        contentClassName={cx(
          "main-panel btd6-panel blue-insert-round pb-0 shadow-none"
        )}
      >
        <Modal.Header closeButton={true} closeVariant={"white"}>
          <Modal.Title className={"luckiest-guy text-outline-black"}>
            Using the Tower Editor
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <h4>Sandbox Testing</h4>
          <ul>
            <li>
              Within a sandbox game, use the Export Tower Model shortcut (Alt+C
              by default) while selecting a tower to put its TowerModel in the
              clipboard.
            </li>
            <li>
              On this site, press Ctrl+V / Alt+V to paste the TowerModel into
              the editor as blocks.
            </li>
            <li>
              Most blocks will be collapsed by default, double click to expand
              them. Use Ctrl+F to search blocks, including collapsed ones..
            </li>
            <li>
              When you've done your edits, select the outer TowerModel block and
              do Ctrl+C // Alt+C to copy the edited TowerModel to the clipboard
              (or Ctrl+X / Alt+X to also delete the blocks).
            </li>
            <li>
              Back in your sandbox game, press the Import Tower Model shortcut
              (Alt+V by default) to apply the changed TowerModel to your
              selected tower.
            </li>
          </ul>
          <h4>Custom Towers</h4>
          <ul>
            <li>Not Yet Implemented</li>
          </ul>
        </Modal.Body>
      </Modal>
    </Layout>
  );
};
