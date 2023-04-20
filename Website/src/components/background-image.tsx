import React, {
  createContext,
  forwardRef,
  PropsWithChildren,
  useEffect,
  useState,
} from "react";
import maps from "../data/maps.json";
import { useUpdateEffect } from "react-use";
import { positionValues } from "react-custom-scrollbars-2";

export const BackgroundContext = createContext([
  "workshop" as string,
  (map: string) => {},
] as const);

export const backgroundOnScroll = (
  { clientHeight, clientWidth, scrollHeight, scrollWidth, top }: positionValues,
  background: HTMLDivElement
) => {
  const style = background.style;
  const factor = scrollHeight / clientHeight;

  if (factor <= 1) {
    style.backgroundPositionY = "center";
    return;
  }

  const aspectRatio = clientWidth / clientHeight;
  const maxEffectiveBgHeight = (9 * clientWidth) / 16;
  const offset = (maxEffectiveBgHeight - clientHeight) * top;

  if (offset < 0) {
    style.backgroundPositionY = `0`;
  } else if (aspectRatio < 16 / 9) {
    style.backgroundPositionY = `${offset}px`;
  } else {
    style.backgroundPositionY = `${-offset}px`;
  }
};

const BackgroundImage = forwardRef<HTMLDivElement, PropsWithChildren>(
  ({ children }, ref) => {
    const [map, setMap] = useState("workshop");

    useEffect(() => {
      setMap(localStorage.getItem("map") || "workshop");
    }, []);

    useUpdateEffect(() => {
      localStorage.setItem("map", map);
    }, [map]);

    return (
      <BackgroundContext.Provider value={[map, setMap]}>
        <div
          ref={ref}
          className={`dynamic-background`}
          style={{
            position: "fixed",
            left: 0,
            right: 0,
            zIndex: -100,
            backgroundImage: `url(${process.env.NEXT_PUBLIC_BASE_PATH}/images/BTD6/Maps/${maps[map]}.png)`,
            backgroundRepeat: "no-repeat",
            filter: "blur(7px)",
            transform: "scale(1.1)",
            height: "100%",
            width: "100%",
          }}
        />
        {children}
      </BackgroundContext.Provider>
    );
  }
);

export default BackgroundImage;
