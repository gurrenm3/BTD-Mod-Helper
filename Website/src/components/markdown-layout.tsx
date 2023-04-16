import React, {
  FunctionComponent,
  PropsWithChildren,
  useContext,
  useState,
} from "react";
import { Helmet } from "react-helmet";
import { Button, Container, Offcanvas } from "react-bootstrap";
import { List, ListUl } from "react-bootstrap-icons";
import { getMarkdownContent } from "../lib/markdown";
import { OffcanvasPlacement } from "react-bootstrap/Offcanvas";
import { ScrollBarsContext, switchSize } from "./layout";
import { MainContentMarker } from "./skip-link";

const ModHelperOffCanvas: FunctionComponent<
  PropsWithChildren<{
    show: boolean;
    setShowing: (showing: boolean) => void;
    title: string;
    placement: OffcanvasPlacement;
  }>
> = ({ show, setShowing, title, placement, children }) => {
  return (
    <Offcanvas
      show={show}
      responsive={switchSize}
      onHide={() => setShowing(false)}
      scroll={true}
      className={"main-black-panel w-auto"}
      restoreFocus={false}
      placement={placement}
    >
      <Offcanvas.Header
        className={"pt-2 pb-0 px-3"}
        closeButton={true}
        closeVariant={"white"}
      >
        <Offcanvas.Title>{title}</Offcanvas.Title>
      </Offcanvas.Header>
      <Offcanvas.Body className={"py-2 px-3 d-block"}>
        {children}
      </Offcanvas.Body>
    </Offcanvas>
  );
};

interface MarkdownLayoutProps {
  data?: Awaited<ReturnType<typeof getMarkdownContent>>;
  sidebar?: Awaited<ReturnType<typeof getMarkdownContent>>;
  noToc?: boolean;
  noTitle?: boolean;
}

export const MarkdownLayout: FunctionComponent<
  PropsWithChildren<MarkdownLayoutProps>
> = ({ data, sidebar, noToc, noTitle, children }) => {
  const hasToc = !noToc && data?.tableOfContentsHtml?.includes("li");
  const [showToc, setShowToc] = useState(false);
  const [showWiki, setShowWiki] = useState(false);

  const scrollbars = useContext(ScrollBarsContext);

  return (
    <>
      <Helmet
        {...(data?.title ? { title: data.title } : {})}
        meta={[{ name: "description", content: data?.description }]}
      />
      <div className={`d-flex flex-grow-1 pb-${switchSize}-4`}>
        <div
          className={`d-flex flex-1 justify-content-end align-items-start pe-${switchSize}-4 ps-xl-4`}
        >
          {hasToc && (
            <ModHelperOffCanvas
              title={"Table of Contents"}
              show={showToc}
              setShowing={setShowToc}
              placement={"start"}
            >
              <div
                dangerouslySetInnerHTML={{
                  __html: data?.tableOfContentsHtml ?? "",
                }}
              />
            </ModHelperOffCanvas>
          )}
        </div>
        <div
          className={`d-flex flex-1 justify-content-start align-items-start ps-${switchSize}-4 pe-xl-4 order-1`}
        >
          {sidebar && (
            <ModHelperOffCanvas
              show={showWiki}
              setShowing={setShowWiki}
              title={"Wiki"}
              placement={"end"}
            >
              <div
                dangerouslySetInnerHTML={{
                  __html: sidebar?.contentHtml ?? "",
                }}
              />
            </ModHelperOffCanvas>
          )}
        </div>
        <MainContentMarker />
        <Container
          fluid={switchSize}
          className={`main-black-panel py-2 px-3 d-flex flex-column`}
        >
          {!(noTitle && !hasToc && !sidebar) && (
            <>
              <h1 className={"d-flex my-1"}>
                <div className={`flex-1 d-${switchSize}-none text-start`}>
                  {hasToc && (
                    <Button
                      className={`d-${switchSize}-none me-2 h-100 p-2 mt-2`}
                      variant={"outline-gray"}
                      onClick={() => setShowToc(true)}
                    >
                      <ListUl size={"1.5rem"} />
                    </Button>
                  )}
                </div>
                <div className={`text-center text-${switchSize}-start`}>
                  {data?.title}
                </div>
                <div className={`flex-1 d-${switchSize}-none text-end`}>
                  {sidebar && (
                    <Button
                      className={`d-${switchSize}-none ms-auto h-100 p-2 mt-2`}
                      variant={"outline-gray"}
                      onClick={() => setShowWiki(true)}
                    >
                      <List size={"1.5rem"} />
                    </Button>
                  )}
                </div>
              </h1>
              <hr />
            </>
          )}
          {children || (
            <div
              className={"d-block"}
              dangerouslySetInnerHTML={{ __html: data?.contentHtml ?? "" }}
            />
          )}
          {!(noTitle && !hasToc && !sidebar) && (
            <div className={"mt-auto"}>
              <hr />
              <h1 className={"d-flex my-1"}>
                <div className={`flex-1 d-${switchSize}-none text-start`}>
                  {hasToc && (
                    <Button
                      className={`d-${switchSize}-none me-2 h-100 p-2 mt-2`}
                      variant={"outline-gray"}
                      onClick={() => setShowToc(true)}
                    >
                      <ListUl size={"1.5rem"} />
                    </Button>
                  )}
                </div>
                <div>
                  <Button
                    variant={"outline-gray"}
                    onClick={() => scrollbars?.scrollTop(0)}
                  >
                    Back to Top
                  </Button>
                </div>
                <div className={`flex-1 d-${switchSize}-none text-end`}>
                  {sidebar && (
                    <Button
                      className={`d-${switchSize}-none ms-auto h-100 p-2 mt-2`}
                      variant={"outline-gray"}
                      onClick={() => setShowWiki(true)}
                    >
                      <List size={"1.5rem"} />
                    </Button>
                  )}
                </div>
              </h1>
            </div>
          )}
        </Container>
      </div>
    </>
  );
};
