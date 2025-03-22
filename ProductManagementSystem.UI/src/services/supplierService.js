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
  }
};
