import { GetStaticPropsContext, InferGetStaticPropsType } from "next";
import { getMarkdownContent } from "../lib/markdown";
import path from "path";
import React from "react";
import { MarkdownLayout } from "../components/markdown-layout";

export const getStaticProps = async ({}: GetStaticPropsContext) => {
  const data = await getMarkdownContent(
    path.join(process.cwd(), "..", "Wiki", "404.md")
  );

  return {
    props: {
      data,
    },
  };
};

export default ({ data }: InferGetStaticPropsType<typeof getStaticProps>) => (
  <MarkdownLayout data={data} noToc={true} className={"p-3 my-2"} />
);
