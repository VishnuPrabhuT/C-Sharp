<template>
  <div class="csp-table-wrapper">
    <div class="csp-table">
      <div class="csp-table-header">
        <div class="csp-table-header-checkbox">
          <csp-checkbox v-model="allIsSelected"></csp-checkbox>
        </div>

        <div
          v-for="column in columns"
          class="csp-table-header-item"
          :key
          :class="[{'is-sortable': column.isSortable }, setSortClass(column.field)]"
        >
          <edit-tooltip
            v-if="column.isEditable && isBulkEditing"
            @edit="onBulkEdit($event, column.field)"
          ></edit-tooltip>

          <span @click="column.isSortable ? sortBy(column.field) : null">{{ column.name }}</span>
        </div>
      </div>

      <div class="csp-table-data">
        <div
          class="csp-table-data-row"
          v-for="row in orderedTable"
          :key="row.id"
          :class="{'is-selected': row.isSelected}"
        >
          <div class="table-checkbox">
            <csp-checkbox v-model="row.isSelected" v-on:change="onCheckboxChanged"></csp-checkbox>
          </div>

          <div class="csp-table-data-cell" v-for="column in columns">
            <table-text-cell
              :editable="column.isEditable"
              :value="row[column.field]"
              :valueType="column.valueType"
              @changed="onCellEdit(row, column.field, $event, row.id)"
            ></table-text-cell>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
const _ = require("lodash");
import CspCheckbox from "./Checkbox.vue";
import TableTextCell from "./TableTextCell.vue";
import EditTooltip from "./EditTooltip.vue";

export default {
  name: "csp-table",
  components: { CspCheckbox, TableTextCell, EditTooltip },
  data() {
    return {
      allIsSelected: false,
      sortKey: "",
      order: "asc",
      fieldIsEditing: false,
      currentEditingVal: null,
      isBulkEditing: false,
      selectedRows: [],
      columns: [
        {
          id: 1,
          name: "Scan Code",
          field: "scan_code",
          isSortable: true,
          isEditable: true,
          type: "text",
          valueType: "string"
        },
        { id: 2, name: "Item Name", field: "item_name" },
        { id: 3, name: "Department", field: "department" },
        { id: 4, name: "Tax Type", field: "tax_type" },
        {
          id: 5,
          name: "Price",
          isSortable: true,
          field: "price",
          type: "text",
          valueType: "number",
          isEditable: true
        },
        { id: 6, name: "Price Group", field: "price_group" },
        { id: 7, name: "Vendor", field: "vendor" },
        { id: 8, name: "Inventory", field: "inventory" }
      ],
      tableData: [
        {
          id: 2,
          scan_code: "183903475",
          item_name: "Item Name",
          department: "Department",
          tax_type: "Non Taxable",
          price_group: "Price Group",
          vendor: "Vendor",
          inventory: "inventory",
          price: 20
        },
        {
          id: 3,
          scan_code: "238975894",
          item_name: "Item Name",
          department: "Department",
          tax_type: "Non Taxable",
          price_group: "Price Group",
          vendor: "Vendor",
          inventory: "inventory",
          price: 20
        },
        {
          id: 4,
          scan_code: "232347839",
          item_name: "Item Name",
          department: "Department",
          tax_type: "Non Taxable",
          price_group: "Price Group",
          vendor: "Vendor",
          inventory: "inventory",
          price: 20
        },
        {
          id: 5,
          scan_code: "489045335",
          item_name: "Item Name",
          department: "Department",
          tax_type: "Non Taxable",
          price_group: "Price Group",
          vendor: "Vendor",
          inventory: "inventory",
          price: 40
        },
        {
          id: 6,
          scan_code: "178359844",
          item_name: "Item Name",
          department: "Department",
          tax_type: "Non Taxable",
          price_group: "Price Group",
          vendor: "Vendor",
          inventory: "inventory",
          price: 20
        },
        {
          id: 7,
          scan_code: "389240284",
          item_name: "Item Name",
          department: "Department",
          tax_type: "Non Taxable",
          price_group: "Price Group",
          vendor: "Vendor",
          inventory: "inventory",
          price: 30
        }
      ]
    };
  },
  computed: {
    getOrder() {
      return this.order;
    },
    orderedTable() {
      return _.orderBy(this.tableData, this.sortKey, this.getOrder);
    }
  },
  watch: {
    allIsSelected(newValue) {
      this.toggleSelectAll(newValue);
    }
  },
  methods: {
    onBulkEdit(newValue, field) {
      this.selectedRows.forEach(function(row) {
        row[field] = newValue;
      });
    },
    onCheckboxChanged(event) {
      this.selectedRows = _.filter(this.tableData, item => {
        return item.isSelected;
      });
      this.selectedRows.length > 0
        ? (this.isBulkEditing = true)
        : (this.isBulkEditing = false);
    },
    onCellEdit(row, field, event, id) {
      if (row[field] == event) {
        return;
      }

      this.tableData = this.orderedTable;
      this.sortKey = "";
      row[field] = event;
    },
    toggleSelectAll(value) {
      this.tableData.forEach(item => {
        item.isSelected = value;
      });
    },
    setSortClass(field) {
      if (this.sortKey !== field) {
        return "";
      }

      if (this.sortKey === field) {
        if (this.getOrder === "asc") {
          return "is-asc";
        } else {
          return "is-desc";
        }
      }
    },
    sortBy(sortKey) {
      this.order = this.order == "asc" ? "desc" : "asc";
      this.sortKey = sortKey;
    }
  }
};
</script>

