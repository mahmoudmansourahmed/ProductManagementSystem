import axios from 'axios';

const API_URL = import.meta.env.VITE_API_URL + '/units';

export default {
  /**
   * جلب جميع الوحدات
   * @returns {Promise<Array>} قائمة الوحدات
   */
  async getAllUnits() {
    try {
      const response = await axios.get(API_URL);
      return response.data;
    } catch (error) {
      console.error('Error fetching units:', error);
      throw error;
    }
  }
};
