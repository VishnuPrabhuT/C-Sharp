<template>
<div id="app" class="container-fluid">
    <div class="row">
        <div class="col-sm-12">
            <home></home>
        </div>
    </div>
</div>
</template>

<script>
import Home from "./home-page";

export default {
  name: "app-root",
  components: {
    Home
  },

  data() {
    return {};
  }
};
</script>

<style>
body {
  background-image: linear-gradient(-90deg, #24c6dc 0%, #514a9d 100%);
}
table,
th,
td {
  border: 1px solid black;
  padding: 1%;
}
</style>
