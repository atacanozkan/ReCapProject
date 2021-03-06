using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.Id
                    join co in context.Colors on c.ColorId equals co.Id
                    select new CarDetailDto {CarId = c.Id, 
                                            CarName = c.Description, 
                                            BrandName = b.Name, 
                                            ColorName = co.Name, 
                                            DailyPrice = c.DailyPrice};

                return result.ToList();
            }
        }
    }
}