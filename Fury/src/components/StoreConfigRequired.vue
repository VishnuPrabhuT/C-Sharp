<template>
  <v-app id="inspire">
    <v-app-bar app color="indigo" dark>
      <v-toolbar-title>StoreConfigRequired</v-toolbar-title>
    </v-app-bar>

    <v-content>
      <v-container fluid fill-height>
        <v-layout align-center justify-center>
          <div class="container2">
            <v-dialog v-model="dialog" persistent max-width="650">
              <v-card>
                <v-card-title class="headline">{{dialogData[dialogView].title}}</v-card-title>
                <v-card-text>{{dialogData[dialogView].text}}</v-card-text>
                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn color="green darken-1" text @click="dialog = false">Agree</v-btn>
                </v-card-actions>
              </v-card>
            </v-dialog>

            <div class="form-list">
              Store Name ABC - CSP Number ABC
              <v-btn @click="gotoConfigScreen" color="primary" dark>Change</v-btn>
              <div>
                Primary POS System
                <v-select :items="items" outlined></v-select>
              </div>Primary POS Endpoint
              <v-text-field outlined></v-text-field>Primary POS Username
              <v-text-field placeholder="Enter Username" outlined></v-text-field>Primary POS Password
              <v-text-field placeholder="Enter Password" outlined></v-text-field>
            </div>
            <div class="form-list">
              <div>
                Secondary POS System
                <v-select :items="items" outlined></v-select>
              </div>Secondary POS Endpoint
              <v-text-field outlined></v-text-field>Secondary POS Username
              <v-text-field placeholder="Enter Username" outlined></v-text-field>Secondary POS Password
              <v-text-field placeholder="Enter Password" outlined></v-text-field>
              <div style="text-align: center;">
                <v-chip outlined>App Version Number</v-chip>
              </div>Settings below are for View only
              <br />
              <b>Log Level:</b> Critical Only
              <br />
              <b>Processsed File Handling:</b> Archive
              <br />
            </div>
            <div class="button-list">
              <v-menu offset-y>
                <template v-slot:activator="{ on }">
                  <v-btn color="primary" dark v-on="on">Configure/Update my POS Connection Settings</v-btn>
                </template>
                <v-list>
                  <v-list-item v-for="(item, index) in items4" :key="index">
                    <v-list-item-title @click="showDialog(item.title)">{{ item.title }}</v-list-item-title>
                  </v-list-item>
                </v-list>
              </v-menu>
            </div>

            <div class="button-list">
              <v-menu offset-y>
                <template v-slot:activator="{ on }">
                  <v-btn color="primary" dark v-on="on">Chat with Support</v-btn>
                </template>
                <v-list>
                  <v-list-item v-for="(item, index) in items2" :key="index">
                    <v-list-item-title @click="showDialog(item.title)">{{ item.title }}</v-list-item-title>
                  </v-list-item>
                </v-list>
              </v-menu>
            </div>
            <div class="button-list">
              <v-menu offset-y>
                <template v-slot:activator="{ on }">
                  <v-btn color="primary" dark v-on="on">Go to Knowledge-base</v-btn>
                </template>
                <v-list>
                  <v-list-item v-for="(item, index) in items3" :key="index">
                    <v-list-item-title @click="showDialog(item.title)">{{ item.title }}</v-list-item-title>
                  </v-list-item>
                </v-list>
              </v-menu>
            </div>
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
  name: "StoreConfigRequired",
  data: () => ({
    dialog: false,
    fav: true,
    menu: false,
    message: false,
    vCard1: true,
    vCard2: false,
    vCard3: false,
    items: ["None", "Passport", "Sapphire", "Crony", "Radiant"],
    items1: [
      { title: "Success" },
      { title: "Exception-No Communications with Service" },
      { title: "Exception-No Internet Connection" },
      { title: "Exception-In Maintenance Mode" },
      { title: "Exception-Authentication Failed" },
      { title: "Exception-Version Not Supported" },
      { title: "Exception-General Business Logic Exception" }
    ],
    items2: [{ title: "Chat/Help" }],
    items3: [{ title: "Knowledge Base" }],
    items4: [
      { title: "Success New Store" },
      { title: "Success Existing Store" },
      { title: "Exception-No Communications with Service" },
      { title: "Exception-No Internet Connection" },
      { title: "Exception-In Maintenance Mode" },
      { title: "Exception-Authentication Failed" },
      { title: "Exception-Version Not Supported" },
      { title: "Exception-General Business Logic Exception" }
    ],
    dialogView: 0,
    dialogData: [
      {
        title: "UX Instructions on Success",
        text:
          "This operation could take 1 to 15 seconds. If successful let the user know about it and redirect them to the main page after 5 seconds."
      },
      {
        title: "UX Instructions on Exception-No Communications with Service",
        text:
          "This happens when the UI layer is not able to communicate with the CSP POS Link Service that is running on the client computer.  This can happen if the underlying Service stops or crashes after the UI was launched.  The fix for this error is Start CSP POS Link Service operation as defined below."
      },
      {
        title: "UX Instructions on Exception-No Internet Connection",
        text:
          " This exception can occur when the internet connection on the client computer is down."
      },
      {
        title: "UX Instructions on Exception-In Maintenance Mode",
        text:
          "This exception can occur when an the CSP POS Server is currently in scheduled maintenance mode and no operation is allowed."
      },
      {
        title: "UX Instructions on Exception-Authentication Failed",
        text:
          "This exception can occur when an this store’s CSP account has been terminated, closed or disabled due to billing or other licensing issues."
      },
      {
        title: "UX Instructions on Exception-Version Not Supported",
        text:
          "This exception can occur when an this store’s CSP POS Link software is out of date and is no longer supported."
      },
      {
        title: "UX Instructions on Exception-General Business Logic Exception",
        text:
          "This is a caught exception that can occur in the normal flow of the code (i.e. validation errors, etc.).  Generally speaking, all such errors should be displayed while maintaining the user’s UI Context."
      },
      {
        title: "UX Instructions on Chat with Support",
        text:
          "This operation allows the user to chat with CSP Support Team via Intercom.io chat widget."
      },
      {
        title: "UX Instructions on Go to Knowledge-base",
        text:
          "This operation allows the user to go to the Knowledgebase for the CSP POS Link product."
      }
    ]
  }),
  methods: {
    showDialog(text) {
      if (text == "Success") {
        this.dialog = true;
        this.dialogView = 0;
      }
      if (text == "Success New Store") {
        this.$router.push({ name: "Running" });
      }
      if (text == "Success Existing Store") {
        this.$router.push({ name: "Running" });
      }
      if (text == "Exception-No Internet Connection") {
        this.dialog = true;
        this.dialogView = 1;
      }
      if (text == "Exception-In Maintenance Mode") {
        this.dialog = true;
        this.dialogView = 2;
      }
      if (text == "Exception-Authentication Failed") {
        this.dialog = true;
        this.dialogView = 3;
      }
      if (text == "Exception-Version Not Supported") {
        this.dialog = true;
        this.dialogView = 4;
      }
      if (text == "Exception-General Business Logic Exception") {
        this.dialog = true;
        this.dialogView = 5;
      }
      if (text == "Chat/Help") {
        this.dialog = true;
        this.dialogView = 6;
      }
      if (text == "Knowledge Base") {
        this.dialog = true;
        this.dialogView = 7;
      }
    },
    gotoConfigScreen() {
      this.$router.push({ name: "NoStoreIdentified" });
    }
  }
};
</script>
<style scoped>
.container2 {
  width: 100%;
  display: flex;
  height: 100%;
  flex-direction: column;
  justify-content: space-evenly;
  text-align: left;
}
.form-list {
  width: 25%;
}
.button-list {
  display: flex;
  flex-direction: row;
  justify-content: left;
}
button {
  padding-top: 10px;
}
</style>