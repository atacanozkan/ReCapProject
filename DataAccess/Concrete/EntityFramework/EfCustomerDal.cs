using System.Collections.Generic;
using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Customers
                    join u in context.Users on c.UserId equals u.Id
                    select new CustomerDetailDto { CustomerId = c.Id, 
                                                    UserId = u.Id, 
                                                    UserFirstName = u.FirstName, 
                                                    UserLastName = u.LastName, 
                                                    CompanyName = c.CompanyName };

                return result.ToList();
            }
        }
    }
}