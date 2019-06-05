<template>
  <div
    @click.prevent.stop
    class="popover-wrapper"
    v-bind:class="{'is-visible': isVisible, 'on-right': onRight}"
  >
    <slot></slot>
  </div>
</template>

<script>
export default {
  name: "csp-popover",
  props: ["target", "on-right"],
  data() {
    return {
      isVisible: false
    };
  },
  mounted() {
    document.querySelector(this.target).addEventListener("click", event => {
      this.isVisible = true;

      var targetWidth = document.querySelector(this.target).offsetWidth;
      var targetX = document.querySelector(this.target).offsetLeft;

      if (this.onRight) {
        this.$el.style.left = targetX - 160 + targetWidth / 2 + "px";
      } else {
        this.$el.style.left = targetX - 30 + targetWidth / 2 + "px";
      }
    });

    document.querySelectorAll(".popover-wrapper ul li a").forEach(item => {
      item.addEventListener("click", () => {
        this.isVisible = false;
      });
    });

    document.body.addEventListener("click", event => {
      if (event.target != document.querySelector(this.target)) {
        this.isVisible = false;
      }
    });
  }
};
</script>
