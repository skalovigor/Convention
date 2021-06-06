import React, { Component } from "react";

class ConventionCreate extends Component {
    
    constructor(props) {
        super(props);
        this.props = props;
        this.state = { 
            name: '',
            startDate: new Date(),
            endDate: new Date(),
            bannerUrl: '',
            information: '',
            address: ''};
      }

      handleChange = (event) => {
        this.setState({[event.target.name]: event.target.value});
      }

      handleSubmit = (event) => {
        var props = this.props;
        fetch(process.env.REACT_APP_API_URL + "/convention", {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${this.props.auth.getAccessToken()}` },
            // We convert the React state to JSON and send it as the POST body
            body: JSON.stringify(this.state)
          }).then(function(response) {
            console.log(response);
            if (response.ok){
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
                            placeholder="Subject"
                            required
                            data-error="Please enter subject"
                          />
                          <div className="help-block with-errors"></div>
                        </div>
                      </div>
                      <div className="col-md-12 form-line">
                        <div className="form-group">
                          <input
                            type="date"
                            className="form-control"
                            id="startDate"
                            name="startDate"
                            placeholder="Start date"
                            value={this.state.value}
                            onChange={this.handleChange}
                            required
                            data-error="Please enter date"
                          />
                          <div className="help-block with-errors"></div>
                        </div>
                      </div>
                      <div className="col-md-12 form-line">
                        <div className="form-group">
                          <input
                            type="date"
                            className="form-control"
                            id="endDate"
                            name="endDate"
                            placeholder="End date"
                            value={this.state.value}
                            onChange={this.handleChange}
                            required
                            data-error="Please enter date"
                          />
                          <div className="help-block with-errors"></div>
                        </div>
                      </div>
                      <div className="col-md-12 form-line">
                        <div className="form-group">
                          <input
                            className="form-control"
                            id="bannerUrl"
                            name="bannerUrl"
                            placeholder="Banner url"
                            value={this.state.value}
                            onChange={this.handleChange}
                            required
                            data-error="Please enter date"
                          />
                          <div className="help-block with-errors"></div>
                        </div>
                      </div>
                      <div className="col-md-12 form-line">
                        <div className="form-group">
                          <input
                            className="form-control"
                            id="address"
                            name="address"
                            placeholder="Address"
                            value={this.state.value}
                            onChange={this.handleChange}
                            required
                            data-error="Please enter address"
                          />
                          <div className="help-block with-errors"></div>
                        </div>
                      </div>
                      <div className="col-md-12">
                        <div className="form-group">
                          <textarea
                            className="form-control"
                            rows="4"
                            id="information"
                            name="information"
                            value={this.state.value}
                            onChange={this.handleChange}
                            required
                            data-error="Write your description"
                          ></textarea>
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
                            Create convention
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

export default ConventionCreate;
