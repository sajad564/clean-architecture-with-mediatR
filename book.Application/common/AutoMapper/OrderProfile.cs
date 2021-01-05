using AutoMapper;
using book.Application.common.Resources;
using book.Domain.Entities;

namespace book.Application.common.AutoMapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order,OrderResource>();
        }
    }
}