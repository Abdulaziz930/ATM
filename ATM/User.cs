using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace ATM
{
    class User
    {
        public int Pin { set; get; } = 1234;

        public int Amount { set; get; } = 1000;

        public void GetMoney(int money)
        {
            if(money > 500)
            {
                throw new MoneyException("Bu miqdarda pul çəkə bilmərsiniz", money,500);
            }else if(money < 0)
            {
                throw new NegativeNumberException("Daxil etdiyiniz miqdarda pul yoxdur", money);
            }
            else if(money > Amount)
            {
                throw new NotEnoughMoneyException("Balansınızda Kifayət Qədər Vəsait Yoxdur.\nXahiş Edirik Balansınız Artırın", money,Amount);
            }
            else
            {
                Console.WriteLine("Daxil Etdiyiniz Miqdar Hazırlanır Xahiş Edirik Gözləyin...");
                Thread.Sleep(1500);
                Amount -= money;
                Console.WriteLine($"Pulu Uğurla Çəkdiniz,yekun məbləğ: {Amount}");
            }
        }
        public void İncreasesBalance(int money)
        {
            if (money < 0)
            {
                throw new NegativeNumberException("Daxil etdiyiniz miqdarda pul yoxdur", money);
            }
            else
            {
                Console.WriteLine("Daxil Etdiyiniz Miqdar Balansınıza Yüklənir Xahiş Edirik Gözləyin...");
                Thread.Sleep(1500);
                Amount += money;
                Console.WriteLine($"Pulu Uğurla Yüklədiniz,Yekun Məbləğ: {Amount}");
            }
        }
        public void CheckBalance()
        {
            Console.WriteLine("Balansınız Yoxlanır Xahiş Edirik Gözləyin...");
            Thread.Sleep(1500);
            Console.WriteLine($"Sizin Hesabınızda {Amount} manat pul var");
        }
        public void ResetPin(int newPin)
        {
            if(newPin.ToString().Length != 4)
            {
                throw new InsufficientNumber("Xahiş Edirik Dörd Rəqəmli Bir Pin Kod Daxil Edin", newPin);
            }
            if(newPin < 0)
            {
                throw new NegativeNumberException("Pin Kod Mənfi Ədəd Ola Bilməz", newPin);
            }
            else
            {
                Console.WriteLine("Pin Kod Yenilənir Xahiş Edirik Gözləyin...");
                Thread.Sleep(1500);
                Pin = newPin;
                Amount--;
                Console.WriteLine("Pin Kodu Uğurla Yenilədiniz");
            }
            
        }
    }
}
