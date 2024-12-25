using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCrud.Business.DTOs.Category;
using ApiCrud.Core.Entities;
using AutoMapper;

namespace ApiCrud.Business.Helpers.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<GetCategoryDTO, Category>().ReverseMap();
            CreateMap<CreateCategoryDTO, Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO, GetCategoryDTO>().ReverseMap();
        }

    }
}
   
    