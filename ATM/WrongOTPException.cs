using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    class WrongOTPException : Exception
    {
        public WrongOTPException(string message) : base(message)
        {

        }
    }
}
