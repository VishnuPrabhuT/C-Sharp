import React, { Component } from "react";
import Table from "./Table.js";
export class Home extends Component {
  displayName = Home.name;

  constructor(props) {
    super(props);
    this.state = {
      headers: [],
      data: null
    };

    this.state.headers = [
      {
        name: "",
        prop: "checked"
      },
      {
        name: "Item",
        prop: "item_name"
      },
      {
        name: "Price",
        prop: "price"
      },
      {
        name: "Quantity",
        prop: "quantity"
      },
      {
        name: "Description",
        prop: "description"
      },
      {
        name: "Expiry Date",
        prop: "expiry_date"
      }
    ];
  }

  styles = {
    h2: {
      color: "white"
    },
    div: {
      textAlign: "center"
    }
  };

  componentDidMount() {
    fetch("api/grocerylist")
      .then(response => response.json())
      .then(data => {
        console.log(data);
        this.setState({ data });
      });
  }

  shouldComponentUpdate() {
    if (this.state.rows === null) {
      return false;
    }
    return true;
  }

  render() {
    let rows = this.state.data === null ? [] : this.state.data;
    return (
      <React.Fragment>
        <div style={this.styles.div}>
          <h2 style={this.styles.h2}>Grocery List</h2>
        </div>
        <Table
          rows={rows}
          headers={this.state.headers}
          page={0}
          rowsPerPage={10}
          selected={rows.filter(r => r["checked"] === true).length}
        />
      </React.Fragment>
    );
  }
}
