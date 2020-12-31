using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("***ATM'mizə Xoş Gəlmişsiniz***");

            User user = new User();
            SaveFile saveFile = new SaveFile();

            byte counter = 1;
            RESTART:
            Console.WriteLine("Pin Kodu Daxil Edin:");
            int pin = Int32.Parse(Console.ReadLine());
            Dictionary<string, string> operations = new Dictionary<string, string>()
            {
                {"1","Balansı Yoxlamaq Əməliyyatı" },
                {"2","Balansı Artırmaq Əməliyyatı" },
                {"3","Pul Çəkmək Əməliyyatı" },
                {"q","Proqramı Sonlandırmaq Əməliyyatı" }
            };

            while (true)
            {
                
                if (pin == user.Pin)
                {
                    Console.WriteLine($"\nƏməliyyatlar:\n1.{operations["1"]}\n2.{operations["2"]}\n3.{operations["3"]}\nq.{operations["q"]}\n");

                    Console.WriteLine("Bir əməliyyat seçin:");
                    string operation = Console.ReadLine();
                    
                    if(operation.ToLower().Trim() == "q")
                    {
                        Console.WriteLine("Proqramdan Çıxılır Xahiş Edirik Gözləyin...");
                        Thread.Sleep(1500);
                        Console.WriteLine("Proqramdan Uğurla Çıxış etdiniz.");
                        saveFile.SaveOperation(operations["q"]);
                        break;
                    }else if(operation.Trim() == "1")
                    {
                        user.CheckBalance();
                        saveFile.SaveOperation(operations["1"]);
                    }
                    else if (operation.Trim() == "2")
                    {
                        Console.WriteLine("Artıracağınız Miqdarı Daxil Edin:");
                        int money = Int32.Parse(Console.ReadLine());
                        try
                        {
                            user.İncreasesBalance(money);
                            saveFile.SaveOperation($"{operations["2"]},Artırılan Miqdar: {money} Manat");
                        }
                        catch(NegativeNumberException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine($"Sizin Daxil Etdiyiniz Miqdar: {ex.Money}");
                        }
                        
                    }
                    else if (operation.Trim() == "3")
                    {
                        Console.WriteLine("Çəkəcəyiniz Miqdarı Daxil Edin:");
                        int money = Int32.Parse(Console.ReadLine());
                        try
                        {
                            user.GetMoney(money);
                            saveFile.SaveOperation($"{operations["3"]},Çəkilən Miqdar: {money} Manat");
                        }
                        catch(MoneyException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine($"Sizin Çəkmək İstədiyiniz Miqdar: {ex.Money}\nBir Dəfəyə Ən Çox Çəkilə Biləcək Pul Miqdarı {ex.MaxMoney} manatdır.");
                        }catch(NegativeNumberException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine($"Sizin Daxil Etdiyiniz Miqdar: {ex.Money}");
                        }catch(NotEnoughMoneyException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine($"Sizin Çəkmək İstədiyiniz Miqdar: {ex.Money}\nSizin Balansınız: {ex.Amount}");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Belə Bir Əməliyyat Mövcud Deyildir!!!");
                    }

                }
                else
                {
                    
                    Console.WriteLine($"Pin kodu yanlış daxil etdiniz xahiş ediriki yenidən sınayın...({counter}/5)");
                    counter++;
                    if (counter > 5)
                    {
                        Console.WriteLine("Sizin Hesab Həddinnən Artıq Çox Yanlış PİN Kod Daxil Etdiyinizə Görə Bloka Düşmüşdür.\nPin Kodu Yeniləmək istəyirsiniz?(QEYD:Pin Kodu Yeniləmək Əməliyyatı üçün Hesabınızdan Bir Manat Çıxacaq)(y/n)");

                        if(Console.ReadKey().Key == ConsoleKey.Y)
                        {
                            while (true)
                            {
                                try
                                {

                                    Console.WriteLine("\nYeni Dörd Rəqəmli Pin Kod Daxil Edin:");
                                    int newpin = Int32.Parse(Console.ReadLine());

                                    user.ResetPin(newpin);
                                    saveFile.SaveOperation("Pin Kodun Dəyişdirilməsi Əməliyyatı");
                                    break;
                                }
                                catch (InsufficientNumber ex)
                                {
                                    Console.WriteLine(ex.Message);

                                }
                                catch (NegativeNumberException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Proqram Sonlandı.");
                            break;
                        }
                        
                    }
                    goto RESTART;
                }
            }
        }
    }
}
