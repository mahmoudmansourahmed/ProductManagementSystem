<template>
  <div id="app">
    <h1>Product Management System</h1><br />
    <nav>
      <router-link to="/">Home</router-link> |
      <router-link to="/products">Products</router-link>
    </nav>
    <router-view />
  </div>
</template>

<script lang="ts">
export default {
  name: 'App'
};
</script>
