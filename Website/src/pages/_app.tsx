import { AppProps } from "next/app";
import React, { useEffect } from "react";
import "../css/bootstrap.scss";
import "../css/fonts.scss";
import "../css/global.scss";
import "../css/btd6.scss";
import { Btd6Styles } from "../components/btd6-ui";
import { SSRProvider } from "react-bootstrap";
import ModHelperHelmet from "../components/helmet";

export default ({ Component, pageProps }: AppProps) => {
  useEffect(() => {
    let theme = "light"; //default to light

    //local storage is used to override OS theme settings
    if (localStorage.getItem("theme")) {
      theme = localStorage.getItem("theme")!;
    } else if (
      "watchMedia" in window &&
      window.matchMedia("(prefers-color-scheme: dark)").matches
    ) {
      //OS theme setting detected as dark
      theme = "dark";
    }

    document.documentElement.setAttribute("data-theme", theme);
  }, []);

  return (
    <SSRProvider>
      <Btd6Styles />
      <ModHelperHelmet />
      <Component {...pageProps} />
    </SSRProvider>
  );
};
