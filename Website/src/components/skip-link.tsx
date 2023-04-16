import Link from "next/link";
import React from "react";

export default () => (
  <Link
    href={"#main-content"}
    className={"position-absolute visually-hidden-focusable"}
    onClick={() => document.getElementById("main-content")?.focus()}
  >
    Skip to Main Content
  </Link>
);

export const MainContentMarker = () => <a id={"main-content"} tabIndex={-1} />;
