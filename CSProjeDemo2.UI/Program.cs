using CSProjeDemo2.Business;
using CSProjeDemo2.DataAccess.AppDbContext;
using CSProjeDemo2.Model.Models;
using CSProjeDemo2.Model.Models.BaseModel;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var dbContext = new PersonelDbContext())
        {
            string secim;
            do
            {
                Console.WriteLine("Personel Türünü Seçin (1: Memur, 2: Yönetici):");
                secim = Console.ReadLine();

                if (secim == "1")
                {
                    // Memur bilgilerini al
                    Console.WriteLine("\nMemur Bilgileri:");
                    Console.Write("Ad: ");
                    string memurAd = Console.ReadLine();

                    Console.Write("Soyad: ");
                    string memurSoyad = Console.ReadLine();

                    Console.Write("Çalışma Saati: ");
                    int memurCalismaSaati;
                    if (!int.TryParse(Console.ReadLine(), out memurCalismaSaati))
                    {
                        Console.WriteLine("Geçersiz çalışma saati. Tekrar deneyin.");
                        continue;
                    }

                    Console.Write("Derece (0,1 veya 2): ");
                    int memurDerece;
                    if (!int.TryParse(Console.ReadLine(), out memurDerece) || (memurDerece != 0 && memurDerece != 1 && memurDerece != 2))
                    {
                        Console.WriteLine("Geçersiz derece. Derece 0,1 veya 2 olmalıdır. Tekrar deneyin.");
                        continue;
                    }

                    //// Memurun saatlik ücretini kullanıcıdan al
                    //Console.Write("Saatlik Ücret: ");
                    //decimal memurSaatlikUcret;
                    //if (!decimal.TryParse(Console.ReadLine(), out memurSaatlikUcret))
                    //{
                    //    Console.WriteLine("Geçersiz saatlik ücret. Tekrar deneyin.");
                    //    continue;
                    //}

                    var memur = new Memur { Ad = memurAd, Soyad = memurSoyad,  CalismaSaati = memurCalismaSaati, Derece = memurDerece , /*Mesai = memurCalismaSaati - 180*/ };
                    dbContext.Personeller.Add(memur);
                }
                else if (secim == "2")
                {
                    // Yönetici bilgilerini al
                    Console.WriteLine("\nYönetici Bilgileri:");
                    Console.Write("Ad: ");
                    string yoneticiAd = Console.ReadLine();

                    Console.Write("Soyad: ");
                    string yoneticiSoyad = Console.ReadLine();

                    decimal yoneticiSaatlikUcret;
                    do
                    {
                        Console.Write("Saatlik Ücret (500 TL'den büyük): ");
                    } while (!decimal.TryParse(Console.ReadLine(), out yoneticiSaatlikUcret) || yoneticiSaatlikUcret < 500);

                    Console.Write("Çalışma Saati: ");
                    int yoneticiCalismaSaati;
                    if (!int.TryParse(Console.ReadLine(), out yoneticiCalismaSaati))
                    {
                        Console.WriteLine("Geçersiz çalışma saati. Tekrar deneyin.");
                        continue;
                    }

                    Console.Write("Bonus: ");
                    decimal yoneticiBonus;
                    if (!decimal.TryParse(Console.ReadLine(), out yoneticiBonus))
                    {
                        Console.WriteLine("Geçersiz bonus miktarı. Tekrar deneyin.");
                        continue;
                    }

                    var yonetici = new Yonetici { Ad = yoneticiAd, Soyad = yoneticiSoyad, SaatlikUcret = yoneticiSaatlikUcret, CalismaSaati = yoneticiCalismaSaati, Bonus = yoneticiBonus };
                    dbContext.Personeller.Add(yonetici);
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
                    continue;
                }

                break;
            } while (true);

            dbContext.SaveChanges();
            Console.WriteLine("\nVeritabanına kaydedildi.");

            var tümpersoneller = dbContext.Personeller.ToList();
            // MaasBordro sınıfını kullanarak maaş bordrosu oluştur
            MaasBordro.MaasBordrosunuOlustur(tümpersoneller, "Mart", 2024);
            // Çalışma saati 10'dan az olan personelleri bul
            var azCalisanlar = tümpersoneller.Where(p => p.CalismaSaati < 10);

            if (azCalisanlar.Any())
            {
                Console.WriteLine("Uyarı: Aşağıdaki personeller 10 saatten az çalışmıştır:");
                foreach (var personel in azCalisanlar)
                {
                    Console.WriteLine($"- {personel.Ad} {personel.Soyad}");
                }
            }
            else
            {
                Console.WriteLine("10 saatten az çalışan personel bulunmamaktadır.");
            }


        }
    }
}