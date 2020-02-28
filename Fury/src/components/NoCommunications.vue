<template>
  <v-app id="inspire">
    <v-app-bar app color="indigo" dark>
      <v-toolbar-title>No Communications</v-toolbar-title>
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
            <h1>Unable to communicate to the Service.</h1>
            <h2>Some additional description.</h2>
            <div class="button-list">
              <v-menu offset-y>
                <template v-slot:activator="{ on }">
                  <v-btn color="primary" dark v-on="on">Start Service</v-btn>
                </template>
                <v-list>
                  <v-list-item v-for="(item, index) in items1" :key="index">
                    <v-list-item-title @click="showDialog(item.title)">{{ item.title }}</v-list-item-title>
                  </v-list-item>
                </v-list>
              </v-menu>
            </div>
            <div class="button-list">
              <v-menu offset-y>
                <template v-slot:activator="{ on }">
                  <v-btn color="primary" dark v-on="on">Re-Install</v-btn>
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
                  <v-btn color="primary" dark v-on="on">Chat / Help</v-btn>
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
  name: "NoCommunications",
  data: () => ({
    dialog: false,
    items1: [
      { title: "Success" },
      { title: "Exception-Unable To Start" },
      { title: "Exception-Service not Found" },
      { title: "Exception-General Error" }
    ],
    items2: [{ title: "Redirect" }],
    items3: [{ title: "Chat/Help" }],
    dialogView: 0,
    dialogData: [
      {
        title: "UX Instructions on Success",
        text:
          "This operation could take 1 to 15 seconds. If successful let the user know about it and redirect them to the main page after 5 seconds."
      },
      {
        title: "UX Instructions on Exception-Unable To Start",
        text:
          "This operation could take 1 to 30 seconds. If unable to start give the user to reinstall the Service via the reinstall button below."
      },
      {
        title: "UX Instructions on Exception-Service not Found",
        text:
          "This operation could take 1 to 30 seconds. If unable to start give the user to reinstall the Service via the reinstall button below."
      },
      {
        title: "UX Instructions on Exception-General Error",
        text: "Show an error message."
      },
      {
        title: "UX Instructions on Redirect",
        text: "Redirect to support article."
      },
      {
        title: "UX Instructions on Chat with Support",
        text:
          "This operation allows the user to chat with CSP Support Team via Intercom.io chat widget."
      }
    ]
  }),
  methods: {
    showDialog(text) {
      if (text == "Success") {
        this.dialog = true;
        this.dialogView = 0;
      }
      if (text == "Exception-Unable To Start") {
        this.dialog = true;
        this.dialogView = 1;
      }
      if (text == "Exception-Service not Found") {
        this.dialog = true;
        this.dialogView = 2;
      }
      if (text == "Exception-General Error") {
        this.dialog = true;
        this.dialogView = 3;
      }
      if (text == "Redirect") {
        this.dialog = true;
        this.dialogView = 4;
      }
      if (text == "Chat/Help") {
        this.dialog = true;
        this.dialogView = 5;
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
}
.button-list {
  display: flex;
  flex-direction: row;
  justify-content: center;
}
button {
  padding-top: 10px;
}
</style>