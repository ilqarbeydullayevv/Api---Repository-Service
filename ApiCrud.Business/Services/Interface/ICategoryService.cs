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
        GetCategoryDTO GetById(int id);
        Task update(UpdateCategoryDTO DTo);
    }
}
