<template>
  <HelloWorld />
</template>

<script>
import HelloWorld from "./components/HelloWorld.vue";
//import Home from "./components/Home.vue";

export default {
  name: "app",
  components: {
    HelloWorld
  },
  mounted() {}
};
</script>

<style lang="sass">
@import "src/assets/main.scss"
#app
  -webkit-font-smoothing: antialiased
  -moz-osx-font-smoothing: grayscale
  text-align: center
</style>
