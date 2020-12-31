using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    
    class NegativeNumberException : Exception
    {
        public int Money { set; get; }

        public NegativeNumberException(string message,int money) : base(message)
        {
            Money = money;
        }
    }
}
