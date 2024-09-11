using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;
using System.Xml.Serialization;
using System.Reflection;

namespace CVioWebServis {
    [Serializable()]
    public class CRRM_FRRaporBilgilerResponse : CRRMBasicXmlResponse {
        #region Accessors
        public CRRMR_SayacVeAdiYapi[] Raporlar { get; set; }
        public CRRMR_FRSecimBilgi[] Secimler { get; set; }
        #endregion

        #region Parser
        public override void parseResponse( CRRMCallArgs args ) {
            base.parseResponse( args );
            var xr = args.UserData as XmlReader;
            if (xr == null) 
                return;

            const string NodeName_Item = "_";
            CList<CRRMR_SayacVeAdiYapi> raporlar = null;
            CList<CRRMR_FRSecimBilgi> secimler = null;

            var xdoc = new XmlDocument();
            xdoc.Load( xr );
            var xroot = xdoc.DocumentElement;
            var xresult = xroot.SelectSingleNode( "Result" );
            var xitems = xresult.SelectNodes( NodeName_Item );
            if (xitems != null && xitems.Count != 0) {
                #region block
                raporlar = new CList<CRRMR_SayacVeAdiYapi>();
                var xitem = xitems[0];
                foreach (XmlElement xsubItem in xitem) {
                    #region block
                    var item = new CRRMR_SayacVeAdiYapi();
                    foreach (XmlElement xnode in xsubItem) {
                        #region block
                        switch (xnode.LocalName) {
                            #region block
                            case "sayac": item.Sayac = xnode.InnerText.Trim().asInteger(); break;
                            case "aciklama": item.Aciklama = xnode.InnerText.TrimEnd(); break;
                            #endregion
                        }
                        #endregion
                    }
                    if (item.Sayac.bosDegilmi())
                        raporlar.Add( item );
                    #endregion
                }
                if (raporlar != null)
                    this.Raporlar = raporlar.ToArray();

                if (xitems.Count > 1) {
                    #region block
                    secimler = new CList<CRRMR_FRSecimBilgi>();
                    xitem = xitems[1];
                    foreach (XmlElement xsubItem in xitem) {
                        #region block
                        var item = new CRRMR_FRSecimBilgi();
                        var subItems = new CList<CRRMR_KodVeAdiYapi>();
                        foreach (XmlElement xnode in xsubItem) {
                            #region block
                            switch (xnode.LocalName) {
                                #region block
                                case "attr": item.Kod = xnode.InnerText.Trim(); break;
                                case "tip": item.TipKod = xnode.InnerText.Trim(); break;
                                case "etiket": item.Aciklama = xnode.InnerText.TrimEnd(); break;
                                case "basi": item.Basi = xnode.InnerText.TrimEnd(); break;
                                case "sonu": item.Sonu = xnode.InnerText.TrimEnd(); break;
                                case "ozellik": item.Ozellik = xnode.InnerText.TrimEnd(); break;
                                case "deger":
                                case "default":
                                    item.DefaultValue = xnode.InnerText.TrimEnd();
                                    break;
                                case "digitSayisi": item.MaxLength = xnode.InnerText.Trim().asIntegerQ(); break;
                                case "sinif": item.MFSinif = xnode.InnerText.TrimEnd(); break;
                                case "ddListmi": item.DDListmi = Convert.ToBoolean( xnode.InnerText.Trim() ); break;
                                case "_":
                                    #region block
                                    string kod = null, aciklama = null;
                                    foreach (XmlElement xvalue in xnode) {
                                        #region block
                                        switch (xvalue.LocalName) {
                                            #region block
                                            case "kod": kod = xvalue.InnerText.TrimEnd(); break;
                                            case "adi": case "aciklama": aciklama = xvalue.InnerText.TrimEnd(); break;
                                            #endregion
                                        }
                                        #endregion
                                    }
                                    if (kod != null)
                                        subItems.Add( new CRRMR_KodVeAdiYapi() { Kod = kod, Aciklama = aciklama } );
                                    break;
                                    #endregion
                                #endregion
                            }
                            #endregion
                        }
                        if (item.Aciklama.bosDegilmi()) {
                            #region block
                            if (subItems.bosDegilmi())
                                item.SubItems = subItems.ToArray();
                            secimler.Add( item );
                            #endregion
                        }
                        #endregion
                    }
                    if (secimler != null)
                        this.Secimler = secimler.ToArray();
                    #endregion
                }
                #endregion
            }
        }
        #endregion
    }
}
