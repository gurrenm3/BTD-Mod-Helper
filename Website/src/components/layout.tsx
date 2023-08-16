import React, {
  createContext,
  forwardRef,
  FunctionComponent,
  HTMLAttributes,
  PropsWithChildren,
} from "react";
import { ScrollbarProps, Scrollbars } from "react-custom-scrollbars-2";
import { use100vh } from "react-div-100vh";
import { ModHelperFooter, ModHelperNavBar } from "./navbar";
import SkipLink from "./skip-link";
import cx from "classnames";
import { useUpdate } from "react-use";

export const switchSize = "lg";

export const ScrollBarsContext = createContext(null as Scrollbars | null);

export const ModHelperScrollBars = forwardRef<Scrollbars, ScrollbarProps>(
  ({ children, ...props }, ref) => {
    return (
      <Scrollbars
        ref={ref}
        universal
        autoHeight
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
        {...props}
      >
        {children}
      </Scrollbars>
    );
  }
);

interface LayoutProps
  extends PropsWithChildren<HTMLAttributes<HTMLDivElement>> {
  backToTop?: () => void;
  headerClassName?: string;
  footerClassName?: string;
  fitHeight?: boolean;
}

const Layout: FunctionComponent<LayoutProps> = ({
  children,
  className,
  style,
  backToTop,
  headerClassName,
  footerClassName,
  fitHeight,
  ...props
}) => {
  const minHeight = use100vh() ?? 1000;

  return (
    <div
      className={cx("d-flex", "flex-column", className)}
      style={{ minHeight: minHeight, ...style }}
      {...props}
    >
      <SkipLink />
      <ModHelperNavBar className={headerClassName} />
      {children}
      <ModHelperFooter backToTop={backToTop} className={footerClassName} />
    </div>
  );
};

export default Layout;
