import React, { Component } from "react";
import { Counter } from "./Counter.js";
export class Home extends Component {
  displayName = Home.name;

  render() {
    return (
      <React.Fragment className="container">
        <Counter />
      </React.Fragment>
    );
  }
}
