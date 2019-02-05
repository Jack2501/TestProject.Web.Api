﻿using System;

namespace YevhenUshakov.TestProject.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User()
        {
            Id = new Guid();
        }
    }

}
