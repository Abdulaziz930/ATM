using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    class InsufficientNumber : Exception
    {
        public int Number { set; get; }

        public InsufficientNumber(string message,int number) : base(message)
        {
            Number = number;
        }
    }
}
