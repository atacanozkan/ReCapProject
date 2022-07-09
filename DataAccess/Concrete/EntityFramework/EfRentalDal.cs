using System.Collections.Generic;
using System.Linq;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
               var result = from r in context.Rentals
                    join cu in context.Customers on r.CustomerId equals cu.Id
                    join u in context.Users on cu.UserId equals u.Id
                    join ca in context.Cars on r.CarId equals ca.Id 
                    select new RentalDetailDto { RentalId = r.Id,
                                                CarId = ca.Id,
                                                CarName = ca.Description,
                                                CustomerId = cu.UserId,
                                                UserId = u.Id,
                                                UserFirstName = u.FirstName,
                                                UserLastName = u.LastName,
                                                CompanyName = cu.CompanyName,
                                                RentDate = r.RentDate,
                                                ReturnDate = r.ReturnDate };

                return result.ToList();
            }
        }
    }
}