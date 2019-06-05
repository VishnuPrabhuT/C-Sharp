<template>
  <header class="core_top-header">
    <div class="core_top-header-store">French Store</div>

    <div class="core_top-header-user-options">
      <a href="#" class="core_user-message">10 days remaining in trial</a>
      <div class="core_user-options-settings">
        <img src="assets/images/core_images/cog_icon.svg">
      </div>
      <div class="core_user-options-notifications">
        <img src="assets/images/core_images/notification_icon.svg">
      </div>

      <div href="#" class="core_user-options-profile">
        <img src="assets/images/dummies/profile_pic.png" id="core_user-options-profile-dropdown">
      </div>
    </div>
  </header>
</template>

<script>
import Popover from "./Popover.vue";
export default {
  name: "top-header",
  components: Popover
};
</script>
