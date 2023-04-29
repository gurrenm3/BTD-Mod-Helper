import React from "react";
import { GetStaticPropsContext, InferGetStaticPropsType } from "next";
import { getMarkdownContent } from "../lib/markdown";
import path from "path";
import { MarkdownLayout } from "../components/markdown-layout";

export const getStaticProps = async ({}: GetStaticPropsContext) => {
  const data = await getMarkdownContent(
    path.join(process.cwd(), "..", "README.md")
  );

  return {
    props: {
      data,
    },
  };
};

const Index = ({ data }: InferGetStaticPropsType<typeof getStaticProps>) => (
  <MarkdownLayout
    data={data}
    noToc={true}
    noTitle={true}
    className={"p-3 my-2"}
  />
);

export default Index;
