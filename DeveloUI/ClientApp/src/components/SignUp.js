import React, { Component } from 'react';
import { Row, Col, FormText, Form, FormGroup, Label, Input } from 'reactstrap';

export class SignUp extends Component {
  static displayName = SignUp.name;

  constructor(props) {
      super(props);
      this.state = {
          firstName: '',
          lastName: '',
          streetAddress: '',
          unitApt: '',
          email: '',
          city: '',
          provincy: 0,
          cities: [],
          provinces: [],
      };

      this.handleInputChange = this.handleInputChange.bind(this);
      this.handleCityChange = this.handleCityChange.bind(this);
      this.handleSubmit = this.handleSubmit.bind(this);
  }

  componentDidMount() {
      const request = new Request("http://localhost:57712/api/v1/State", {
          method: "get",
          mode: 'cors',
          headers: {
             'Access-Control-Allow-Origin': '*'
          },
      });

      fetch(request)
          .then(response => response.json())
          .then(body => {
              this.setState({ provinces: body.data });
          })
          
  }

  handleInputChange(event) {
      const target = event.target;
      const value = target.value;
      const name = target.name;
      this.setState({
        [name]: value,
      });
  }

  handleCityChange(event) {
      const target = event.target;
      const value = target.value;
      this.setState({
          provincy: value,
      });

      const request = new Request(`http://localhost:57712/api/v1/City/GetAll/${value}`, {
          method: "get",
          mode: 'cors',
          headers: {
              'Access-Control-Allow-Origin': '*'
          },
      });

      fetch(request)
          .then(response => response.json())
          .then(body => {
              this.setState({ cities: body });
              console.log(this.state.cities);
          })
  }

  handleSubmit(event) {
      event.preventDefault();
      var erros = [];
      const { firstName, lastName, streetAddress, unitApt, email, provincy, city } = this.state;

      if (firstName.length > 40) {
          document.querySelector('#firstName').classList.add('is-invalid');
          document.querySelector('.firstName small').style.display = 'block';
          erros.push(1);
      } else {
          document.querySelector('#firstName').classList.remove('is-invalid');
          document.querySelector('#firstName').classList.add('is-valid');
          document.querySelector('.firstName small').style.display = 'none';
      }

      if (lastName.length > 40) {
          document.querySelector('#lastName').classList.add('is-invalid');
          document.querySelector('.lastName small').style.display = 'block';
          erros.push(1);
      } else {
          document.querySelector('#lastName').classList.remove('is-invalid');
          document.querySelector('#lastName').classList.add('is-valid');
          document.querySelector('.lastName small').style.display = 'none';
      }

      if (streetAddress.length > 128) {
          document.querySelector('#address').classList.add('is-invalid');
          document.querySelector('.address small').style.display = 'block';
          erros.push(1);
      } else {
          document.querySelector('#address').classList.remove('is-invalid');
          document.querySelector('#address').classList.add('is-valid');
          document.querySelector('.address small').style.display = 'none';
      }

      if (unitApt.length > 128) {
          document.querySelector('#unit').classList.add('is-invalid');
          document.querySelector('.unit small').style.display = 'block';
          erros.push(1);
      } else {
          document.querySelector('#unit').classList.remove('is-invalid');
          document.querySelector('#unit').classList.add('is-valid');
          document.querySelector('.unit small').style.display = 'none';
      }

      if (email.length > 128) {
          document.querySelector('#email').classList.add('is-invalid');
          document.querySelector('.email small').style.display = 'block';
          erros.push(1);
      } else {
          document.querySelector('#email').classList.remove('is-invalid');
          document.querySelector('#email').classList.add('is-valid');
          document.querySelector('.email small').style.display = 'none';
      }

      if (provincy === 0) {
          document.querySelector('#provincy').classList.add('is-invalid');
          document.querySelector('#city').classList.add('is-invalid');
          erros.push(1);
      } else {
          document.querySelector('#provincy').classList.remove('is-invalid');
          document.querySelector('#provincy').classList.add('is-valid');
          document.querySelector('#city').classList.remove('is-invalid');
          document.querySelector('#city').classList.add('is-valid');
      }

      if (erros.length === 0) {
          const data = {
              "name": `${firstName} ${lastName}`,
              "address": streetAddress ,
              "address2": unitApt,
              "province": provincy.toString(),
              "city": city,
              "email": email
          };

          fetch("http://localhost:57712/api/v1/Contact/SendContact", {
              method: 'POST',
              headers: {
                  'Content-Type': 'application/json',
              },
              body: JSON.stringify(data),
          })
              .then((data) => {
                  alert("Contact has been successfully saved");
                  window.location.reload();
              })

          console.log(data);
      } else {
          return false;
      }
      
  }  

