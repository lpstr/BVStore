using AutoMapper;
using BVStore.Domain.Contracts;
using BVStore.Domain.Entities;
using BVStore.Domain.Models;
using BVStore.Infrastructure;

namespace BVStore.API.Configuration
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDTO, Order>()
                .ForMember(dest => dest.Products, opt => opt.Ignore())
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<ProductDTO, OrderProduct>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.PricePerUnit))
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.Order, opt => opt.Ignore());

            CreateMap<OrderProduct, ProductDTO>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.PricePerUnit, opt => opt.MapFrom(src => src.UnitPrice));

            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.Products, opt => opt.Ignore());
        }
    }
}
