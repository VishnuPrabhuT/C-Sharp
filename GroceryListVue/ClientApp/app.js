import Vue from "vue";
import axios from "axios";
import App from "components/app-root";

// Registration of global components

Vue.prototype.$http = axios;

const app = new Vue({
  ...App
});

export { app };
