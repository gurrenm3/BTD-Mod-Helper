import React, { forwardRef, useEffect, useRef } from "react";
import Blockly, { BlocklyOptions, Theme, WorkspaceSvg } from "blockly";

export interface SimpleReactBlocklyProps {
  wrapperDivClassName: string;
  workspaceConfiguration: BlocklyOptions;
  workspaceDidChange: () => void;
  init?: (workspace: WorkspaceSvg) => void;
}

export interface SimpleReactBlocklyRef {
  workspace: WorkspaceSvg;
  innerBlocklyDiv: HTMLDivElement | null;
}

export default forwardRef<SimpleReactBlocklyRef, SimpleReactBlocklyProps>(
  (props, ref) => {
    const innerBlocklyDiv = useRef<HTMLDivElement>(null);

    const options = props.workspaceConfiguration;

    useEffect(() => {
      const workspace = Blockly.inject(
        innerBlocklyDiv.current!,
        props.workspaceConfiguration
      );
      workspace.addChangeListener(props.workspaceDidChange);
      props.init?.(workspace);

      const state = { workspace, innerBlocklyDiv: innerBlocklyDiv.current };

      if (typeof ref === "function") {
        ref(state);
      } else if (ref) {
        ref.current = state;
      }
    }, []);

    // Handle layout changes
    useEffect(() => {
      if (ref && typeof ref !== "function") {
        const workspace = ref.current!.workspace;
        const state = Blockly.serialization.workspaces.save(workspace);
        const scale = workspace.getScale();
        workspace.dispose();

        const newWorkspace = Blockly.inject(
          innerBlocklyDiv.current!,
          props.workspaceConfiguration
        );
        newWorkspace.addChangeListener(props.workspaceDidChange);
        Blockly.serialization.workspaces.load(state, newWorkspace);
        newWorkspace.setScale(scale);
        props.init?.(newWorkspace);

        ref.current = {
          workspace: newWorkspace,
          innerBlocklyDiv: innerBlocklyDiv.current,
        };
      }
    }, [options.horizontalLayout, options.toolboxPosition]);

    useEffect(() => {
      if (typeof ref !== "function" && ref.current?.workspace) {
        if (props.workspaceConfiguration?.theme instanceof Theme) {
          ref.current.workspace.setTheme(props.workspaceConfiguration.theme);
        }
      }
    }, [props.workspaceConfiguration?.theme, ref]);

    return <div ref={innerBlocklyDiv} className={props.wrapperDivClassName} />;
  }
);
