import * as path from "path";
import * as fs from "fs";
import matter from "gray-matter";
import { remark } from "remark";
import remarkGfm from "remark-gfm";
import { glob } from "glob";
import rehypeHighlight from "rehype-highlight";
import remarkRehype from "remark-rehype";
import rehypeStringify from "rehype-stringify";
import rehypeRewrite from "rehype-rewrite";
import { RootContent } from "hast";
import rehypeAutolinkHeadings from "rehype-autolink-headings";
import rehypeSlug from "rehype-slug";
import {
  HtmlElementNode,
  Options,
  TextNode,
  toc,
} from "@jsdevtools/rehype-toc";
import { Parent } from "unist";
import rehypeRaw from "rehype-raw";

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

const rewrite = (node: RootContent) => {
  if (node.type !== "element" || !node.properties) return;

  if (node.tagName === "code") {
    node.properties.className = [
      ...new Set([...((node.properties.className as string[]) ?? []), "hljs"]),
    ];
  }
  if (node.tagName === "a" && node.properties?.href) {
    let href = node.properties.href as string;
    if (href.startsWith("BTD_Mod_Helper") || href.startsWith("README")) {
      node.properties.href = href = href.replace(/\.md$/, "");
    }
    if (href.startsWith("https://github.com/gurrenm3/BTD-Mod-Helper/wiki")) {
      node.properties.href = href = href.replace(
        "https://github.com/gurrenm3/BTD-Mod-Helper",
        ""
      );
    }
    if (
      process.env.CI &&
      href.startsWith("/") &&
      !href.startsWith("/BTD-Mod-Helper")
    ) {
      node.properties.href = "/BTD-Mod-Helper" + href;
    }
  }
};

export const getMarkdownContent = async (file) => {
  const fileContents = await fs.promises.readFile(
    file.replaceAll(path.sep, "/"),
    {
      encoding: "utf8",
    }
  );
  const matterResult = matter(fileContents);

  const processedContent = await remark()
    .use(remarkGfm)
    .use(remarkRehype, { allowDangerousHtml: true })
    .use(rehypeRaw)
    .use(rehypeHighlight, {
      detect: true,
      ignoreMissing: true,
      aliases: { json: "json5" },
    })
    .use(rehypeSlug)
    .use(rehypeAutolinkHeadings, {
      properties: { "aria-hidden": "true", tabIndex: -1, className: [""] },
    })
    .use(rehypeRewrite, {
      rewrite,
    })
    .use(rehypeStringify)
    .process(matterResult.content);

  const contentHtml = processedContent.toString();

  const processedTableOfContents = await remark()
    .use(remarkRehype)
    .use(rehypeSlug)
    .use(toc, {
      customizeTOCItem: (node) => {
        const anchor = node.children.find(
          (value) =>
            value.type === "element" &&
            (value as HtmlElementNode).tagName === "a"
        ) as HtmlElementNode | undefined;
        if (!anchor) return true;

        const text = anchor.children?.find((value) => value.type === "text") as
          | TextNode
          | undefined;
        if (!text || !text.value || text.value.length < 50) return true;

        if (text.value.includes(":")) {
          text.value =
            text.value.substring(0, text.value.indexOf(":") + 1) + " ...";
        }

        if (text.value.includes("!")) {
          text.value =
            text.value.substring(0, text.value.indexOf("!") + 1) + " ...";
        }

        return true;
      },
    } as Options)
    .use(() => (tree: Parent) => tree.children[0])
    .use(rehypeStringify)
    .process(matterResult.content);

  const tableOfContentsHtml = processedTableOfContents.toString();

  return {
    contentHtml,
    tableOfContentsHtml,
    ...(matterResult.data as {
      title?: string;
      description?: string;
    }),
  };
};
