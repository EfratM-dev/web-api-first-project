using System;
using System.Collections.Generic;
using System.Text;
using Zxcvbn;

namespace Services
{
    public class PasswordService : IPasswordService
    {
        public int Post(string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password).Score;
        }
    }
}
