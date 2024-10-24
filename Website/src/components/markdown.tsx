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
import { HtmlElementNode, TextNode, toc } from "@jsdevtools/rehype-toc";
import { Parent } from "unist";
import cx from "classnames";
import { Link45deg } from "react-bootstrap-icons";

const rewrittenUrl = (href: string, basePath?: string) => {
  // Migrate Wiki links
  if (href.startsWith("https://github.com/gurrenm3/BTD-Mod-Helper/wiki")) {
    href = href.replace("https://github.com/gurrenm3/BTD-Mod-Helper", "");

    href = href
      .replace(encodeURIComponent("[3.0]-"), "")
      .replace(encodeURIComponent("-(ModHelperComponents)"), "");
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
      properties: {
        "aria-hidden": "true",
        tabIndex: -1,
        className: ["position-relative"],
      },
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
        a: ({ className, href, ...props }: any) =>
          href ? (
            <Link
              className={cx(className, "next-link")}
              href={href}
              {...props}
            />
          ) : (
            <a className={className} {...props} />
          ),
        span: ({ className, children, ...props }) =>
          className === "icon icon-link" && !children ? (
            <Link45deg
              className={"hide-unless-hover position-absolute ms-1 mt-1 end-0"}
            />
          ) : (
            <span className={className} children={children} {...props} />
          ),
      },
    } as Options);

export const markdownToToc = () =>
  remark()
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
    })
    .use(() => (tree: Parent) => tree.children[0])
    .use(rehypeStringify);
