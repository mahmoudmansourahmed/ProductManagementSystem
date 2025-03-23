import axios from 'axios';

// قراءة رابط API من ملف .env
const API_URL = import.meta.env.VITE_API_URL + '/products';

export default {
  /**
   * جلب جميع المنتجات
   * @returns {Promise<Array>} قائمة المنتجات
   */
  async getAllProducts() {
    try {
      const response = await axios.get(API_URL);
      return response.data;
    } catch (error) {
      console.error('Error fetching products:', error);
      throw error;
    }
  },

  /**
   * جلب منتج بواسطة المعرف
   * @param {number} id - معرف المنتج
   * @returns {Promise<Object>} بيانات المنتج
   */
  async getProductById(id) {
    try {
      const response = await axios.get(`${API_URL}/${id}`);
      return response.data;
    } catch (error) {
      console.error('Error fetching product by ID:', error);
      throw error;
    }
  },

  /**
   * إضافة منتج جديد
   * @param {Object} product - بيانات المنتج الجديد
   * @returns {Promise<Object>} المنتج المضاف
   */
  async addProduct(product) {
    try {
      const response = await axios.post(API_URL, product);
      return response.data;
    } catch (error) {
      console.error('Error adding product:', error);
      throw error;
    }
  },

  /**
   * تحديث منتج موجود
   * @param {Object} product - بيانات المنتج المحدثة
   * @returns {Promise<Object>} المنتج المحدث
   */
  async updateProduct(product) {
    try {
      const response = await axios.put(`${API_URL}/${product.id}`, product);
      return response.data;
    } catch (error) {
      console.error('Error updating product:', error);
      throw error;
    }
  },

  /**
   * حذف منتج بواسطة المعرف
   * @param {number} id - معرف المنتج
   * @returns {Promise<void>}
   */
  async deleteProduct(id) {
    try {
      await axios.delete(`${API_URL}/${id}`);
    } catch (error) {
      console.error('Error deleting product:', error);
      throw error;
    }
  },

  /**
   * جلب المنتجات التي تحتاج إلى إعادة طلب
   * @returns {Promise<Array>} قائمة المنتجات التي تحتاج إلى إعادة طلب
   */
  async getProductsToReorder() {
    try {
      const response = await axios.get(`${API_URL}/reorder`);
      return response.data;
    } catch (error) {
      console.error('Error fetching products to reorder:', error);
      throw error;
    }
  },

  /**
   * البحث في المنتجات
   * @param {*} query
   * @returns
   */
  async searchProducts(query) {
    try {
      const response = await axios.get(`${API_URL}?productName=${query}`);
      return response.data;
    } catch (error) {
      console.error('Error searching products:', error);
      throw error;
    }
  },

  async getProductsToReorder() {
    try {
      const response = await axios.get(`${API_URL}/reorder`);
      return response.data;
    } catch (error) {
      console.error('Error fetching products to reorder:', error);
      throw error;
    }
  },

  async getProductWithMinOrders() {
    try {
      const response = await axios.get(`${API_URL}/min-orders`);
      return response.data;
    } catch (error) {
      console.error('Error fetching product with minimum orders:', error);
      throw error;
    }
  }

};
