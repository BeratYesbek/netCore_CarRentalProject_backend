using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment :  IEntity
    {
        public int PaymentId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CardMonth { get; set; }
        public int CardYear { get; set; }
        public int Cvv { get; set; }
        public int TotalPrice { get; set; }

    }
}
