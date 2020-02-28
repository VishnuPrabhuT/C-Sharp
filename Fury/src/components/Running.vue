<template>
  <v-app id="inspire">
    <v-app-bar app color="indigo" dark>
      <v-toolbar-title>Running</v-toolbar-title>
    </v-app-bar>

    <v-content>
      <v-container fluid fill-height>
        <v-layout align-center justify-center>
          <div class="container2">
            <div style="text-align: center;">
              <v-chip outlined>App Version Number</v-chip>
            </div>
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
            <v-alert prominent type="error">
              <v-row align="center">
                <v-col class="grow">
                  New Version of CStorePro POS Link is available. Please update by
                  <strong>Monday January 1st</strong> to avoid disruptions.
                </v-col>
                <v-col class="shrink">
                  <v-btn @click="showDialog2('Update Now')">Update Now</v-btn>
                </v-col>
              </v-row>
            </v-alert>
            <h3>
              Store Name ABC - CSP Number ABC
              <v-btn @click="gotoConfigScreen" color="primary" dark>Change</v-btn>
            </h3>
            <h5>
              You are connected to Passport POS
              <v-btn @click="gotoStoreConfig" color="primary" dark>Change</v-btn>
            </h5>
            <v-alert dense text type="success">
              Maintenance Mode Alert CSP will be down on Sunday January 1st from
              <strong>8 AM to 9 PM.</strong>
            </v-alert>
            <div class="form-list">
              <v-card class="mx-auto" color="#F9F9F9" max-width="400">
                <v-list-item two-line>
                  <v-list-item-content>
                    <v-list-item-title class="headline">Last Price Change On</v-list-item-title>
                    <v-list-item-subtitle></v-list-item-subtitle>
                  </v-list-item-content>
                </v-list-item>

                <v-card-text>
                  <v-row align="center">
                    <v-col class="display-3" cols="12">Aug 23</v-col>
                  </v-row>
                </v-card-text>

                <v-list-item>
                  <v-list-item-subtitle>At 9:22 PM</v-list-item-subtitle>
                </v-list-item>

                <v-divider></v-divider>

                <v-menu offset-y>
                  <template v-slot:activator="{ on }">
                    <v-btn v-on="on" text>Get New Price Changes</v-btn>
                  </template>
                  <v-list>
                    <v-list-item v-for="(item, index) in items1" :key="index">
                      <v-list-item-title @click="showDialog(item.title)">{{ item.title }}</v-list-item-title>
                    </v-list-item>
                  </v-list>
                </v-menu>
              </v-card>
              <v-card class="mx-auto" color="#F9F9F9" max-width="400">
                <v-list-item two-line>
                  <v-list-item-content>
                    <v-list-item-title class="headline">Last POS Transaction On</v-list-item-title>
                    <v-list-item-subtitle></v-list-item-subtitle>
                  </v-list-item-content>
                </v-list-item>

                <v-card-text>
                  <v-row align="center">
                    <v-col class="display-3" cols="12">Aug 23</v-col>
                  </v-row>
                </v-card-text>

                <v-list-item>
                  <v-list-item-subtitle>At 9:22 PM</v-list-item-subtitle>
                </v-list-item>
                <v-divider></v-divider>
                <v-menu offset-y>
                  <template v-slot:activator="{ on }">
                    <v-btn v-on="on" text>Upload 7 unprocessed files</v-btn>
                  </template>
                  <v-list>
                    <v-list-item v-for="(item, index) in items1" :key="index">
                      <v-list-item-title @click="showDialog(item.title)">{{ item.title }}</v-list-item-title>
                    </v-list-item>
                  </v-list>
                </v-menu>
              </v-card>
              <v-card class="mx-auto" color="#F9F9F9" max-width="400">
                <v-list-item two-line>
                  <v-list-item-content>
                    <v-list-item-title class="headline">Last Day Report On</v-list-item-title>
                    <v-list-item-subtitle></v-list-item-subtitle>
                  </v-list-item-content>
                </v-list-item>

                <v-card-text>
                  <v-row align="center">
                    <v-col class="display-3" cols="12">Aug 23</v-col>
                  </v-row>
                </v-card-text>

                <v-list-item>
                  <v-list-item-subtitle>At 9:22 PM</v-list-item-subtitle>
                </v-list-item>

                <v-divider></v-divider>
                <v-menu
                  v-model="menu"
                  persistent
                  max-width="650"
                  :close-on-content-click="false"
                  :nudge-width="400"
                  offset-y
                >
                  <template v-slot:activator="{ on }">
                    <v-btn v-on="on">Reupload Day Closing</v-btn>
                  </template>

                  <v-card v-if="vCard1">
                    <span>Select the date for which you would like to regenerate the day report.</span>
                    <v-text-field
                      color="primary"
                      id="apiKeyText"
                      label="This should be a calendar field"
                      solo
                    ></v-text-field>
                    <div>
                      <v-menu offset-y>
                        <template v-slot:activator="{ on }">
                          <v-btn color="primary" dark v-on="on">Generate Report</v-btn>
                        </template>
                        <v-list>
                          <v-list-item v-for="(item, index) in items1" :key="index">
                            <v-list-item-title @click="showDialog(item.title)">{{ item.title }}</v-list-item-title>
                          </v-list-item>
                        </v-list>
                      </v-menu>
                    </div>
                  </v-card>
                </v-menu>
              </v-card>
            </div>
            <div class="table">
              <v-simple-table dense>
                <thead>
                  <tr>
                    <th class="text-left">
                      <h2>Last 5 Errors</h2>
                    </th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="item in desserts" :key="item.name">
                    <td>
                      <strong>{{ item.name }}</strong>
                    </td>
                  </tr>
                </tbody>
              </v-simple-table>
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
  name: "NoStoreIdentified",
  data: () => ({
    dialog: false,
    fav: true,
    menu: false,
    message: false,
    vCard1: true,
    desserts: [
      {
        name: "Error 1"
      },
      {
        name: "Error 2"
      },
      {
        name: "Error 3"
      },
      {
        name: "Error 4"
      },
      {
        name: "Error 5"
      }
    ],
    headers: [
      {
        text: "Last 5 Errors",
        align: "left",
        sortable: false,
        value: "name"
      }
    ],
    labels: ["SU", "MO", "TU", "WED", "TH", "FR", "SA"],
    time: 0,
    forecast: [
      {
        day: "Tuesday",
        icon: "mdi-white-balance-sunny",
        temp: "24\xB0/12\xB0"
      },
      {
        day: "Wednesday",
        icon: "mdi-white-balance-sunny",
        temp: "22\xB0/14\xB0"
      },
      { day: "Thursday", icon: "mdi-cloud", temp: "25\xB0/15\xB0" }
    ],
    items1: [
      { title: "Reupload Success" },
      { title: "Failure" },
      { title: "Exception-No Internet Connection" },
      { title: "Exception-In Maintenance Mode" },
      { title: "Exception-Authentication Failed" },
      { title: "Exception-Version Not Supported" },
      { title: "Exception-General Business Logic Exception" }
    ],
    items2: [{ title: "Chat/Help" }],
    items3: [{ title: "Knowledge Base" }],
    items4: [
      { title: "Reupload Success" },
      { title: "Failure" },
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
          "This operation could take 1 to 15 seconds. If successful let the user know about it."
      },
      {
        title: "UX Instructions on Exception-No Internet Connection",
        text:
          "This exception can occur when the internet connection on the client computer is down. Show the error message but keep the user in this context."
      },
      {
        title: "UX Instructions on Exception-In Maintenance Mode",
        text:
          "This exception can occur when an the CSP POS Server is currently in scheduled maintenance mode and no operation is allowed. Redirect to Maintenance Mode state."
      },
      {
        title: "UX Instructions on Exception-Authentication Failed",
        text:
          "This exception can occur when an this store’s CSP account has been terminated, closed or disabled due to billing or other licensing issues. Show this error message in context."
      },
      {
        title: "UX Instructions on Exception-Version Not Supported",
        text:
          "This exception can occur when an this store’s CSP POS Link software is out of date and is no longer supported. Show the error message and stay in this context."
      },
      {
        title: "UX Instructions on Exception-General Business Logic Exception",
        text:
          "This is a caught exception that can occur in the normal flow of the code (i.e. validation errors, etc.). Generally speaking, all such errors should be displayed while maintaining the user’s UI Context. Show the error message and stay in this context."
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
      },
      {
        title: "UX Instructions on Failure",
        text: "Show the user the reason for the failure."
      },
      {
        title: "UX Instructions on Reupload Success",
        text:
          "This operation could take 1 to 15 seconds. If successful let the user know about it."
      },
      {
        title: "UX Instructions on Update Now",
        text: "Redirect to Help article to update."
      }
    ]
  }),
  methods: {
    showDialog2(text) {
      if (text == "Update Now") {
        this.dialog = true;
        this.dialogView = 9;
      }
    },
    showDialog(text) {
      if (text == "Success") {
        this.dialog = true;
        this.dialogView = 0;
      }
      if (text == "Reupload Success") {
        this.dialog = true;
        this.dialogView = 9;
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
      if (text == "Failure") {
        this.dialog = true;
        this.dialogView = 8;
      }
    },
    gotoConfigScreen() {
      this.$router.push({ name: "NoStoreIdentified" });
    },
    gotoStoreConfig() {
      this.$router.push({ name: "StoreConfigRequired" });
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
  display: flex;
  flex-direction: row;
  width: 75%;
}
.button-list {
  display: flex;
  flex-direction: row;
  justify-content: left;
}
.table {
  width: 50%;
  align-self: center;
}

button {
  padding-top: 10px;
}
</style>