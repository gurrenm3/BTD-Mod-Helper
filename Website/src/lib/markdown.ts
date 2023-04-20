import * as path from "path";
import * as fs from "fs";
import matter from "gray-matter";
import { remark } from "remark";
import { glob } from "glob";
import remarkRehype from "remark-rehype";
import rehypeStringify from "rehype-stringify";
import rehypeSlug from "rehype-slug";
import { HtmlElementNode, TextNode, toc } from "@jsdevtools/rehype-toc";
import { Parent } from "unist";
import { markdownToHtml, markdownToToc } from "../components/markdown";

export const getMarkdownPaths = async (dir: string) =>
  await glob(path.join(dir, "**", "*.md").replaceAll(path.sep, "/"));

export const toMdPath = (file: string, dir: string) =>
  path
    .relative(dir, file)
    .replace(/\.md$/, "")
    .replaceAll(path.sep, "/")
    .split("/");

export const fromMdPath = (mdPath: string[], dir: string) =>
  path.join(dir, path.join(...mdPath) + ".md").replaceAll(path.sep, "/");

export const getMarkdownContent = async (file) => {
  const fileContents = await fs.promises.readFile(
    file.replaceAll(path.sep, "/"),
    {
      encoding: "utf8",
    }
  );
  const matterResult = matter(fileContents);

  const processedContent = await markdownToHtml().process(matterResult.content);
  const contentHtml = processedContent.toString();

  const processedTableOfContents = await markdownToToc().process(
    matterResult.content
  );
  const tableOfContentsHtml = processedTableOfContents.toString();

  return {
    contentHtml,
    tableOfContentsHtml,
    ...(matterResult.data as {
      title?: string;
      subtitle?: string;
    }),
  };
};
