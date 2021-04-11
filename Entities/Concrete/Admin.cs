using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Admin : IEntity
    {
        public int AdminId { get; set; }
        public int UserId { get; set; }
    }
}