<style scoped>
.csp-table-wrapper .csp-table > .csp-table-header {
  height: 70px;
  background-color: #f7f7f7;
  padding: 40px 20px 0 20px;
  display: flex;
  flex-wrap: nowrap;
  justify-content: space-evenly;
}
.csp-table-wrapper .csp-table > .csp-table-header > .csp-table-header-checkbox {
  flex-basis: 20%;
  position: relative;
  top: -5px;
}
.csp-table-wrapper .csp-table > .csp-table-header > .csp-table-header-item {
  flex-basis: 100%;
  color: #b1b1b1;
  font-size: 13px;
  user-select: none;
  position: relative;
}
.csp-table-wrapper
  .csp-table
  > .csp-table-header
  > .csp-table-header-item.is-desc:before,
.csp-table-wrapper
  .csp-table
  > .csp-table-header
  > .csp-table-header-item.is-asc:before {
  content: "↓";
  display: inline;
  position: absolute;
  top: -3px;
  left: -10px;
}
.csp-table-wrapper
  .csp-table
  > .csp-table-header
  > .csp-table-header-item.is-asc:before {
  content: "↑";
}
.csp-table-wrapper
  .csp-table
  > .csp-table-header
  > .csp-table-header-item.is-sortable
  span {
  cursor: pointer;
}
.csp-table-wrapper
  .csp-table
  > .csp-table-header
  > .csp-table-header-item.is-sortable
  span:hover {
  color: #616060;
}

.csp-table-wrapper .csp-table > .csp-table-data .csp-table-data-row {
  background: white;
  height: 50px;
  margin-top: 1px;
  display: flex;
  flex-wrap: nowrap;
  justify-content: space-evenly;
  padding: 0 20px;
  transition: background-color 200ms ease;
  font-size: 13px;
}
.csp-table-wrapper
  .csp-table
  > .csp-table-data
  .csp-table-data-row.is-selected {
  background-color: rgba(255, 255, 255, 0.9);
}
.csp-table-wrapper
  .csp-table
  > .csp-table-data
  .csp-table-data-row
  > .table-checkbox {
  flex-basis: 20%;
  display: inline;
  position: relative;
  top: 14px;
}
.csp-table-wrapper .csp-table > .csp-table-data .csp-table-data-cell {
  flex-basis: 100%;
  color: #4a4a4a;
  font-size: 13px;
  line-height: 52px;
}
</style>