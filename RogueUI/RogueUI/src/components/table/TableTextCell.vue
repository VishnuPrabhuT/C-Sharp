<template>
  <div class="table-text-cell" :class="{'is-editable': editable}">
    <div
      class="label"
      v-if="!isEditing"
      @click="startEditing"
      :class="{'is-edited': isEdited}"
    >{{ value }}</div>
    <input
      v-if="isEditing"
      type="text"
      v-model="newValue"
      ref="input"
      @keyup.enter="commitChange"
      @blur="commitChange"
    >
  </div>
</template>

<script>
module.exports = {
  name: "table-text-cell",
  props: ["value", "valueType", "editable", "edited"],
  data() {
    return {
      isEditing: false,
      newValue: null,
      originalValue: null,
      isEdited: false
    };
  },
  mounted() {
    this.originalValue = this.value;
  },
  methods: {
    startEditing() {
      if (!this.editable) {
        return;
      }

      this.isEditing = true;
      this.newValue = this.value;

      this.$nextTick(() => {
        this.$refs.input.focus();
      });
    },
    commitChange(event) {
      if (!this.isEditing) {
        return;
      }

      if (this.valueType == "number") {
        this.newValue = parseFloat(this.newValue);

        if (this.newValue != this.originalValue) {
          this.isEdited = true;
        } else {
          this.isEdited = false;
        }
      }

      if (this.valueType == "string") {
        if (this.newValue != this.originalValue) {
          this.isEdited = true;
        } else {
          this.isEdited = false;
        }
      }

      this.$emit("changed", this.newValue);
      this.isEditing = false;
    }
  }
};
</script>

<style scoped>
.table-text-cell {
  font-size: 13px;
  color: #4a4a4a;
}
.table-text-cell.is-editable > .label {
  cursor: pointer;
  display: inline;
  border: 1px solid transparent;
  padding: 8px 5px 5px 5px;
  height: 32px;
  border-radius: 4px;
  width: auto;
  transition: border-color 250ms ease;
}
.table-text-cell.is-editable > .label:hover {
  border-color: #a1a1a1;
}
.table-text-cell.is-editable > .label.is-edited {
  border-color: #2eabcf;
  color: #2eabcf;
}
.table-text-cell > input {
  color: #4a4a4a;
  font-size: 13px;
  background: transparent;
  border: 1px solid #a1a1a1;
  padding: 8px 5px 5px 5px;
  border-radius: 3px;
  width: 90%;
}
</style>