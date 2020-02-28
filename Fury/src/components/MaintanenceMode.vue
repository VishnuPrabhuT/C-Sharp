<template>
  <v-app id="inspire">
    <v-app-bar app color="indigo" dark>
      <v-toolbar-title>Maintenence Mode</v-toolbar-title>
    </v-app-bar>

    <v-content>
      <v-container fluid fill-height>
        <v-layout align-center justify-center>
          <div class="container3">
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
            <v-alert dense text type="success">
              Maintenance Mode Alert CSP is down for Maintenence and will be back with
              <strong>all your files processed.</strong>
            </v-alert>
            <div class="button-list">
              <v-menu offset-y>
                <template v-slot:activator="{ on }">
                  <v-btn color="primary" dark v-on="on">Chat with Support</v-btn>
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
                  <v-btn color="primary" dark v-on="on">Go to Knowledge-base</v-btn>
                </template>
                <v-list>
                  <v-list-item v-for="(item, index) in items2" :key="index">
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
  name: "MaintanenceMode",
  data: () => ({
    dialog: false,
    items1: [{ title: "Chat/Help" }],
    items2: [{ title: "Knowledge Base" }],
    dialogView: 0,
    dialogData: [
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
      if (text == "Chat/Help") {
        this.dialog = true;
        this.dialogView = 0;
      }
      if (text == "Knowledge Base") {
        this.dialog = true;
        this.dialogView = 1;
      }
    }
  }
};
</script>
<style scoped>
.container3 {
  display: flex;
  height: 45vh;
  flex-direction: column;
  justify-content: space-evenly;
  text-align: center;
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