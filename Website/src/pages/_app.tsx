import { AppProps } from "next/app";
import React, { useEffect, useRef } from "react";
import "../css/bootstrap.scss";
import "../css/fonts.scss";
import "../css/global.scss";
import "../css/btd6.scss";
import { Btd6Styles } from "../components/btd6-ui";
import { SSRProvider } from "react-bootstrap";
import ModHelperHelmet from "../components/helmet";
import { use100vh } from "react-div-100vh";
import BackgroundImage, {
  backgroundOnScroll,
} from "../components/background-image";
import cx from "classnames";
import SkipLink from "../components/skip-link";
import { ModHelperFooter, ModHelperNavBar } from "../components/navbar";
import { ModHelperScrollBars, ScrollBarsContext } from "../components/layout";
import { Scrollbars } from "react-custom-scrollbars-2";

export default ({ Component, pageProps }: AppProps) => {
  const height = use100vh() ?? 1000;
  const scrollbars = useRef<Scrollbars>(null);
  const background = useRef<HTMLDivElement>(null);

  return (
    <SSRProvider>
      <Btd6Styles />
      <ModHelperHelmet />
      <ModHelperScrollBars
        ref={scrollbars}
        autoHeightMax={height}
        onUpdate={(values) => backgroundOnScroll(values, background.current!)}
      >
        <ScrollBarsContext.Provider value={scrollbars.current}>
          <BackgroundImage ref={background}>
            <Component {...pageProps} />
          </BackgroundImage>
        </ScrollBarsContext.Provider>
      </ModHelperScrollBars>
    </SSRProvider>
  );
};
