﻿namespace Seq.App.aspsms.Models
{
    public class CheckCredits : JsonBase
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public CheckCredits(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}