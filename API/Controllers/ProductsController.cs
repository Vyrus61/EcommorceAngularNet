using Core.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public readonly IProductRepository _repo;

        public StoreContext Context { get; }
        public ProductsController(IProductRepository repo)
        {
            
            _repo=repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            var products = await _repo.GetProductAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){
            return await _repo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands(){
            var productBrands = await _repo.GetProductBrandsAsync();
            return Ok(productBrands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes(){
            var productTypes = await _repo.GetProductTypesAsync();
            return Ok(productTypes);
        }
    }
}