import React, { FunctionComponent } from "react";
import { ModHelperRepoName, ModHelperRepoOwner } from "../lib/mod-helper-data";
import Head from "next/head";

interface ModHelperHelmetProps {
  title?: string;
  description?: string;
}

const ModHelperHelmet: FunctionComponent<ModHelperHelmetProps> = ({
  title,
  description,
  ...props
}) => (
  <Head {...props}>
    {title && <title key={"title"}>{title}</title>}
    {description && (
      <meta key={"description"} name={"description"} content={description} />
    )}
    <meta
      key={"mobile-web-app-capable"}
      name="mobile-web-app-capable"
      content="yes"
    />
    <meta
      key={"mobile-web-app-status-bar-style"}
      name="mobile-web-app-status-bar-style"
      content="black-translucent"
    />
    <link
      key={"icon"}
      rel={"icon"}
      href={`${process.env.NEXT_PUBLIC_BASE_PATH ?? ""}/favicon.ico`}
    />
    <link
      key={"icon2"}
      rel={"icon"}
      href={`${process.env.NEXT_PUBLIC_BASE_PATH ?? ""}/favicon-32.png`}
      type="image/png"
      sizes="32x32"
    />
    <link
      key={"icon3"}
      rel={"icon"}
      href={`${process.env.NEXT_PUBLIC_BASE_PATH ?? ""}/favicon-16.png`}
      type="image/png"
      sizes="16x16"
    />
    <meta
      key="google-site-verification"
      name="google-site-verification"
      content="8DwKXJQq71931r8NqcsVa4A9OaulAugH83ha5ghbda4"
    />
    {title && <meta key={"og:title"} name={"og:title"} content={title} />}
    {description && (
      <meta
        key={"og:description"}
        name={"og:description"}
        content={description}
      />
    )}
    <meta
      key={"og:image"}
      name={"og:image"}
      content={`https://${ModHelperRepoOwner}.github.io/${ModHelperRepoName}/images/ModHelper.png`}
    />
    <meta
      key={"og:site_name"}
      name={"og:site_name"}
      content={"BTD Mod Helper"}
    />
    <meta key={"og:type"} name="og:type" content="website" />
    <meta
      key={"viewport"}
      name={"viewport"}
      content={"width=device-width, initial-scale=1.0, viewport-fit=cover"}
    />
  </Head>
);

export default ModHelperHelmet;
