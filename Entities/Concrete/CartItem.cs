using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CartItem : IEntity
    {
        public int CartItemId { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
    }
}
