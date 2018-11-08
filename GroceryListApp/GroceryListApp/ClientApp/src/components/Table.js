import React, { Component } from "react";
import PropTypes from "prop-types";
import { withStyles } from "@material-ui/core/styles";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableHead from "@material-ui/core/TableHead";
import TableFooter from "@material-ui/core/TableFooter";
import TablePagination from "@material-ui/core/TablePagination";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";
import Button from "@material-ui/core/Button";
import Checkbox from "@material-ui/core/Checkbox";
import FirstPageIcon from "@material-ui/icons/FirstPage";
import KeyboardArrowLeft from "@material-ui/icons/KeyboardArrowLeft";
import KeyboardArrowRight from "@material-ui/icons/KeyboardArrowRight";
import LastPageIcon from "@material-ui/icons/LastPage";
import Counter from "./Counter.js";

const actionsStyles = theme => ({
  root: {
    flexShrink: 0,
    color: theme.palette.text.secondary,
    marginLeft: theme.spacing.unit * 2.5
  }
});

class TablePaginationActions extends React.Component {
  handleFirstPageButtonClick = event => {
    this.props.onChangePage(event, 0);
  };

  handleBackButtonClick = event => {
    this.props.onChangePage(event, this.props.page - 1);
  };

  handleNextButtonClick = event => {
    this.props.onChangePage(event, this.props.page + 1);
  };

  handleLastPageButtonClick = event => {
    this.props.onChangePage(
      event,
      Math.max(0, Math.ceil(this.props.count / this.props.rowsPerPage) - 1)
    );
  };

  handleSelectAllClick = event => {
    if (event.target.checked) {
      this.setState(state => ({ selected: state.data.map(n => n.id) }));
      return;
    }
    this.setState({ selected: [] });
  };

  handleClick = (event, id) => {
    const { selected } = this.state;
    const selectedIndex = selected.indexOf(id);
    let newSelected = [];

    if (selectedIndex === -1) {
      newSelected = newSelected.concat(selected, id);
    } else if (selectedIndex === 0) {
      newSelected = newSelected.concat(selected.slice(1));
    } else if (selectedIndex === selected.length - 1) {
      newSelected = newSelected.concat(selected.slice(0, -1));
    } else if (selectedIndex > 0) {
      newSelected = newSelected.concat(
        selected.slice(0, selectedIndex),
        selected.slice(selectedIndex + 1)
      );
    }

    this.setState({ selected: newSelected });
  };

  render() {
    const { classes, count, page, rowsPerPage, theme } = this.props;

    return (
      <div className={classes.root}>
        <Button
          onClick={this.handleFirstPageButtonClick}
          disabled={page === 0}
          aria-label="First Page"
        >
          {theme.direction === "rtl" ? <LastPageIcon /> : <FirstPageIcon />}
        </Button>
        <Button
          onClick={this.handleBackButtonClick}
          disabled={page === 0}
          aria-label="Previous Page"
        >
          {theme.direction === "rtl" ? (
            <KeyboardArrowRight />
          ) : (
            <KeyboardArrowLeft />
          )}
        </Button>
        <Button
          onClick={this.handleNextButtonClick}
          disabled={page >= Math.ceil(count / rowsPerPage) - 1}
          aria-label="Next Page"
        >
          {theme.direction === "rtl" ? (
            <KeyboardArrowLeft />
          ) : (
            <KeyboardArrowRight />
          )}
        </Button>
        <Button
          onClick={this.handleLastPageButtonClick}
          disabled={page >= Math.ceil(count / rowsPerPage) - 1}
          aria-label="Last Page"
        >
          {theme.direction === "rtl" ? <FirstPageIcon /> : <LastPageIcon />}
        </Button>
      </div>
    );
  }
}

const CustomTableCell = withStyles(theme => ({
  head: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
    fontSize: 19
  },
  body: {
    width: "1fr",
    fontSize: 14
  }
}))(TableCell);

const styles = theme => ({
  root: {
    marginTop: theme.spacing.unit * 1,
    overflowX: "hidden"
  },
  table: {
    minWidth: "100%"
  },
  row: {
    "&:nth-of-type(odd)": {
      backgroundColor: "powderblue"
    }
  }
});

const TablePaginationActionsWrapped = withStyles(actionsStyles, {
  withTheme: true
})(TablePaginationActions);

class CustomizedTable extends Component {
  constructor(props) {
    super();
    this.state = {
      rows: [],
      headers: [],
      selected: 0,
      page: 0,
      rowsPerPage: 0,
      selectAll: false
    };
  }

