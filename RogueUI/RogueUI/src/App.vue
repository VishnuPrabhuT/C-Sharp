<template>
  <div class="wrapper">
    <store-bar></store-bar>
    <section class="core_main-wrapper" id="main">
      <top-header></top-header>
      <side-nav></side-nav>
      <top-nav></top-nav>
      <main class="core_module-wrapper">
        <csp-table></csp-table>
      </main>
    </section>
  </div>
</template>

<script>
import Home from "./components/Home.vue";
import TopHeader from "./components/TopHeader.vue";
import TopNav from "./components/TopNav.vue";
import SideNav from "./components/SideNav.vue";
import CspTable from "./components/table/Table.vue";
import StoreBar from "./components/StoreBar.vue";

//StoreBar.;
export default {
  name: "app",
  components: {
    Home,
    TopHeader,
    TopNav,
    SideNav,
    CspTable,
    StoreBar
  }
};
</script>

<style>
/* Custom */
/* Custom */

@font-face {
  font-family: "Santral";
  src: url("./assets/fonts/Santral-Medium.woff2") format("woff2"),
    url("./assets/fonts/Santral-Medium.woff") format("woff");
  font-weight: 400;
  font-style: normal;
}
@font-face {
  font-family: "Santral";
  src: url("./assets/fonts/Santral-Book.woff2") format("woff2"),
    url("./assets/fonts/Santral-Book.woff") format("woff");
  font-weight: 300;
  font-style: normal;
}
@font-face {
  font-family: "Santral";
  src: url("./assets/fonts/Santral-Bold.woff2") format("woff2"),
    url("./assets/fonts/Santral-Bold.woff") format("woff");
  font-weight: 500;
  font-style: normal;
}

* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  outline: none;
}

input {
  font-family: inherit;
}

