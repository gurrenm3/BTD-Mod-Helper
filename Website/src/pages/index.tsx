import React from "react";
import cx from "classnames";
import { use100vh } from "react-div-100vh";
import Image from "next/image";
import EngineerMonkey from "public/images/000-EngineerMonkey.png";
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

const Index = ({ data }: InferGetStaticPropsType<typeof getStaticProps>) => {
  return (
    <MarkdownLayout data={data} noToc={true} noTitle={true}>
      <div
        className={"p-2"}
        dangerouslySetInnerHTML={{ __html: data?.contentHtml ?? "" }}
      />
    </MarkdownLayout>
  );
};

export default Index;
