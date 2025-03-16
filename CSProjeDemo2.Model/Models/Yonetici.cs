using CSProjeDemo2.Model.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.Model.Models;

public class Yonetici : Personel
{
    public decimal Bonus { get; set; }

    // Maaş hesaplama metodu override ediliyor
    public override decimal MaasHesapla()
    {
       

        decimal maas = (SaatlikUcret * CalismaSaati) + Bonus;
        return maas;
    }
}    
