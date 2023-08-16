/**
 * @license
 * Copyright 2023 Google LLC
 * SPDX-License-Identifier: Apache-2.0
 */

import * as Blockly from "blockly/core";
import { BlockInfo } from "blockly/core/utils/toolbox";

import { newBlock } from "../../lib/blockly-utils";

/**
 * A class that provides methods for indexing and searching blocks.
 */
export class BlockSearcher {
  private blockCreationWorkspace = new Blockly.Workspace();
  private trigramsToBlocks = new Map<string, Set<string>>();
  private blocksToBlockInfos = new Map<string, BlockInfo>();

  /**
   * Populates the cached map of trigrams to the blocks they correspond to.
   *
   * This method must be called before blockTypesMatching(). Behind the
   * scenes, it creates a workspace, loads the specified block types on it,
   * indexes their types and human-readable text, and cleans up after
   * itself.
   * @param blockInfos A list of block types to index.
   */
  indexBlocks(blockInfos: BlockInfo[]) {
    const blockCreationWorkspace = new Blockly.Workspace();
    blockInfos.forEach((blockInfo) => {
      let block: Blockly.Block;
      try {
        block = Blockly.serialization.blocks.append(
          blockInfo as Blockly.serialization.blocks.State,
          blockCreationWorkspace
        );
      } catch (e) {
        block = newBlock(blockCreationWorkspace, blockInfo.type);
        console.warn(blockInfo.type, e.message);
      }
      const blockType = block.getFieldValue("id") || block.type;
      // TODO include shadow block text values in searching?
      this.blocksToBlockInfos[blockType] = blockInfo;
      this.indexBlockText(blockType.replaceAll("_", " "), blockType);
      block.inputList.forEach((input) => {
        input.fieldRow.forEach((field) => {
          this.indexBlockText(field.getText(), blockType);
        });
      });
    });
  }

  /**
   * Filters the available blocks based on the current query string.
   * @param query The text to use to match blocks against.
   * @returns A list of block types matching the query.
   */
  blockTypesMatching(query: string): BlockInfo[] {
    return [
      ...this.generateTrigrams(query)
        .map((trigram) => {
          return this.trigramsToBlocks.get(trigram) ?? new Set<string>();
        })
        .reduce((matches, current) => {
          return this.getIntersection(matches, current);
        })
        .values(),
    ].map((blockType) => this.blocksToBlockInfos[blockType]);
  }

  /**
   * Generates trigrams for the given text and associates them with the given
   * block type.
   * @param text The text to generate trigrams of.
   * @param blockType The block type to associate the trigrams with.
   */
  private indexBlockText(text: string, blockType: string) {
    this.generateTrigrams(text).forEach((trigram) => {
      const blockSet = this.trigramsToBlocks.get(trigram) ?? new Set<string>();
      blockSet.add(blockType);
      this.trigramsToBlocks.set(trigram, blockSet);
    });
  }

  /**
   * Generates a list of trigrams for a given string.
   * @param input The string to generate trigrams of.
   * @returns A list of trigrams of the given string.
   */
  private generateTrigrams(input: string): string[] {
    const normalizedInput = input.toLowerCase();
    if (!normalizedInput) return [];
    if (normalizedInput.length <= 3) return [normalizedInput];

    const trigrams: string[] = [];
    for (let start = 0; start < normalizedInput.length - 3; start++) {
      trigrams.push(normalizedInput.substring(start, start + 3));
    }

    return trigrams;
  }

  /**
   * Returns the intersection of two sets.
   * @param a The first set.
   * @param b The second set.
   * @returns The intersection of the two sets.
   */
  private getIntersection(a: Set<string>, b: Set<string>): Set<string> {
    return new Set([...a].filter((value) => b.has(value)));
  }
}
