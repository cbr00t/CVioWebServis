using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;

namespace CVioWebServis {
    [Serializable()]
    public enum CRRMR_FRSecimTipi {
        Belirsiz, GorselUyari, TekKullan, BirKismi, TekSecim, CheckBox, Ozellik, Tarih, Saat, Number, Decimal,
        GuneKadar, Kullan, KullanVeBirKismi, SayiyaKadar, TariheKadar, TarihSaatmi,
        TekAy, TekYil, TekSube, TekTarih, DropDownList
    }
}
