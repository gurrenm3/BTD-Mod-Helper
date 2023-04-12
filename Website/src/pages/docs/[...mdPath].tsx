import * as path from "path";
import {
  GetStaticPaths,
  GetStaticPropsContext,
  InferGetStaticPropsType,
} from "next";
import {
  fromMdPath,
  getMarkdownContent,
  getMarkdownPaths,
  toMdPath,
} from "../../lib/markdown";
import React from "react";
import { MarkdownLayout } from "../../components/markdown-layout";

const directory = path.join(process.cwd(), "..", "Documentation");

type Params = { mdPath: string[] };

export const getStaticPaths: GetStaticPaths<Params> = async () => {
  const paths = await getMarkdownPaths(directory);

  return {
    paths: paths.map((path) => ({
      params: { mdPath: toMdPath(path, directory) },
    })),
    fallback: false,
  };
};

export const getStaticProps = async ({
  params,
}: GetStaticPropsContext<Params>) => {
  const filePath = fromMdPath(params!.mdPath, directory);

  const data = await getMarkdownContent(filePath);
  data.title ??= decodeURIComponent(params!.mdPath.join(" ")).replaceAll(
    "-",
    " "
  );

  return {
    props: {
      data,
    },
  };
};

export default ({ data }: InferGetStaticPropsType<typeof getStaticProps>) => (
  <MarkdownLayout data={data} />
);
