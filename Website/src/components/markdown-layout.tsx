import React, {
  createElement,
  Fragment,
  FunctionComponent,
  PropsWithChildren,
  ReactElement,
  useMemo,
  useState,
} from "react";
import { Helmet } from "react-helmet";
import { Button, Container, Offcanvas } from "react-bootstrap";
import { List, ListUl } from "react-bootstrap-icons";
import { OffcanvasPlacement } from "react-bootstrap/Offcanvas";
import Layout, { switchSize } from "./layout";
import { MainContentMarker } from "./skip-link";
import { rehype } from "rehype";
import rehypeParse from "rehype-parse";
import rehypeReact, { Options } from "rehype-react";
import Link from "next/link";
import { getMarkdownContent } from "../lib/markdown";
import { htmlToReact } from "./markdown";

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
      className={"main-panel w-auto btd6-panel blue"}
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
      <Offcanvas.Body
        className={"py-2 px-3 d-block btd6-panel blue-insert-round"}
      >
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

  // noinspection JSVoidFunctionReturnValueUsed
  const tableOfContents = useMemo(
    () => htmlToReact().processSync(data?.tableOfContentsHtml).result,
    [data?.tableOfContentsHtml]
  ) as ReactElement;

  return (
    <Layout>
      <Helmet
        {...(data?.title ? { title: data.title } : {})}
        meta={[{ name: "description", content: data?.description }]}
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
            >
              {tableOfContents}
            </ModHelperOffCanvas>
          )}
        </div>
        <div
          className={`d-flex flex-1 justify-content-start align-items-start ps-${switchSize}-4 pe-${switchSize}-4 order-1`}
        >
          {sidebar && (
            <ModHelperOffCanvas
              show={showWiki}
              setShowing={setShowWiki}
              title={"Wiki"}
              placement={"end"}
            >
              {sidebarContent}
            </ModHelperOffCanvas>
          )}
        </div>
        <MainContentMarker />
        <Container
          fluid={switchSize}
          className={`main-panel py-2 px-3 d-flex flex-column btd6-panel blue`}
        >
          {!(noTitle && !hasToc && !sidebar) && (
            <>
              <h1 className={"d-flex my-1 btd6-panel blue-insert-round"}>
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
                  className={`text-center text-${switchSize}-start mt-1 mt-${switchSize}-start`}
                >
                  {data?.title}
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
              <hr />
            </>
          )}
          {children || (
            <div className={"d-block btd6-panel blue-insert-round"}>
              {content}
            </div>
          )}
        </Container>
      </div>
    </Layout>
  );
};
