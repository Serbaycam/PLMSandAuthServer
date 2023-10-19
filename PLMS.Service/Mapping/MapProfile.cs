using AutoMapper;
using PLMS.Core.DTOs.Category;
using PLMS.Core.DTOs.Product;
using PLMS.Core.Entity;

namespace PLMS.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
        }
    }
}
