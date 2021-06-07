import React, { Component } from "react";
import TalkCreate from "./../Talks/TalkCreate";
import dateFormat from "dateformat";

class ConventionDetails extends Component {
  state = {
    convention: {},
    talks: [],
    speakers: [],
    days: [],
  };

  componentDidMount() {
    const conventionId = this.props.match.params.conventionId;

    //TODO: shoudl be created ome service for such calls and one place for error message handling
    Promise.all([
      fetch(process.env.REACT_APP_API_URL + "/convention/" + conventionId).then(
        (res) => res.json()
      ),
      fetch(
        process.env.REACT_APP_API_URL + "/convention/" + conventionId + "/talks"
      ).then((res) => res.json()),
      fetch(
        process.env.REACT_APP_API_URL +
          "/convention/" +
          conventionId +
          "/speakers"
      ).then((res) => res.json()),
    ]).then(([convention, talks, speakers]) => {
      var uniqueDates = [];
      talks.map((talk) => {
        if (uniqueDates.indexOf(talk.date) === -1) {
          uniqueDates.push(talk.date);
        }
      });
      this.setState({
        convention: convention,
        talks: talks,
        speakers: speakers,
        days: uniqueDates,
      });
    });
  }

  render() {
    return (
      <>
        <section className="section-padding">
          <div className="row">
            <div className="col-12">
              <div className="section-title-header text-center">
                <h1
                  className="section-title wow fadeInUp"
                  data-wow-delay="0.2s"
                >
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
       
        <section id="schedules" className="schedule section-padding">
          <div className="container">
            <div className="row">
              <div className="col-12">
                <div className="section-title-header text-center">
                  <h1
                    className="section-title wow fadeInUp"
                    data-wow-delay="0.2s"
                  >
                    Event Schedules
                  </h1>
                  <p className="wow fadeInDown" data-wow-delay="0.2s">
                    Lorem ipsum dolor sit amet, consectetur adipiscing <br />{" "}
                    elit, sed do eiusmod tempor
                  </p>
                </div>
              </div>
            </div>
          </div>
        </section>
        {this.state.days.map((date) => {
          return (
            <section key={date} className="schedule section-padding">
              <div className="container">
                <div
                  className="schedule-area row wow fadeInDown"
                  data-wow-delay="0.3s"
                >
                  <div className="schedule-tab-title col-md-3 col-lg-3 col-xs-12">
                    <div className="table-responsive">
                      <ul className="nav nav-tabs" id="myTab" role="tablist">
                        <li className="nav-item">
                        
                            <div className="item-text">
                              <h4>{dateFormat(date, "dddd")}</h4>
                              <h5>{dateFormat(date, "dd mmmm")}</h5>
                            </div>
                        </li>
                      </ul>
                    </div>
                  </div>
                  <div className="schedule-tab-content col-md-9 col-lg-9 col-xs-12">
                    <div className="tab-content" id="myTabContent">
                      <div>
                        <div>
                          {this.state.talks.filter(f=> f.date == date).map((talk) => {
                            var speaker = this.state.speakers.filter(f=> f.id == talk.speakerId)[0];
                            return (
                              <div className="card" key={talk.id}>
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
                                        src={speaker.profileUrl}
                                        alt=""
                                      />
                                    </div>
                                    <span className="time">{talk.startTime.hours}:{talk.startTime.minutes} - {talk.endTime.hours}:{talk.endTime.hours}</span>
                                    <h4>{talk.name}</h4>
                                    <h5 className="name"> {speaker.name}</h5>
                                  </div>
                                </div>
                              </div>
                            );
                          })}
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </section>
          );
        })}
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
        <TalkCreate {...this.props} />;
      </>
    );
  }
}

export default ConventionDetails;
