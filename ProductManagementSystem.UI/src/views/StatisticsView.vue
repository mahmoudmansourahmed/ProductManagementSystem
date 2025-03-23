<template>
  <div>
    <h2>Statistics</h2>
    <div>
      <h3>Products to Reorder</h3>
      <ul>
        <li v-for="product in productsToReorder" :key="product.id">
          {{ product.name }} - {{ product.unitsInStock }} units in stock
        </li>
      </ul>
    </div>

    <div>
      <h3>Largest Supplier</h3>
      <p>{{ largestSupplier.name }} - {{ largestSupplier.productCount }} products</p>
    </div>

    <div>
      <h3>Product with Minimum Orders</h3>
      <p>{{ productWithMinOrders.name }} - {{ productWithMinOrders.unitsOnOrder }} units on order</p>
    </div>
  </div>
</template>

<script lang="ts">
import productService from '@/services/productService';
import supplierService from '@/services/supplierService';

export default {
  data() {
    return {
      productsToReorder: [],
      largestSupplier: {},
      productWithMinOrders: {}
    };
  },
  async created() {
    try {
      this.productsToReorder = await productService.getProductsToReorder();
      this.largestSupplier = await supplierService.getLargestSupplier();
      this.productWithMinOrders = await productService.getProductWithMinOrders();
    } catch (error) {
      console.error('Failed to load statistics:', error);
    }
  }
};
</script>

<style scoped>
  div {
    margin-bottom: 20px;
  }

  ul {
    list-style-type: none;
    padding: 0;
  }

  li {
    margin: 10px 0;
  }
</style>
