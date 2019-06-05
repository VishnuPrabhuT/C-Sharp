import Vue from "vue";
import App from "./App.vue";
import Popover from "./components/Popover.vue";

Vue.config.productionTip = true;

new Vue({
  render: h => h(App)
}).$mount("#app");
