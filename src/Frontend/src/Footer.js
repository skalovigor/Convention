import React, { Component } from 'react';

class Footer extends Component {
    render() {
        return (
            <>
            <footer className="footer-area section-padding">
            <div className="container">
              <div className="row">
                <div className="col-md-6 col-lg-3 col-sm-6 col-xs-12 wow fadeInUp" data-wow-delay="0.2s">
                  <p>
                    Aorem ipsum dolor sit amet elit sed lum tempor incididunt ut labore el dolore alg minim veniam quis nostrud ncididunt.
                  </p>
                </div>
                <div className="col-md-6 col-lg-3 col-sm-6 col-xs-12 wow fadeInUp" data-wow-delay="0.4s">
                  <h3>QUICK LINKS</h3>
                  <ul>
                    <li><a href="#">About Conference</a></li>
                    <li><a href="#">Our Speakers</a></li>
                    <li><a href="#">Event Shedule</a></li>
                    <li><a href="#">Latest News</a></li>
                    <li><a href="#">Events Photo Gallery</a></li>
                  </ul>
                </div>
                <div className="col-md-6 col-lg-3 col-sm-6 col-xs-12 wow fadeInUp" data-wow-delay="0.6s">
                  <h3>RECENT POSTS</h3>
                  <ul className="image-list">
                    <li>
                      <figure className="overlay">
                        <img className="img-fluid" src="assets/img/art/a1.jpg" alt=""/>
                      </figure>
                      <div className="post-content">
                        <h6 className="post-title"> <a href="blog-single.html">Lorem ipsm dolor sumit.</a> </h6>
                        <div className="meta"><span className="date">October 12, 2018</span></div>
                      </div>
                    </li>
                    <li>
                      <figure className="overlay">
                        <img className="img-fluid" src="assets/img/art/a2.jpg" alt=""/>
                      </figure>
                      <div className="post-content">
                        <h6 className="post-title"><a href="blog-single.html">Lorem ipsm dolor sumit.</a></h6>
                        <div className="meta"><span className="date">October 12, 2018</span></div>
                      </div>
                    </li>
                  </ul>
                </div>
                <div className="col-md-6 col-lg-3 col-sm-6 col-xs-12 wow fadeInUp" data-wow-delay="0.8s">
                  <div className="widget">
                    <h5 className="widget-title">FOLLOW US ON</h5>
                    <ul className="footer-social">
                      <li><a className="facebook" href="#"><i className="lni-facebook-filled"></i></a></li>
                      <li><a className="twitter" href="#"><i className="lni-twitter-filled"></i></a></li>
                      <li><a className="linkedin" href="#"><i className="lni-linkedin-filled"></i></a></li>
                      <li><a className="google-plus" href="#"><i className="lni-google-plus"></i></a></li>
                    </ul>
                  </div>
                </div>
              </div>
            </div>
          </footer>
          <div id="copyright">
            <div className="container">
              <div className="row">
                <div className="col-md-12">
                  <div className="site-info">
                    <p>© Designed and Developed by Ihor!</p>
                  </div>      
                </div>
              </div>
            </div>
          </div>
          </>
        );
    }
}

export default Footer;