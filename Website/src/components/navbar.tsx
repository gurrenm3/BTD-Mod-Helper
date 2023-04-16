import React, { ComponentPropsWithoutRef, FunctionComponent } from "react";
import {
  Container,
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
import { switchSize } from "./layout";

const ModHelperNavItem: FunctionComponent<
  NavLinkProps & LinkProps & { path: string }
> = ({ path, title, href, disabled, children, ...props }) => (
  <NavItem data-toggle="tooltip" title={title}>
    <NavLink
      as={Link}
      href={href}
      disabled={disabled}
      active={
        !disabled && (href === "/" ? href === path : path.startsWith(href))
      }
      className={"text-outline-black fs-3 py-0"}
      {...props}
    >
      {children}
    </NavLink>
  </NavItem>
);

export const ModHelperNavBar: FunctionComponent = () => {
  const router = useRouter();
  const path = router?.asPath ?? "";

  return (
    <Container
      fluid={switchSize}
      className={`p-2 my-${switchSize}-4 main-black-panel`}
    >
      <Navbar variant={"dark"} expand={"md"} className={"luckiest-guy p-0"}>
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
          />
        </NavbarBrand>
        <NavbarBrand
          href={(process.env.NEXT_PUBLIC_BASE_PATH ?? "") + "/"}
          className={"text-outline-black text-white fs-3 py-0 me-auto"}
        >
          BTD Mod Helper
        </NavbarBrand>
        <NavbarToggle label={"toggle"}>
          <span className="navbar-toggler-icon" />
        </NavbarToggle>
        <NavbarCollapse>
          <div className={"navbar-nav ms-auto text-center"}>
            <ModHelperNavItem path={path} href={"/"}>
              Home
            </ModHelperNavItem>
            <ModHelperNavItem path={path} href={"/wiki"}>
              Wiki
            </ModHelperNavItem>
            <ModHelperNavItem path={path} href={"/docs"}>
              Docs
            </ModHelperNavItem>
            {/*<ModHelperNavItem path={path} href={""} disabled={true}>
              Download
            </ModHelperNavItem>*/}
            <ModHelperNavItem
              path={path}
              href={""}
              disabled={true}
              title={"Coming Soon!"}
            >
              Mod Browser
            </ModHelperNavItem>
          </div>
        </NavbarCollapse>
      </Navbar>
    </Container>
  );
};
