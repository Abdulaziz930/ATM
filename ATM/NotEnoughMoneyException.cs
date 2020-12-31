using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    class NotEnoughMoneyException : Exception
    {
        public int Money { set; get; }

        public int Amount { set; get; }

        public NotEnoughMoneyException(string message,int money,int amount) : base(message)
        {
            Money = money;
            Amount = amount;
        }
    }
}
