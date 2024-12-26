using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCrud.Business.DTOs.Category;

namespace ApiCrud.Business.Services.Interface
{
    public interface ICategoryService
    {
        
        Task<GetCategoryDTO> create(CreateCategoryDTO DTO);
       Task< GetCategoryDTO> GetById(int id);
         List<GetCategoryDTO> GetAll();
        Task update(UpdateCategoryDTO DTo);
    }
}
