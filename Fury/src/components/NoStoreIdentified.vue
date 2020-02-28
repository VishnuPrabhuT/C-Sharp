<template>
  <v-app id="inspire">
    <v-app-bar app color="indigo" dark>
      <v-toolbar-title>No Store Identified</v-toolbar-title>
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
            <h2>Please Identify your Store</h2>
            <div class="button-list">
              <v-menu
                v-model="menu"
                persistent
                max-width="650"
                :close-on-content-click="false"
                :nudge-width="400"
                offset-y
              >
                <template v-slot:activator="{ on }">
                  <v-btn color="primary" dark v-on="on">Connect to my Store's Account</v-btn>
                </template>

                <v-card v-if="vCard1">
                  <span>Enter you Store's API Key</span>
                  <v-text-field color="primary" id="apiKeyText" label="API Key" solo></v-text-field>
                  <div>
                    <v-menu offset-y>
                      <template v-slot:activator="{ on }">
                        <v-btn color="primary" dark v-on="on">Verify API Key</v-btn>
                      </template>
                      <v-list>
                        <v-list-item v-for="(item, index) in items1" :key="index">
                          <v-list-item-title @click="showDialog(item.title)">{{ item.title }}</v-list-item-title>
                        </v-list-item>
                      </v-list>
                    </v-menu>
                  </div>
                </v-card>
                <v-card v-if="vCard2">
                  <h3>Confirm your Store's Information</h3>
                  <h4>Store Logo:</h4>
                  <h4>Store:</h4>
                  <span>Store Name ABC - CSP Number - 123</span>
                  <h4>Last Connection Date:</h4>
                  <span>DateTime Stamp</span>
                  <div>
                    <v-menu offset-y>
                      <template v-slot:activator="{ on }">
                        <v-btn v-on="on" color="primary" dark>Yes</v-btn>
                      </template>
                      <v-list>
                        <v-list-item v-for="(item, index) in items4" :key="index">
                          <v-list-item-title @click="showDialog(item.title+' Yes')">{{ item.title }}</v-list-item-title>
                        </v-list-item>
                      </v-list>
                    </v-menu>
                    <br />
                    <br />
                    <v-btn @click="showDialog('No')" color="primary" dark>No</v-btn>
                  </div>
                </v-card>
                <v-card v-if="vCard3">
                  <h3>
                    You already have a Store assigned to API Key.
                    <b>Are you sure to proceed?</b>
                  </h3>
                  <h3>Confirm your Store's Information</h3>
                  <h4>Store Logo:</h4>
                  <h4>Store:</h4>
                  <span>Store Name ABC - CSP Number - 123</span>
                  <h4>Last Connection Date:</h4>
                  <span>DateTime Stamp</span>
                  <div>
                    <v-menu offset-y>
                      <template v-slot:activator="{ on }">
                        <v-btn v-on="on" color="primary" dark>Yes</v-btn>
                      </template>
                      <v-list>
                        <v-list-item v-for="(item, index) in items5" :key="index">
                          <v-list-item-title @click="showDialog(item.title+' Yes')">{{ item.title }}</v-list-item-title>
                        </v-list-item>
                      </v-list>
                    </v-menu>
                    <br />
                    <br />
                    <v-btn @click="showDialog('No')" color="primary" dark>No</v-btn>
                  </div>
                </v-card>
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
            <div style="text-align: center;">
              <v-chip outlined>App Version Number</v-chip>
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
  name: "NoStoreIdentified",
  data: () => ({
    fav: true,
    menu: false,
    message: false,
    vCard1: true,
    vCard2: false,
    vCard3: false,
    hints: true,
    dialog: false,
    items1: [
      { title: "Success New Store" },
      { title: "Success Existing Store" },
      { title: "Failed due to some reason" },
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
      { title: "Exception-General Business Logic Exception" }
    ],
    items5: [
      { title: "Success Existing Store" },
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
      if (text == "No") {
        this.vCard1 = true;
        this.vCard2 = false;
        this.vCard3 = false;
      }
      if (text == "Success New Store") {
        this.vCard1 = false;
        this.vCard2 = true;
        this.vCard3 = false;
      }
      if (text == "Success Existing Store") {
        this.vCard1 = false;
        this.vCard2 = false;
        this.vCard3 = true;
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
      if (text == "Exception-General Business Logic Exception Yes") {
        this.dialog = true;
        this.dialogView = 5;
      }
      if (text == "Success New Store Yes") {
        this.$router.push({ name: "StoreConfigRequired" });
      }
      if (text == "Success Existing Store Yes") {
        this.$router.push({ name: "Running" });
      }
    }
  }
};
</script>
<style scoped>
.container2 {
  display: flex;
  height: 45vh;
  flex-direction: column;
  justify-content: space-evenly;
  text-align: center;
}
.button-list {
  display: flex;
  flex-direction: column;
  justify-content: center;
  height: 10vh;
}

div.v-card div {
  padding-top: 5%;
}

div.v-card div {
  text-align: center;
}

div.v-card {
  text-align: left;
  padding: 5%;
}
</style>