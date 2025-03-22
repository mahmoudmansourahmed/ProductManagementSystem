using ProductManagementSystem.Domain.Entity;
using ProductManagementSystem.Domain.IServices;
using ProductManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Unit> _unitRepository;
        private readonly IRepository<Supplier> _supplierRepository;

        public ProductService(IRepository<Product> productRepository, IRepository<Unit> unitRepository, IRepository<Supplier> supplierRepository)
        {
            _productRepository = productRepository;
            _unitRepository = unitRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            //var result = from o in await _productRepository.GetAllAsync() join o2 in await _unitRepository.GET
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsToReorderAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Where(p => p.UnitsInStock <= p.ReorderLevel).ToList();
        }
    }
}
