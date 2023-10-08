using Carglass.TechnicalAssessment.Backend.BL;
using Carglass.TechnicalAssessment.Backend.BL.Products;
using Carglass.TechnicalAssessment.Backend.Dtos;
using Carglass.TechnicalAssessment.Backend.Dtos.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Carglass.TechnicalAssessment.Backend.Api.Controllers
{    
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductsController(IProductAppService productAppService)
        {
            this._productAppService = productAppService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // TODO Implement       
            return Ok(_productAppService.GetAll());

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_productAppService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductDTO dto)
        {
            // TODO Implement
            _productAppService.Create(dto);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProductDTO dto)
        {
            _productAppService.Update(dto);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] ProductDTO dto)
        {
            // TODO Implement
            _productAppService.Delete(dto);
            return Ok();
        }
    }
}
