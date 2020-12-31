using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    class MoneyException : Exception
    {
        public int Money { set; get; }

        public int MaxMoney { set; get; }

        public MoneyException(string message,int money,int maxMoney) : base(message)
        {
            Money = money;
            MaxMoney = maxMoney;
        }
    }
}
