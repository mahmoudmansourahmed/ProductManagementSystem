<template>
  <div>
    <!-- زر للتبديل بين إضافة المنتج وعرض المنتجات -->
    <div>
      <button @click="showAddProduct = true">Add Product</button>
      <button @click="showAddProduct = false">View Products</button>
    </div>

    <!-- عرض المكون المناسب بناءً على الحالة -->
    <AddProduct v-if="showAddProduct" />
    <ProductList v-else />
  </div>
</template>

<script lang="ts">
import AddProduct from '@/components/Product/AddProduct.vue';
import ProductList from '@/components/Product/ProductList.vue';

export default {
  components: {
    AddProduct,
    ProductList,
  },
  data() {
    return {
      showAddProduct: false, // حالة للتبديل بين المكونات
    };
  },
};
</script>

<style scoped>
/* أنماط CSS خاصة بالمكون */
button {
  margin: 5px;
  padding: 10px 20px;
  background-color: #3498db;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

button:hover {
  background-color: #2980b9;
}
</style>
