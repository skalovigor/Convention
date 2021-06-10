import React, { Component } from "react";
import { Link } from "react-router-dom";

class Conventions extends Component {
  state = {
    conventions: [],
  };

  componentDidMount() {
    fetch(process.env.REACT_APP_API_URL + "/convention/list")
      .then((response) => {
        if (response.ok) return response.json();
        throw new Error("Network response was not ok.");
      })
      .then((response) => this.setState({ conventions: response }))
      .catch((error) => this.setState({ message: error.message }));
  }


  render() {
    return (
      <>
        <section id="services" className="services section-padding">
          <div className="container">
            <div className="row">
              <div className="col-12">
                <div className="section-title-header text-center">
                  <h1
                    className="section-title wow fadeInUp"
                    data-wow-delay="0.2s"
                  >
                    Active/Future conventions
                  </h1>
                </div>
              </div>
            </div>
          </div>
        </section>
        <section id="event-slides" className="section-padding">
          {this.state.conventions.map((convention) => {
            return (
              <div key={convention.id} className="container padding-bottom-40">
                <div className="row">
                  <div className="col-12">
                    <div className="section-title-header text-center">
                      <h2
                        className="intro-title wow fadeInUp"
                        data-wow-delay="0.2s"
                      >
                        {convention.name}
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
                        src={convention.bannerUrl}
                        alt=""
                      />
                    </div>
                  </div>
                  <div
                    className="col-md-6 col-lg-6 col-xs-12 wow fadeInLeft"
                    data-wow-delay="0.3s"
                  >
                    <p className="intro-desc">{convention.information}</p>
                    <h2 className="intro-title">Info:</h2>
                    <ul className="list-specification">
                      <li>
                        <i className="lni-check-mark-circle"></i> {convention.address}
                      </li>
                      <li>
                        <i className="lni-check-mark-circle"></i>
                         {convention.startDateFormatted} - {convention.endDateFormatted}
                      </li>
                    </ul>
                    <p> <Link to={"/convention/" + convention.id}>Read more</Link></p>

                  </div>
                 

                </div>
              </div>
            );
          })}
        </section>
      </>
    );
  }
}

export default Conventions;
