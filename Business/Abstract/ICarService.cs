using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAll();
        Car GetById(int id);
        Car GetByBrandId(int id);
        Car GetByColorId(int id);
        List<CarDetailDto> GetCarDetails();
    }
}