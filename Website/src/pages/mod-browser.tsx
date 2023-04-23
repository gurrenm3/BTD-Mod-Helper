import Layout, { ModHelperScrollBars, switchSize } from "../components/layout";
import React, {
  ReactElement,
  useCallback,
  useEffect,
  useMemo,
  useRef,
  useState,
} from "react";
import {
  Button,
  Col,
  Collapse,
  Container,
  Dropdown,
  Form,
  FormControl,
  Modal,
  ProgressBar,
  Row,
  Spinner,
} from "react-bootstrap";
import { useDebounce, useList, useMap } from "react-use";
import {
  findDependencies,
  getContentUrl,
  getGithubUrl,
  getStarCount,
  LatestVersion,
  modDisplayAuthor,
  modDisplayName,
  modDisplayVersion,
  ModHelperData,
  modIsOld,
  StoppedWorkingVersion,
} from "../lib/mod-helper-data";
import {
  downloadRelease,
  getModdersData,
  ModdersData,
  populateMods,
  populateSpecificMod,
} from "../lib/mod-browser";
import { useParam, useParamBool, useParamInt } from "../lib/routing";
import { useRouter } from "next/router";
import { chain, rangeRight } from "lodash";
import DropdownToggle from "react-bootstrap/DropdownToggle";
import DropdownMenu from "react-bootstrap/DropdownMenu";
import DropdownItem from "react-bootstrap/DropdownItem";
import { use100vh } from "react-div-100vh";
import Fuse from "fuse.js";
import { ModEntry, ReleaseWithMod } from "../components/mod-browser";
import cx from "classnames";
import { htmlToReact, markdownToHtml } from "../components/markdown";
import VerifiedIcon from "public/images/BTD6/VerifiedIcon.png";
import WarningSign from "public/images/BTD6/WarningSign.png";
import Image from "next/image";
import { MainContentMarker } from "../components/skip-link";
import { Scrollbars } from "react-custom-scrollbars-2";
import ModHelperHelmet from "../components/helmet";

enum SortingMethod {
  RecentlyUpdated = "Recently Updated",
  Popularity = "Popularity",
  Alphabetical = "Alphabetical",
  New = "New",
  Old = "Old",
}

const sortMods = (method: SortingMethod) => (mod: ModHelperData) => {
  const createdAt = new Date(mod.Repository.created_at).getTime();
  let updatedAt = new Date(
    mod.Repository.pushed_at || mod.Repository.created_at
  ).getTime();
  if ((mod.CountOfMonoRepo ?? 1) > 1) {
    const splitBetween = Math.floor(Math.sqrt(mod.CountOfMonoRepo ?? 1));
    const since = Date.now() - updatedAt;
    updatedAt -= since * splitBetween;
  }

  switch (method) {
    case SortingMethod.Popularity:
      return -getStarCount(mod);
    case SortingMethod.Alphabetical:
      return modDisplayName(mod);
    case SortingMethod.Old:
      return createdAt;
    case SortingMethod.New:
      return -createdAt;
    case SortingMethod.RecentlyUpdated:
    default:
      return -updatedAt;
  }
};

const DefaultTopic = "Filter Topic";

