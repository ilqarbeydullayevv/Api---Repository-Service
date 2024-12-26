
using ApiCrud.Business.DTOs.Category;
using ApiCrud.Business.Helpers.Exceptions;
using ApiCrud.Business.Services.Implementations;
using ApiCrud.Business.Services.Interface;
using ApiCrud.Core.Entities;
using ApiCrud.DAL.Context;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.apı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task< IActionResult> get(int id)
        {
            try
            {
                return Ok( await categoryService.GetById(id));
            }
            catch (Exception ex)
            {
            return BadRequest(ex.Message);
            
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDTO DTO)
        {
            try
            {
                return Ok( await categoryService.create(DTO));
            }
            catch ( CategoryNameExsistException ex)
            {

                return StatusCode(StatusCodes.Status409Conflict , ex.Message);
            }
            catch ( Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCategoryDTO DTO)
        {
            try
            {
              await  categoryService.update(DTO);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {

            try
            {
                return Ok(categoryService.GetAll());

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

