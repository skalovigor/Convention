import React, { Component } from "react";


const initialState = { 
  name: '',
  description: '',
  date: undefined,
  startTime: undefined,
  amountOfSeats:undefined,
  endTime: undefined};

class TalkCreate extends Component {

    constructor(props) {
        super(props);
        this.props = props;
        this.state = initialState;
      }

      handleChange = (event) => {
        this.setState({[event.target.name]: event.target.value});
      }

      handleSubmit = (event) => {
        const conventionId = this.props.match.params.conventionId;
        var props = this.props;
        fetch(process.env.REACT_APP_API_URL + "/convention/"+conventionId+"/talk", {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${this.props.auth.getAccessToken()}` },
            // We convert the React state to JSON and send it as the POST body
            body: JSON.stringify(this.state)
          }).then(function(response) {
            console.log(response);
            if (response.ok){
                alert('Administrator will review you request!');
                props.history.push("/conventions");
                return "ok";
            } 
            throw new Error(response);
          })
          .catch(
            error => alert("Error, please check your data! " + error));;
    
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
                  Propose a talk
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
                    method="post"
                    id="contactForm"
                    name="contact-form"
                    onSubmit={this.handleSubmit}
                    data-toggle="validator"
                  >
                    <div className="col-md-12 form-line">
                      <div className="form-group">
                        <input
                          type="tel"
                          className="form-control"
                          id="name"
                          name="name"
                          value={this.state.name}
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
                        <textarea
                          className="form-control"
                          id="description"
                          name="description"
                          placeholder="Description"
                          value={this.state.description}
                          onChange={this.handleChange}
                          required
                          data-error="Please enter description"
                        />
                        <div className="help-block with-errors"></div>
                      </div>
                    </div>
                    <div className="col-md-12 form-line">
                      <div className="form-group">
                        <input
                          className="form-control"
                          rows="4"
                          type="date"
                          id="date"
                          name="date"
                          value={this.state.date}
                          onChange={this.handleChange}
                          placeholder="Date"
                          required
                          data-error="Date"
                        />
                      </div>
                    </div>
                    <div className="col-md-12 form-line">
                      <div className="form-group">
                        <input
                          className="form-control"
                          rows="4"
                          type="time"
                          id="startTime"
                          name="startTime"
                          value={this.state.startTime}
                          onChange={this.handleChange}
                          placeholder="Start time"
                          required
                          data-error="Start time"
                        />
                      </div>
                    </div>
                    <div className="col-md-12 form-line">
                      <div className="form-group">
                        <input
                          className="form-control"
                          rows="4"
                          type="time"
                          id="endTime"
                          name="endTime"
                          value={this.state.endTime}
                          onChange={this.handleChange}
                          placeholder="End time"
                          required
                          data-error="End time"
                        />
                      </div>
                    </div>
                    <div className="col-md-12 form-line">
                      <div className="form-group">
                        <input
                          className="form-control"
                          rows="4"
                          type="number"
                          id="amountOfSeats"
                          name="amountOfSeats"
                          value={this.state.amountOfSeats}
                          onChange={this.handleChange}
                          placeholder="Amount of seats"
                          required
                          data-error="Amount of seats is required"
                        />
                      </div>
                    </div>
                    <div className="col-md-12">
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
                          Propose a talk
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

export default TalkCreate;
