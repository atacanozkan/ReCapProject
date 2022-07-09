using System;

namespace Entities.DTOs
{
    public class RentalDetailDto
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string CompanyName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}