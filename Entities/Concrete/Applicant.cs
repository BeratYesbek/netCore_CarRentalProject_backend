using Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Applicant : IEntity
    {
        
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public bool Status { get; set; }

    }
}
