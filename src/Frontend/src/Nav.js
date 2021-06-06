import React, { Component } from "react";
import { Link } from "react-router-dom";

class Nav extends Component {
  render() {
    const { isAuthenticated, login, logout, userHasScopes } = this.props.auth;
    const { pathname } = this.props.location;
    return (
      <header id="header-wrap">
        <nav className="navbar navbar-expand-lg fixed-top scrolling-navbar">
          <div className="container">
            <div className="collapse navbar-collapse" id="main-navbar">
              <ul className="navbar-nav">
                <li className="nav-item active">
                  <Link className="nav-link" to="/">
                    Home
                  </Link>
                </li>
                <li className="nav-item">
                  <Link className="nav-link" to="/profile">
                    My profile
                  </Link>
                </li>
                <li className="nav-item">
                  <Link className="nav-link" to="/conventions">
                    Convenions
                  </Link>
                </li>
                <li className="nav-item">
                  <a className="nav-link" href="#schedules">
                    schedules
                  </a>
                </li>
                <li className="nav-item">
                  <a className="nav-link" href="#team">
                    Speakers
                  </a>
                </li>
                <li className="nav-item">
                  <a className="nav-link" href="#gallery">
                    Gallery
                  </a>
                </li>
                <li className="nav-item">
                  <a className="nav-link" href="#pricing">
                    pricing
                  </a>
                </li>
                <li>
                  <Link
                    className="nav-link"
                    role="button"
                    to="/"
                    onClick={isAuthenticated() ? logout : login}
                  >
                    {" "}
                    {isAuthenticated() ? "Log Out" : "Log In"}
                  </Link>
                </li>
                {isAuthenticated() &&
            userHasScopes(["manage:convention"]) && (
              <li>
                 <Link className="nav-link" to="/convention/create">
                    Manage
                  </Link>
              </li>
            )}
              </ul>
            </div>
          </div>
        </nav>
        <Banner path={pathname} />
      </header>
    );
  }
}

function Banner(path) {
  console.log(path);
  if (path.path === "/home" || path.path === "/") {
    return <div></div>;
  }
  return (
    <div id="main-slide">
      <div className="carousel-inner">
        <div className="carousel-item active">
          <img
            className="d-block w-100"
            src="/assets/img/slider/small-banner.png"
            alt="First slide"
          />
        </div>
      </div>
    </div>
  );
}

export default Nav;
