import { AppProps } from "next/app";
import React, { createContext, useRef } from "react";
import "../css/bootstrap.scss";
import "../css/fonts.scss";
import "../css/global.scss";
import "../css/btd6.scss";
import "../css/blockly.scss";
import { Btd6Styles } from "../components/btd6-ui";
import ModHelperHelmet from "../components/helmet";
import { use100vh } from "react-div-100vh";
import BackgroundImage, {
  backgroundOnScroll,
} from "../components/background-image";
import { ModHelperScrollBars, ScrollBarsContext } from "../components/layout";
import { Scrollbars } from "react-custom-scrollbars-2";
import { usePathname } from "next/navigation";
import { useUpdateEffect } from "react-use";
import { useUpdate } from "react-use";

type Theme = "light" | "dark" | string | undefined;

export const ThemeContext = createContext<{
  theme: Theme;
  refreshTheme: () => void;
}>(undefined);

const DefaultTitle = "BTD Mod Helper";
const DefaultDescription =
  "Home of the modding api for BloonsTD6. Learn how to download, install and make BTD6 mods.";

export default ({ Component, pageProps }: AppProps) => {
  const height = use100vh() ?? 1000;
  const scrollbars = useRef<Scrollbars>(null);
  const background = useRef<HTMLDivElement>(null);
  const pathname = usePathname();

  useUpdateEffect(() => {
    scrollbars.current?.scrollToTop();
  }, [pathname]);

  const theme =
    typeof document !== "undefined"
      ? document.documentElement.getAttribute("data-theme") || "light"
      : typeof localStorage !== "undefined"
      ? localStorage.getItem("theme") || "light"
      : "light";

  const refreshTheme = useUpdate();

  return (
    <>
      <Btd6Styles />
      <ModHelperHelmet title={DefaultTitle} description={DefaultDescription} />
      <ModHelperScrollBars
        ref={scrollbars}
        autoHeightMax={height}
        onUpdate={(values) => backgroundOnScroll(values, background.current!)}
      >
        <ScrollBarsContext.Provider value={scrollbars.current}>
          <ThemeContext.Provider value={{ theme, refreshTheme }}>
            <BackgroundImage ref={background}>
              <Component {...pageProps} />
            </BackgroundImage>
          </ThemeContext.Provider>
        </ScrollBarsContext.Provider>
      </ModHelperScrollBars>
    </>
  );
};
