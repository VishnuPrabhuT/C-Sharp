import React, { Component } from "react";

export class Counter extends Component {
  displayName = Counter.name;

  constructor(props) {
    super(props);
    this.state = { currentCount: 0 };
    //this.incrementCounter = this.incrementCounter.bind(this);
    //this.decrementCounter = this.decrementCounter.bind(this);
  }

  incrementCounter = () => {
    this.setState({
      currentCount:
        this.state.currentCount === 0 ? 1 : this.state.currentCount + 1
    });
  };

  decrementCounter = () => {
    this.setState({
      currentCount:
        this.state.currentCount === 0 ? 0 : this.state.currentCount - 1
    });
  };

  getCounterValue() {
    const counterValue =
      this.state.currentCount === 0 ? 0 : this.state.currentCount;
    return counterValue > 0 ? counterValue : "Zero";
  }

  render() {
    return (
      <React.Fragment>
        <button className="btn btn-primary" onClick={this.decrementCounter}>
          ↓
        </button>
        <span style={{ fontSize: 30 }} className={this.getBadgeClass()}>
          {this.getCounterValue()}
        </span>
        <button className="btn btn-primary" onClick={this.incrementCounter}>
          ↑
        </button>
      </React.Fragment>
    );
  }

  getBadgeClass() {
    let quantityClasses = "label label-pill label-";
    quantityClasses += this.state.currentCount > 0 ? "success" : "danger";
    return quantityClasses;
  }
}
