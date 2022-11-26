using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_Back.DataAccess;
using TP_Back.DataAccess.UnitOfWork;
using TP_Back.Dto;
using TP_Back.Entities;

namespace TP_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly ILogger<CategoriesController> logger;
        private readonly IMapper mapper;

        public CategoriesController(IUnitOfWork uow, ILogger<CategoriesController> logger,
            IMapper mapper)
        {
            this.uow = uow;
            this.logger = logger;
            this.mapper = mapper;
        }

        // GET: api/Categories
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = uow.CategoryRepo.GetAll();
            var results = mapper.Map<IList<CategoryDto>>(categories);
            return Ok(results);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category =  uow.CategoryRepo.GetOne(id);
            
            if (category == null)
            {
                return NotFound();
            }
            var result = mapper.Map<CategoryDto>(category);
            return Ok(result);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCategory(int id,[FromBody] CategoryDtoCreation editCategoryDto)
        {
            if (!ModelState.IsValid || id < 1)
            {
                logger.LogError($"Invalid UPDATE attempt in {nameof(EditCategory)}");
                return BadRequest(ModelState);
            }

            var category = await uow.CategoryRepo.GetAsync(q => q.Id == id);
            if (category == null)
            {
                logger.LogError($"Invalid UPDATE attempt in {nameof(EditCategory)}");
                return BadRequest("Submitted data is invalid");
            }

            mapper.Map(editCategoryDto, category);
            uow.CategoryRepo.update(category);
            await uow.SaveAsync();

            return NoContent();
        }

        // POST: api/Categories
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDtoCreation createCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                logger.LogError($"Invalid POST attempt in {nameof(CreateCategory)}");
                return BadRequest(ModelState);
            }

            var category = mapper.Map<Category>(createCategoryDto);
            await uow.CategoryRepo.InsertAsync(category);
            await uow.SaveAsync();

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id < 1)
            {
                logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCategory)}");
                return BadRequest();
            }

            var category = await uow.CategoryRepo.GetAsync(q => q.Id == id);
            if (category == null)
            {
                logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCategory)}");
                return BadRequest("Submitted data is invalid");
            }

            await uow.CategoryRepo.DeleteAsync(id);
            await uow.SaveAsync();

            return NoContent();
        }
    }
}
