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
import { TowerImportCategory } from "../components/blockly/tower-import-category";

const defaultToolbox = {
  kind: "categoryToolbox",
  contents: [
    {
      kind: ToolboxSearchCategory.registrationName,
      name: "Search Blocks",
      colour: "rgb(85, 119, 238)",
      contents: [],
    },
    {
      kind: TowerImportCategory.registrationName,
      name: "Import Towers",
      colour: "#888888",
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
    2000
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
    if (pasteBlockFromText(getMainWorkspace() as WorkspaceSvg, text)) {
      e.preventDefault();
      e.stopPropagation();
    }
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

  const init = (workspace: WorkspaceSvg) => {
    new WorkspaceSearch(workspace).init();
    new CustomWorkspaceControl(
      workspace,
      "fullscreen",
      toggleFullscreen,
      fullscreenSvg
    ).init();

    workspace.addChangeListener(() => debouncedSave(workspace));
    workspace.addChangeListener(() => {
      const savedWorkspace = localStorage.getItem("workspace");
      if (!savedWorkspace || Blockly["loaded"]) return;
      Blockly["loaded"] = true;

      try {
        Blockly.serialization.workspaces.load(
          JSON.parse(savedWorkspace),
          workspace
        );
      } catch (e) {
        console.warn(e);
      }
    });

    initWorkspace(workspace);
  };

  const xs = !useBreakpoint("sm", "up");

  const options: BlocklyOptions = {
    disable: false,
    zoom: {
      controls: true,
      wheel: true,
      pinch: true,
      minScale: 0.2,
      maxScale: 1.5,
      startScale: 0.8,
    },
    move: {
      wheel: true,
    },
    grid: {
      snap: true,
      spacing: 27,
      length: 1,
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
      footerBody={
        <>
          For sandbox editing, use the{" "}
          <a
            href={
              "https://nightly.link/gurrenm3/BTD-Mod-Helper/workflows/build/preview/Btd6ModHelper.dll.zip"
            }
          >
            latest Mod Helper preview build.
          </a>
          . For custom towers, see{" "}
          <a target={"_blank"} href={"https://ko-fi.com/doombubbles"}>
            my Ko-Fi
          </a>
          . View Editor Tips for more details.
        </>
      }
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
          <h4>Tips</h4>
          <ul>
            <li>
              Double click on blocks to expand them when they're collapsed.
            </li>
            <li>
              Use Ctrl+F to search for blocks in the workspace, including
              collapsed ones.
            </li>
            <li>
              Press the gear icon on Blocks to control which fields you want to
              set on them. Fields that aren't shown have their default value.
            </li>
          </ul>
          <h4>
            Custom Towers (
            <a target={"_blank"} href={"https://ko-fi.com/doombubbles"}>
              Ko-Fi Early Access
            </a>
            )
          </h4>
          <ul>
            <li>
              Start with one of the Custom Tower blocks from the Base category.
            </li>
            <li>
              Import a base tower and edit it to use as the default TowerModel,
              or define the changes to the base tower using the Model Changes
              blocks.
            </li>
            <li>
              Use Custom Upgrade blocks to add upgrades to your tower, defining
              their effects using the Model Changes blocks.
            </li>
            <li>
              Use custom textures for your tower with the Custom Texture Sprite
              Reference block and providing it the name of the .png/.jpg file
              you're going to use (don't include the extension).
            </li>
            <li>
              Create custom displays for your Blocks with the Custom Display
              block, modify it with Display Changes blocks, and then reference
              them with the Custom Display PrefabReference block. You can export
              the textures of your base display using the Export Display button
              in Mod Helper's Mod Making settings.
            </li>
            <li>
              Use your creations in game by saving (Ctrl+S or Right Click {">"}{" "}
              Save to Json) each Tower/Upgrade/Display to a .json file within a
              folder in your <code>../BloonsTD6/Towers/</code> directory. Also
              put any .png/.jpg textures you're using in that folder.
            </li>
            <li>
              When you boot up the game, your tower will be added! If anything
              went wrong, you may see errors in the console. Currently, you will
              need to restart for changes to your .json files to take effect.
              However, you can use the sandbox testing feature to test specific
              edits live in game (included with Ko-Fi version).
            </li>
          </ul>
          <h4>
            Sandbox Testing (
            <a
              href={
                "https://nightly.link/gurrenm3/BTD-Mod-Helper/workflows/build/preview/Btd6ModHelper.dll.zip"
              }
            >
              Public Alpha
            </a>
            )
          </h4>
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
              When you've done your edits, select the outer TowerModel block and
              do Ctrl+C / Alt+C to copy the edited TowerModel to the clipboard
              (or Ctrl+X / Alt+X to also delete the blocks).
            </li>
            <li>
              Back in your sandbox game, press the Import Tower Model shortcut
              (Alt+V by default) to apply the changed TowerModel to your
              selected tower.
            </li>
          </ul>
        </Modal.Body>
      </Modal>
    </Layout>
  );
};
