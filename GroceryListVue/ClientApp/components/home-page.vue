<template>
<div>
  <div>
        <h1>{{title}}</h1>
    </div>
    <table>
        <thead>
            <th>ID</th>
            <th>Name</th>
            <th>Quantity</th>
            <th>Price</th>
            <th>Description</th>
        </thead>
        <tbody>
          <tr v-for="row in rows" :key="row.id">
            <td>{{row.id}}</td>
            <td>{{row.item_Name}}</td>
            <td>{{row.quantity}}</td>
            <td>{{row.price}}</td>
            <td>{{row.description}}</td>
          </tr>
        </tbody>
    </table>
    
</div>
</template>

<script>
export default {
  name: "home",
  data() {
    return {
      title: "Vue!",
      rows: null
    };
  },
  mounted() {
    fetch("api/grocerylist")
      .then(response => response.json())
      .then(data => {
        this.rows = data;
      });
  },
  computed() {}
};
</script>

<style>
</style>
