<template>
  <div>
    <h2>Product List</h2>
    <div class="CenterPage">
        <label for="nameFilter">Filter by name : </label><br />
        <input name="nameFilter"
          type="text"
          v-model="searchQuery"
          placeholder="Search by product name"
          @input="searchProducts"
        />
    </div>
      <br />
    <div class="CenterPage">
      <table>
        <thead>

          <tr>
            <th>Product Name</th>
            <th>Unit Price</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="product in products" :key="product.id">
            <td>{{ product.productName }}</td>
            <td>{{ product.unitPrice }}</td>
            <td><button @click="deleteProduct(product.id)">Delete</button></td></tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script lang="ts">
  import productService from '@/services/productService';

  export default {
    data() {
      return {
        searchQuery: '',
        products: []
      };
    },
    async created() {
      try {
        this.products = await productService.getAllProducts();
      } catch (error) {
        console.error('Failed to load products:', error);
      }
    },
    methods: {
      async deleteProduct(id) {
        try {
          await productService.deleteProduct(id);
          this.products = this.products.filter(product => product.id !== id);
        } catch (error) {
          console.error('Failed to delete product:', error);
        }
      },
      async searchProducts() {

          try {
            this.products = await productService.searchProducts(this.searchQuery);
          } catch (error) {
            console.error('Error searching products:', error);
          }

      }
    }

  };
</script>

<style scoped>
  table {
      width: 70%; /* عرض الجدول نصف الصفحة */
      border-collapse: collapse; /* لجعل الخطوط بين الخلايا متصلة */
  }

  table, th, td {
      border: 1px solid black; /* إضافة حدود للجدول والخلايا */
  }

  th, td {
      padding: 10px; /* إضافة مسافة داخل الخلايا */
      text-align: center; /* محاذاة النص في المنتصف */
  }

  th {
      background-color: #f2f2f2; /* لون خلفية عناوين الجدول */
  }


  ul {
    list-style-type: none;
    padding: 0;
  }

  li {
    margin: 10px 0;
  }


  .CenterPage {
    display: flex;
    justify-content: center;
    align-items: center;
    margin: 0;
    font-family: Arial, sans-serif;
  }
</style>
