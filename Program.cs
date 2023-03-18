using System;
using System.Collections.Generic;

namespace UcakRezervasyonSistemi
{
    class Program
    {


        static string[] ekonomi = { "6A", "6B", "6C", "6D", "6E",
                                    "7A", "7B", "7C", "7D", "7E",
                                    "8A", "8B", "8C", "8D", "8E" };
        static string[] business = { "1A", "1B", "1C", "1D", "1E",
                                    "2A", "2B", "2C", "2D", "2E",
                                    "3A", "3B", "3C", "3D", "3E",
                                    "4A", "4B", "4C", "4D", "4E",
                                    "5A", "5B", "5C", "5D", "5E" };
        static List<Ucak> yolcuListesi = new List<Ucak>();
        static void Main(string[] args)
        {
            bool devam = true;
            while (devam)
            {
                Console.WriteLine(@"==**==**==**==*/ İstanbul -> Gaziantep \*==**==**==**==");
                Console.WriteLine(@"==**==**==*/ Uçuşu İçin Lütfen Seçim Yapınız \*==**==**==");
                Console.WriteLine("(1) Rezarvasyon");
                Console.WriteLine("(2) Doğrulama");
                Console.WriteLine("(3) Çıkış");
                Console.WriteLine("------------------------");
                string anaMenu = Console.ReadLine();
                switch (anaMenu)
                {
                    case "1":
                        KoltukListeleme();
                        Console.WriteLine("Devam etmek için bir tuşa basınız");
                        Console.ReadKey();
                        break;
                    case "2":
                        Dogrulama();
                        Console.WriteLine("Devam etmek için bir tuşa basınız");
                        Console.ReadKey();
                        break;
                    case "3":
                        devam = false;
                        break;
                    default:
                        Console.WriteLine("Hatalı giriş");
                        break;
                }

            }


        }

        private static void Dogrulama()
        {
            Console.Write("Doğrulama yapmak istediğiniz koltuğu seçiniz: ");
            string koltuk = Console.ReadLine().ToUpper();
            foreach (var item in yolcuListesi)
            {
                if (koltuk != "XX")
                {
                    if (item.Koltuk.KoltukAdi == koltuk)
                    {
                        Console.WriteLine("Yolcu Adı: " + item.Koltuk.Yolcu.AdSoyad);
                        Console.WriteLine("Yolcu Pasaport No: " + item.Koltuk.Yolcu.PasaportNo);
                    }
                }
            }
        }

        public static void KoltukListeleme()
        {
            Console.WriteLine("Hangi sınıfta seyahat etmek istersiniz");
            Console.WriteLine("(1)-Ekonomi\n(2)-Business");
            string sinifSecimi = Console.ReadLine();
            switch (sinifSecimi)
            {
                case "1":
                    Console.WriteLine("==**==**==**==**==**==**==**==");
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int i = 0; i < ekonomi.Length; i++)
                    {
                        Console.Write($"| {ekonomi[i]} |");
                        if ((i + 1) % 5 == 0)
                        {
                            Console.WriteLine();
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("===**==**==**==**==**==**==**==");

                    KoltukSecimYapEco();
                    break;
                case "2":
                    Console.WriteLine("===**==**==**==**==**==**==**==");
                    Console.ForegroundColor = ConsoleColor.Green;
                    // for (int i = 0; i < business.Length; i++)
                    // {
                    //     if (business[i] == "XX")
                    //     {
                    //         Console.ForegroundColor = ConsoleColor.DarkRed;

                    //     }
                    // }
                    for (int i = 0; i < business.Length; i++)
                    {
                        Console.Write($"| {business[i]} |");
                        if ((i + 1) % 5 == 0)
                        {
                            Console.WriteLine();
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("===**==**==**==**==**==**==**==");
                    KoltukSecimYapBusi();
                    break;
                default:
                    Console.WriteLine("Hatalı seçim");
                    break;
            }

        }
        public static void KoltukSecimYapEco()
        {
            bool devam = true;
            while (devam)
            {
                Console.Write("Sayın FAKİR Lütfen Koltuk Seçimi Yapınız (Örnek A6): ");
                string koltukSecim = Console.ReadLine().ToUpper();
                if (koltukSecim != "XX")
                {
                    //Console.WriteLine("Dolu koltuk seçilemez!!");
                    for (int i = 0; i < ekonomi.Length; i++)
                    {
                        if (ekonomi[i] == koltukSecim)
                        {
                            ekonomi[i] = "XX";
                            YolcuBilgiAlma(koltukSecim);
                            devam = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("!!!Dolu Koltuk Seçilemez!!!");
                    Console.WriteLine("Lütfen Boş Bir Koltuk Seçiniz");
                }
            }
        }
        public static void KoltukSecimYapBusi()
        {
            bool devam = true;
            while (devam)
            {
                Console.Write("Lütfen Koltuk seçimi yapınız (Örnek A1): ");
                string koltukSecim = Console.ReadLine().ToUpper();
                if (koltukSecim != "XX")
                {
                    Console.WriteLine("Dolu koltuklar seçilemez!!");
                    for (int i = 0; i < business.Length; i++)
                    {
                        if (business[i] == koltukSecim)
                        {
                            business[i] = "XX";
                            YolcuBilgiAlma(koltukSecim);
                            devam = false;
                        }
                        else if (business[i] == "XX")
                        {
                            Console.WriteLine("!!!Dolu Koltuk Seçilemez!!!");
                            Console.WriteLine("Lütfen Boş Bir Koltuk Seçiniz");
                        }
                    }
                }
            }
        }

        public static void YolcuBilgiAlma(string s)
        {
            Console.Write("Ad Soyad  :");
            string yolcuAd = Console.ReadLine();
            Console.Write("Pasaport No :");
            string yolcuPassNo = Console.ReadLine();
            Ucak yolcu = new Ucak(yolcuAd, yolcuPassNo);
            yolcu.Koltuk.KoltukAdi = s;
            yolcuListesi.Add(yolcu);

        }


    }
}
