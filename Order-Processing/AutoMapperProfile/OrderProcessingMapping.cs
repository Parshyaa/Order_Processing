using AutoMapper;
using Order_Processing.BusinessObjects.Interfae;
using Order_Processing.Entities;
using Order_Processing.Entities.Interface;

namespace Order_Processing.AutoMapperProfile
{
    public class OrderProcessingMapping : Profile
    {
        public OrderProcessingMapping()
        {
            CreateMap<IOrder, IOrderBo>()
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails)); ;
            CreateMap<Order, IOrderBo>()
                                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails)); ;
            CreateMap<IOrderBo, IOrder>()
                                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails)); ;

            CreateMap<IOrderBo, Order>()
                                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails)); ;


            CreateMap<IOrderDetail, IOrderDetailBo>();
            CreateMap<OrderDetail, IOrderDetailBo>();
            CreateMap<IOrderDetailBo, IOrderDetail>();
            CreateMap<IOrderDetailBo, OrderDetail>();

            CreateMap<IProductType, IProductTypeBo>();
            CreateMap<ProductType, IProductTypeBo>();
            CreateMap<IProductTypeBo, IProductType>();
            CreateMap<IProductTypeBo, ProductType>();
        }
    }
}
