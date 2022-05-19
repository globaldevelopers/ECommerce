namespace ECommerce.Api.Customers.Db
{
    public class Address
    {
        public int Id { get; set; }
        public int HouseNumber { get; set; }
        public string Line1 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
    }
}