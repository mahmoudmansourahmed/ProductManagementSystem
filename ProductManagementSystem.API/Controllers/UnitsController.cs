using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Domain.Entity;
using ProductManagementSystem.Domain;

namespace ProductManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitsController : ControllerBase
    {
        private readonly IRepository<Unit> _unitRepository;

        public UnitsController(IRepository<Unit> unitRepository)
        {
            _unitRepository = unitRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Units = await _unitRepository.GetAllAsync();
            return Ok(Units);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Unit = await _unitRepository.GetByIdAsync(id);
            if (Unit == null)
            {
                return NotFound();
            }
            return Ok(Unit);
        }
    }
}
