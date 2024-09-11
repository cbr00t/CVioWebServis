using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.ComponentModel;

namespace CVioWebServis {
    [Serializable()]
    public class CRRMR_GYPerSozlesmeliDonemOlusturArg : CRRMRequestRecord {
        #region Accessors
        [XmlElement( "donemID" )] public Guid DonemID { get; set; }
        [XmlElement( "firmaID" )] public Guid FirmaID { get; set; }
        [XmlElement( "bolgeID" )] public Guid BolgeID { get; set; }
        [XmlElement( "yetkiliID" )] public Guid? YetkiliID { get; set; }
        [XmlElement( "yilAy" ), DefaultValue( 0 )] public int YilAy { get; set; }
        [XmlElement( "yil" ), DefaultValue( 0 )] public int Yil { get; set; }
        [XmlElement( "ay" ), DefaultValue( 0 )] public int Ay { get; set; }
        #endregion
    }
}
