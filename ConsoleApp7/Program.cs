using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace CarSite
{

    static class Program

    {
        static int _key;

        static void Main(string[] args)
        {
            #region dil
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.Title = "masin";
            CultureInfo ci = new CultureInfo("AZ-Latn-Az");
            ci.NumberFormat.NumberDecimalSeparator = ".";
            ci.DateTimeFormat.LongDatePattern = "dd.MM.yyyy HH:mm";
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            #endregion
            #region qeydiyyat və giriş
            Console.WriteLine("İstifadə üçün qeydiyyatdan keçin");
            Console.WriteLine("----------------------------");
        l9:
            Console.WriteLine("İstifadəçi adı");
            string ad = Console.ReadLine();
            if (String.IsNullOrEmpty(ad) == true)
            {
                Console.WriteLine("Yenidən qeydiyyatdan keçin");
                goto l9;
            }
        l10:
            Console.WriteLine("Parol");
            string parol = Console.ReadLine();


            if (String.IsNullOrEmpty(parol) == true)
            {
                Console.WriteLine("Yenidən qeydiyyatdan keçin");
                goto l10;
            }
            Console.Clear();

        l77:
            Console.WriteLine("Giriş edin:");
            Console.WriteLine("Ad");
            string adg = Console.ReadLine();
            Console.WriteLine("Parol");
            string parolg = Console.ReadLine();
            if (adg != ad && parolg != parol)
            {
                Console.WriteLine("Xəta");
                goto l10;
            }
            else if (string.IsNullOrWhiteSpace(parolg) == true)
            {
                goto l77;
            }
            else
            {
                Console.WriteLine("Giris ugurludur");
            }
            Console.Clear();

            #endregion



            IDictionary<int, Car> car = new Dictionary<int, Car>();

            while (true)                                          
            {
            l00:
                Menu();
                Console.WriteLine();
                switch (Console.ReadLine())
                {
                    #region cap
                    case "1":
                        foreach (var item in car)
                        {
                            Console.WriteLine(item.Value.ToString());
                        }
                        if (car.Count == 0)
                        {
                            Console.WriteLine("Kataloq boşdur");
                        }
                        break;
                    #endregion
                    #region daxilet
                    case "2":
                        Console.WriteLine("Marka");
                        string marka = Console.ReadLine().ToUpper();

                        Console.WriteLine("Model");
                        string model = Console.ReadLine().ToUpper();
                    l8:
                        Console.WriteLine("İl");
                        // int year = Convert.ToInt32(Console.ReadLine());
                        int year;
                        try
                        {
                            year = Convert.ToInt32(Console.ReadLine());
                            bool b1 = year.GetType() == typeof(int);

                        }
                        catch (Exception)
                        {
                            goto l8;
                            throw;
                        }



                    l11:
                        Console.WriteLine("Qiymət");
                        int price;
                        try
                        {
                            price = Convert.ToInt32(Console.ReadLine());
                            bool b5 = price.GetType() == typeof(int);

                        }
                        catch (Exception)
                        {
                            goto l11;
                            throw;
                        }


                    l1:
                        Console.WriteLine("Ban");

                        Console.WriteLine("1- Hibrid   2-Sedan");

                        string ban;
                        try
                        {
                            ban = Console.ReadLine();

                        }
                        catch (Exception)
                        {
                            goto l1;
                            throw;
                        }
                        if (ban != "1" && ban != "2")
                        {
                            goto l1;

                        }
                    l3:
                        Console.WriteLine("Rəng");
                        Console.WriteLine("1-Ağ  2-Qara 3-Qırmızı 4-Göy");

                        string color;
                        try
                        {
                            color = Console.ReadLine();

                        }
                        catch (Exception)
                        {
                            goto l3;
                            throw;
                        }

                        if (color != "1" && color != "2" && color != "3" && color != "4")
                        {
                            goto l3;
                        }
                    l5:
                        Console.WriteLine("Yanacaq");
                        Console.WriteLine("1-Dizel 2-Benzin");
                        string yanacaq;

                        try
                        {
                            yanacaq = Console.ReadLine();

                        }
                        catch (Exception)
                        {
                            goto l5;
                            throw;
                        }
                        if (yanacaq != "1" && yanacaq != "2")
                        {
                            goto l5;
                        }

                        int key = Interlocked.Increment(ref _key);

                        car.Add(key, new Car(marka, model, year, price, ban, color, yanacaq));
                        break;
                    #endregion
                    #region sil
                    case "3":

                        Console.WriteLine("Silmək istədiyiniz elanın İD-si");
                        try
                        {
                            int id = Convert.ToInt32(Console.ReadLine());
                            if (car.ContainsKey(id) == false)
                            {
                                Console.WriteLine("Mövcud deyil");
                                goto l00;
                            }
                            else
                            {
                                car.Remove(id);
                            }



                        }
                        catch (Exception)
                        {
                            goto l00;
                            throw;
                        }

                        break;
                    #endregion
                    #region redakte
                    case "4":
                        l44:
                        Console.WriteLine("Redaktə etmək istədiyiniz elanın İD-si, düzəltməmək" +
                            "üçün boş buraxın");



                        
                        int idtoedit = Convert.ToInt32(Console.ReadLine());
                        string itdo = idtoedit.ToString();
                        if (string.IsNullOrEmpty(itdo)==true)
                        {
                            goto l44;
                        }
                        
                        if (!car.ContainsKey(idtoedit))
                        {
                            Console.WriteLine("Bu nömrəli elan mövcud deyil");
                            goto l00;
                        }

                        else
                        {
                            Console.WriteLine("Marka");
                            string y = Console.ReadLine().ToUpper();

                            if (string.IsNullOrEmpty(y) == true)
                            {
                                marka = car[idtoedit].Marka;
                                Console.WriteLine("Bu hissə əvvəlki kimi qaldı");
                            }
                            else
                            {
                                marka = car[idtoedit].Marka = y;
                            }

                            Console.WriteLine("Model");
                            string z = Console.ReadLine().ToUpper();

                            if (string.IsNullOrEmpty(z) == true)
                            {
                                model = car[idtoedit].Model;
                                Console.WriteLine("Bu hissə əvvəlki kimi qaldı");
                            }
                            else
                            {
                                model = car[idtoedit].Model = z;
                            }

                            Console.WriteLine("İl");

                            try
                            {
                                string v = Console.ReadLine();
                                if (string.IsNullOrEmpty(v) == true)
                                {
                                    year = car[idtoedit].Year;
                                    Console.WriteLine("Bu hissə əvvəlki kimi qaldı");
                                }
                                else
                                {
                                    year = car[idtoedit].Year = Convert.ToInt32(v);
                                }
                                bool b4 = year.GetType() == typeof(int);


                            }
                            catch (Exception)
                            {
                                goto l8;
                                throw;
                            }

                            Console.WriteLine("Qiymət");


                            try
                            {

                                string u = Console.ReadLine();
                                if (string.IsNullOrEmpty(u) == true)
                                {
                                    price = car[idtoedit].Price;
                                    Console.WriteLine("Bu hissə əvvəlki kimi qaldı");
                                }
                                else
                                {
                                    price = car[idtoedit].Year = Convert.ToInt32(u);
                                }
                                bool b9 = price.GetType() == typeof(int);

                            }
                            catch (Exception)
                            {
                                goto l8;
                                throw;
                            }


                        l2:
                            Console.WriteLine("Ban");
                            Console.WriteLine("1- Hibrid   2-Sedan");
                            ban = Console.ReadLine();


                            try
                            {
                                if (string.IsNullOrEmpty(ban) == true)
                                {
                                    ban = car[idtoedit].ban;
                                    Console.WriteLine("Bu hissə əvvəlki kimi qaldı");
                                }
                                else
                                {

                                    ban = car[idtoedit].ban;
                                    if (ban != "1" && ban != "2" && ban != "3" && string.IsNullOrEmpty(ban) == true)

                                    {
                                        goto l2;
                                    }
                                    else
                                    {
                                        ban = car[idtoedit].ban;
                                    }
                                }
                                bool b9 = ban.GetType() == typeof(int);


                            }
                            catch (Exception)
                            {
                                goto l2;
                                throw;
                            }

                        l4:
                            Console.WriteLine("Rəng");
                            Console.WriteLine("1-Ağ  2-Qara 3-Qırmızı 4-Göy");
                            color = Console.ReadLine();
                            try
                            {

                                if (string.IsNullOrEmpty(color) == true)
                                {
                                    color = car[idtoedit].color;
                                    Console.WriteLine("Bu hissə əvvəlki kimi qaldı");
                                }

                                else
                                {
                                   
                                    if (color != "1" && color != "2" && color != "3" && color != "4")

                                    {
                                        goto l4;
                                    }
                                    else
                                    {
                                        color = car[idtoedit].color;
                                    }
                                }
                                


                            }
                            catch (Exception)
                            {
                                goto l4;
                                throw;

                            }


                        l6:
                            Console.WriteLine("Yanacaq");
                            Console.WriteLine("1-Dizel 2-Benzin");
                            yanacaq = Console.ReadLine();


                            try
                            {
                                if (string.IsNullOrEmpty(color) == true)
                                {
                                    yanacaq = car[idtoedit].yanacaq;
                                    Console.WriteLine("Bu hissə əvvəlki kimi qaldı");
                                }

                                else
                                {

                                    if (yanacaq != "1" && yanacaq != "2")

                                    {
                                        goto l4;
                                    }
                                    else
                                    {
                                        yanacaq = car[idtoedit].yanacaq;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                goto l6;
                                throw;
                            }
                            break;
                            #endregion
                        }


                    #region cixis & save
                    case "5":
                        Environment.Exit(0);
                        break;

                        #endregion

                }
                Console.WriteLine();
            }
        }

        public static void Menu()
        {
            Console.WriteLine("Əməliyyatlar");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1.Kataloq ");
            Console.WriteLine("2.Elan yerləşdirmək");
            Console.WriteLine("3.Elan silmək");
            Console.WriteLine("4.Redaktə et");
            Console.WriteLine("5.Çıxış");


        }





    }
}
