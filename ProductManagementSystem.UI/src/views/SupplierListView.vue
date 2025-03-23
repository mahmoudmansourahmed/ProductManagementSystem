<template>
  <div>
    <h2>Supplier List</h2>
    <table>
      <thead>
        <tr>
          <th>ID</th>
          <th>Name</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="supplier in suppliers" :key="supplier.id">
          <td>{{ supplier.id }}</td>
          <td>{{ supplier.supplierName }}</td>
          <td>
            <button @click="editSupplier(supplier)">Edit</button>
            <button @click="deleteSupplier(supplier.id)">Delete</button>
          </td>
        </tr>
      </tbody>
    </table>

    <h3>Add New Supplier</h3>
    <form @submit.prevent="addSupplier">
      <div>
        <label for="supplierName">Supplier Name:</label>
        <input
          type="text"
          id="supplierName"
          v-model="newSupplier.supplierName"
          required
          placeholder="Enter supplier name"
        />
      </div>
      <button type="submit">Add Supplier</button>
    </form>
  </div>
</template>

<script lang="ts">
import supplierService from '@/services/supplierService';

export default {
  data() {
    return {
      suppliers: [],
      newSupplier: {
        supplierName: ''
      }
    };
  },
  async created() {
    try {
      this.suppliers = await supplierService.getAllSuppliers();
    } catch (error) {
      console.error('Failed to load suppliers:', error);
    }
  },
  methods: {
    async addSupplier() {
      try {
        const newSupplier = await supplierService.addSupplier(this.newSupplier);
        this.suppliers.push(newSupplier);
        this.newSupplier = { supplierName: '' };
      } catch (error) {
        console.error('Failed to add supplier:', error);
      }
    },
    async deleteSupplier(id) {
      try {
        await supplierService.deleteSupplier(id);
        this.suppliers = this.suppliers.filter(supplier => supplier.id !== id);
      } catch (error) {
        console.error('Failed to delete supplier:', error);
      }
    },
    editSupplier(supplier) {
      // يمكنك تنفيذ منطق التعديل هنا
      console.log('Edit supplier:', supplier);
    }
  }
};
</script>

<style scoped>
  table {
    width: 100%;
    border-collapse: collapse;
    margin-bottom: 20px;
  }

  th, td {
    border: 1px solid #ddd;
    padding: 8px;
    text-align: left;
  }

  th {
    background-color: #f4f4f4;
  }

  button {
    margin-right: 5px;
  }
</style>
