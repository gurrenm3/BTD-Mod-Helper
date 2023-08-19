import Layout, { switchSize } from "../components/layout";
import React, { useMemo, useState } from "react";
import { Col, Container, Row } from "react-bootstrap";
import { use100vh } from "react-div-100vh";
import { remark } from "remark";
import remarkGfm from "remark-gfm";
import remarkRehype from "remark-rehype";
import rehypeRaw from "rehype-raw";
import rehypeStringify from "rehype-stringify";
import rehypeMinifyWhitespace from "rehype-minify-whitespace";
import rehypeRewrite from "rehype-rewrite";

export default () => {
  const height = use100vh() ?? 1000;

  const [leftArea, setLeftArea] = useState("");

  const rightArea = useMemo(
    () =>
      remark()
        .use(remarkGfm)
        .use(remarkRehype, { allowDangerousHtml: true })
        .use(rehypeRaw)
        .use(rehypeRewrite, {
          rewrite(node) {
            if (node.type === "element" && node.tagName == "h3") {
              node.tagName = "h2";
            }
          },
        })
        .use(rehypeStringify)
        .use(rehypeMinifyWhitespace)
        .processSync(leftArea)
        .toString() + "\n",
    [leftArea]
  );

  return (
    <Layout style={{ height }}>
      <Container
        fluid={switchSize}
        className={`d-flex flex-column main-panel btd6-panel blue flex-1 gap-2`}
      >
        <Row className={"flex-grow-1"}>
          <Col xs={6} className={"d-flex flex-column"}>
            <textarea
              className={"h-100"}
              value={leftArea}
              placeholder={"markdown"}
              onChange={(e) => setLeftArea(e.target.value)}
            />
          </Col>
          <Col xs={6} className={"d-flex flex-column"}>
            <textarea
              className={"h-100"}
              value={rightArea}
              placeholder={"ko-fi html"}
              readOnly={true}
            />
          </Col>
        </Row>
      </Container>
    </Layout>
  );
};
