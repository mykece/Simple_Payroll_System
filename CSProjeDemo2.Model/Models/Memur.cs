using CSProjeDemo2.Model.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.Model.Models
{
    public class Memur : Personel
    {
        public int Derece { get; set; }

        public Memur()
        {
            Derece = 0; // Varsayılan olarak 0 atanıyor
        }

        // Maaş hesaplama metodu override ediliyor
        public override decimal MaasHesapla()
        {
            decimal saatlikUcret = 500; // Varsayılan saatlik ücret
            switch (Derece)
            {
                case 0:
                    saatlikUcret = 550;
                    break;
                case 1:
                    saatlikUcret = 550;
                    break;
                case 2:
                    saatlikUcret = 600;
                    break;
                    // Daha fazla derece için case'ler eklenebilir
            }

            decimal maas = saatlikUcret * CalismaSaati;
            if (CalismaSaati > 180)
            {
                maas += (CalismaSaati - 180) * (saatlikUcret * 1.5m);
            }
            return maas;
        }
    }
}
