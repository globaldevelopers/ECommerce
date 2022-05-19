namespace ECommerce.Api.Orders.Profiles
{
    public class OrderProfile : AutoMapper.Profile
    {
        public OrderProfile()
        {
            CreateMap<Db.OrderItem, Models.OrderItem>();
            CreateMap<Db.Order, Models.Order>();
        }
    }
}
