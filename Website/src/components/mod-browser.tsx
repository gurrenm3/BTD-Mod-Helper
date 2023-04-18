import React, { FunctionComponent, useMemo, useState } from "react";
import {
  getContentUrl,
  getGithubUrl,
  getIconUrl,
  modDisplayAuthor,
  modDisplayName,
  modDisplayVersion,
  ModHelperData,
} from "../lib/mod-helper-data";
import { ModdersData } from "../lib/mod-browser";
import { Button, Col, Collapse, Row } from "react-bootstrap";
import cx from "classnames";
import { getColor } from "../lib/blatant-favoritism";
import Image from "next/image";
import Star from "public/images/BTD6/Star.png";
import HomeBtn from "public/images/BTD6/HomeBtn.png";
import InfoBtn from "public/images/BTD6/InfoBtn.png";
import ArrowHideBtn from "public/images/BTD6/ArrowHideBtn.png";
import VerifiedIcon from "public/images/BTD6/VerifiedIcon.png";
import DownloadBtn from "public/BloonsTD6 Mod Helper/Resources/DownloadBtn.png";
import { Octokit } from "octokit";
import { Commit, Release } from "@octokit/webhooks-types";
import { htmlToReact } from "./markdown";

export interface ReleaseWithMod extends Release {
  mod: ModHelperData;
}

export const ModEntry: FunctionComponent<{
  mod: ModHelperData;
  data: ModdersData;
  selectMod: (mod: ModHelperData) => void;
  showRelease: (release: ReleaseWithMod) => void;
  showCommit?: (commit: Commit) => void;
}> = ({ mod, data, selectMod, showRelease }) => {
  const iconSize = mod.SquareIcon ? 49 : 60;
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

  const downloadMod = async () => {
    if (!mod.LatestRelease) {
      const octokit = new Octokit();
      mod.LatestRelease = octokit.rest.repos
        .getLatestRelease({
          owner: mod.RepoOwner,
          repo: mod.RepoName,
        })
        .then((value) => value.data as Release)
        .catch(() => null);
    }

    const release = (await mod.LatestRelease) as ReleaseWithMod;

    if (release) {
      release.mod = mod;
      showRelease(release);
      return;
    }

    if (!mod.DllName) return;

    let path = mod.DllName;
    if (
      mod.SubPath &&
      !mod.SubPath.endsWith(".json") &&
      !mod.SubPath.endsWith(".txt")
    ) {
      path = mod.SubPath + path;
    }

    window.open(getContentUrl(mod, path), "_blank");

    /*if (!mod.LatestCommit) {
      const octokit = new Octokit();
      mod.LatestCommit = octokit.rest.repos
        .listCommits({
          path,
          owner: mod.RepoOwner,
          repo: mod.RepoName,
        })
        .then((value) => value.data[0] as Commit)
        .catch((reason) => null);
    }*/
  };

  return (
    <div>
      <div className={"d-flex"}>
        <Row
          key={mod.Identifier}
          className={cx(
            "non-main-panel bg-black bg-opacity-50 btd6-panel blue",
            "user-select-none",
            "flex-fill mx-0 p-md-0 gap-3 gap-md-0 gx-0 gx-md-3",
            "align-items-center align-content-around justify-content-around",
            "luckiest-guy lh-1 fs-5",
            "flex-wrap flex-md-nowrap"
          )}
        >
          <Col
            id={"icon"}
            xs={"auto"}
            style={{ margin: `-1rem 0 -1rem ${iconLeftPad}` }}
            className={"d-lg-block"}
          >
            <div style={{ height: 60, width: 60 }}>
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
          <Col id={"version"} xs={"auto"} className={"text-outline-black"}>
            {modDisplayVersion(mod)}
          </Col>
          <Col
            xs={"auto"}
            id={"stars"}
            className={"mx-md-auto text-outline-black"}
          >
            <a
              href={`https://github.com/${mod.RepoOwner}/${mod.RepoName}/stargazers`}
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
            {mod.Repository.stargazers_count}
          </Col>
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
            onClick={downloadMod}
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
      <Collapse in={description}>
        <div>
          <div className={"mt-2 btd6-panel blue-insert text-white"}>
            {descriptionBody}
          </div>
        </div>
      </Collapse>
    </div>
  );
};
