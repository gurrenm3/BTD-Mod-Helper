import React, {
  createContext,
  FunctionComponent,
  PropsWithChildren,
  useRef,
} from "react";
import BackgroundImage from "./background-image";
import { Scrollbars } from "react-custom-scrollbars-2";
import { use100vh } from "react-div-100vh";
import { ModHelperNavBar } from "./navbar";
import ModHelperHelmet from "./helmet";
import { Container } from "react-bootstrap";
import SkipLink from "./skip-link";

export const switchSize = "xl";

export const ScrollBarsContext = createContext(null as Scrollbars | null);

const Layout: FunctionComponent<PropsWithChildren> = ({ children }) => {
  const height = use100vh() ?? 1000;

  const ref = useRef<Scrollbars | null>(null);

  return (
    <>
      <ModHelperHelmet />
      <Scrollbars
        ref={ref}
        universal
        autoHeight
        autoHeightMax={height}
        autoHide
        autoHideTimeout={1000}
        autoHideDuration={200}
        renderTrackVertical={({ style, ...props }) => (
          <div
            {...props}
            style={{
              ...style,
              width: 10,
              top: 2,
              bottom: 2,
              borderRadius: 3,
              right: 2,
              backgroundColor: "rgba(255, 255, 255, 0.2)",
            }}
          />
        )}
        renderThumbVertical={({ style, ...props }) => (
          <div
            {...props}
            style={{
              ...style,
              borderRadius: 3,
              backgroundColor: "rgba(255, 255, 255, 0.5)",
            }}
          />
        )}
      >
        <ScrollBarsContext.Provider value={ref.current}>
          <div
            style={{
              height,
            }}
            className={"d-flex flex-column"}
          >
            <SkipLink />
            <BackgroundImage />
            <ModHelperNavBar />
            <Container id={"main"} className={"main-black-panel m-0"}>
              <hr className={"d-xl-none m-0 bg-black"} />
            </Container>
            {children}
          </div>
        </ScrollBarsContext.Provider>
      </Scrollbars>
    </>
  );
};

export default Layout;
