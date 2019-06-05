<template>
  <aside
    class="core_storebar"
    v-on:click.prevent.stop
    v-bind:class="{'is-expanded': isExpanded }"
    id="core_storebar"
  >
    <div class="core_storebar-enterprise">
      <div class="core_storebar-enterprise-icon">
        <img src="assets/images/core_images/storebar_heading.svg">
      </div>
      <div class="core_storebar-enterprise-name">Enterprise Name</div>
    </div>

    <div class="core_storebar-search">
      <div v-on:click="toggleSearch" class="core_search-icon">
        <img src="assets/images/core_images/search_icon.svg">
      </div>
      <input
        v-model="searchInput"
        class="core_storebar-input"
        type="text"
        placeholder="Search a Store"
      >
    </div>
    <div class="core_storebar-list">
      <div
        v-for="(store, index) in filteredStores"
        v-on:click="onStoreSelected(store)"
        class="core_storebar-item"
        v-bind:class="{'is-selected': store.isSelected}"
        :key="index"
      >
        <div class="core_storebar-item-store-slug">{{ store.slug }}</div>
        <div class="core_storebar-item-store-name">{{ store.name }}</div>
      </div>
    </div>
    <div class="core_storebar-add-new">
      <div class="core_storebar-add-new-plus">+</div>
      <span>Add a new Store</span>
    </div>
  </aside>
</template>
<script>
import Vue from "vue";
import Scrollbar from "perfect-scrollbar";
export default {
  name: "store-bar",
  mounted() {
    this.sc = new Scrollbar(".core_storebar-list", {
      suppressScrollX: true
    });
    document
      .querySelector(".core_storebar-item.is-selected")
      .scrollIntoView({ block: "start" });
  },
  data() {
    return {
      sc: "",
      isExpanded: false,
      searchInput: "",
      stores: [
        { name: "French Store 1", slug: "FS1", isSelected: false },
        { name: "French Store 2", slug: "FS2", isSelected: false },
        { name: "French Store 3", slug: "FS3", isSelected: true },
        { name: "French Store 4", slug: "FS4", isSelected: false },
        { name: "French Store 5", slug: "FS5", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Store 6", slug: "FS6", isSelected: false },
        { name: "French Last", slug: "LST", isSelected: false }
      ]
    };
  },
  methods: {
    toggleSearch() {
      this.isExpanded = !this.isExpanded;
      if (this.isExpanded) {
        setTimeout(() => {
          document.querySelector(".core_storebar-input").focus();
        }, 500);
      }
    },
    onStoreSelected(store) {
      this.stores.forEach(s => {
        s.isSelected = false;
      });
      store.isSelected = true;
    }
  },
  computed: {
    filteredStores() {
      return this.stores.filter(store => {
        var storeLowerCase = store.name.toLowerCase();

        if (this.isExpanded) {
          return storeLowerCase.indexOf(this.searchInput.toLowerCase()) !== -1;
        } else {
          return true;
        }
      });
    }
  }
};
</script>
