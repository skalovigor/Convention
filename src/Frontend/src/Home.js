import React, { Component } from "react";

class Home extends Component {
  render() {
    const { isAuthenticated, login } = this.props.auth;
    return (
      <>
      <div id="main-slide">
        <div className="carousel-inner">
          <div className="carousel-item active">
            <img className="d-block w-100" src="assets/img/slider/slide1.jpg" alt="First slide"/>
            <div className="carousel-caption d-md-block">
              <p className="fadeInUp wow" data-wow-delay=".6s">You will find what is interesting for you</p>
              <h1 className="wow fadeInDown heading" data-wow-delay=".4s">The best conventions ever!!</h1>
              <a href="#" className="fadeInLeft wow btn btn-common btn-lg" data-wow-delay=".6s">See conventions</a>
            </div>
          </div>
        </div>
      </div>
      <section id="services" className="services section-padding">
      <div className="container">
        <div className="row">
          <div className="col-12">
            <div className="section-title-header text-center">
              <h1 className="section-title wow fadeInUp" data-wow-delay="0.2s">Why You Choose Us?</h1>
              <p className="wow fadeInDown" data-wow-delay="0.2s">Global Grand Event on Digital Design</p>
            </div>
          </div>
        </div>
        <div className="row services-wrapper">
          <div className="col-md-6 col-lg-4 col-xs-12 padding-none">
            <div className="services-item wow fadeInDown" data-wow-delay="0.2s">
              <div className="icon">
                <i className="lni-heart"></i>
              </div>
              <div className="services-content">
                <h3><a href="#">Get Inspired</a></h3>
                <p>Lorem ipsum dolor sit amet, consectetuer commodo ligula eget dolor.</p>
              </div>
            </div>
          </div>
          <div className="col-md-6 col-lg-4 col-xs-12 padding-none">
            <div className="services-item wow fadeInDown" data-wow-delay="0.4s">
              <div className="icon">
                <i className="lni-gallery"></i>
              </div>
              <div className="services-content">
                <h3><a href="#">Meet New Faces</a></h3>
                <p>Lorem ipsum dolor sit amet, consectetuer commodo ligula eget dolor.</p>
              </div>
            </div>
          </div>
          <div className="col-md-6 col-lg-4 col-xs-12 padding-none">
            <div className="services-item wow fadeInDown" data-wow-delay="0.6s">
              <div className="icon">
                <i className="lni-envelope"></i>
              </div>
              <div className="services-content">
                <h3><a href="#">Fresh Tech Insights</a></h3>
                <p>Lorem ipsum dolor sit amet, consectetuer commodo ligula eget dolor.</p>
              </div>
            </div>
          </div>
          <div className="col-md-6 col-lg-4 col-xs-12 padding-none">
            <div className="services-item wow fadeInDown" data-wow-delay="0.8s">
              <div className="icon">
                <i className="lni-cup"></i>
              </div>
              <div className="services-content">
                <h3><a href="#">Networking Session</a></h3>
                <p>Lorem ipsum dolor sit amet, consectetuer commodo ligula eget dolor.</p>
              </div>
            </div>
          </div>
          <div className="col-md-6 col-lg-4 col-xs-12 padding-none">
            <div className="services-item wow fadeInDown" data-wow-delay="1s">
              <div className="icon">
                <i className="lni-user"></i>
              </div>
              <div className="services-content">
                <h3><a href="#">Global Event</a></h3>
                <p>Lorem ipsum dolor sit amet, consectetuer commodo ligula eget dolor.</p>
              </div>
            </div>
          </div>
          <div className="col-md-6 col-lg-4 col-xs-12 padding-none">
            <div className="services-item wow fadeInDown" data-wow-delay="1.2s">
              <div className="icon">
                <i className="lni-bubble"></i>
              </div>
              <div className="services-content">
                <h3><a href="#">Free Swags</a></h3>
                <p>Lorem ipsum dolor sit amet, consectetuer commodo ligula eget dolor.</p>
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

export default Home;
