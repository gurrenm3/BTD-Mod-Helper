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

const wikiDirectory = path.join(process.cwd(), "..", "Wiki");

type Params = { mdPath: string[] };

export const getStaticPaths: GetStaticPaths<Params> = async () => {
  const paths = await getMarkdownPaths(wikiDirectory);

  return {
    paths: paths.map((path) => ({
      params: { mdPath: toMdPath(path, wikiDirectory) },
    })),
    fallback: false,
  };
};

export const getStaticProps = async ({
  params,
}: GetStaticPropsContext<Params>) => {
  const data = await getMarkdownContent(
    fromMdPath(params!.mdPath, wikiDirectory)
  );
  const sidebar = await getMarkdownContent(
    path.join(wikiDirectory, "_Sidebar.md")
  );

  data.title ??= decodeURIComponent(params!.mdPath.join(" ")).replaceAll(
    "-",
    " "
  );

  return {
    props: {
      data,
      sidebar,
    },
  };
};

export default ({
  data,
  sidebar,
}: InferGetStaticPropsType<typeof getStaticProps>) => (
  <MarkdownLayout
    data={data}
    sidebar={sidebar}
    description={
      "Wiki for the modding api for BloonsTD6. Learn how to download, install and make BTD6 mods."
    }
  />
);