  render() {
      return (
        <Form id="form" onSubmit={this.handleSubmit}>
            <FormGroup className="firstName">
                <Label htmlFor="firstName">First Name</Label>
                <Input
                    type="text"
                    id="firstName"
                    name="firstName"
                    required
                    placeholder="Insert your first name"
                    defaultValue={this.state.firstName}
                    onChange={this.handleInputChange}
                />
                <FormText style={{ "display": "none" }}>You have exceeded the 40 characters limit</FormText>
            </FormGroup>
            <FormGroup className="lastName">
                <Label htmlFor="lastName">Last Name</Label>
                <Input
                    type="text"
                    id="lastName"
                    name="lastName"
                    required
                    placeholder="Insert your last name"
                    defaultValue={this.state.lastName}
                    onChange={this.handleInputChange}
                />
                <FormText style={{ "display": "none" }}>You have exceeded the 40 characters limit</FormText>
            </FormGroup>
            <FormGroup className="address">
                <Label htmlFor="address">Address</Label>
                <Input
                    type="text"
                    id="address"
                    name="streetAddress"
                    required
                    placeholder="Insert your address"
                    defaultValue={this.state.streetAddress}
                    onChange={this.handleInputChange}
                />
                <FormText style={{ "display": "none" }}>You have exceeded the 128 characters limit</FormText>
            </FormGroup>
            <FormGroup className="unit">
                <Label htmlFor="unit">Unit/Apt</Label>
                <Input
                    type="text"
                    id="unit"
                    name="unitApt"
                    placeholder="Unit/Apt"
                    defaultValue={this.state.unitApt}
                    onChange={this.handleInputChange}
                />
                <FormText style={{ "display": "none" }}>You have exceeded the 128 characters limit</FormText>
            </FormGroup>
            <Row form>
                <Col md={6}>
                    <FormGroup>
                        <Label htmlFor="provincy">Provincy</Label>
                        <Input type="select" name="provincy" id="provincy" onChange={this.handleCityChange} required>
                              <option value="0">Select</option>
                              {
                                  this.state.provinces.map(province => (
                                      <option key={province.idState} value={province.idState}>{province.name}</option>
                                  ))
                              }
                        </Input>
                    </FormGroup>
                </Col>
                <Col md={6}>
                    <FormGroup>
                        <Label htmlFor="city">City</Label>
                        <Input type="select" name="city" id="city" onChange={this.handleInputChange} required>
                              <option value="0">Select</option>
                              {
                                  this.state.cities.map(city => (
                                      <option key={city.idCity} value={city.name}>{city.name}</option>
                                  ))
                              }
                        </Input>
                    </FormGroup>
                </Col>
            </Row>
            <FormGroup className="email">
                <Label htmlFor="email">Email</Label>
                <Input
                    type="email"
                    id="email"
                    name="email"
                    required
                    placeholder="example@example.com"
                    defaultValue={this.state.email}
                    onChange={this.handleInputChange}
                  />
                  <FormText style={{ "display": "none" }}>You have exceeded the 128 characters limit</FormText>
             </FormGroup>
             <Input type="submit" value="Save" />
        </Form>
    );
  }
}
