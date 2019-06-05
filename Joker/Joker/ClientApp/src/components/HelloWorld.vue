<template>
  <div class="hello">
    <h1>{{ msg }}</h1>

    <h1>Today's Date</h1>
    <h4>{{data}}</h4>
    <div id="supers">
      <h4 @click="getB">Batman</h4>
      <h4 @click="getG">GreenLantern</h4>
      <h4 @click="getS">Spiderman</h4>
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
    return { data: "" };
  },
  created() {
    fetch("api/Data/Batman")
      .then(res => res.json())
      .then(d => {
        this.data = d;
      });
  },
  methods: {
    getB() {
      fetch("api/Data/Batman")
        .then(res => res.json())
        .then(d => {
          this.data = d;
        });
    },
    getG() {
      fetch("api/Data/GreenLantern")
        .then(res => res.json())
        .then(d => {
          this.data = d;
        });
    },
    getS() {
      fetch("api/Data/Spiderman")
        .then(res => res.json())
        .then(d => {
          this.data = d;
        });
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="sass">
h3
  margin: 40px 0 0

#supers
    display: flex
    flex-direction: row
    line-height: 100px
    justify-content: space-evenly
    align-content: center
    width: 100%
    font-size: 2em
</style>
