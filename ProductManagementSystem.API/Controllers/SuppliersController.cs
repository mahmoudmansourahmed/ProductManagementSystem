using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Domain.Entity;
using ProductManagementSystem.Domain;

namespace SupplierManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly IRepository<Supplier> _supplierRepository;

        public SuppliersController(IRepository<Supplier> supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Suppliers = await _supplierRepository.GetAllAsync();
            return Ok(Suppliers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Supplier = await _supplierRepository.GetByIdAsync(id);
            if (Supplier == null)
            {
                return NotFound();
            }
            return Ok(Supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Supplier Supplier)
        {
            await _supplierRepository.AddAsync(Supplier);
            return CreatedAtAction(nameof(GetById), new { id = Supplier.Id }, Supplier);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Supplier Supplier)
        {
            if (id != Supplier.Id)
            {
                return BadRequest();
            }

            await _supplierRepository.UpdateAsync(Supplier);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _supplierRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
