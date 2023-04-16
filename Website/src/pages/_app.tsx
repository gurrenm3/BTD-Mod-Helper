import { AppProps } from "next/app";
import Layout from "../components/layout";
import React from "react";
import "../css/bootstrap.scss";
import "../css/fonts.scss";
import "../css/global.scss";
import "../css/global.scss";
import "highlight.js/styles/github-dark.css";

export default ({ Component, pageProps }: AppProps) => {
  return (
    <Layout>
      <Component {...pageProps} />
    </Layout>
  );
};
