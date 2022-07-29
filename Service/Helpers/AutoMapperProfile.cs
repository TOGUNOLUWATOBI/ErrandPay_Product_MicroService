using AutoMapper;
using Models.DTOs;
using Models.Entities;

namespace Services.Helpers
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDTO, Product>();
        }
    }
}