  handleChangePage = (event, page) => {
    this.setState({ page });
  };

  handleChangeRowsPerPage = event => {
    this.setState({ rowsPerPage: event.target.value });
  };

  handleSelectAllClick = event => {
    let newRows = this.state.rows;
    newRows.forEach(item => {
      item.checked = event.target.checked;
    });
    this.setState(state => ({
      rows: newRows,
      selected: state.rows.filter(x => x.checked === true).length
    }));

    fetch("api/grocerylist/", {
      method: "PUT",
      headers: {
        Accept: "application/json, text/plain",
        "Content-type": "application/json"
      },
      body: JSON.stringify({
        isChecked: event.target.checked
      })
    }).then(res => console.log(res));
  };

  handleClick = (row, quantity) => {
    var newRows = this.state.rows;
    newRows.forEach(item => {
      if (item.id === row.id && quantity === -1) {
        console.log(row.checked, item.checked);
        item.checked = !row.checked;
      }
    });
    this.setState({
      rows: newRows
    });
    var result = this.state.rows.filter(r => r.id === row.id)[0];

    fetch("api/grocerylist/" + row.id, {
      method: "PUT",
      headers: {
        Accept: "application/json, text/plain",
        "Content-type": "application/json"
      },
      body: JSON.stringify({
        id: result.id,
        itemName: result.item_Name,
        price: result.price,
        description: result.description,
        expiryDate: result.expiry_Date,
        quantity: quantity > -1 ? quantity : result.quantity,
        isChecked: result.checked
      })
    });
    //this.setState({ selected: newSelected });
  };

  isSelected = id => {
    var result = this.state.rows.filter(row => row.id === id);
    return result[0].checked === true;
  };

  componentWillReceiveProps(p, s) {
    this.setState({
      rows: p.rows,
      selected: p.selected,
      rowsPerPage: p.rowsPerPage
    });
    console.log(p);
  }

  render() {
    const { classes } = this.props;
    //console.log(this.state.selected, this.state.rows.length);
    //console.log(this.state.rows);
    return (
      <Paper className={classes.root}>
        <Table className={classes.table}>
          <TableHead>
            <TableRow>
              {this.props.headers.map(header => (
                <CustomTableCell key={header.prop}>
                  {header.prop === "checked" ? (
                    <Checkbox
                      checked={
                        this.state.selected === this.state.rows.length &&
                        this.state.selected > 0
                      }
                      onClick={this.handleSelectAllClick}
                    />
                  ) : (
                    header.name
                  )}
                </CustomTableCell>
              ))}
            </TableRow>
          </TableHead>
          <TableBody>
            {this.state.rows
              .slice(
                this.state.page * this.state.rowsPerPage,
                this.state.page * this.state.rowsPerPage +
                  this.state.rowsPerPage
              )
              .map(row => {
                let isChecked = this.isSelected(row.id);
                return (
                  <TableRow className={classes.row} key={row.id}>
                    <CustomTableCell component="th" scope="row">
                      <Checkbox
                        onClick={event => this.handleClick(row, -1)}
                        checked={isChecked}
                      />
                    </CustomTableCell>
                    <CustomTableCell component="th" scope="row">
                      {row.item_Name}
                    </CustomTableCell>
                    <CustomTableCell component="th" scope="row">
                      {row.price}
                    </CustomTableCell>
                    <CustomTableCell component="th" scope="row">
                      <Counter
                        handlerChildClick={this.handleClick}
                        count={row.quantity}
                        row={row}
                      />
                    </CustomTableCell>
                    <CustomTableCell component="th" scope="row">
                      {row.description.slice(0, 43)}
                    </CustomTableCell>
                    <CustomTableCell component="th" scope="row">
                      {row.expiry_Date.slice(0, 10)}
                    </CustomTableCell>
                  </TableRow>
                );
              })}
          </TableBody>
          <TableFooter>
            <TableRow>
              <TablePagination
                colSpan={3}
                count={this.props.rows.length}
                rowsPerPage={this.state.rowsPerPage}
                page={this.state.page}
                onChangePage={this.handleChangePage}
                onChangeRowsPerPage={this.handleChangeRowsPerPage}
                ActionsComponent={TablePaginationActionsWrapped}
              />
            </TableRow>
          </TableFooter>
        </Table>
      </Paper>
    );
  }
}

CustomizedTable.propTypes = {
  classes: PropTypes.object.isRequired
};

export default withStyles(styles)(CustomizedTable);
