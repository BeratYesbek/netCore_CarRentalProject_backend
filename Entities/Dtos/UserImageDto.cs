using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserImageDto : IDto
    {
        public int UserImageId { get; set; }
        public int UserId { get; set; }
        public string ImagePath { get; set; }
        public IFormFile File { get; set; }
    }
}
