﻿namespace Application.Common.Models.Auth
{
    public class AuthLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AuthLoginRequest(string email, string password)
        {
            Email = email;
            Password = password;    
        }
    }
}
