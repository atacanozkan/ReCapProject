using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //Car carAdd = new Car();
            ////carAdd.Id = 5;
            //carAdd.BrandId = 5;
            //carAdd.ColorId = 50;
            //carAdd.DailyPrice = 0;
            //carAdd.ModelYear = 2005;
            //carAdd.Description = "Car 5";
            //carManager.Add(carAdd);

            foreach (var item in carManager.GetAll())
                Console.WriteLine(item.Description);

            foreach (var item in carManager.GetCarDetails())
                Console.WriteLine($"Car Name: {item.CarName}, " +
                    $"Brand: {item.BrandName}," +
                    $"Color: {item.ColorName}," +
                    $"Daily Price: {item.DailyPrice}");

            //foreach (var item in carManager.GetById(1))
            //    Console.WriteLine(item.Description);

            //Car carUpdate = new Car();
            //carUpdate.Id = 5;
            //carUpdate.BrandId = 5;
            //carUpdate.ColorId = 50;
            //carUpdate.DailyPrice = 500;
            //carUpdate.ModelYear = 2005;
            //carUpdate.Description = "Car 5.1";
            //carManager.Update(carUpdate);

            //foreach (var item in carManager.GetAll())
            //    Console.WriteLine(item.Description);

            //Car carDelete = new Car();
            //carDelete.Id = 5;
            //carManager.Delete(carDelete);

            //foreach (var item in carManager.GetAll())
            //    Console.WriteLine(item.Description);
        }
    }
}
