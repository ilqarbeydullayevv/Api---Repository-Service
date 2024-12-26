using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCrud.Business.DTOs.Category;
using ApiCrud.Business.Helpers.Exceptions;
using ApiCrud.Business.Helpers.Exceptions.Common;
using ApiCrud.Business.Services.Interface;
using ApiCrud.Core.Entities;
using ApiCrud.DAL.Repositories.implementations;
using ApiCrud.DAL.Repositories.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiCrud.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _rep;
        readonly IMapper    _mapper;



        public CategoryService(ICategoryRepository rep, IMapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }

        public async Task<GetCategoryDTO> create(CreateCategoryDTO DTO)
        {
            if(await _rep.IsExsist(c => c.Name == DTO.Name))
            {

                throw new CategoryNameExsistException();
            }
            var category = _mapper.Map<Category>(DTO);
            var newcategory = await _rep.Create(category);
             await _rep.Savechanges();
            return _mapper.Map<GetCategoryDTO>(newcategory);

        }

        public List<GetCategoryDTO> GetAll()
        {
            List<GetCategoryDTO> dtos = new();
            var datas = _rep.GetAll();
            foreach (var item in datas)
            { 
            GetCategoryDTO dto = _mapper.Map<GetCategoryDTO>(item);
            dtos.Add(dto);
            }
           return dtos;
        }

        public async Task<GetCategoryDTO> GetById(int id)
        {
            
           if(id <= 0)
            {
                throw new NullIdException();
            }

            GetCategoryDTO dtos = _mapper.Map<GetCategoryDTO>(await _rep.GetById(id));
            return  dtos;

           
        }

        public async Task update(UpdateCategoryDTO DTo)
        {
            var oldcategory =  await GetById(DTo.Id);
            if (await _rep.IsExsist(c => c.Name == DTo.Name))
            {

                throw new CategoryNameExsistException();
            }
            oldcategory = _mapper.Map<GetCategoryDTO>(DTo);

            _rep.Update(_mapper.Map<Category>(oldcategory));
             await _rep.Savechanges();
            

        }

       
    }
}
