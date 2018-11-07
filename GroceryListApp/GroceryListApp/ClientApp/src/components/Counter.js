import React, { Component } from "react";

class Counter extends Component {
  displayName = Counter.name;

  constructor(props) {
    super(props);
    this.state = {
      currentCount: props.count,
      styles: {
        fontSize: 15
      }
    };
    //this.incrementCounter = this.incrementCounter.bind(this);
    //this.decrementCounter = this.decrementCounter.bind(this);
  }

  incrementCounter = () => {
    this.props.handlerChildClick(this.props.row, this.state.currentCount + 1);
    this.setState({
      currentCount:
        this.state.currentCount === 0 ? 1 : this.state.currentCount + 1
    });
  };

  decrementCounter = () => {
    this.props.handlerChildClick(this.props.row, this.state.currentCount - 1);
    this.setState({
      currentCount:
        this.state.currentCount === 0 ? 0 : this.state.currentCount - 1
    });
  };

  getCounterValue() {
    const counterValue =
      this.state.currentCount === 0 ? 0 : this.state.currentCount;
    return counterValue > 0 ? counterValue : 0;
  }

  getBadgeClass() {
    let quantityClasses = "label label-pill label-";
    quantityClasses += this.state.currentCount > 0 ? "success" : "danger";
    return quantityClasses;
  }

  styles = {
    counterDiv: {
      display: "grid",
      gridTemplateColumns: "30% 40% 30%"
    }
  };

  render() {
    return (
      <div styles={this.styles.counterDiv}>
        <button
          className="btn btn-primary btn-sm"
          onClick={this.decrementCounter}
        >
          ↓
        </button>
        <span style={this.state.styles} className={this.getBadgeClass()}>
          {this.getCounterValue()}
          {/* {console.log(this.props.handlerChildClick)} */}
        </span>
        <button
          className="btn btn-primary btn-sm"
          onClick={this.incrementCounter}
        >
          ↑
        </button>
      </div>
    );
  }
}

export default Counter;
