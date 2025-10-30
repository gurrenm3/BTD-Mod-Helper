import React, {
  Fragment,
  FunctionComponent,
  PropsWithChildren,
  ReactElement,
  useEffect,
  useMemo,
  useRef,
  useState,
} from "react";
import { Button, Container, Offcanvas } from "react-bootstrap";
import { List, ListUl } from "react-bootstrap-icons";
import { OffcanvasPlacement } from "react-bootstrap/Offcanvas";
import Layout, { ModHelperScrollBars, switchSize } from "./layout";
import { MainContentMarker } from "./skip-link";
import { getMarkdownContent } from "../lib/markdown";
import { htmlToReact } from "./markdown";
import ModHelperHelmet from "./helmet";
import cx from "classnames";
import { use100vh } from "react-div-100vh";

const ModHelperOffCanvas: FunctionComponent<
  PropsWithChildren<{
    show: boolean;
    setShowing: (showing: boolean) => void;
    title: string;
    placement: OffcanvasPlacement;
    mainHeight?: number;
  }>
> = ({ show, setShowing, title, placement, children, mainHeight }) => {
  const pageHeight = use100vh() || 1000;

  const navbarSize = 74 + 24 * 2;

  const maxHeight = pageHeight - navbarSize * (mainHeight > pageHeight ? 1 : 2);

  return (
    <Offcanvas
      show={show}
      responsive={switchSize}
      onHide={() => setShowing(false)}
      scroll={true}
      className={
        "main-panel w-auto btd6-panel blue overflow-hidden sticky-top-lg p-0"
      }
      restoreFocus={false}
      placement={placement}
      style={{ maxHeight }}
    >
      <div className={"overflow-y-scroll"} style={{ maxHeight }}>
        <div className={"p-2"}>
          <Offcanvas.Header
            className={"pt-2 pb-0 ps-3 pe-4"}
            closeButton={true}
            closeVariant={"white"}
          >
            <Offcanvas.Title>{title}</Offcanvas.Title>
          </Offcanvas.Header>
          <Offcanvas.Body
            className={`py-2 px-${switchSize}-3 d-block btd6-panel blue-insert-round`}
          >
            {children}
          </Offcanvas.Body>
        </div>
      </div>
    </Offcanvas>
  );
};

interface MarkdownLayoutProps {
  data?: Awaited<ReturnType<typeof getMarkdownContent>>;
  sidebar?: Awaited<ReturnType<typeof getMarkdownContent>>;
  noToc?: boolean;
  noTitle?: boolean;
  description?: string;
  className?: string;
}

export const MarkdownLayout: FunctionComponent<
  PropsWithChildren<MarkdownLayoutProps>
> = ({ data, sidebar, noToc, noTitle, description, children, className }) => {
  const hasToc = !noToc && data?.tableOfContentsHtml?.includes("li");
  const [showToc, setShowToc] = useState(false);
  const [showWiki, setShowWiki] = useState(false);

  // noinspection JSVoidFunctionReturnValueUsed
  const content = useMemo(
    () => htmlToReact().processSync(data?.contentHtml).result,
    [data?.contentHtml]
  ) as ReactElement;

  // noinspection JSVoidFunctionReturnValueUsed
  const sidebarContent = useMemo(
    () => htmlToReact().processSync(sidebar?.contentHtml).result,
    [sidebar?.contentHtml]
  ) as ReactElement;

  // console.log(sidebarContent)

  // noinspection JSVoidFunctionReturnValueUsed
  const tableOfContents = useMemo(
    () => htmlToReact().processSync(data?.tableOfContentsHtml).result,
    [data?.tableOfContentsHtml]
  ) as ReactElement;

  const mainPanel = useRef<HTMLDivElement>(null);
  const [mainHeight, setMainHeight] = useState<number>(
    mainPanel.current?.clientHeight
  );

  useEffect(() => {
    const el = mainPanel.current;
    if (!el) return;

    const observer = new ResizeObserver(() => {
      setMainHeight(el.clientHeight);
    });

    observer.observe(el);
    setMainHeight(el.clientHeight);

    return () => observer.disconnect();
  }, []);
  return (
    <Layout>
      <ModHelperHelmet
        title={data?.title}
        description={data?.subtitle ?? description}
      />
      <div className={`d-flex flex-grow-1`}>
        <div
          className={`d-flex flex-1 justify-content-end align-items-start pe-${switchSize}-4 ps-${switchSize}-4`}
        >
          {hasToc && (
            <ModHelperOffCanvas
              title={"Table of Contents"}
              show={showToc}
              setShowing={setShowToc}
              placement={"start"}
              mainHeight={mainHeight}
            >
              {tableOfContents}
            </ModHelperOffCanvas>
          )}
        </div>
        <div
          className={`sidebar d-flex flex-1 justify-content-start align-items-start ps-${switchSize}-4 pe-${switchSize}-4 order-1`}
        >
          {sidebar && (
            <ModHelperOffCanvas
              show={showWiki}
              setShowing={setShowWiki}
              title={"Wiki"}
              placement={"end"}
              mainHeight={mainHeight}
            >
              {sidebarContent}
            </ModHelperOffCanvas>
          )}
        </div>
        <MainContentMarker />
        <Container
          ref={mainPanel}
          fluid={switchSize}
          className={`main-panel py-${switchSize}-2 px-${switchSize}-3 d-flex flex-column btd6-panel blue`}
        >
          {!(noTitle && !hasToc && !sidebar) && (
            <>
              <div
                className={`mb-1 pt-0 py-${switchSize}-2 px-0 px-${switchSize}-2 btd6-panel blue-insert-round`}
              >
                <h1 className={"d-flex m-0"}>
                  <div className={`flex-1 d-${switchSize}-none text-start`}>
                    {hasToc && (
                      <Button
                        className={`d-${switchSize}-none me-2 btd6-button blue p-2`}
                        variant={"outline-light"}
                        onClick={() => setShowToc(true)}
                      >
                        <ListUl size={"2rem"} />
                      </Button>
                    )}
                  </div>
                  <div
                    className={`text-center text-${switchSize}-start mt-1 mt-${switchSize}-start `}
                  >
                    {data?.title?.replace(/\./g, "\u200B.")}
                  </div>
                  <div className={`flex-1 d-${switchSize}-none text-end`}>
                    {sidebar && (
                      <Button
                        className={`d-${switchSize}-none ms-auto btd6-button blue p-2`}
                        variant={"outline-light"}
                        onClick={() => setShowWiki(true)}
                      >
                        <List size={"2rem"} />
                      </Button>
                    )}
                  </div>
                </h1>
                {data?.subtitle && <div>{data.subtitle}</div>}
              </div>
              <hr className={"mt-0 mb-2"} />
            </>
          )}
          {children || (
            <div
              className={cx(
                "d-block",
                "btd6-panel",
                "blue-insert-round",
                className
              )}
            >
              {content}
            </div>
          )}
        </Container>
      </div>
    </Layout>
  );
};
