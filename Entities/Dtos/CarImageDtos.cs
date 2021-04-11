using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CarImageDto : IDto
    {
        public int CarId { get; set; }
        public IFormFile File  { get; set; }
        public int CarImageId { get; set; }
        public string ImagePath { get; set; }
     
    }
}