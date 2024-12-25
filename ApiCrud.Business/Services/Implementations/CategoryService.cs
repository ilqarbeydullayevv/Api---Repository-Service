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
using ApiCrud.DAL.Repositories.Interface;
using AutoMapper;

namespace ApiCrud.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _rep;
        readonly IMapper    _mapper;

        public CategoryService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public CategoryService(ICategoryRepository rep)
        {
            _rep = rep;
        }

        public async Task<GetCategoryDTO> create(CreateCategoryDTO DTO)
        {
            if(await _rep.IsExsist(c => c.Name == DTO.Name))
            {

                throw new CategoryNameExsistException();
            }
            var category = _mapper.Map<Category>(DTO);
            var newcategory = await _rep.Create(category);
             _rep.Savechanges();
            return _mapper.Map<GetCategoryDTO>(newcategory);

        }

        public GetCategoryDTO GetById(int id)
        {
            
           if(id <= 0)
            {
                throw new NullIdException();
            }

           GetCategoryDTO dtos = _mapper.Map<GetCategoryDTO>(_rep.GetById(id));
            return dtos;

           
        }

        public async Task update(UpdateCategoryDTO DTo)
        {
            var oldcategory =   GetById(DTo.Id);
            if (await _rep.IsExsist(c => c.Name == DTo.Name))
            {

                throw new CategoryNameExsistException();
            }
            oldcategory= _mapper.Map<GetCategoryDTO>(oldcategory);
            _rep.Update(_mapper.Map<Category>(oldcategory));
             _rep.Savechanges();

        }
    }
}
