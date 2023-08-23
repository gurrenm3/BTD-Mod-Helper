/**
 * @license
 * Copyright 2021 Google LLC
 * SPDX-License-Identifier: Apache-2.0
 */

import Blockly from "blockly";

export class CustomWorkspaceControl implements Blockly.IPositionable {
  /**
   * The SVG group containing the workspace control.
   */
  private svgGroup: SVGElement | null = null;

  /**
   * Left coordinate of the workspace control.
   */
  private left = 0;

  /**
   * Top coordinate of the workspace control.
   */
  private top = 0;

  /**
   * Width of the workspace control.
   */
  private readonly width = 32;

  /**
   * Height of the workspace control.
   */
  private readonly height = 32;

  /**
   * Distance between workspace control and bottom or top edge of workspace.
   */
  private readonly marginVertical = 10;

  /**
   * Distance between workspace control and right or left edge of workspace.
   */
  private readonly marginHorizontal = 20;

  /**
   * Whether this has been initialized.
   */
  private initialized = false;

  private onWorkspaceControlWrapper: Blockly.browserEvents.Data | null = null;

  /**
   * Constructor for workspace control.
   * @param workspace The workspace that the workspace
   *     control will be added to.
   * @param id
   * @param onClick
   * @param svg
   */
  constructor(
    protected workspace: Blockly.WorkspaceSvg,
    public id: string,
    private onClick: () => void,
    private svg: string
  ) {}

  /**
   * Initializes the workspace control.
   */
  init() {
    this.workspace.getComponentManager().addComponent({
      component: this,
      weight: 2,
      capabilities: [Blockly.ComponentManager.Capability.POSITIONABLE],
    });
    this.createDom();
    this.initialized = true;
    this.workspace.resize();
  }

  /**
   * Disposes of workspace search.
   * Unlink from all DOM elements and remove all event listeners
   * to prevent memory leaks.
   */
  dispose() {
    if (this.svgGroup) {
      Blockly.utils.dom.removeNode(this.svgGroup);
    }
    if (this.onWorkspaceControlWrapper) {
      Blockly.browserEvents.unbind(this.onWorkspaceControlWrapper);
      this.onWorkspaceControlWrapper = null;
    }
  }

  /**
   * Creates DOM for ui element.
   */
  private createDom() {
    this.svgGroup = Blockly.utils.dom.createSvgElement(
      Blockly.utils.Svg.IMAGE,
      {
        height: `${this.height}px`,
        width: `${this.width}px`,
        class: "blocklyWorkspaceControl",
      }
    );
    this.svgGroup.setAttributeNS(
      Blockly.utils.dom.XLINK_NS,
      "xlink:href",
      this.svg
    );
    Blockly.utils.dom.insertAfter(
      this.svgGroup,
      this.workspace.getBubbleCanvas()
    );

    // Attach listener.
    this.onWorkspaceControlWrapper = Blockly.browserEvents.conditionalBind(
      this.svgGroup,
      "mousedown",
      null,
      this.onClick.bind(this)
    );
  }

  /**
   * Returns the bounding rectangle of the UI element in pixel units relative to
   * the Blockly injection div.
   * @returns The component’s bounding box.
   */
  getBoundingRectangle(): Blockly.utils.Rect {
    return new Blockly.utils.Rect(
      this.top,
      this.top + this.height,
      this.left,
      this.left + this.width
    );
  }

  /**
   * Positions the workspace control.
   * It is positioned in the opposite corner to the corner the
   * categories/toolbox starts at.
   * @param metrics The workspace metrics.
   * @param savedPositions List of rectangles that
   *     are already on the workspace.
   */
  position(
    metrics: Blockly.MetricsManager.UiMetrics,
    savedPositions: Blockly.utils.Rect[]
  ) {
    if (!this.initialized) {
      return;
    }
    const hasVerticalScrollbars =
      this.workspace.scrollbar &&
      this.workspace.scrollbar.canScrollHorizontally();
    const hasHorizontalScrollbars =
      this.workspace.scrollbar &&
      this.workspace.scrollbar.canScrollVertically();

    if (
      metrics.toolboxMetrics.position === Blockly.TOOLBOX_AT_LEFT ||
      (this.workspace.horizontalLayout && !this.workspace.RTL)
    ) {
      // Right corner placement.
      this.left =
        metrics.absoluteMetrics.left +
        metrics.viewMetrics.width -
        this.width -
        this.marginHorizontal;
      if (hasVerticalScrollbars && !this.workspace.RTL) {
        this.left -= Blockly.Scrollbar.scrollbarThickness;
      }
    } else {
      // Left corner placement.
      this.left = this.marginHorizontal;
      if (hasVerticalScrollbars && this.workspace.RTL) {
        this.left += Blockly.Scrollbar.scrollbarThickness;
      }
    }

    const startAtBottom =
      metrics.toolboxMetrics.position !== Blockly.TOOLBOX_AT_BOTTOM;
    if (startAtBottom) {
      // Bottom corner placement
      this.top =
        metrics.absoluteMetrics.top +
        metrics.viewMetrics.height -
        this.height -
        this.marginVertical;
      if (hasHorizontalScrollbars) {
        // The horizontal scrollbars are always positioned on the bottom.
        this.top -= Blockly.Scrollbar.scrollbarThickness;
      }
    } else {
      // Upper corner placement
      this.top = metrics.absoluteMetrics.top + this.marginVertical;
    }

    // Check for collision and bump if needed.
    let boundingRect = this.getBoundingRectangle();
    for (let i = 0, otherEl; (otherEl = savedPositions[i]); i++) {
      if (boundingRect.intersects(otherEl)) {
        if (startAtBottom) {
          // Bump up.
          this.top = otherEl.top - this.height - this.marginVertical;
        } else {
          // Bump down.
          this.top = otherEl.bottom + this.marginVertical;
        }
        // Recheck other savedPositions
        boundingRect = this.getBoundingRectangle();
        i = -1;
      }
    }

    this.svgGroup.setAttribute(
      "transform",
      `translate(${this.left}, ${this.top})`
    );
  }
}

Blockly.Css.register(`
.blocklyWorkspaceControl {
  opacity: 0.4;
}
.blocklyWorkspaceControl:hover {
  opacity: 0.6;
}
.blocklyWorkspaceControl:active {
  opacity: 0.8;
}
`);
