﻿namespace BabyLibrary.Contracts.V1.Requests
{
    public class UserLoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}