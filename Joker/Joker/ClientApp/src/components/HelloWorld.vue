<template>
  <div class="hello">
    <h1>{{ msg }}</h1>

    <h4>{{data}}</h4>
    <div id="supers">
      <h4 @click="getB">Batman</h4>
      <h4 @click="getG">GreenLantern</h4>
      <h4 @click="getS">Spiderman</h4>
    </div>
    <div id="supers">
      <h4>{{batman}}</h4>
      <h4>{{greenlantern}}</h4>
      <h4>{{spiderman}}</h4>
    </div>
  </div>
</template>

<script>
export default {
  name: "HelloWorld",
  props: {
    msg: String
  },
  data() {
    return { data: "", batman: "", greenlantern: "", spiderman: "" };
  },
  created() {
    //Intercom("show");
    // fetch("api/Data/Batman")
    //   .then(res => res.json())
    //   .then(d => {
    //     this.data = d;
    //   });
  },
  methods: {
    getB() {
      //Intercom("show");
      fetch("api/Data/Batman")
        .then(res => res.json())
        .then(d => {
          this.data = d;
          this.batman = d;
        });
    },
    getG() {
      //Intercom("hide");
      fetch("api/Data/GreenLantern")
        .then(res => res.json())
        .then(d => {
          this.data = d;
          this.greenlantern = d;
        });
    },
    getS() {
      fetch("api/Data/Spiderman")
        .then(res => res.json())
        .then(d => {
          this.data = d;
          this.spiderman = d;
        });
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="sass">
#supers
    display: flex
    flex-direction: row
    line-height: 100px
    justify-content: space-evenly
    align-content: center
    width: 100%
    font-size: 2em
    border: 1px

    h4
        border-style: double
</style>
