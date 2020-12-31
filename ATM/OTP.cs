using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ATM
{
    class OTP
    {
        public void SendOTP()
        {
            using(StreamWriter sw = new StreamWriter("OTP.txt"))
            {
                Random rand = new Random();

                DateTime dt = new DateTime();

                dt = DateTime.Now;

                sw.Write($"{dt.ToString("dd-MM-yyyy HH:mm")} -> {rand.Next(1000, 9999).ToString()}");
            }
        }
        public void CheckOTP(string number)
        {
            using(StreamReader sr = new StreamReader("OTP.txt"))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    if (line.Substring(line.Length - 4).Trim() == number)
                    {
                        Console.WriteLine("OTP Şifrəsi Doğrudur Pini Yeniləyə Bilərsiniz...");
                    }
                    else
                    {
                        throw new WrongOTPException("Yannlış OTP Şifrəsi Daxil Etdiniz,Yeni OTP Şifrəsi Göndərildi.");
                    }
                }
            }
        }
    }
}
