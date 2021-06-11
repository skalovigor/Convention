import React, { Component } from 'react';

class SpeakerCreate extends Component {
    constructor(props) {
        super(props);
        const { isAuthenticated, userHasScopes } = this.props.auth;
        this.props = props;
        this.state = { 
            name: '',
            profileUrl: '',
            position: ''};
      }

      handleChange = (event) => {
        this.setState({[event.target.name]: event.target.value});
      }

      handleSubmit = (event) => {
        var props = this.props;
        fetch(process.env.REACT_APP_API_URL + "/speaker/create", {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${this.props.auth.getAccessToken()}` },
            // We convert the React state to JSON and send it as the POST body
            body: JSON.stringify(this.state)
          }).then(function(response) {
            console.log(response);
            if (response.ok){
              alert("Administrators will review your request!")
              props.history.push("/conventions");
              return;
            } 
            throw new Error(response);
          })
          .catch(error => alert("Error, please check your data!"));;
    
        event.preventDefault();
    }

    render() {
        return (
            <section id="contact-map" className="section-padding">
        <div className="container">
          <div className="row justify-content-center">
            <div className="col-12">
              <div className="section-title-header text-center">
                <h1
                  className="section-title wow fadeInUp"
                  data-wow-delay="0.2s"
                >
                  New convention
                </h1>
              </div>
            </div>
            <div className="col-lg-7 col-md-12 col-xs-12">
              <div
                className="container-form wow fadeInLeft"
                data-wow-delay="0.2s"
              >
                <div className="form-wrapper">
                  <form
                    role="form"
                    method="post"
                    id="contactForm"
                    name="contact-form"
                    onSubmit={this.handleSubmit}
                    data-toggle="validator">
                    <div className="col-md-12 form-line">
                        <div className="form-group">
                          <input
                            type="tel"
                            className="form-control"
                            id="name"
                            name="name"
                            value={this.state.value}
                            onChange={this.handleChange}
                            placeholder="Name"
                            required
                            data-error="Please enter name"
                          />
                          <div className="help-block with-errors"></div>
                        </div>
                      </div>
                      <div className="col-md-12 form-line">
                        <div className="form-group">
                          <input
                            className="form-control"
                            id="profileUrl"
                            name="profileUrl"
                            placeholder="Profile url"
                            value={this.state.value}
                            onChange={this.handleChange}
                            required
                            data-error="Please enter profile url"
                          />
                          <div className="help-block with-errors"></div>
                        </div>
                      </div>
                      <div className="col-md-12">
                        <div className="form-group">
                          <input
                            className="form-control"
                            rows="4"
                            id="position"
                            name="position"
                            value={this.state.value}
                            onChange={this.handleChange}
                            placeholder="Position"
                            required
                            data-error="Position"
                          />
                        </div>
                        <div className="form-submit">
                          <button
                            type="submit"
                            className="btn btn-common"
                            id="form-submit"
                          >
                            <i
                              className="fa fa-paper-plane"
                              aria-hidden="true"
                            ></i>{" "}
                            Sign up
                          </button>
                          <div
                            id="msgSubmit"
                            className="h3 text-center hidden"
                          ></div>
                        </div>
                      </div>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
        );
    }
}

export default SpeakerCreate;