body {
  font-family: "Santral", Helvetica, Arial, sans-serif;
  font-weight: 400;
  color: white;
  font-size: 16px;
  background-repeat: no-repeat;
  background-attachment: fixed;
  background-image: linear-gradient(-45deg, #24c6dc 0%, #514a9d 100%);
}

.wrapper:after {
  content: "";
  display: grid;
  clear: both;
}

.core_storebar {
  width: 60px;
  background: rgba(0, 0, 0, 0);
  box-shadow: 0px 0px 20px 0px rgba(0, 0, 0, 0.16);
  background-image: linear-gradient(-135deg, #4e479b 0%, #4271b1 100%);
  position: absolute;
  transition: width 500ms cubic-bezier(0.785, 0.135, 0.15, 0.86);
  overflow: hidden;
  bottom: 0;
  top: 0;
}
.core_storebar.is-expanded {
  background-image: linear-gradient(-135deg, #4e479b 0%, #4271b1 100%);
  width: 200px;
  z-index: 9999;
}
.core_main-wrapper {
  height: 100vh;
  margin-left: 60px;
  overflow: hidden;
}
.core_main-wrapper:after {
  content: "";
  display: table;
  clear: both;
}

.core_main-wrapper > .core_top-header {
  padding: 35px 35px 0px 35px;
}
.core_main-wrapper > .core_top-header:after {
  content: "";
  display: table;
  clear: both;
}
.core_main-wrapper > .core_top-header > .core_top-header-store {
  float: left;
  color: white;
  font-size: 20px;
  font-weight: 400;
}
.core_main-wrapper > .core_top-header > .core_top-header-user-options {
  color: white;
  font-size: 22px;
  font-weight: 400;
  text-align: right;
}

.core_main-wrapper > .core_side-nav {
  float: left;
  width: 180px;
  height: 100vh;
  padding: 35px 12px 35px 12px;
  text-align: center;
}

.core_main-wrapper > .core_top-nav {
  padding: 35px 12px 12px 12px;
}

.core_main-wrapper > .core_module-wrapper {
  height: 100vh;
  margin: 10px;
  padding-left: 10px;
}

/*
 * Container style
 */
.ps {
  overflow: hidden !important;
  overflow-anchor: none;
  -ms-overflow-style: none;
  touch-action: auto;
  -ms-touch-action: auto;
}

/*
 * Scrollbar rail styles
 */
.ps__rail-x {
  display: none;
  opacity: 0;
  transition: background-color 0.2s linear, opacity 0.2s linear;
  -webkit-transition: background-color 0.2s linear, opacity 0.2s linear;
  height: 15px;
  /* there must be 'bottom' or 'top' for ps__rail-x */
  bottom: 0px;
  /* please don't change 'position' */
  position: absolute;
}

.ps__rail-y {
  display: none;
  opacity: 0;
  transition: background-color 0.2s linear, opacity 0.2s linear;
  -webkit-transition: background-color 0.2s linear, opacity 0.2s linear;
  width: 15px;
  /* there must be 'right' or 'left' for ps__rail-y */
  right: 0;
  /* please don't change 'position' */
  position: absolute;
}

.ps--active-x > .ps__rail-x,
.ps--active-y > .ps__rail-y {
  display: block;
  background-color: transparent;
  width: 0;
}

.ps:hover > .ps__rail-x,
.ps:hover > .ps__rail-y,
.ps--focus > .ps__rail-x,
.ps--focus > .ps__rail-y,
.ps--scrolling-x > .ps__rail-x,
.ps--scrolling-y > .ps__rail-y {
  opacity: 0.6;
}

.ps .ps__rail-x:hover,
.ps .ps__rail-y:hover,
.ps .ps__rail-x:focus,
.ps .ps__rail-y:focus,
.ps .ps__rail-x.ps--clicking,
.ps .ps__rail-y.ps--clicking {
  background-color: #eee;
  opacity: 0.9;
}

/*
 * Scrollbar thumb styles
 */
.ps__thumb-x {
  background-color: #aaa;
  border-radius: 6px;
  transition: background-color 0.2s linear, height 0.2s ease-in-out;
  -webkit-transition: background-color 0.2s linear, height 0.2s ease-in-out;
  height: 6px;
  /* there must be 'bottom' for ps__thumb-x */
  bottom: 2px;
  /* please don't change 'position' */
  position: absolute;
}

.ps__thumb-y {
  background-color: #aaa;
  border-radius: 6px;
  transition: background-color 0.2s linear, width 0.2s ease-in-out;
  -webkit-transition: background-color 0.2s linear, width 0.2s ease-in-out;
  width: 3px;
  /* there must be 'right' for ps__thumb-y */
  right: 2px;
  /* please don't change 'position' */
  position: absolute;
}

.ps__rail-x:hover > .ps__thumb-x,
.ps__rail-x:focus > .ps__thumb-x,
.ps__rail-x.ps--clicking .ps__thumb-x {
  background-color: #999;
  height: 11px;
}

.ps__rail-y:hover > .ps__thumb-y,
.ps__rail-y:focus > .ps__thumb-y,
.ps__rail-y.ps--clicking .ps__thumb-y {
  background-color: #999;
}

/* MS supports */
@supports (-ms-overflow-style: none) {
  .ps {
    overflow: auto !important;
  }
}
@media screen and (-ms-high-contrast: active), (-ms-high-contrast: none) {
  .ps {
    overflow: auto !important;
  }
}
.core_storebar {
  position: fixed;
  z-index: 100;
}
.core_storebar.is-expanded > .core_storebar-search {
  border-bottom: 1px solid rgba(0, 0, 0, 0.14);
}
.core_storebar > .core_storebar-add-new {
  padding: 10px 10px 20px 10px;
  width: 200px;
  border-top: 1px solid rgba(0, 0, 0, 0.1);
  box-shadow: 0px 5px 20px 3px rgba(0, 0, 0, 0.16);
  font-size: 13px;
}
.core_storebar > .core_storebar-add-new > span {
  position: relative;
  bottom: 4px;
  left: 11px;
}
.core_storebar > .core_storebar-add-new > .core_storebar-add-new-plus {
  width: 39px;
  height: 39px;
  display: inline-block;
  padding: 10px 13px;
  font-size: 23px;
}
.core_storebar > .core_storebar-enterprise {
  width: 200px;
  margin-left: 10px;
}
.core_storebar > .core_storebar-enterprise:after {
  content: "";
  display: table;
  clear: both;
}
.core_storebar > .core_storebar-enterprise > .core_storebar-enterprise-icon {
  margin-top: -10px;
  float: left;
}
.core_storebar > .core_storebar-enterprise > .core_storebar-enterprise-name {
  font-size: 14px;
  float: left;
  position: relative;
  top: 20px;
  left: 10px;
}
.core_storebar > .core_storebar-search {
  height: 39px;
  position: relative;
  left: 10px;
  margin-bottom: 10px;
  width: 200px;
}
.core_storebar > .core_storebar-search:after {
  content: "";
  display: table;
  clear: both;
}
.core_storebar > .core_storebar-search > .core_search-icon {
  position: relative;
  width: 10px;
  top: 10px;
  left: 12px;
  cursor: pointer;
  float: left;
}
.core_storebar > .core_storebar-search > .core_storebar-input {
  float: left;
  width: 150px;
  background-color: transparent;
  border: none;
  position: relative;
  font-size: 16px;
  font-weight: 400;
  top: 7px;
  left: 30px;
  padding: 2px 10px;
  color: white;
  outline: none;
}
.core_storebar
  > .core_storebar-search
  > .core_storebar-input::-webkit-input-placeholder {
  color: rgba(255, 255, 255, 0.5);
}
.core_storebar
  > .core_storebar-search
  > .core_storebar-input:-ms-input-placeholder {
  color: rgba(255, 255, 255, 0.5);
}
.core_storebar
  > .core_storebar-search
  > .core_storebar-input::-ms-input-placeholder {
  color: rgba(255, 255, 255, 0.5);
}
.core_storebar > .core_storebar-search > .core_storebar-input::placeholder {
  color: rgba(255, 255, 255, 0.5);
}
.core_storebar > .core_storebar-list {
  height: calc(100vh - 180px);
  position: relative;
  overflow: hidden;
}
.core_storebar > .core_storebar-list > .core_storebar-item {
  width: 200px;
  margin-left: 10px;
  margin-bottom: 10px;
  cursor: pointer;
  transition: background-color 100ms ease-out;
  overflow: hidden;
}
.core_storebar > .core_storebar-list > .core_storebar-item:after {
  content: "";
  display: table;
  clear: both;
}
.core_storebar
  > .core_storebar-list
  > .core_storebar-item
  > .core_storebar-item-store-slug {
  background-color: rgba(255, 255, 255, 0.1);
  color: rgba(255, 255, 255, 0.37);
  border-radius: 3px;
  width: 39px;
  height: 39px;
  font-size: 13px;
  text-align: center;
  line-height: 39px;
  text-transform: uppercase;
  float: left;
}
.core_storebar
  > .core_storebar-list
  > .core_storebar-item:hover
  > .core_storebar-item-store-slug,
.core_storebar
  > .core_storebar-list
  > .core_storebar-item.is-selected
  > .core_storebar-item-store-slug {
  background-color: #6b86d3;
}
.core_storebar
  > .core_storebar-list
  > .core_storebar-item:hover
  > .core_storebar-item-store-name,
.core_storebar
  > .core_storebar-list
  > .core_storebar-item.is-selected
  > .core_storebar-item-store-name {
  color: #e0ebb1;
}
.core_storebar
  > .core_storebar-list
  > .core_storebar-item.is-selected
  > .core_storebar-item-store-slug {
  background-color: none;
  background: url("./assets/images/core_images/storebar_item_bg.svg") no-repeat
    transparent;
  color: #e0ebb1;
}
.core_storebar
  > .core_storebar-list
  > .core_storebar-item
  > .core_storebar-item-store-name {
  float: left;
  padding: 13px 11px 0 13px;
  color: white;
  font-size: 13px;
}

.core_main-wrapper > .core_top-header > .core_top-header-user-options:after {
  content: "";
  display: table;
  clear: both;
}
.core_main-wrapper > .core_top-header > .core_top-header-user-options > div {
  display: inline-block;
  margin: 0 15px;
}
.core_main-wrapper
  > .core_top-header
  > .core_top-header-user-options
  > .core_user-message {
  position: relative;
  bottom: 2px;
  font-size: 13px;
  font-weight: 400;
  background-color: rgba(0, 0, 0, 0.1);
  padding: 12px 20px 10px 20px;
  border-radius: 15px;
  color: white;
  text-decoration: none;
  transition: color 250ms ease;
  margin-right: 14px;
}
.core_main-wrapper
  > .core_top-header
  > .core_top-header-user-options
  > .core_user-message:hover {
  color: #e0ebb1;
}
.core_main-wrapper
  > .core_top-header
  > .core_top-header-user-options
  > .core_user-options-profile {
  cursor: pointer;
  overflow: hidden;
  border: 1px solid white;
  border-radius: 100%;
  width: 40px;
  height: 40px;
  vertical-align: middle;
  box-shadow: 1px 0 14px 2px rgba(0, 0, 0, 0.16);
}
.core_main-wrapper
  > .core_top-header
  > .core_top-header-user-options
  > .core_user-options-profile
  > img {
  width: 100%;
}

.core_top-nav > .core_top-nav-list > .core_top-nav-item {
  display: inline;
  font-size: 14px;
  padding: 7px 30px 5px 30px;
  border-radius: 30px;
  text-align: center;
  margin-right: 5px;
  color: white;
  text-decoration: none;
  transition: background-color 250ms ease;
}
.core_top-nav > .core_top-nav-list > .core_top-nav-item.is-active {
  background-color: rgba(0, 0, 0, 0.1);
}
.core_top-nav > .core_top-nav-list > .core_top-nav-item:hover {
  background-color: rgba(0, 0, 0, 0.1);
}

.core_side-nav > .core_side-nav-list > .core_side-nav-item {
  text-align: center;
  text-decoration: none;
  display: block;
  margin-bottom: 40px;
}
.core_side-nav > .core_side-nav-list > .core_side-nav-item:hover > span {
  color: #e0ebb1;
}
.core_side-nav > .core_side-nav-list > .core_side-nav-item > img {
  padding: 0px 0 10px 0;
}
.core_side-nav > .core_side-nav-list > .core_side-nav-item > span {
  display: block;
  color: white;
  font-size: 14px;
}
.core_side-nav
  > .core_side-nav-list
  > .core_side-nav-item
  > .core_side-nav-border {
  display: none;
}
.core_side-nav
  > .core_side-nav-list
  > .core_side-nav-item.is-selected
  .core_side-nav-border {
  display: block;
}
</style>
