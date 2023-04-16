import React from "react";

const BackgroundImage = () => (
  <div
    style={{
      position: "fixed",
      left: 0,
      right: 0,
      zIndex: -1,
      backgroundImage: `url(${process.env.NEXT_PUBLIC_BASE_PATH}/images/Workshop_No_UI.png)`,
      backgroundSize: "cover",
      filter: "blur(5px)",
      transform: "scale(1.1)",
      height: "100%",
      width: "100%",
    }}
  />
);

export default BackgroundImage;
