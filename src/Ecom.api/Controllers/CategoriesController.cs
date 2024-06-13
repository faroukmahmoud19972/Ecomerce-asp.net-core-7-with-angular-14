using AutoMapper;
using Ecom.api.DTOS;
using Ecom.core.Entities;
using Ecom.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ecom.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriesController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("Get-All-Categories")]
        public async Task<IActionResult> Get()
        {

            var allcategories = await _unitOfWork.categoryRepository.GetAllAsync();

            var res = _mapper.Map<IReadOnlyList<Category>,IReadOnlyList<ListingCategoryDTO>>(allcategories);

            //var res = allcategories.Select(a => new ListingCategoryDTO
            //{
            //    id = a.Id,
            //    Name = a.Name,
            //    Description = a.Description,
            //}).ToList();

            if (allcategories is not null)
            {
                return Ok(res);
            }
            return NotFound("Current No Data Found");
        }
        [HttpGet("Get-by-Category-id/{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var category = await _unitOfWork.categoryRepository.GetAsync(id);
            if (category == null)
                return NotFound($"Not Found Id {id}");

            //ListingCategoryDTO newCategory = new()
            //{
            //    id = category.Id,
            //    Name = category.Name,
            //    Description = category.Description,
            //};
            return Ok(_mapper.Map<Category, ListingCategoryDTO>(category));

        }

        [HttpPost("add-new-category")]
        public async Task<IActionResult> Post(CategoryDTO category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Category newCategory = new()
                    //{
                    //    Name = category.Name,
                    //    Description = category.Description,
                    //};

                   var newCategory =  _mapper.Map<CategoryDTO, Category>(category);

                    await _unitOfWork.categoryRepository.AddAsync(newCategory);
                    return Ok(category);

                }
                return BadRequest("Something wrong happen");
            }
            catch (Exception)
            {

                return BadRequest("Something wrong happen");
            }
        }

        [HttpPut("update-exiting-category-by-id/{id}")]
        public async Task<IActionResult> update(int id, CategoryDTO categoryDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var exitingCategory = await _unitOfWork.categoryRepository.GetAsync(id);
                    if (exitingCategory != null)
                    {
                        //updating 
                        exitingCategory.Name = categoryDTO.Name;
                        exitingCategory.Description = categoryDTO.Description;

                        await _unitOfWork.categoryRepository.UpdateAsync(id, exitingCategory);
                    }
                }
                return BadRequest($"category not found , id [{id}] is not Coorect");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-cayegory-by-id/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            try
            {
                var existcategory = await _unitOfWork.categoryRepository.GetAsync(id);
                if (existcategory != null)
                {
                    await _unitOfWork.categoryRepository.DeleteAsync(id);
                    return Ok($"this category >> [{existcategory.Name}] deleted successfully  ");
                }
                return NotFound($"this category with id  >> [{id}] not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
