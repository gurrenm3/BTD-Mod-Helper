import React, { FunctionComponent, PropsWithChildren, useState } from "react";
import { Helmet } from "react-helmet";
import { Button, Container, Offcanvas } from "react-bootstrap";
import { List } from "react-bootstrap-icons";
import { getMarkdownContent } from "../lib/markdown";
import { OffcanvasPlacement } from "react-bootstrap/Offcanvas";
import { switchSize } from "./layout";

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

  return (
    <div>
      <Helmet
        {...(data?.title ? { title: data.title } : {})}
        meta={[{ name: "description", content: data?.description }]}
      />
      <div className={"d-flex"}>
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
        <Container
          fluid={switchSize}
          className={`main-black-panel mb-${switchSize}-4 py-2 px-3`}
        >
          {!noTitle && (
            <>
              <h1 className={"d-flex"}>
                {hasToc && (
                  <Button
                    className={`d-${switchSize}-none me-2 h-100 p-2 mt-2`}
                    variant={"outline-gray"}
                    onClick={() => setShowToc(true)}
                  >
                    <List size={"1.5rem"} />
                  </Button>
                )}
                {data?.title}
                {sidebar && (
                  <Button
                    className={`d-${switchSize}-none ms-auto h-100 p-2 mt-2`}
                    variant={"outline-gray"}
                    onClick={() => setShowWiki(true)}
                  >
                    <List size={"1.5rem"} />
                  </Button>
                )}
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
        </Container>
        <div
          className={`d-flex flex-1 justify-content-start align-items-start ps-${switchSize}-4 pe-xl-4`}
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
      </div>
    </div>
  );
};
