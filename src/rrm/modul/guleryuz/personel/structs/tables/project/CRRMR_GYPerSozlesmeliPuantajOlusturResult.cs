using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerSozlesmeliPuantajOlusturResult : CRRMResponseRecord {
        #region Accessors
        [XmlElement( "yilAy" ), DefaultValue( 0 )] public int YilAy { get; set; }
        [XmlElement( "yil" ), DefaultValue( 0 )] public int Yil { get; set; }
        [XmlElement( "ay" ), DefaultValue( 0 )] public int Ay { get; set; }
        /*[XmlElement( "perID" )] public Guid? PerID { get; set; }*/
        [XmlElement( "perSayac" ), DefaultValue( 0 )] public int PerSayac { get; set; }
        [XmlElement( "perKod" )] public string PerKod { get; set; }
        /*[XmlElement( "perIsim" )] public string PerIsim { get; set; }*/
        [XmlElement( "calismaID" ), DefaultValue( 0 )] public int CalismaID { get; set; }
        [XmlElement( "toplamCalismaGunu" ), DefaultValue( typeof( decimal ), "0" )] public decimal ToplamCalismaGunu { get; set; }
        [XmlElement( "toplamFazlaMesaiNormal" ), DefaultValue( typeof( decimal ), "0" )] public decimal ToplamFazlaMesaiNormal { get; set; }
        [XmlElement( "toplamFazlaMesai50" ), DefaultValue( typeof( decimal ), "0" )] public decimal ToplamFazlaMesai50 { get; set; }
        [XmlElement( "toplamFazlaMesai100" ), DefaultValue( typeof( decimal ), "0" )] public decimal ToplamFazlaMesai100 { get; set; }
        [XmlElement( "toplamCalismaSaat" ), DefaultValue( typeof( decimal ), "0" )] public decimal ToplamCalismaSaat { get; set; }
        [XmlElement( "toplamMesaiTumSaat" ), DefaultValue( typeof( decimal ), "0" )] public decimal ToplamMesaiTumSaat { get; set; }
        [XmlElement( "fazlaMesaiNormalSaat" ), DefaultValue( typeof( decimal ), "0" )] public decimal FazlaMesaiNormalSaat { get; set; }
        [XmlElement( "fazlaMesai50Saat" ), DefaultValue( typeof( decimal ), "0" )] public decimal FazlaMesai50Saat { get; set; }
        [XmlElement( "fazlaMesai100Saat" ), DefaultValue( typeof( decimal ), "0" )] public decimal FazlaMesai100Saat { get; set; }
        [XmlElement( "toplamYanOdemeBedel" ), DefaultValue( typeof( decimal ), "0" )] public decimal ToplamYanOdemeBedel { get; set; }
        #endregion
    }
}
