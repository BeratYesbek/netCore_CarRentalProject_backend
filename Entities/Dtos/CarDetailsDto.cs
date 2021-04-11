using Core;
using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailsDto : IDto
    {
        public int CarId { get; set; }

        public string BrandName { get; set; }
        public int CategoryId { get; set; }


        public int BrandId { get; set; }

        public int ColorId { get; set; }

        public string ModelName { get; set; }

        public int ModelYear { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ColorName { get; set; }

        public int FindeksScore { get; set; }

        public List<Rental> Rentals { get; set; }

        public List<CarImage> CarImages { get; set; }

        public int DailyPrice { get; set; }
    }
}
