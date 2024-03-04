using AutoMapper;
using Packgroup.Ecommerce.Aplication.DTO;
using Packgroup.Ecommerce.Domain.Entities;
using Packgroup.Ecommerce.Domain.Events;

namespace Packgroup.Ecommerce.Aplication.UseCases.Common.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Categorie, CategorieDto>().ReverseMap();
            CreateMap<Domain.Entities.Discount, DiscountDto>().ReverseMap();
            CreateMap<Domain.Entities.Discount, DiscountCreatedEvent>().ReverseMap();
        }
    }
}
