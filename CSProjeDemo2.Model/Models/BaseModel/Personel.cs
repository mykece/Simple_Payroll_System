using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.Model.Models.BaseModel
{
    public abstract class Personel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public decimal SaatlikUcret { get; set; }
        public int CalismaSaati { get; set; }
        //public int Mesai { get; set; }

        // Abstract metot, türetilen sınıflarda implement edilecek
        public abstract decimal MaasHesapla();
    }
}
