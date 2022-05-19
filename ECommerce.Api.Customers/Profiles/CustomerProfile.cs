namespace ECommerce.Api.Customers.Profiles
{
    public class CustomerProfile : AutoMapper.Profile
    {
        public CustomerProfile()
        {
            CreateMap<Db.Address, Models.Address>();
            CreateMap<Db.Customer, Models.Customer>();
        }
    }
}
