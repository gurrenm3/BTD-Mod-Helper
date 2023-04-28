import React from "react";
import { GetStaticPropsContext, InferGetStaticPropsType } from "next";
import { getMarkdownContent } from "../lib/markdown";
import path from "path";
import { MarkdownLayout } from "../components/markdown-layout";

export const getStaticProps = async ({}: GetStaticPropsContext) => {
  const data = await getMarkdownContent(
    path.join(process.cwd(), "..", "README.md"),
    process.env.NEXT_PUBLIC_BASE_PATH
  );

  return {
    props: {
      data,
    },
  };
};

const Index = ({ data }: InferGetStaticPropsType<typeof getStaticProps>) => {
  return (
    <MarkdownLayout data={data} noToc={true} noTitle={true}>
      <div
        className={"p-2 btd6-panel blue-insert-round mt-1"}
        dangerouslySetInnerHTML={{ __html: data?.contentHtml ?? "" }}
      />
    </MarkdownLayout>
  );
};

export default Index;
