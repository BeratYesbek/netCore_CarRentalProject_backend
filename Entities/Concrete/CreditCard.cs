using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard :IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Cvv { get; set; }
        public int CardYear { get; set; }
        public string CardName { get; set; }
        public string CardMonth { get; set; }
        public string CardNumber { get; set; }


    }
}
