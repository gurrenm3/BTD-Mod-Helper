import { useEffect } from "react";

const Themes = ["light", "dark"];
const DefaultTheme = "dark";

export const Btd6Styles = () => {
  const basePath = process.env.NEXT_PUBLIC_BASE_PATH;

  useEffect(() => {
    let theme = DefaultTheme;

    //local storage is used to override OS theme settings
    if (localStorage.getItem("theme")) {
      theme = localStorage.getItem("theme")!;
    } else if (
      "watchMedia" in window &&
      window.matchMedia("(prefers-color-scheme: dark)").matches
    ) {
      //OS theme setting detected as dark
      theme = "dark";
    }

    if (!Themes.includes(theme)) {
      theme = DefaultTheme;
    }

    document.documentElement.setAttribute("data-theme", theme);
  }, []);

  return (
    <>
      <style jsx={true} global={true}>
        {`
          // Panels

          [data-theme="light"] .btd6-panel.blue {
            border-image-source: url(${basePath}/images/BTD6/MainBGPanelBlue.png);
          }

          .btd6panel.brown {
            border-image-source: url(${basePath}/images/BTD6/MainBgPanel.png);
          }

          .btd6-panel.yellow {
            border-image-source: url(${basePath}/images/BTD6/MainBGPanelYellow.png);
          }

          .btd6-panel.grey {
            border-image-source: url(${basePath}/images/BTD6/MainBgPanelGrey.png);
          }

          .btd6-panel.dark {
            border-image-source: url(${basePath}/images/BTD6/MainBgPanelJukebox.png);
          }

          // Insert Panels

          [data-theme="light"] .btd6-panel.blue-insert {
            border-image-source: url(${basePath}/images/BTD6/BlueInsertPanel.png);
          }

          .btd6-panel.grey-insert {
            border-image-source: url(${basePath}/images/BTD6/GreyInsertPanel.png);
          }

          .btd6-panel.brown-insert {
            border-image-source: url(${basePath}/images/BTD6/BrownInsertPanel.png);
          }

          .btd6-panel.white-insert {
            border-image-source: url(${basePath}/images/BTD6/InsertPanelWhite.png);
          }

          // Round Insert Panels

          .btd6-panel.white-insert-round {
            border-image-source: url(${basePath}/images/BTD6/InsertPanelWhiteRound.png);
            color: black;
          }

          [data-theme="light"] .btd6-panel.blue-insert-round {
            border-image-source: url(${basePath}/images/BTD6/BlueInsertPanelRound.png);
          }

          [data-theme="light"] .btd6-button.blue {
            background-image: url(${basePath}/images/BTD6/BlueBtn.png);
          }

          [data-theme="light"] .btd6-button.blue.long {
            background-image: url(${basePath}/images/BTD6/BlueBtnLong.png);
          }

          [data-theme="light"].btd6-button.green {
            background-image: url(${basePath}/images/BTD6/GreenBtn.png);
          }

          [data-theme="light"] .btd6-button.green.long {
            background-image: url(${basePath}/images/BTD6/GreenBtnLong.png);
          }

          [data-theme="light"] .btd6-button.red {
            background-image: url(${basePath}/images/BTD6/RedBtn.png);
          }

          [data-theme="light"] .btd6-button.red.long {
            background-image: url(${basePath}/images/BTD6/RedBtnLong.png);
          }

          [data-theme="light"] .btd6-button.yellow {
            background-image: url(${basePath}/images/BTD6/YellowBtn.png);
          }

          [data-theme="light"] .btd6-button.yellow.long {
            background-image: url(${basePath}/images/BTD6/YellowBtnLong.png);
          }
        `}
      </style>
    </>
  );
};
