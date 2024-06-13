using AutoMapper;
using Ecom.api.DTOS;
using Ecom.core.Entities;
using Ecom.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _UOW;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork UOW , IMapper mapper)
        {
            _UOW  = UOW;
            _mapper = mapper;
        }
        [HttpGet("get-all-products")]
        public async Task<IActionResult> get()
        {
            var res = await _UOW.productRepository.GetAllAsync(x => x.Category);
            var result = _mapper.Map<List<ProductDTO>>(res);

            return Ok(result);

        }

        [HttpGet("get-product-by-id/{id}")]
        public async Task<IActionResult> get(int id)
        {
            var res = await _UOW.productRepository.GetByIdAsync(id , x=>x.Category);
            var result = _mapper.Map<ProductDTO>(res);
            return Ok(result);
        }
        [HttpPost("add-new-product")]
        public async Task<IActionResult> Post(CreateProductDTO productDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = _mapper.Map<Product>(productDTO);
                    await _UOW.productRepository.AddAsync(res);
                    return Ok(res);
                }
                return BadRequest(productDTO);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return BadRequest();

        }
    }
}
