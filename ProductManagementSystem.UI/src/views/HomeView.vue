<template>
  <div class="home">
    <h1>Welcome to the Product Management System</h1>
    <p>This is the home page of the application. You can navigate to other pages using the links below:</p>

    <!-- روابط التنقل -->
    <nav>
      <router-link to="/products" class="nav-link">Manage Products</router-link>
    </nav>
  </div>
</template>

<script lang="ts">
export default {
  name: 'HomeView',
};
</script>

<style scoped>


h1 {
  color: #2c3e50;
  margin-bottom: 20px;
}

p {
  color: #34495e;
  font-size: 1.1em;
  margin-bottom: 30px;
}

nav {
  display: flex;
  justify-content: center;
  gap: 20px;
}

.nav-link {
  padding: 10px 20px;
  background-color: #3498db;
  color: white;
  text-decoration: none;
  border-radius: 5px;
  transition: background-color 0.3s ease;
}

.nav-link:hover {
  background-color: #2980b9;
}
</style>
