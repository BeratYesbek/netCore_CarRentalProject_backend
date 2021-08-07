using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserDetailsDto : IDto
    {
        public int Id { get; set; }

        public List<int> CustomerId { get; set; }
        public List<int> FindeksScore { get; set; }
        public List<int> AdminId { get; set; }
        public List<UserImage> Images { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public bool Status { get; set; }

    }
}
