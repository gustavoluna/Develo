import React, { Component } from 'react';
import { FormText, Form, FormGroup, Label, Input } from 'reactstrap';

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
          error: 0,
      };

      this.handleInputChange = this.handleInputChange.bind(this);
      this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleInputChange(event) {
      const target = event.target;
      const value = target.value;
      const name = target.name;
      this.setState({
        [name]: value,
      });
  }

  handleSubmit(event) {
      event.preventDefault();
      var erros = [];
      const { firstName, lastName, streetAddress, unitApt, email } = this.state;

      if (firstName.length > 40) {
          document.querySelector('#firstName').classList.add('is-invalid');
          document.querySelector('.firstName small').style.display = 'block';
          erros.push(1);
      } else {
          document.querySelector('#firstName').classList.remove('is-invalid');
          document.querySelector('#firstName').classList.add('is-valid');
      }

      if (lastName.length > 40) {
          document.querySelector('#lastName').classList.add('is-invalid');
          document.querySelector('.lastName small').style.display = 'block';
          erros.push(1);
      } else {
          document.querySelector('#lastName').classList.remove('is-invalid');
          document.querySelector('#lastName').classList.add('is-valid');
      }

      if (streetAddress.length > 128) {
          document.querySelector('#address').classList.add('is-invalid');
          document.querySelector('.address small').style.display = 'block';
          erros.push(1);
      } else {
          document.querySelector('#address').classList.remove('is-invalid');
          document.querySelector('#address').classList.add('is-valid');
      }

      if (unitApt.length > 128) {
          document.querySelector('#unit').classList.add('is-invalid');
          document.querySelector('.unit small').style.display = 'block';
          erros.push(1);
      } else {
          document.querySelector('#unit').classList.remove('is-invalid');
          document.querySelector('#unit').classList.add('is-valid');
      }

      if (email.length > 128) {
          document.querySelector('#email').classList.add('is-invalid');
          document.querySelector('.email small').style.display = 'block';
          erros.push(1);
      } else {
          document.querySelector('#email').classList.remove('is-invalid');
          document.querySelector('#email').classList.add('is-valid');
      }

      if (erros.length === 0) {
          const data = [
              firstName,
              lastName,
              streetAddress,
              unitApt,
              email
          ];
          console.log(data);
      } else {
          return false;
      }
      
  }  

  render() {
      return (
        <Form onSubmit={this.handleSubmit}>
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
