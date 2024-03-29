import React, { Component } from "react";
import { Route } from "react-router-dom";
import Home from "./Home";
import Profile from "./Profile";
import Nav from "./Nav";
import Auth from "./Auth/Auth";
import Callback from "./Callback";
import Private from "./Private";
import Conventions from "./Conventions/Conventions";
import ConventionCreate from "./Conventions/ConventionCreate";
import ConventionDetails from "./Conventions/ConventionDetails";
import SpeakerCreate from "./Speaker/SpeakerCreate";
import PrivateRoute from "./PrivateRoute";
import AuthContext from "./AuthContext";
import Footer from "./Footer";

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      auth: new Auth(this.props.history),
      tokenRenewalComplete: false
    };
  }

  componentDidMount() {
    this.state.auth.renewToken(() =>
      this.setState({ tokenRenewalComplete: true })
    );
  }

  render() {
    const { auth } = this.state;
    // Show loading message until the token renewal check is completed.
    if (!this.state.tokenRenewalComplete) return "Loading...";
    return (
      <AuthContext.Provider value={auth}>
        <Route render={ props => (<Nav auth={auth} { ...props } />) } />
        <div className="body">
          <Route
            path="/"
            exact
            render={props => <Home auth={auth} {...props} />}
          />
          <Route
            path="/callback"
            render={props => <Callback auth={auth} {...props} />}
          />
          <Route
            path="/conventions"
            render={props => <Conventions {...props} />}
          />
          <PrivateRoute path="/convention-create" component={ConventionCreate} />
          <PrivateRoute path="/speaker-signup" component={SpeakerCreate} />
          <Route
            path="/convention/:conventionId"
            render={props => <ConventionDetails auth={auth} {...props} />}
          />
          <PrivateRoute path="/profile" component={Profile} />
          <PrivateRoute path="/private" component={Private} />
          <Footer/>
        </div>
      </AuthContext.Provider>
    );
  }
}

export default App;
