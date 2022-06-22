using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        private List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id = 1, BrandId = 1, ColorId = 10, DailyPrice = 100, Description = "Car 1", ModelYear = 2001},
                new Car {Id = 2, BrandId = 2, ColorId = 20, DailyPrice = 200, Description = "Car 2", ModelYear = 2002},
                new Car {Id = 3, BrandId = 3, ColorId = 30, DailyPrice = 300, Description = "Car 3", ModelYear = 2003},
                new Car {Id = 4, BrandId = 4, ColorId = 40, DailyPrice = 400, Description = "Car 4", ModelYear = 2004}
            };
        }
        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            car = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(car);
        }
    }
}