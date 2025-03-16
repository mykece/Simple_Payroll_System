using CSProjeDemo2.Model.Models;
using CSProjeDemo2.Model.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.Business
{
    public static class MaasBordro
    {
        public static void MaasBordrosunuOlustur(List<Personel> personelListesi, string ay, int yil)
        {
            Console.WriteLine($"Maas Bordrosu, {ay} {yil}");

            foreach (var personel in personelListesi)
            {
                decimal anaOdeme = personel.MaasHesapla();
                decimal mesai = 0;

                if (personel is Memur memur && memur.CalismaSaati > 180)
                {
                    mesai = (memur.CalismaSaati - 180) * (memur.SaatlikUcret * 1.5m);
                }

                decimal toplamOdeme = anaOdeme + mesai;

                Console.WriteLine(" { ");
                Console.WriteLine($"  \"Personel Ismi\": \"{personel.Ad} {personel.Soyad}\",");
                Console.WriteLine($"  \"Calisma Saati\": {personel.CalismaSaati},");
                Console.WriteLine($"  \"Ana Odeme\": {anaOdeme:0,0.00}tl,");
                Console.WriteLine($"  \"Mesai\": {mesai:0,0.00},");
                Console.WriteLine($"  \"Toplam Odeme\": {toplamOdeme:0,0.00}tl");
                Console.WriteLine(" }");
            }


        }
        private static void KontrolEt(int calismaSaati)
        {
            if (calismaSaati < 10 * 20) // 1 güne 8 saat düşürdüm
            {
                Console.WriteLine($"  'Uyarı': Bu personel ayda yeterince çalışmadı.");
            }
        }
    }
}
