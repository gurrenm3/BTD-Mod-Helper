export type Maybe<T> = T | null;

export type BlockDef = {
  type?: Maybe<string>;
  output?: Maybe<string> | Maybe<Array<Maybe<string>>>;
  colour?: Maybe<string>;
  nextStatement?: Maybe<string> | Maybe<Array<Maybe<string>>>;
  previousStatement?: Maybe<string> | Maybe<Array<Maybe<string>>>;
  data?: Maybe<string>;
  inputsInline?: Maybe<boolean>;
  hat?: Maybe<string>;
  comment?: Maybe<string>;
  category?: Maybe<string>;
  subcategory?: Maybe<string>;
  plural?: Maybe<boolean>;
  id?: Maybe<string>;
  path?: Maybe<string>;
  value?: Maybe<number>;
  mutator?: Maybe<string>;
  enableContextMenu?: Maybe<boolean>;
  mutatorOptions?: any;
  next?: BlocklyShadowState;
  extensions?: Maybe<Array<string>>;
} & {
  [K in `message${number}`]?: Maybe<string>;
} & {
  [K in `args${number}`]?: Maybe<Array<BlockArgDef>>;
};

export type BlockArgDef = {
  type?: Maybe<string>;
  check?: Maybe<Array<Maybe<string>> | Maybe<string>>;
  name?: Maybe<string>;
  min?: Maybe<number>;
  max?: Maybe<number>;
  int?: Maybe<boolean>;
  text?: Maybe<string>;
  options?: Maybe<Array<Maybe<Array<Maybe<string>>>>>;
  width?: Maybe<number>;
  height?: Maybe<number>;
  alt?: Maybe<string>;
  src?: Maybe<string>;
  variable?: Maybe<string>;
  variableTypes?: Maybe<Array<Maybe<string>>>;
  defaultType?: Maybe<string>;
  value?: Maybe<number | string | boolean>;
  next?: Maybe<BlockShadowDef>;
  checked?: Maybe<boolean>;
  precision?: Maybe<number>;
} & BlocklyShadowState;

export type BlocklyShadowState = {
  shadow?: Maybe<BlockShadowDef>;
  block?: Maybe<BlockShadowDef>;
};

export type BlockShadowDef = {
  type: string;
  fields?: object;
  toolbox?: Maybe<boolean>;
};