export default () => {
  const router = useRouter();
  const height = use100vh() ?? 1000;

  const [moddersData, setModdersData] = useState({
    forceVerifiedOnly: false,
    verified: [],
    banned: [],
    bannedMods: [],
    topics: [],
  } as ModdersData);
  const [mods, { upsert: addMod, reset: clearMods }] = useList(
    [] as ModHelperData[]
  );
  const [modsById, { set: setMod, reset: clearModsById }] = useMap(
    {} as Record<string, ModHelperData>
  );
  const [fuse] = useState(
    () =>
      new Fuse([] as ModHelperData[], {
        keys: ["Name", "RepoName", "RepoOwner", "Author"],
      })
  );

  const onModFound = (mod?: ModHelperData) => {
    if (
      !mod ||
      moddersData.banned.includes(mod.RepoOwner) ||
      moddersData.bannedMods.includes(mod.Identifier)
    )
      return;
    addMod((value) => value.Identifier === mod.Identifier, mod);
    fuse.add(mod);
    setMod(mod.Identifier, mod);
  };

  const [totalCount, setTotalCount] = useState(100);

  const getAllMods = () => {
    clearMods();
    clearModsById();
    fuse.remove(() => true);

    populateMods(onModFound, (count) => {
      setTotalCount(count);
      console.log(`Setting count to ${count}`);
    }).then(() => console.log("Finished populating mods"));
  };

  useEffect(() => {
    getModdersData()
      .then(setModdersData)
      .then(() => console.log("Got modders data"));

    getAllMods();
  }, []);

  const [selectedMod, setSelectedMod] = useParam(router, "selected-mod");
  const [topic, setTopic] = useParam(router, "topic");
  const [search, setSearch] = useParam(router, "search");
  const [searchbar, setSearchbar] = useState("");
  const [showUnverified, setShowUnverified] = useParamBool(
    router,
    "unverified"
  );
  const [oldCutoff, setOldCutoff] = useParamInt(
    router,
    "old",
    StoppedWorkingVersion
  );
  useDebounce(() => setSearch(searchbar), 500, [searchbar]);
  useEffect(() => setSearchbar(search), [search]);

  useEffect(() => {
    if (selectedMod && !(selectedMod in modsById)) {
      populateSpecificMod(selectedMod).then(onModFound);
    }
  }, [selectedMod]);

  const [sortingMethod, setSortingMethod] = useParam<SortingMethod>(
    router,
    "sort"
  );

  const filteredMods = useMemo(
    () =>
      chain(search ? fuse.search(search).map((value) => value.item) : mods)
        .filter((data) => !modIsOld(data, oldCutoff))
        .filter(
          (data) =>
            (showUnverified && !moddersData.forceVerifiedOnly) ||
            moddersData.verified.includes(data.RepoOwner)
        )
        .filter(
          (data) =>
            !topic || topic === DefaultTopic || data.Topics.includes(topic)
        )
        .sortBy(sortMods(sortingMethod || SortingMethod.RecentlyUpdated))
        .value(),
    [mods, sortingMethod, topic, search, showUnverified, oldCutoff]
  );

  const [release, setRelease] = useState<ReleaseWithMod | undefined>(undefined);
  // noinspection JSVoidFunctionReturnValueUsed
  const releaseBody = useMemo(() => {
    if (!release?.body) return <></>;
    const body = release.body
      .split(/<!--Mod Browser Message Start-->[\r\n\s]*/)
      .findLast((value) => !!value);
    const html = markdownToHtml(getContentUrl(release.mod)).processSync(body);
    if (!html) return <></>;
    const element = htmlToReact(true).processSync(html.toString()).result;
    return element as ReactElement;
  }, [release]);

  const [selectedModBody, setSelectedModBody] = useState<ReactElement>(<></>);
  useEffect(() => {
    if (!selectedMod || !(selectedMod in modsById)) {
      setSelectedModBody(<></>);
      return;
    }

    const mod = modsById[selectedMod];
    const readmeUrl = getContentUrl(mod, "README.md");

    fetch(readmeUrl).then(async (value) => {
      let readmeMd = value ? await value.text() : "This mod has no README.md";
      if (!readmeMd || !readmeMd.trim()) {
        readmeMd = "This mod has an empty README.md";
      }

      const html = await markdownToHtml(
        getGithubUrl(mod),
        getContentUrl(mod)
      ).process(readmeMd);

      const element = await htmlToReact(true).process(html.toString());

      setSelectedModBody(element.result as ReactElement);
    });
  }, [selectedMod, modsById[selectedMod]]);

  const selectedModDependencies = useMemo(
    () =>
      selectedMod && selectedMod in modsById
        ? findDependencies(modsById[selectedMod], modsById).filter(
            (value) => value !== selectedMod
          )
        : [],
    [selectedMod, modsById]
  );

  const scrollbars = useRef<Scrollbars>(null);

  return (
    <Layout
      style={{ height: height }}
      backToTop={() => scrollbars.current?.scrollTop(0)}
      footerClassName={`d-none d-${switchSize}-flex`}
    >
      <ModHelperHelmet
        title={"BTD6 Mod Browser"}
        description={
          "Browse, search and download mods for BloonsTD6 using BTD Mod Helper."
        }
      />
      <Container
        fluid={switchSize}
        className={`d-flex flex-column main-panel btd6-panel blue flex-1 gap-2`}
      >
        <Row className={"g-3 justify-content-between"}>
          <Col xs={7} lg={5} className={"flex-grow-1"}>
            <Form
              onSubmit={(event) => {
                event.preventDefault();
                setSearch(searchbar);
              }}
            >
              <FormControl
                value={searchbar}
                className={"btd6-panel blue-insert-round"}
                placeholder={"Search..."}
                onChange={(event) => setSearchbar(event.target.value)}
              />
            </Form>
          </Col>
          {!moddersData.forceVerifiedOnly && (
            <Col xs={"auto"} className={"order-lg-last"}>
              <Button
                variant={"outline-light"}
                className={cx(
                  "btd6-button",
                  showUnverified ? "yellow" : "blue"
                )}
                onClick={() => setShowUnverified(!showUnverified)}
              >
                {showUnverified ? (
                  <Image
                    src={WarningSign}
                    alt={"Unverified"}
                    height={20}
                    width={20}
                    className={"p-0"}
                    draggable={false}
                  />
                ) : (
                  <Image
                    src={VerifiedIcon}
                    alt={"Verified"}
                    height={20}
                    width={20}
                    className={"p-0"}
                    draggable={false}
                  />
                )}
              </Button>
            </Col>
          )}
          <Col xs={5} lg={2} className={"order-lg-first"}>
            <Dropdown>
              <DropdownToggle
                variant={"outline-light"}
                className={"btd6-panel blue-insert-round w-100"}
              >
                {sortingMethod || SortingMethod.RecentlyUpdated}
              </DropdownToggle>
              <DropdownMenu
                className={"non-main-panel bg-black btd6-panel blue-insert"}
              >
                {Object.entries(SortingMethod).map(([key, value]) => (
                  <DropdownItem
                    key={key}
                    active={sortingMethod === value}
                    onClick={() => setSortingMethod(value)}
                    className={"text-white"}
                  >
                    {value}
                  </DropdownItem>
                ))}
              </DropdownMenu>
            </Dropdown>
          </Col>
          <Col xs={4} lg={2}>
            <Dropdown>
              <DropdownToggle
                variant={"outline-light"}
                className={"btd6-panel blue-insert-round w-100"}
              >
                {topic || DefaultTopic}
              </DropdownToggle>
              <DropdownMenu
                className={"non-main-panel bg-black btd6-panel blue-insert"}
              >
                <DropdownItem
                  onClick={() => setTopic(DefaultTopic)}
                  className={"text-white"}
                  active={topic === DefaultTopic}
                >
                  Any
                </DropdownItem>
                {moddersData.topics.map((key) => (
                  <DropdownItem
                    key={key}
                    onClick={() => setTopic(key)}
                    className={"text-white"}
                    active={topic === key}
                  >
                    {key}
                  </DropdownItem>
                ))}
              </DropdownMenu>
            </Dropdown>
          </Col>
          <Col xs={3} lg={2}>
            <Dropdown>
              <DropdownToggle
                variant={"outline-light"}
                className={"btd6-panel blue-insert-round w-100"}
              >
                {oldCutoff === 0 ? "All" : `BTD6 v${oldCutoff}+`}
              </DropdownToggle>
              <DropdownMenu
                className={"non-main-panel bg-black btd6-panel blue-insert"}
              >
                {rangeRight(StoppedWorkingVersion, LatestVersion + 1).map(
                  (version) => (
                    <DropdownItem
                      key={version}
                      onClick={() => setOldCutoff(version)}
                      className={"text-white"}
                      active={oldCutoff === version}
                    >
                      {`BTD6 v${version}+`}
                    </DropdownItem>
                  )
                )}
                <DropdownItem
                  onClick={() => setOldCutoff(0)}
                  className={"text-white"}
                  active={oldCutoff === 0}
                >
                  All
                </DropdownItem>
              </DropdownMenu>
            </Dropdown>
          </Col>
        </Row>
        <MainContentMarker />
        <div
          className={
            "flex-grow-1 position-relative btd6-panel blue-insert-round overflow-hidden p-0"
          }
        >
          {mods.length === 0 && (
            <div
              className={"position-absolute top-50 start-50 translate-middle"}
            >
              <Spinner />
            </div>
          )}
          <ModHelperScrollBars
            ref={scrollbars}
            className={"position-absolute h-100"}
            autoHeightMin={"100%"}
            autoHeightMax={"100%"}
          >
            <div className={"d-flex flex-column gap-3 p-3"}>
              {filteredMods.map((mod) => (
                <ModEntry
                  key={mod.Identifier}
                  mod={mod}
                  data={moddersData}
                  selectMod={(mod) => setSelectedMod(mod.Identifier)}
                  showRelease={setRelease}
                />
              ))}
            </div>
          </ModHelperScrollBars>
        </div>
        <Collapse in={mods.length < totalCount}>
          <ProgressBar
            max={totalCount}
            now={mods.length}
            animated={true}
            className={"mt-1"}
          />
        </Collapse>
      </Container>
      <Modal
        id={"release"}
        show={!!release}
        onHide={() => setRelease(undefined)}
        dialogClassName={cx("main-panel btd6-panel blue")}
        contentClassName={cx(
          "main-panel btd6-panel blue-insert-round pb-0 shadow-none"
        )}
      >
        <Modal.Header closeButton={true} closeVariant={"white"}>
          <Modal.Title className={"luckiest-guy text-outline-black"}>
            {modDisplayName(release?.mod)} {modDisplayVersion(release?.mod)}
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>{releaseBody}</Modal.Body>
        <Modal.Footer
          className={"p-0 luckiest-guy d-flex justify-content-between"}
        >
          <Button
            variant={"outline-light"}
            className={"btd6-button red long fs-5 pb-2 text-outline-black"}
            style={{ height: 45 }}
            onClick={() => setRelease(undefined)}
          >
            Cancel
          </Button>
          <Button
            variant={"outline-light"}
            className={"btd6-button blue long fs-5 pb-2 text-outline-black"}
            style={{ height: 45 }}
            onClick={() =>
              window.open(
                `https://github.com/${release?.mod.RepoOwner}/${release?.mod.RepoName}/releases`
              )
            }
          >
            More
          </Button>
          <Button
            variant={"outline-light"}
            className={"btd6-button green long fs-5 pb-2 text-outline-black"}
            style={{ height: 45 }}
            onClick={() => {
              downloadRelease(release!);
              if (release?.mod.Dependencies) {
                setSelectedMod(release!.mod.Identifier);
              }
              setRelease(undefined);
            }}
          >
            Download
          </Button>
        </Modal.Footer>
      </Modal>
      <Modal
        id={"selectedMod"}
        show={!!selectedMod && selectedMod in modsById}
        size={"xl"}
        onHide={() => setSelectedMod("")}
        dialogClassName={cx("main-panel btd6-panel blue")}
        contentClassName={cx(
          "main-panel btd6-panel blue-insert-round pb-0 shadow-none"
        )}
      >
        <Modal.Header closeButton={true} closeVariant={"white"}>
          README.md for {modDisplayName(modsById[selectedMod])}
        </Modal.Header>
        <Modal.Body>{selectedModBody}</Modal.Body>
        {selectedModDependencies.length > 0 && (
          <Modal.Footer className={"flex-column"}>
            <div className={"fs-2 m-0"}>Dependencies</div>
            <div>
              This mod has the following dependencies. It may not function
              properly if you don't download them as well.
            </div>
            <div className={"w-100 d-flex flex-column gap-3"}>
              {selectedModDependencies.map((id) => {
                const mod = modsById[id];

                return mod ? (
                  <ModEntry mod={mod} data={moddersData} mini={true} />
                ) : (
                  <div className={"w-100 text-center"}>{id}</div>
                );
              })}
            </div>
          </Modal.Footer>
        )}
      </Modal>
    </Layout>
  );
};
