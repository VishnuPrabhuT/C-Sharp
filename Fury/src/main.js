import Vue from "vue";
import App from "./App.vue";
import "vuetify/dist/vuetify.min.css";
import Vuetify from "vuetify";
import vuetify from "./plugins/vuetify";
import "roboto-fontface/css/roboto/roboto-fontface.css";
import "@mdi/font/css/materialdesignicons.css";
import VueRouter from "vue-router";
import Home from "./components/Home.vue";
import NoCommunications from "./components/NoCommunications.vue";
import MaintanenceMode from "./components/MaintanenceMode.vue";
import UpdateRequired from "./components/UpdateRequired.vue";
import AuthenticationFailed from "./components/AuthenticationFailed.vue";
import NoStoreIdentified from "./components/NoStoreIdentified.vue";
import StoreConfigRequired from "./components/StoreConfigRequired.vue";
import Running from "./components/Running.vue";

Vue.use(VueRouter);
Vue.use(Vuetify);
Vue.config.productionTip = false;

const router = new VueRouter({
  mode: "history",
  routes: [
    {
      name: "Home",
      path: "/",
      component: Home
    },
    {
      name: "NoCommunications",
      path: "/NoCommunications",
      component: NoCommunications
    },
    {
      name: "NoStoreIdentified",
      path: "/NoStoreIdentified",
      component: NoStoreIdentified
    },
    {
      name: "StoreConfigRequired",
      path: "/StoreConfigRequired",
      component: StoreConfigRequired
    },
    {
      name: "Running",
      path: "/Running",
      component: Running
    },
    {
      name: "MaintanenceMode",
      path: "/MaintanenceMode",
      component: MaintanenceMode
    },
    {
      name: "UpdateRequired",
      path: "/UpdateRequired",
      component: UpdateRequired
    },
    {
      name: "AuthenticationFailed",
      path: "/AuthenticationFailed",
      component: AuthenticationFailed
    }
  ]
});

new Vue({
  vuetify,
  render: h => h(App)
}).$mount("#app");
