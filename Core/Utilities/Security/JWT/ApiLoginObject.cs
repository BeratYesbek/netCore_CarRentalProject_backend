using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class ApiLoginObject
    {
        public string Token { get; set; }
        
        public int userId { get; set; }

        public DateTime Expiration { get; set; }
    }
}
