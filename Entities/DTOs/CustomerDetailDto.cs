namespace Entities.DTOs
{
    public class CustomerDetailDto
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string CompanyName { get; set; }
    }
}