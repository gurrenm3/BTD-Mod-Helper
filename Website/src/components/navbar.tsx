import React, { FunctionComponent, ReactNode, useContext } from "react";
import {
  Button,
  Container,
  Dropdown,
  Navbar,
  NavbarBrand,
  NavItem,
  NavLink,
  NavLinkProps,
} from "react-bootstrap";
import Link, { LinkProps } from "next/link";
import Image from "next/image";
import Logo from "public/BloonsTD6 Mod Helper/Resources/ModsBtn.png";
import NavbarCollapse from "react-bootstrap/NavbarCollapse";
import { useRouter } from "next/router";
import NavbarToggle from "react-bootstrap/NavbarToggle";
import { ModHelperScrollBars, ScrollBarsContext, switchSize } from "./layout";
import { DarkModeSwitch } from "react-toggle-dark-mode";
import DropdownToggle from "react-bootstrap/DropdownToggle";
import DropdownMenu from "react-bootstrap/DropdownMenu";
import maps from "../data/maps.json";
import DropdownItem from "react-bootstrap/DropdownItem";
import { BackgroundContext } from "./background-image";
import { List } from "react-bootstrap-icons";
import cx from "classnames";
import { useUpdate } from "react-use";
import { ThemeContext } from "../pages/_app";

const ModHelperNavItem: FunctionComponent<
  Omit<NavLinkProps, "active"> & LinkProps & { path: string; active?: string }
> = ({ path, title, href, disabled, children, active, ...props }) => (
  <NavItem data-toggle="tooltip" title={title}>
    <NavLink
      as={Link}
      href={href}
      disabled={disabled}
      active={
        !disabled &&
        (href === "/" ? href === path : path.startsWith(active || href))
      }
      className={"text-outline-black fs-3 py-0"}
      {...props}
    >
      {children}
    </NavLink>
  </NavItem>
);

export const ModHelperNavBar: FunctionComponent<{
  className?: string;
}> = ({ className }) => {
  const router = useRouter();
  const path = router?.asPath ?? "";

  const { theme, refreshTheme } = useContext(ThemeContext);

  return (
    <Container
      fluid={switchSize}
      className={cx("p-0", `my-${switchSize}-4`, className)}
    >
      <Navbar
        variant={"dark"}
        expand={"md"}
        className={"luckiest-guy d-flex main-panel btd6-panel blue"}
      >
        <NavbarBrand
          href={(process.env.NEXT_PUBLIC_BASE_PATH ?? "") + "/"}
          className={"py-0"}
        >
          <Image
            src={Logo}
            alt={"Mod Helper logo"}
            width={50}
            height={50}
            loading={"eager"}
            priority={true}
          />
        </NavbarBrand>
        <NavbarBrand
          href={(process.env.NEXT_PUBLIC_BASE_PATH ?? "") + "/"}
          className={"text-outline-black text-white fs-3 py-0 me-auto"}
        >
          BTD Mod Helper
        </NavbarBrand>
        <div className={"ms-auto me-4"}>
          <DarkModeSwitch
            className={"dark-mode-switch"}
            checked={theme === "dark"}
            sunColor={"rgba(255,255,255,.75)"}
            moonColor={"rgba(255,255,255,.75)"}
            onChange={() => {
              const newTheme = theme === "dark" ? "light" : "dark";
              localStorage.setItem("theme", newTheme);
              document.documentElement.setAttribute("data-theme", newTheme);
              refreshTheme();
            }}
            size={"2rem"}
            style={{ userSelect: "none" }}
          />
        </div>
        <NavbarToggle label={"toggle"} className={"btd6-button blue p-2"}>
          <List size={"2rem"} className={"text-white"} />
        </NavbarToggle>
        <NavbarCollapse className={"flex-grow-0"}>
          <div className={"navbar-nav ms-auto text-center"}>
            <ModHelperNavItem path={path} href={"/"}>
              Home
            </ModHelperNavItem>
            <ModHelperNavItem path={path} href={"/wiki/Home"} active={"/wiki"}>
              Wiki
            </ModHelperNavItem>
            <ModHelperNavItem
              path={path}
              href={"/docs/README"}
              active={"/docs"}
            >
              Docs
            </ModHelperNavItem>
            {/*<ModHelperNavItem path={path} href={""} disabled={true}>
              Download
            </ModHelperNavItem>*/}
            <ModHelperNavItem path={path} href={"/mod-browser"}>
              Mod Browser
            </ModHelperNavItem>
          </div>
        </NavbarCollapse>
      </Navbar>
    </Container>
  );
};

export const ModHelperFooter: FunctionComponent<{
  buttonName?: string;
  buttonOnClick?: () => void;
  className?: string;
  body?: ReactNode;
}> = ({ buttonName, buttonOnClick, className, body }) => {
  const scrollbars = useContext(ScrollBarsContext);
  const [map, setMap] = useContext(BackgroundContext);

  return (
    <Container
      fluid={switchSize}
      className={cx(
        "main-panel btd6-panel blue",
        `my-${switchSize}-4`,
        "d-flex justify-content-between align-items-center",
        className
      )}
    >
      <Button
        variant={"outline-light"}
        onClick={() => {
          if (buttonOnClick) {
            buttonOnClick();
          } else {
            scrollbars?.scrollTop(0);
          }
        }}
        className={"btd6-button blue long align-self-stretch p-3 text-white"}
      >
        {buttonName || "Back to Top"}
      </Button>
      <div className={`text-center d-none d-sm-block fs-larger`}>
        {body || (
          <>
            To learn how to download BTD Mod Helper and install mods,{" "}
            <Link href={"/wiki/Install-Guide#main-content"}>click here</Link>
          </>
        )}
      </div>
      <Dropdown drop={"up"} align={"end"} className={"text-end"}>
        <DropdownToggle
          className={"btd6-panel blue-insert-round"}
          variant={"outline-light"}
        >
          Background
        </DropdownToggle>
        <DropdownMenu
          className={"non-main-panel bg-black btd6-panel blue-insert pe-0"}
        >
          <ModHelperScrollBars>
            {Object.keys(maps).map((key) => (
              <DropdownItem
                key={key}
                active={key === map}
                className={"p-0 me-3 w-auto text-white"}
                onClick={() => setMap(key)}
              >
                {maps[key]}
              </DropdownItem>
            ))}
          </ModHelperScrollBars>
        </DropdownMenu>
      </Dropdown>
    </Container>
  );
};
