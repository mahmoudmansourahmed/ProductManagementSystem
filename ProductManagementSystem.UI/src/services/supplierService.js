import axios from 'axios';

const API_URL = import.meta.env.VITE_API_URL + '/suppliers';

export default {
  /**
   * جلب جميع الموردين
   * @returns {Promise<Array>} قائمة الموردين
   */
  async getAllSuppliers() {
    try {
      const response = await axios.get(API_URL);
      return response.data;
    } catch (error) {
      console.error('Error fetching suppliers:', error);
      throw error;
    }
  },

  /**
   * اضافة مورد
   * @param {*} supplier
   * @returns
   */
  async addSupplier(supplier) {
    try {
      const response = await axios.post(API_URL, supplier);
      return response.data;
    } catch (error) {
      console.error('Error adding supplier:', error);
      throw error;
    }
  },

  /**
   * تعديل مورد
   * @param {*} supplier
   * @returns
   */
  async updateSupplier(supplier) {
    try {
      const response = await axios.put(`${API_URL}/${supplier.id}`, supplier);
      return response.data;
    } catch (error) {
      console.error('Error updating supplier:', error);
      throw error;
    }
  },

  /**
   * حذف مورد
   * @param {*} id
   */
  async deleteSupplier(id) {
    try {
      await axios.delete(`${API_URL}/${id}`);
    } catch (error) {
      console.error('Error deleting supplier:', error);
      throw error;
    }
  },

  async getLargestSupplier() {
    try {
      const response = await axios.get(`${API_URL}/largest`);
      return response.data;
    } catch (error) {
      console.error('Error fetching largest supplier:', error);
      throw error;
    }
  }
};

