import React, { Component } from "react";

class ConventionDetails extends Component {
  state = {
    convention: {},
  };

  componentDidMount() {
    const conventionId = this.props.match.params.conventionId;

    fetch(process.env.REACT_APP_API_URL + "/convention/" + conventionId)
      .then((response) => {
        if (response.ok) return response.json();
        throw new Error("Network response was not ok.");
      })
      .then((response) => this.setState({ convention: response }))
      .catch((error) => this.setState({ message: error.message }));
  }

  render() {
    return (
      <>
        <section className="section-padding">
          <div className="row">
            <div className="col-12">
              <div className="section-title-header text-center">
                <h1 className="section-title wow fadeInUp" data-wow-delay="0.2s">
                  Convention Overview
                </h1>
                <p className="wow fadeInDown" data-wow-delay="0.2s">
                  Lorem ipsum dolor sit amet, consectetur adipiscing <br />{" "}
                  elit, sed do eiusmod tempor
                </p>
              </div>
            </div>
          </div>
          <div className="container padding-bottom-40">
            <div className="row">
              <div className="col-12">
                <div className="section-title-header text-center">
                  <h2
                    className="intro-title wow fadeInUp"
                    data-wow-delay="0.2s"
                  >
                    {this.state.convention.name}
                  </h2>
                </div>
              </div>
              <div
                className="col-md-6 col-lg-6 col-xs-12 wow fadeInRight"
                data-wow-delay="0.3s"
              >
                <div className="video">
                  <img
                    className="img-fluid"
                    src={this.state.convention.bannerUrl}
                    alt=""
                  />
                </div>
              </div>
              <div
                className="col-md-6 col-lg-6 col-xs-12 wow fadeInLeft"
                data-wow-delay="0.3s"
              >
                <p className="intro-desc">
                  {this.state.convention.information}
                </p>
              </div>
            </div>
          </div>
        </section>
        <section className="counter-section section-padding">
          <div className="container">
            <div className="row">
              <div className="col-md-6 col-lg-3 col-xs-12 work-counter-widget text-center">
                <div className="counter wow fadeInRight" data-wow-delay="0.3s">
                  <div className="icon">
                    <i className="lni-map"></i>
                  </div>
                  <p>Wst. Conference Center</p>
                  <span>San Francisco, CA</span>
                </div>
              </div>
              <div className="col-md-6 col-lg-3 col-xs-12 work-counter-widget text-center">
                <div className="counter wow fadeInRight" data-wow-delay="0.6s">
                  <div className="icon">
                    <i className="lni-timer"></i>
                  </div>
                  <p>February 14 - 19, 2018</p>
                  <span>09:00 AM – 05:00 PM</span>
                </div>
              </div>
              <div className="col-md-6 col-lg-3 col-xs-12 work-counter-widget text-center">
                <div className="counter wow fadeInRight" data-wow-delay="0.9s">
                  <div className="icon">
                    <i className="lni-users"></i>
                  </div>
                  <p>343 Available Seats</p>
                  <span>Hurryup! few tickets are left</span>
                </div>
              </div>
              <div className="col-md-6 col-lg-3 col-xs-12 work-counter-widget text-center">
                <div className="counter wow fadeInRight" data-wow-delay="1.2s">
                  <div className="icon">
                    <i className="lni-coffee-cup"></i>
                  </div>
                  <p>Free Lunch & Snacks</p>
                  <span>Don’t miss it</span>
                </div>
              </div>
            </div>
          </div>
        </section>
        <section id="schedules" className="schedule section-padding">
          <div className="container">
            <div className="row">
              <div className="col-12">
                <div className="section-title-header text-center">
                  <h1 className="section-title wow fadeInUp" data-wow-delay="0.2s">
                    Event Schedules
                  </h1>
                  <p className="wow fadeInDown" data-wow-delay="0.2s">
                    Lorem ipsum dolor sit amet, consectetur adipiscing <br />{" "}
                    elit, sed do eiusmod tempor
                  </p>
                </div>
              </div>
            </div>
            <div className="schedule-area row wow fadeInDown" data-wow-delay="0.3s">
              <div className="schedule-tab-title col-md-3 col-lg-3 col-xs-12">
                <div className="table-responsive">
                  <ul className="nav nav-tabs" id="myTab" role="tablist">
                    <li className="nav-item">
                      <a
                        className="nav-link active"
                        id="monday-tab"
                        data-toggle="tab"
                        href="#monday"
                        role="tab"
                        aria-controls="monday"
                        aria-expanded="true"
                      >
                        <div className="item-text">
                          <h4>Monday</h4>
                          <h5>14 February</h5>
                        </div>
                      </a>
                    </li>
                    <li className="nav-item">
                      <a
                        className="nav-link"
                        id="tuesday-tab"
                        data-toggle="tab"
                        href="#tuesday"
                        role="tab"
                        aria-controls="tuesday"
                      >
                        <div className="item-text">
                          <h4>Tuesday</h4>
                          <h5>15 February</h5>
                        </div>
                      </a>
                    </li>
                    <li className="nav-item">
                      <a
                        className="nav-link"
                        id="wednesday-tab"
                        data-toggle="tab"
                        href="#wednesday"
                        role="tab"
                        aria-controls="wednesday"
                      >
                        <div className="item-text">
                          <h4>Wednesday</h4>
                          <h5>16 February</h5>
                        </div>
                      </a>
                    </li>
                    <li className="nav-item">
                      <a
                        className="nav-link"
                        id="thursday-tab"
                        data-toggle="tab"
                        href="#thursday"
                        role="tab"
                        aria-controls="thursday"
                      >
                        <div className="item-text">
                          <h4>Thursday</h4>
                          <h5>17 February</h5>
                        </div>
                      </a>
                    </li>
                  </ul>
                </div>
              </div>
              <div className="schedule-tab-content col-md-9 col-lg-9 col-xs-12 clearfix">
                <div className="tab-content" id="myTabContent">
                  <div
                    className="tab-pane fade show active"
                    id="monday"
                    role="tabpanel"
                    aria-labelledby="monday-tab"
                  >
                    <div id="accordion">
                      <div className="card">
                        <div id="headingOne">
                          <div
                            className="collapsed card-header"
                            data-toggle="collapse"
                            data-target="#collapseOne"
                            aria-expanded="false"
                            aria-controls="collapseOne"
                          >
                            <div className="images-box">
                              <img
                                className="img-fluid"
                                src="/assets/img/speaker/speakers-1.jpg"
                                alt=""
                              />
                            </div>
                            <span className="time">10am - 12:30pm</span>
                            <h4>Web Design Principles and Best Practices</h4>
                            <h5 className="name">David Warner</h5>
                          </div>
                        </div>
                      </div>
                      <div className="card">
                        <div id="headingTwo">
                          <div
                            className="collapsed card-header"
                            data-toggle="collapse"
                            data-target="#collapseTwo"
                            aria-expanded="false"
                            aria-controls="collapseTwo"
                          >
                            <div className="images-box">
                              <img
                                className="img-fluid"
                                src="/assets/img/speaker/speakers-2.jpg"
                                alt=""
                              />
                            </div>
                            <span className="time">10am - 12:30pm</span>
                            <h4>15 Free Productive Design Tools</h4>
                            <h5 className="name">David Warner</h5>
                          </div>
                        </div>
                      </div>
                      <div className="card">
                        <div id="headingThree">
                          <div
                            className="collapsed card-header"
                            data-toggle="collapse"
                            data-target="#collapseThree"
                            aria-expanded="false"
                            aria-controls="collapseThree"
                          >
                            <div className="images-box">
                              <img
                                className="img-fluid"
                                src="/assets/img/speaker/speakers-3.jpg"
                                alt=""
                              />
                            </div>
                            <span className="time">10am - 12:30pm</span>
                            <h4>Getting Started With SketchApp</h4>
                            <h5 className="name">David Warner</h5>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div
                    className="tab-pane fade"
                    id="tuesday"
                    role="tabpanel"
                    aria-labelledby="tuesday-tab"
                  >
                    <div id="accordion2">
                      <div className="card">
                        <div id="headingOne1">
                          <div
                            className="collapsed card-header"
                            data-toggle="collapse"
                            data-target="#collapseOne1"
                            aria-expanded="false"
                            aria-controls="collapseOne1"
                          >
                            <div className="images-box">
                              <img
                                className="img-fluid"
                                src="/assets/img/speaker/speakers-1.jpg"
                                alt=""
                              />
                            </div>
                            <span className="time">10am - 12:30pm</span>
                            <h4>Web Design Principles and Best Practices</h4>
                            <h5 className="name">David Warner</h5>
                          </div>
                        </div>
                      </div>
                      <div className="card">
                        <div id="headingTwo2">
                          <div
                            className="collapsed card-header"
                            data-toggle="collapse"
                            data-target="#collapseTwo2"
                            aria-expanded="false"
                            aria-controls="collapseTwo2"
                          >
                            <div className="images-box">
                              <img
                                className="img-fluid"
                                src="/assets/img/speaker/speakers-2.jpg"
                                alt=""
                              />
                            </div>
                            <span className="time">10am - 12:30pm</span>
                            <h4>Web Design Principles and Best Practices</h4>
                            <h5 className="name">David Warner</h5>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div
                    className="tab-pane fade"
                    id="wednesday"
                    role="tabpanel"
                    aria-labelledby="wednesday-tab"
                  >
                    <div id="accordion3">
                      <div className="card">
                        <div id="headingOne3">
                          <div
                            className="collapsed card-header"
                            data-toggle="collapse"
                            data-target="#collapseOne3"
                            aria-expanded="false"
                            aria-controls="collapseOne3"
                          >
                            <div className="images-box">
                              <img
                                className="img-fluid"
                                src="/assets/img/speaker/speakers-1.jpg"
                                alt=""
                              />
                            </div>
                            <span className="time">10am - 12:30pm</span>
                            <h4>Web Design Principles and Best Practices</h4>
                            <h5 className="name">David Warner</h5>
                          </div>
                        </div>
                      </div>
                      <div className="card">
                        <div id="headingTwo3">
                          <div
                            className="collapsed card-header"
                            data-toggle="collapse"
                            data-target="#collapseTwo3"
                            aria-expanded="false"
                            aria-controls="collapseTwo3"
                          >
                            <div className="images-box">
                              <img
                                className="img-fluid"
                                src="/assets/img/speaker/speakers-2.jpg"
                                alt=""
                              />
                            </div>
                            <span className="time">10am - 12:30pm</span>
                            <h4>Web Design Principles and Best Practices</h4>
                            <h5 className="name">David Warner</h5>
                          </div>
                        </div>
                      </div>
                      <div className="card">
                        <div id="headingThree3">
                          <div
                            className="collapsed card-header"
                            data-toggle="collapse"
                            data-target="#collapseThree3"
                            aria-expanded="false"
                            aria-controls="collapseThree3"
                          >
                            <div className="images-box">
                              <img
                                className="img-fluid"
                                src="/assets/img/speaker/speakers-3.jpg"
                                alt=""
                              />
                            </div>
                            <span className="time">10am - 12:30pm</span>
                            <h4>Web Design Principles and Best Practices</h4>
                            <h5 className="name">David Warner</h5>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div
                    className="tab-pane fade"
                    id="thursday"
                    role="tabpanel"
                    aria-labelledby="thursday-tab"
                  >
                    <div id="accordion4">
                      <div className="card">
                        <div id="headingOne">
                          <div
                            className="collapsed card-header"
                            data-toggle="collapse"
                            data-target="#collapseOne4"
                            aria-expanded="false"
                            aria-controls="collapseOne4"
                          >
                            <div className="images-box">
                              <img
                                className="img-fluid"
                                src="/assets/img/speaker/speakers-1.jpg"
                                alt=""
                              />
                            </div>
                            <span className="time">10am - 12:30pm</span>
                            <h4>Web Design Principles and Best Practices</h4>
                            <h5 className="name">David Warner</h5>
                          </div>
                        </div>
                      </div>
                      <div className="card">
                        <div id="headingTwo">
                          <div
                            className="collapsed card-header"
                            data-toggle="collapse"
                            data-target="#collapseTwo4"
                            aria-expanded="false"
                            aria-controls="collapseTwo4"
                          >
                            <div className="images-box">
                              <img
                                className="img-fluid"
                                src="/assets/img/speaker/speakers-2.jpg"
                                alt=""
                              />
                            </div>
                            <span className="time">10am - 12:30pm</span>
                            <h4>Web Design Principles and Best Practices</h4>
                            <h5 className="name">David Warner</h5>
                          </div>
                        </div>
                      </div>
                      <div className="card">
                        <div id="headingThree4">
                          <div
                            className="collapsed card-header"
                            data-toggle="collapse"
                            data-target="#collapseThree4"
                            aria-expanded="false"
                            aria-controls="collapseThree4"
                          >
                            <div className="images-box">
                              <img
                                className="img-fluid"
                                src="/assets/img/speaker/speakers-3.jpg"
                                alt=""
                              />
                            </div>
                            <span className="time">10am - 12:30pm</span>
                            <h4>Web Design Principles and Best Practices</h4>
                            <h5 className="name">David Warner</h5>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div
                    className="tab-pane fade"
                    id="friday"
                    role="tabpanel"
                    aria-labelledby="friday-tab"
                  >
                    <div id="accordion">
                      <div className="card">
                        <div id="headingOne">
                          <div
                            className="collapsed card-header"
                            data-toggle="collapse"
                            data-target="#collapseOne"
                            aria-expanded="false"
                            aria-controls="collapseOne"
                          >
                            <div className="images-box">
                              <img
                                className="img-fluid"
                                src="/assets/img/speaker/speakers-1.jpg"
                                alt=""
                              />
                            </div>
                            <span className="time">10am - 12:30pm</span>
                            <h4>Web Design Principles and Best Practices</h4>
                            <h5 className="name">David Warner</h5>
                          </div>
                        </div>
                      </div>
                      <div className="card">
                        <div id="headingTwo">
                          <div
                            className="collapsed card-header"
                            data-toggle="collapse"
                            data-target="#collapseTwo"
                            aria-expanded="false"
                            aria-controls="collapseTwo"
                          >
                            <div className="images-box">
                              <img
                                className="img-fluid"
                                src="/assets/img/speaker/speakers-2.jpg"
                                alt=""
                              />
                            </div>
                            <span className="time">10am - 12:30pm</span>
                            <h4>Web Design Principles and Best Practices</h4>
                            <h5 className="name">David Warner</h5>
                          </div>
                        </div>
                      </div>
                      <div className="card">
                        <div id="headingThree">
                          <div
                            className="collapsed card-header"
                            data-toggle="collapse"
                            data-target="#collapseThree"
                            aria-expanded="false"
                            aria-controls="collapseThree"
                          >
                            <div className="images-box">
                              <img
                                className="img-fluid"
                                src="/assets/img/speaker/speakers-3.jpg"
                                alt=""
                              />
                            </div>
                            <span className="time">10am - 12:30pm</span>
                            <h4>Web Design Principles and Best Practices</h4>
                            <h5 className="name">David Warner</h5>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </section>
      </>
    );
  }
}

export default ConventionDetails;
