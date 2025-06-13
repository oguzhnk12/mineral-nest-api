﻿using Domain.Entities;

namespace Application.Features.UserFeatures
{
    public class User
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public required Address Address { get; set; }
    }
}
