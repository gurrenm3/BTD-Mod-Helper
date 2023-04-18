import { remark } from "remark";
import remarkGfm from "remark-gfm";
import remarkRehype from "remark-rehype";
import rehypeRaw from "rehype-raw";
import rehypeHighlight from "rehype-highlight";
import rehypeSlug from "rehype-slug";
import rehypeAutolinkHeadings from "rehype-autolink-headings";
import rehypeRewrite from "rehype-rewrite";
import rehypeStringify from "rehype-stringify";
import { rehype } from "rehype";
import rehypeParse from "rehype-parse";
import rehypeReact, { Options } from "rehype-react";
import React, { createElement, Fragment } from "react";
import Link from "next/link";
import { RootContent } from "hast";
import rehypeSanitize from "rehype-sanitize";

const rewrittenUrl = (href: string, basePath?: string) => {
  // Migrate Wiki links
  if (href.startsWith("https://github.com/gurrenm3/BTD-Mod-Helper/wiki")) {
    href = href.replace("https://github.com/gurrenm3/BTD-Mod-Helper", "");
  }

  // Adjust base paths
  if (basePath && !href.startsWith("http")) {
    if (!href.startsWith("/")) {
      href = "/" + href;
    }

    if (basePath.endsWith("/")) {
      basePath = basePath.substring(0, basePath.length - 1);
    }

    if (!href.startsWith(basePath)) {
      href = basePath + href;
    }
  }

  // Remove .md names from local links
  if (!href.startsWith("http")) {
    href = href.replace(/\.md/, "");
  }

  return href;
};

const rewrite = (linkBasePath?: string, imgBasePath?: string) => ({
  rewrite: (node: RootContent) => {
    if (node.type !== "element" || !node.properties) return;

    if (node.tagName === "code") {
      node.properties.className = [
        ...new Set([
          ...((node.properties.className as string[]) ?? []),
          "hljs",
        ]),
      ];
    }

    if (node.tagName === "a" && node.properties?.href) {
      let href = node.properties.href as string;

      node.properties.href = rewrittenUrl(href, linkBasePath);
    }

    if (node.tagName === "img" && node.properties?.src) {
      let src = node.properties.src as string;

      node.properties.src = rewrittenUrl(src, imgBasePath);
    }

    if (
      node.tagName === "img" &&
      node.properties?.src ===
        "https://raw.githubusercontent.com/gurrenm3/BTD-Mod-Helper/master/banner.png"
    ) {
      node.tagName = "div";
    }
  },
});

export const markdownToHtml = (linkBasePath?: string, imgBasePath?: string) =>
  remark()
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
    .use(rehypeRewrite, rewrite(linkBasePath, imgBasePath))
    .use(rehypeStringify);

export const htmlToReact = (sanitize?: boolean) =>
  rehype()
    .use(rehypeParse, { fragment: true })
    .use(sanitize ? rehypeSanitize : () => {})
    .use(rehypeReact, {
      createElement,
      Fragment,
      components: {
        a: (props: any) =>
          props.href ? <Link {...props} /> : <a {...props} />,
      },
    } as Options);
