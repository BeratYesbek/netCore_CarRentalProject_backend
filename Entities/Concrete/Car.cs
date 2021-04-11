
using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int CarId { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        public int ColorId { get; set; }

        public int ModelYear { get; set; }

        public int DailyPrice { get; set; }

        public string Description { get; set; }

        public int FindeksScore { get; set; }

        public string ModelName { get; set; }

    }
}
