<template>
  <div class="csp-checkbox">
    <input
      type="checkbox"
      v-bind:checked="checked"
      v-on:change="$emit('change', $event.target.checked)"
    >
  </div>
</template>

<script>
module.exports = {
  name: "csp-checkbox",
  props: ["checked"],
  model: {
    prop: "checked",
    event: "change"
  }
};
</script>

<style scoped>
.csp-checkbox input {
  -webkit-appearance: none;
  -moz-appearance: none;
  width: 20px;
  height: 20px;
  border: 1px solid #e0e0e0;
  border-radius: 3px;
  background-color: transparent;
  cursor: pointer;
  display: block;
  transition: background-color 200ms ease;
}

.csp-checkbox input:checked {
  background-color: #fc6767;
  box-shadow: inset 0px 0px 0px 2px white;
}
</style>