using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerPersonelOlusturResult : CRRMR_GYBasicResultWithID {
        #region Accessors
        /*[XmlElement( "webServisIslemHataKod" )] public string WebServisIslemHataKod { get; set; }
        [XmlElement( "webServisIslemHataAciklama" )] public string WebServisIslemHataAciklama { get; set; }*/
        [XmlElement( "eslesmeVarmi" ), DefaultValue( false )] public bool EslesmeVarmi { get; set; }
        [XmlElement( "kimlikSorgulamaYapilirmi" ), DefaultValue( false )] public bool KimlikSorgulamaYapilirmi { get; set; }
        [XmlElement( "kimlikSorgulamaYapildimi" ), DefaultValue( false )] public bool KimlikSorgulamaYapildimi { get; set; }
        [XmlElement( "perSayac" )]
        public int? PerSayac { get; set; }
        [XmlElement( "perKod" )] public string PerKod { get; set; }
        [XmlElement( "tcKimlikNo" )] public string TCKimlikNo { get; set; }
        [XmlElement( "emeklimi" ), DefaultValue( false )] public bool Emeklimi { get; set; }
        [XmlElement( "masrafKod" )] public string MasrafKod { get; set; }
        [XmlElement( "grupKod" )] public string GrupKod { get; set; }
        [XmlElement( "gorevKod" )] public string GorevKod { get; set; }
        [XmlElement( "adi" )] public string Adi { get; set; }
        [XmlElement( "soyadi" )] public string Soyadi { get; set; }
        [XmlElement( "babaAdi" )] public string BabaAdi { get; set; }
        [XmlElement( "ilKod" )] public string IlKod { get; set; }
        [XmlElement( "ilAdi" )] public string IlAdi { get; set; }
        [XmlElement( "ilceAdi" )] public string IlceAdi { get; set; }
        [XmlElement( "mahalle" )] public string Mahalle { get; set; }
        [XmlElement( "cadde" )] public string Cadde { get; set; }
        [XmlElement( "sokak" )] public string Sokak { get; set; }
        [XmlElement( "disKapiNo" )] public string DisKapiNo { get; set; }
        [XmlElement( "icKapiNo" )] public string IcKapiNo { get; set; }
        [XmlElement( "cepTel" )] public string CepTel { get; set; }
        [XmlElement( "ibanNo" )] public string IBANNo { get; set; }
        [XmlElement( "hesKod" )] public string HESKod { get; set; }
        #endregion
    }
}
