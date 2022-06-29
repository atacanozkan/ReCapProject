using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Car: IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }

        private decimal dailyPrice;
        public decimal DailyPrice
        {
            get
            {
                return dailyPrice;
            }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Price value must be greater than 0");
                }
                else
                    dailyPrice = value;
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if(value.Length<2)
                    Console.WriteLine("Minimum character length must be 2");
                else
                    description = value;
            }
        }
    }
}