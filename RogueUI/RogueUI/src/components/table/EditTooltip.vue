<template>
  <div class="edit-tooltip" :class="{'is-editing': editMode }">
    <div class="edit-button" v-if="!editMode" @click="startEditing">EDIT</div>

    <div v-if="editMode" class="input">
      <input v-model="newValue" type="text" ref="input">
    </div>

    <div class="apply-button" v-if="editMode" @click="commitEdit">APPLY</div>
  </div>
</template>

<script>
export default {
  name: "edit-tooltip",
  data() {
    return {
      editMode: false,
      newValue: ""
    };
  },
  methods: {
    startEditing() {
      this.editMode = true;

      this.$nextTick(() => {
        this.$refs.input.focus();
      });
    },
    commitEdit() {
      this.editMode = false;
      this.$emit("edit", this.newValue);
    }
  }
};
</script>

<style scoped>
.edit-tooltip {
  position: absolute;
  background-color: #fc6767;
  top: -50px;
  width: 70px;
  color: white;
  border-radius: 4px;
  box-shadow: -1px 2px 8px 0px rgba(0, 0, 0, 0.2);
  text-align: center;
}
.edit-tooltip .edit-button {
  padding: 8px 20px;
  cursor: pointer;
}
.edit-tooltip .apply-button {
  padding: 8px 20px;
  cursor: pointer;
}
.edit-tooltip:before {
  content: " ";
  width: 10px;
  height: 10px;
  transform: rotateZ(45deg) translate(-50%, 50%);
  position: absolute;
  background-color: inherit;
  bottom: -4px;
  left: 54%;
}
.edit-tooltip > .input {
  width: 100%;
  background-color: white;
  height: 42px;
  padding: 8px 20px;
  border-radius: 4px 4px 0 0;
}
.edit-tooltip > .input > input {
  padding: 0px 10px;
  text-align: center;
  font-family: inherit;
  display: inline-block;
  width: 100px;
  font-size: 14px;
  border: none;
  background-color: transparent;
  position: relative;
  top: 5px;
}
.edit-tooltip.is-editing {
  width: 140px;
  left: -35px;
  top: -90px;
}
</style>