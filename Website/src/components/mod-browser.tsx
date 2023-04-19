import React, {
  CSSProperties,
  FunctionComponent,
  useMemo,
  useRef,
  useState,
} from "react";
import {
  getContentUrl,
  getGithubUrl,
  getIconUrl,
  getStarCount,
  getStarsUrl,
  modDisplayAuthor,
  modDisplayName,
  modDisplayVersion,
  ModHelperData,
} from "../lib/mod-helper-data";
import { downloadMod, ModdersData } from "../lib/mod-browser";
import { Button, Col, Collapse, Overlay, Row } from "react-bootstrap";
import cx from "classnames";
import { getColor } from "../lib/blatant-favoritism";
import Image from "next/image";
import Star from "public/images/BTD6/Star.png";
import HomeBtn from "public/images/BTD6/HomeBtn.png";
import InfoBtn from "public/images/BTD6/InfoBtn.png";
import ArrowHideBtn from "public/images/BTD6/ArrowHideBtn.png";
import VerifiedIcon from "public/images/BTD6/VerifiedIcon.png";
import DownloadBtn from "public/BloonsTD6 Mod Helper/Resources/DownloadBtn.png";
import { Commit, Release } from "@octokit/webhooks-types";
import { htmlToReact } from "./markdown";

export interface ReleaseWithMod extends Release {
  mod: ModHelperData;
}

interface ModEntryProps {
  mod: ModHelperData;
  data: ModdersData;
  selectMod?: (mod: ModHelperData) => void;
  showRelease?: (release: ReleaseWithMod) => void;
  showCommit?: (commit: Commit) => void;
  mini?: boolean;
  style?: CSSProperties;
}

export const ModEntry: FunctionComponent<ModEntryProps> = ({
  mod,
  data,
  selectMod,
  showRelease,
  mini,
  style,
}) => {
  const iconSize = mod.SquareIcon ? 50 : 60;
  const iconLeftPad = mod.SquareIcon ? "-.75rem" : "-1rem";

  const [description, showDescription] = useState(false);

  // noinspection JSVoidFunctionReturnValueUsed
  const descriptionBody = useMemo(
    () =>
      htmlToReact().processSync(
        (mod.Description ?? "").replaceAll("\\n", "<br/>")
      ).result,
    [mod.Description]
  );

  const container = useRef<HTMLDivElement>(null);
  const panel = useRef<HTMLDivElement>(null);

  return (
    <div style={style} ref={container}>
      <div className={"d-flex"}>
        <Row
          ref={panel}
          key={mod.Identifier}
          className={cx(
            "non-main-panel bg-black bg-opacity-50 btd6-panel blue",
            "user-select-none",
            "flex-fill mx-0 p-md-0 gap-3 gap-md-0 gx-0 gx-md-3",
            "align-items-center align-content-around",
            "luckiest-guy lh-1 fs-5",
            "flex-wrap flex-md-nowrap",
            mini ? "justify-content-between" : "justify-content-around"
          )}
        >
          <Col
            id={"icon"}
            xs={"auto"}
            style={{ margin: `-1rem 0 -1rem ${iconLeftPad}` }}
            className={"d-lg-block"}
          >
            <div style={{ height: 60, width: 60 }} className={"d-flex"}>
              <img
                alt={""}
                src={getIconUrl(mod)}
                onError={(event) => {
                  const img = event.target as HTMLImageElement;
                  img.style.height = "0";
                  img.style.width = "0";
                  img.parentElement!.parentElement!.classList.add("d-none");
                }}
                height={iconSize}
                width={iconSize}
                className={"m-auto"}
              />
            </div>
          </Col>
          <Col
            id={"name"}
            xs={8}
            sm={"auto"}
            md={3}
            className={"text-outline-black"}
            style={{ overflowWrap: "break-word" }}
          >
            {modDisplayName(mod)}
          </Col>
          <Col
            id={"author"}
            xs={8}
            sm={"auto"}
            md={4}
            className={"text-center"}
          >
            <a
              className={"text-outline-black text-decoration-none"}
              href={`https://github.com/${mod.RepoOwner}`}
              style={{ color: getColor(mod.RepoOwner) }}
              target={"_blank"}
            >
              {modDisplayAuthor(mod)}
              {data.verified.includes(mod.RepoOwner) && (
                <Image
                  src={VerifiedIcon}
                  height={20}
                  width={20}
                  alt={"VerifiedIcon"}
                  className={"ms-1 user-select-none"}
                  draggable={false}
                />
              )}
            </a>
          </Col>
          {!mini && (
            <Col
              id={"version"}
              xs={"auto"}
              className={"text-outline-black"}
              style={{ minWidth: "5rem" }}
            >
              {modDisplayVersion(mod)}
            </Col>
          )}
          {!mini && (
            <Col
              xs={"auto"}
              id={"stars"}
              className={"mx-md-auto text-outline-black"}
            >
              <a
                href={getStarsUrl(mod)}
                className={"btn btd6-button p-0 border-0"}
                target={"_blank"}
              >
                <Image
                  src={Star}
                  height={25}
                  width={25}
                  alt={"Star"}
                  className={"mb-1 me-1 user-select-none"}
                  draggable={false}
                />
              </a>
              {getStarCount(mod)}
              {mod.CountOfMonoRepo ? "+" : " "}
            </Col>
          )}
          {selectMod && (
            <Col id={"info"} xs={"auto"}>
              <Image
                src={InfoBtn}
                alt={"More Info"}
                className={"btn btd6-button m-0 p-0 border-0"}
                height={35}
                draggable={false}
                onClick={() => selectMod(mod)}
              />
            </Col>
          )}
          <Col id={"description"} xs={"auto"}>
            <Image
              src={ArrowHideBtn}
              alt={"Description"}
              className={"btn btd6-button m-0 p-0 border-0"}
              height={35}
              draggable={false}
              onClick={() => showDescription(!description)}
            />
          </Col>
        </Row>
        <div
          className={
            "flex-shrink-0 d-flex gap-3 ms-3 flex-column flex-md-row justify-content-around"
          }
        >
          <a href={getGithubUrl(mod, "#readme")} target={"_blank"}>
            <Image
              src={HomeBtn}
              alt={"Homepage"}
              className={"btn btd6-button m-0 p-0 border-0"}
              height={50}
              width={50}
              loading={"eager"}
              draggable={false}
            />
          </a>
          <Button
            className={"p-0 bg-transparent border-0"}
            onClick={() =>
              downloadMod(mod, showRelease, mini ? undefined : selectMod)
            }
          >
            <Image
              src={DownloadBtn}
              alt={"Download"}
              className={"btn btd6-button m-0 p-0 border-0"}
              height={50}
              width={50}
              draggable={false}
              loading={"eager"}
            />
          </Button>
        </div>
      </div>
      <Overlay
        target={panel.current}
        container={container.current}
        show={description}
        placement={"bottom"}
        rootClose={true}
        onHide={() => showDescription(false)}
      >
        <div
          style={{
            width: panel.current?.clientWidth,
          }}
          className={
            "main-panel non-main-panel bg-black btd6-panel blue-insert text-white"
          }
        >
          {descriptionBody || "No Description Provided"}
        </div>
      </Overlay>
    </div>
  );
};
