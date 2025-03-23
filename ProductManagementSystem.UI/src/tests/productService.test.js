import { describe, it, expect, vi } from 'vitest';
import axios from 'axios';
import productService from '@/services/productService';

// Mock axios
vi.mock('axios');

describe('productService', () => {
  it('should fetch all products', async () => {
    const mockProducts = [{ id: 1, name: 'Product 1', unitPrice: 10 }];
    axios.get.mockResolvedValue({ data: mockProducts });

    const products = await productService.getAllProducts();
    expect(products).toEqual(mockProducts);
    expect(axios.get).toHaveBeenCalledWith(import.meta.env.VITE_API_URL + '/products');
  });

  it('should add a new product', async () => {
    const newProduct = { name: 'New Product', unitPrice: 20 };
    axios.post.mockResolvedValue({ data: newProduct });

    const addedProduct = await productService.addProduct(newProduct);
    expect(addedProduct).toEqual(newProduct);
    expect(axios.post).toHaveBeenCalledWith(import.meta.env.VITE_API_URL + '/products', newProduct);
  });

  it('should handle errors when fetching products', async () => {
    axios.get.mockRejectedValue(new Error('Network Error'));

    await expect(productService.getAllProducts()).rejects.toThrow('Network Error');
  });
});
