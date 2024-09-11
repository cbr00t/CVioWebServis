using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerTarCalismaOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "perID" )] public Guid PerID { get; set; }
        [XmlElement( "firmaCalismaAlanID" )] public Guid FirmaCalismaAlanID { get; set; }
        [XmlElement( "donemID" )] public Guid DonemID { get; set; }
        [XmlElement( "baslangicTarihi" )] public DateTime BaslangicTarihi { get; set; }
        [XmlElement( "gunSayisi" )] public int GunSayisi { get; set; }
        [XmlElement( "netBrut" )] public string NetBrutKod { get; set; }
        public CRRM_GYPerTarNetBrut NetBrut {
            get {
                if (NetBrutKod != null) {
                    switch (NetBrutKod.ToUpper()) {
                        case "N": return CRRM_GYPerTarNetBrut.Net;
                        case "A": return CRRM_GYPerTarNetBrut.AgiDahilNet;
                    }
                }
                return CRRM_GYPerTarNetBrut.Brut;
            }
            set {
                switch (value) {
                    case CRRM_GYPerTarNetBrut.Net: NetBrutKod = "N"; break;
                    case CRRM_GYPerTarNetBrut.AgiDahilNet: NetBrutKod = "A"; break;
                    default: NetBrutKod = "B"; break;
                }
            }
        }
        [XmlElement( "ucret" )] public decimal Ucret { get; set; }
        [XmlElement( "fazlaMesai50" ), DefaultValue( typeof( decimal ), "0" )] public decimal FazlaMesai50 { get; set; }
        [XmlElement( "fazlaMesai100" ), DefaultValue( typeof( decimal ), "0" )] public decimal FazlaMesai100 { get; set; }
        [XmlElement( "fazlaMesai150" ), DefaultValue( typeof( decimal ), "0" )] public decimal FazlaMesai150 { get; set; }
        [XmlElement( "fazlaMesaiNormal" ), DefaultValue( typeof( decimal ), "0" )] public decimal FazlaMesaiNormal { get; set; }
        [XmlElement( "yemek" ), DefaultValue( typeof( decimal ), "0" )] public decimal Yemek { get; set; }
        [XmlElement( "ekKatkilar" )] public CXmlDict<string, decimal> EkKatkilar { get; set; }
        #endregion
    }
}
