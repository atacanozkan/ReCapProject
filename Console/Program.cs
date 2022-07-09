using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //UserTest();
            //CustomerTest();
            RentalTest();
        }
        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user1 = new User()
            {
                Id = 1,
                FirstName = "UserName1", 
                LastName = "UserLastName1", 
                Email = "UserEmail1", 
                Password = "UserPass1"
            };
            User user2 = new User()
            {
                Id = 2,
                FirstName = "UserName2", 
                LastName = "UserLastName2", 
                Email = "UserEmail2", 
                Password = "UserPass2"
            };

            userManager.Add(user1);
            userManager.Add(user2);

            var resultUser = userManager.GetAll();
            if (resultUser.Success)
            {
                foreach (var item in resultUser.Data)
                    Console.WriteLine($"User Id: {item.Id}, \n" +
                                      $"User Name: {item.FirstName}" +
                                      $"User Name: { item.FirstName}");
            }
            else
            {
                Console.WriteLine(resultUser.Message);
            }
        }
        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer1 = new Customer()
            {
                Id = 1,
                UserId = 1, 
                CompanyName = "CompanyNameName1"
            };
            Customer customer2 = new Customer()
            {
                Id = 2,
                UserId = 2, 
                CompanyName = "CompanyNameName2"
            };

            customerManager.Add(customer1);
            customerManager.Add(customer2);

            var resultCustomer = customerManager.GetCustomerDetails();
            if (resultCustomer.Success)
            {
                foreach (var item in resultCustomer.Data)
                    Console.WriteLine($"Customer Id: {item.CustomerId}, \n" +
                                      $"User Id: {item.UserId},\n" +
                                      $"User First Name: {item.UserFirstName},\n" +
                                      $"User Last Name: {item.UserLastName}\n" +
                                      $"Company Name: {item.CompanyName}\n");
            }
            else
            {
                Console.WriteLine(resultCustomer.Message);
            }
        }
        private static void RentalTest()
        {
            List<Rental> rental = new List<Rental>();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rental.Add(new Rental()
            {
                Id = 1,
                CarId = 1,
                CustomerId = 1,
                RentDate = new DateTime(2022, 07, 01),
                ReturnDate = new DateTime(2022, 07, 09)
            });
            rental.Add(new Rental()
            {
                Id = 2,
                CarId = 1,
                CustomerId = 2,
                RentDate = new DateTime(2022, 07, 10),
                ReturnDate = new DateTime(2022, 07, 12)
            });
            rental.Add(new Rental()
            {
                Id = 3,
                CarId = 1,
                CustomerId = 2,
                RentDate = new DateTime(2022, 07, 11),
                ReturnDate = new DateTime(2022, 07, 12)
            });

            foreach (var r in rental)
            {
                var result = rentalManager.Add(r);
                Console.WriteLine(result.Message);
            }

            var resultCustomer = rentalManager.GetRentalDetails();
            if (resultCustomer.Success)
            {
                foreach (var item in resultCustomer.Data)
                    Console.WriteLine($"Customer Id: {item.CustomerId}, \n" +
                                      $"Company Name: {item.CompanyName}, \n" +
                                      $"User Id: {item.UserId},\n" +
                                      $"User First Name: {item.UserFirstName}\n" +
                                      $"User Last Name: {item.UserLastName}\n" +
                                      $"Car Id: {item.CarId}\n" +
                                      $"Car Name: {item.CarName}\n" +
                                      $"Rental Id: {item.RentalId}\n" +
                                      $"Rent Date: {item.RentDate}\n" +
                                      $"Return Date: {item.ReturnDate}\n");
            }
            else
            {
                Console.WriteLine(resultCustomer.Message);
            }

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

            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var item in result.Data)
                    Console.WriteLine(item.Description);
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            var result2 = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var item in result2.Data)
                    Console.WriteLine($"Car Name: {item.CarName}, " +
                                      $"Brand: {item.BrandName}," +
                                      $"Color: {item.ColorName}," +
                                      $"Daily Price: {item.DailyPrice}");
            }
            else
            {
                Console.WriteLine(result.Message);
            }


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
