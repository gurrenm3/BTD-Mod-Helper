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
      <meta
        key={"description"}
        property={"description"}
        content={description}
      />
    )}
    <meta
      key={"apple-mobile-web-app-capable"}
      property="apple-mobile-web-app-capable"
      content="yes"
    />
    <meta
      key={"apple-mobile-web-app-status-bar-style"}
      property="apple-mobile-web-app-status-bar-style"
      content="black-translucent"
    />
    <link
      key={"icon"}
      rel={"icon"}
      href={`${process.env.NEXT_PUBLIC_BASE_PATH}/images/ModHelper.ico`}
    />
    {title && <meta key={"og:title"} property={"og:title"} content={title} />}
    {description && (
      <meta
        key={"og:description"}
        property={"og:description"}
        content={description}
      />
    )}
    <meta
      key={"og:image"}
      property={"og:image"}
      content={`https://${ModHelperRepoOwner}.github.io/${ModHelperRepoName}/images/ModHelper.png`}
    />
    <meta
      key={"og:site_name"}
      property={"og:site_name"}
      content={"BTD Mod Helper"}
    />
    <meta key={"og:type"} property="og:type" content="website" />
  </Head>
);

export default ModHelperHelmet;
