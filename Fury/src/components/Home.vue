<template>
  <v-app id="inspire">
    <v-app-bar app color="indigo">
      <v-toolbar-title>CSP POS Link UI Wireframe</v-toolbar-title>
    </v-app-bar>

    <v-content>
      <v-container fluid fill-height>
        <v-layout align-center justify-center>
          <div class="container">
            <v-card class="mx-auto" max-width="420" outlined>
              <v-list-item three-line>
                <v-list-item-content>
                  <div class="overline mb-4"></div>
                  <v-list-item-title class="headline mb-1">No Communications</v-list-item-title>
                  <v-list-item-subtitle>Exception State when CSP POS Link Service is down.</v-list-item-subtitle>
                </v-list-item-content>
              </v-list-item>
              <v-card-actions>
                <v-btn @click="gotoNoCommunications" color="info">Go to State</v-btn>
              </v-card-actions>
            </v-card>
            <v-card class="mx-auto" max-width="420" outlined>
              <v-list-item three-line>
                <v-list-item-content>
                  <div class="overline mb-4"></div>
                  <v-list-item-title class="headline mb-1">No Store Identified</v-list-item-title>
                  <v-list-item-subtitle>This state happens when the CSP POS Link Service does not know which store is associated with this install instance.</v-list-item-subtitle>
                </v-list-item-content>
              </v-list-item>
              <v-card-actions>
                <v-btn @click="gotoNoStoreIdentified" color="info">Go to State</v-btn>
              </v-card-actions>
            </v-card>
            <v-card class="mx-auto" max-width="420" outlined>
              <v-list-item three-line>
                <v-list-item-content>
                  <div class="overline mb-4"></div>
                  <v-list-item-title class="headline mb-1">Store Config Required</v-list-item-title>
                  <v-list-item-subtitle>This state happens when CSP POS Link Service does not know the settings required to connect to the POS.</v-list-item-subtitle>
                </v-list-item-content>
              </v-list-item>

              <v-card-actions>
                <v-btn color="info" @click="gotoStoreConfigRequired">No Info State</v-btn>
                <v-btn color="info">Partial Info State</v-btn>
              </v-card-actions>
            </v-card>
            <v-card class="mx-auto" max-width="420" outlined>
              <v-list-item three-line>
                <v-list-item-content>
                  <div class="overline mb-4"></div>
                  <v-list-item-title class="headline mb-1">Running</v-list-item-title>
                  <v-list-item-subtitle>Exception State when CSP POS Link Service is down.</v-list-item-subtitle>
                </v-list-item-content>
              </v-list-item>

              <v-card-actions>
                <v-btn color="info" @click="gotoRunning">Go to State</v-btn>
              </v-card-actions>
            </v-card>
            <v-card class="mx-auto" max-width="420" outlined>
              <v-list-item three-line>
                <v-list-item-content>
                  <div class="overline mb-4"></div>
                  <v-list-item-title class="headline mb-1">Maintanence Mode</v-list-item-title>
                  <v-list-item-subtitle>This is the base state when CSP POS Link knows the store that is associated with this instance and it has the minimum required store config to talk to the POS and to process (in and out) POS Data.</v-list-item-subtitle>
                </v-list-item-content>
              </v-list-item>
              <v-card-actions>
                <v-btn color="info" @click="gotoMaintanenceMode">Go to State</v-btn>
              </v-card-actions>
            </v-card>
            <v-card class="mx-auto" max-width="420" outlined>
              <v-list-item three-line>
                <v-list-item-content>
                  <div class="overline mb-4"></div>
                  <v-list-item-title class="headline mb-1">Update Required</v-list-item-title>
                  <v-list-item-subtitle>The state when CSP POS Link Service and UI App requires an update.</v-list-item-subtitle>
                </v-list-item-content>
              </v-list-item>
              <v-card-actions>
                <v-btn color="info" @click="gotoUpdateRequired">Go to State</v-btn>
              </v-card-actions>
            </v-card>
            <v-card class="mx-auto" max-width="420" outlined>
              <v-list-item three-line>
                <v-list-item-content>
                  <div class="overline mb-4"></div>
                  <v-list-item-title class="headline mb-1">Authentication Failed</v-list-item-title>
                  <v-list-item-subtitle>The state when CSP POS Link Service and UI App requires an update.</v-list-item-subtitle>
                </v-list-item-content>
              </v-list-item>
              <v-card-actions>
                <v-btn color="info" @click="gotoAuthenticationFailed">Go to State</v-btn>
              </v-card-actions>
            </v-card>
          </div>
        </v-layout>
      </v-container>
    </v-content>
    <v-footer color="indigo" app>
      <span class="white--text">&copy; 2019</span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  name: "Home",
  data: () => ({}),
  methods: {
    gotoNoCommunications() {
      this.$router.push({ name: "NoCommunications" });
    },
    gotoNoStoreIdentified() {
      this.$router.push({ name: "NoStoreIdentified" });
    },
    gotoStoreConfigRequired() {
      this.$router.push({ name: "StoreConfigRequired" });
    },
    gotoRunning() {
      this.$router.push({ name: "Running" });
    },
    gotoMaintanenceMode() {
      this.$router.push({ name: "MaintanenceMode" });
    },
    gotoUpdateRequired() {
      this.$router.push({ name: "UpdateRequired" });
    },
    gotoAuthenticationFailed() {
      this.$router.push({ name: "AuthenticationFailed" });
    }
  }
};
</script>
<style scoped>
.container {
  display: flex;
  justify-content: space-evenly;
  align-content: space-evenly;
  flex-wrap: wrap;
  height: 70vh;
  width: 140vh;
  padding-top: 5%;
}
</style>