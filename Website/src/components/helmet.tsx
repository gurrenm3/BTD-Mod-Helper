import React from "react";
import { Helmet } from "react-helmet";

const ModHelperHelmet = () => (
  <Helmet>
    <title>BTD Mod Helper</title>
    <meta name={"description"} content={""} />
    <meta
      name="apple-mobile-web-app-status-bar-style"
      content="black-translucent"
    />
    <link
      rel={"icon"}
      href={`${process.env.NEXT_PUBLIC_BASE_PATH}/images/ModHelper.ico`}
    />
  </Helmet>
);

export default ModHelperHelmet;
