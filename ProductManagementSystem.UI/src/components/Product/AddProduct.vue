<template>
  <div>
    <h2>Add New Product</h2>
    <form @submit.prevent="addProduct">
      <!-- حقل إدخال لاسم المنتج -->
      <div>
        <label for="name">Product Name:</label>
        <input
          type="text"
          id="name"
          v-model="product.productName"
          required
          placeholder="Enter product name"
        />
      </div>

      <!-- حقل إدخال لسعر المنتج -->
      <div>
        <label for="unitPrice">Unit Price:</label>
        <input
          type="number"
          id="unitPrice"
          v-model="product.unitPrice"
          required
          placeholder="Enter unit price"
        />
      </div>

      <!-- قائمة منسدلة للموردين -->
      <div>
        <label for="supplierId">Supplier:</label>
        <select id="supplierId" v-model="product.supplierId" required>
          <option value="">Select a supplier</option>
          <option v-for="supplier in suppliers" :key="supplier.id" :value="supplier.id">
            {{ supplier.supplierName }}
          </option>
        </select>
      </div>

      <!-- قائمة منسدلة للوحدات -->
      <div>
        <label for="quantityPerUnitId">Unit:</label>
        <select id="quantityPerUnitId" v-model="product.quantityPerUnitId" required>
          <option value="">Select a unit</option>
          <option v-for="unit in units" :key="unit.id" :value="unit.id">
            {{ unit.unitName }}
          </option>
        </select>
      </div>

      <div>
        <label for="ReorderLevel">Reorder Level:</label>
        <input
          type="number"
          id="ReorderLevel"
          v-model="product.reorderLevel"
          required
          placeholder="Enter Reorder Level"
        />
      </div>

      <div>
        <label for="unitsInStock">units In Stock:</label>
        <input
          type="number"
          id="unitsInStock"
          v-model="product.unitsInStock"
          required
          placeholder="Enter units In Stock"
        />
      </div>

      <div>
        <label for="unitsOnOrder">units On Order:</label>
        <input
          type="number"
          id="unitsOnOrder"
          v-model="product.unitsOnOrder"
          required
          placeholder="Enter Units On Order"
        />
      </div>


      <!-- زر لإضافة المنتج -->
      <button type="submit">Add Product</button>
    </form>

    <!-- عرض رسالة نجاح أو خطأ -->
    <div v-if="message" :class="messageClass">
      {{ message }}
    </div>
  </div>
</template>


<script lang="ts">
import productService from '@/services/productService';
import supplierService from '@/services/supplierService';
import unitService from '@/services/unitService';


export default {
  data() {
    return {
      product: {
        productName: '',
        unitPrice: 0,
        supplierId: null, // معرف المورد
        quantityPerUnitId: null, // معرف الوحدة
        reorderLevel: 0,
        unitsInStock: 0,
        unitsOnOrder: 0
      },
      suppliers: [], // قائمة الموردين
      units: [], // قائمة الوحدات
      message: '', // رسالة نجاح أو خطأ
      messageClass: '', // فئة CSS للرسالة
    };
  },
  async created() {
    // جلب الموردين عند تحميل المكون
    try {
      this.suppliers = await supplierService.getAllSuppliers();
    } catch (error) {
      console.error('Failed to load suppliers:', error);
    }

    // جلب الوحدات عند تحميل المكون
    try {
      this.units = await unitService.getAllUnits();
    } catch (error) {
      console.error('Failed to load units:', error);
    }
  },
  methods: {
    async addProduct() {
      try {
        console.log('Sending product data:', this.product); // تسجيل البيانات المرسلة
        const newProduct = await productService.addProduct(this.product);
        this.message = 'Product added successfully!';
        this.messageClass = 'success';
        this.product = { productName: '', unitPrice: 0, supplierId: null, quantityPerUnitId: null }; // إعادة تعيين النموذج
      } catch (error) {
        this.message = 'Failed to add product. Please try again.';
        this.messageClass = 'error';
        console.error('Error adding product:', error);
      }
    },
  },
};
</script>

<style scoped>
/* أنماط CSS خاصة بالمكون */
form {
  max-width: 400px;
  margin: 0 auto;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 5px;
  background-color: #f9f9f9;
}

div {
  margin-bottom: 15px;
}

label {
  display: block;
  margin-bottom: 5px;
  font-weight: bold;
}

input, select {
  width: 100%;
  padding: 8px;
  box-sizing: border-box;
  border: 1px solid #ccc;
  border-radius: 4px;
}

button {
  padding: 10px 15px;
  background-color: #28a745;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

button:hover {
  background-color: #218838;
}

.success {
  color: green;
  margin-top: 10px;
}

.error {
  color: red;
  margin-top: 10px;
}
</style>
