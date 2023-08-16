import Blockly, { Block, BlockSvg, Workspace } from "blockly";

type PartialBlock = Partial<Block>;

interface IPartialBlock extends PartialBlock {}

export type MutatorFn<T> = (this: T & (Block | BlockSvg)) => void;

export abstract class ExtensionMixin<
  Mixin,
  State extends object,
  ContainerBlock extends Block = Block,
  MutatedBlock = Mixin & Block
> implements IPartialBlock
{
  abstract saveExtraState(this: MutatedBlock): State;

  abstract loadExtraState(this: MutatedBlock, state: State);
}

export abstract class MutatorMixin<
  Mixin,
  State extends object,
  ContainerBlock extends Block = Block,
  MutatedBlock = Mixin & Block
> extends ExtensionMixin<Mixin, State, ContainerBlock> {
  abstract decompose(this: MutatedBlock, workspace: Workspace): ContainerBlock;

  abstract compose(this: MutatedBlock, containerBlock: ContainerBlock): void;

  abstract rebuildShape_(this: MutatedBlock): void;
}

/**
 * Returns the extra state of the given block (either as XML or a JSO, depending
 * on the block's definition).
 * @param {!Blockly.BlockSvg} block The block to get the extra state of.
 * @returns {string} A stringified version of the extra state of the given
 *     block.
 */
export function getExtraBlockState(block) {
  // TODO: This is a dupe of the BlockChange.getExtraBlockState code, do we
  //    want to make that public?
  if (block.saveExtraState) {
    const state = block.saveExtraState();
    return state ? JSON.stringify(state) : "";
  } else if (block.mutationToDom) {
    const state = block.mutationToDom();
    return state ? Blockly.Xml.domToText(state) : "";
  }
  return "";
}
