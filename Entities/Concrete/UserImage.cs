using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class UserImage : IEntity
    {
        public int UserImageId { get; set; }
        public int UserId { get; set; }
        public string ImagePath { get; set; }
    }
}
