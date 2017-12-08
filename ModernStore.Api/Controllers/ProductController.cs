using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Repositories;

namespace ModernStore.Api.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        ProductController(IProductRepository repository) => _repository = repository;

        [HttpGet]
        [Route("api/products")]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }
    }
}
