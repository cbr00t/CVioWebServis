using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Xml;
using System.Net;
using System.Web.Services.Protocols;

namespace CVioWebServis {
    /// <summary>Vio WebServis Islemleri</summary>
    //[WebService( Namespace = "http://tempuri.org/" )]
    [WebService( Namespace = "http://vioyazilim.com.tr/viows" )]
    [WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
    [System.ComponentModel.ToolboxItem( false )]

    [ScriptService()]
    [XmlInclude( typeof( CIOType ) ), XmlInclude( typeof( DataTable ) ), XmlInclude( typeof( DataSet ) )]
    [XmlInclude( typeof( Filtre ) ), XmlInclude( typeof( FiltreBasiSonu ) ), XmlInclude( typeof( FiltreOzellik ) ), XmlInclude( typeof( FiltreListe ) )]
    [XmlInclude( typeof( CRRMRequest ) ), XmlInclude( typeof( CRRMSimpleRequest ) ), XmlInclude( typeof( CRRMXmlRequest ) ), XmlInclude( typeof( CRRMErrorResponse ) ), XmlInclude( typeof( CRRMErrorCategory ) )]
    [XmlInclude( typeof( CRRMBinaryRequest ) ), XmlInclude( typeof( CRRMDownloadRequest ) )]
    [XmlInclude( typeof( CRRMResponse ) ), XmlInclude( typeof( CRRMStringResponse ) ), XmlInclude( typeof( CRRMBoolResponse ) ), XmlInclude( typeof( CRRMIntegerResponse ) )]
    [XmlInclude( typeof( CRRMBasicXmlResponse ) ), XmlInclude( typeof( CRRMXmlResponse ) )]
    [XmlInclude( typeof( CRRMBinaryResponse ) ), XmlInclude( typeof( CRRMDownloadResponse ) )]
    /*[XmlInclude( typeof( CRRMWSBilgiResponse ) ), XmlInclude( typeof( CRRMSessionInfoResponse ) ), XmlInclude( typeof( CRRMProgramVersionResponse ) )]
    [XmlInclude( typeof( CRRMPingResponse ) ), XmlInclude( typeof( CRRMLoginResponse ) ), XmlInclude( typeof( CRRMLogoutResponse ) ), XmlInclude( typeof( CRRMIslemListesiResponse ) )]
    [XmlInclude( typeof( CRRMRecord ) ), XmlInclude( typeof( CRRMRecordList<CRRMRecord> ) ), XmlInclude( typeof( CRRMR_KodVeAdiYapi ) ), XmlInclude( typeof( CRRMR_KodNoVeAdiYapi ) )]
    [XmlInclude( typeof( CRRMMasterResponse<CRRMR_KodYapi> ) ), XmlInclude( typeof( CRRMMasterResponse<CRRMR_KodVeAdiYapi> ) )]
    [XmlInclude( typeof( CRRMMasterResponse<CRRMR_Stok> ) ), XmlInclude( typeof( CRRMMasterResponse<CRRMR_Cari> ) ), XmlInclude( typeof( CRRMMasterResponse<CRRMR_Plasiyer> ) )]
    [XmlInclude( typeof( CRRMMasterResponse<CRRMR_Il> ) ), XmlInclude( typeof( CRRMMasterResponse<CRRMR_Sube> ) )]*/

    public class VioWS : WebService {
        protected CWSComm wsComm;


        #region Web Service Methods
        [WebMethod()]
        public bool pingBasit() {
            CRRMPingResponse response;

            response = ping( new CRRMPingRequest() );
            return response == null ? false : response.Value;
        }

        [WebMethod()]
        public CRRMPingResponse ping( CRRMPingRequest request ) {
            return (CRRMPingResponse)request.wsCall( wsComm );
        }

        [WebMethod()]
        public CRRMIslemListesiResponse islemListesi( CRRMIslemListesiRequest request ) {
            return (CRRMIslemListesiResponse)request.wsCall( wsComm );
        }

        [WebMethod()]
        public CRRMSessionInfoResponse getSessionInfo( CRRMSessionInfoRequest request ) {
            return (CRRMSessionInfoResponse)request.wsCall( wsComm );
        }

        [WebMethod()]
        public CRRMWSBilgiResponse wsBilgi( CRRMWSBilgiRequest request ) {
            return (CRRMWSBilgiResponse)request.wsCall( wsComm );
        }

        [WebMethod()]
        public CRRMProgramVersionResponse programVersion( CRRMProgramVersionRequest request ) {
            return (CRRMProgramVersionResponse)request.wsCall( wsComm );
        }

        [WebMethod()]
        public CRRMLoginResponse login( CRRMLoginRequest request ) {
            return (CRRMLoginResponse)request.wsCall( wsComm );
        }

        [WebMethod()]
        public CRRMLogoutResponse logout( CRRMLogoutRequest request ) {
            return (CRRMLogoutResponse)request.wsCall( wsComm );
        }

        [WebMethod()]
        public CRRMKayitDegistiKontroluResponse kayitDegistiKontrolu( CRRMKayitDegistiKontroluRequest request ) {
            return (CRRMKayitDegistiKontroluResponse)request.wsCall( wsComm );
        }

        [WebMethod()]
        public CRRM_FRRaporBilgilerResponse frRaporBilgiler( CRRM_FRRaporBilgilerRequest request ) {
            return (CRRM_FRRaporBilgilerResponse)request.wsCall( wsComm );
        }
        [WebMethod()]
        public CRRM_FRRaporOlusturResponse frRaporOlustur( CRRM_FRRaporOlusturRequest request ) {
            return (CRRM_FRRaporOlusturResponse)request.wsCall( wsComm );
        }
        [WebMethod()]
        public CRRM_FRRaporOlusturResponse frRaporGetStream( CRRM_FRRaporGetStreamRequest request ) {
            return (CRRM_FRRaporOlusturResponse)request.wsCall( wsComm );
        }

        [WebMethod()]
        public CRRMMasterResponse<CRRMR_Il> ilListe( CRRMMasterRequest<CRRMR_Il> request ) {
            return (CRRMMasterResponse<CRRMR_Il>)request.wsCall( wsComm, new CRRMCallArgs( "ilListe" ) );
        }

        [WebMethod()]
        public CRRMMasterResponse<CRRMR_Cari> cariListe( CRRMMasterRequest<CRRMR_Cari> request ) {
            return (CRRMMasterResponse<CRRMR_Cari>)request.wsCall( wsComm, new CRRMCallArgs( "cariListe" ) );
        }

        [WebMethod()]
        public CRRMMasterResponse<CRRMR_Plasiyer> plasiyerListe( CRRMMasterRequest<CRRMR_Plasiyer> request ) {
            return (CRRMMasterResponse<CRRMR_Plasiyer>)request.wsCall( wsComm, new CRRMCallArgs( "plasiyerListe" ) );
        }

        [WebMethod()]
        public CRRMMasterResponse<CRRMR_Sube> subeListe( CRRMMasterRequest<CRRMR_Sube> request ) {
            return (CRRMMasterResponse<CRRMR_Sube>)request.wsCall( wsComm, new CRRMCallArgs( "subeListe" ) );
        }

        [WebMethod()]
        public CRRMMasterResponse<CRRMR_Stok> stokListe( CRRMMasterRequest<CRRMR_Stok> request ) {
            return (CRRMMasterResponse<CRRMR_Stok>)request.wsCall( wsComm, new CRRMCallArgs( "stokListe" ) );
        }

        [WebMethod()]
        public CRRMMasterResponse<CRRMR_TahsilSekli> tahsilSekliListe( CRRMMasterRequest<CRRMR_TahsilSekli> request ) {
            return (CRRMMasterResponse<CRRMR_TahsilSekli>)request.wsCall( wsComm, new CRRMCallArgs( "stokListe" ) );
        }

        [WebMethod()]
        public CRRMTest01Response test01( CRRMTest01Request request ) {
            return (CRRMTest01Response)request.wsCall( wsComm );
        }

        /*[WebMethod()]
        public DataTable nakliyeSekliListe( CRRMRequest request, Filtre[] filtreler ) {
            return wsComm.sendWebRequestAndGetDataTable( islem: "nakliyeSekliListe", request: request, filtreler: filtreler );
        }

        [WebMethod()]
        public DataTable tahsilSekliListe( CRRMRequest request, Filtre[] filtreler ) {
            return wsComm.sendWebRequestAndGetDataTable( islem: "tahsilSekliListe", request: request, filtreler: filtreler );
        }

        [WebMethod()]
        public DataTable barkodReferansListe( CRRMRequest request, Filtre[] filtreler ) {
            return wsComm.sendWebRequestAndGetDataTable( islem: "barkodReferansListe", request: request, filtreler: filtreler );
        }

        [WebMethod()]
        public DataTable tartiFormatListe( CRRMRequest request, Filtre[] filtreler ) {
            return wsComm.sendWebRequestAndGetDataTable( islem: "tartiFormatListe", request: request, filtreler: filtreler );
        }

        [WebMethod()]
        public DataTable modelListe( CRRMRequest request, Filtre[] filtreler ) {
            return wsComm.sendWebRequestAndGetDataTable( islem: "modelListe", request: request, filtreler: filtreler );
        }

        [WebMethod()]
        public DataTable renkListe( CRRMRequest request, Filtre[] filtreler ) {
            return wsComm.sendWebRequestAndGetDataTable( islem: "renkListe", request: request, filtreler: filtreler );
        }

        [WebMethod()]
        public DataTable desenListe( CRRMRequest request, Filtre[] filtreler ) {
            return wsComm.sendWebRequestAndGetDataTable( islem: "desenListe", request: request, filtreler: filtreler );
        }

        [WebMethod()]
        public DataSet masterBilgiler( CRRMRequest request, Filtre[] filtreler ) {
            return wsComm.sendWebRequestAndGetDataSet( islem: "masterBilgiler", request: request, filtreler: filtreler );
        }

        [WebMethod()]
        public DataSet modelRenkDesenListe( CRRMRequest request, Filtre[] filtreler ) {
            return wsComm.sendWebRequestAndGetDataSet( islem: "modelRenkDesenListe", request: request, filtreler: filtreler );
        }

        [WebMethod()]
        public int ticariBelgeGonder( CRRMRequest request, GonderimFisTipi fisTipi, params Kaydet_BelgeOrtak[] belgeler ) {
            int fisSayac = 0;

            wsComm.sendWebRequest(
                islem: "fisKaydet"
                , request: request
                , outputType: CIOType.tab
                , ekArgs: new string[][] {
                            new string[] { "fisTipi", fisTipi.ToString() }
                            }.asEkArgs()
                , requestBlock: ( req, aStream ) => {
                    wsComm.sendWebRequestWithXMLReader_requestProc(
                        req: req
                        , aStream: aStream
                        , postRequestBlock: ( _req, xw, _aStream ) => {
                            #region #function block#
                            xw.WriteStartDocument();
                            if (belgeler != null) {
                                xw.WriteStartElement( "Fisler" );
                                foreach (var belge in belgeler)
                                    belge.xmlWriteTo( xw );
                                xw.WriteEndElement();
                            }
                            xw.WriteEndDocument();
                            #endregion
                        }
                    );
                }
                , responseBlock: ( resp, aStream, req ) => {
                    #region #function block#
                    StreamReader sr;

                    ( sr = new StreamReader( aStream ) ).ReadLine();
                    fisSayac = Convert.ToInt32( sr.ReadLine().Split( '\t' )[1].Trim( '"' ) );
                    #endregion
                } );

            return fisSayac;
        }

        [WebMethod()]
        public string cariKaydet( CRRMRequest request, params Cari[] kayitlar ) {
            return masterKaydet( request: request, islem: "cariKaydet", kayitlar: kayitlar );
        }

        [WebMethod()]
        public string stokKaydet( CRRMRequest request, params Stok[] kayitlar ) {
            return masterKaydet( request: request, islem: "stokKaydet", kayitlar: kayitlar );
        }

        [WebMethod()]
        public DataSet belgeler( CRRMRequest request, TicariBelgePIFTipi pifTipi, TicariBelgeAlmSat almSat, bool iademi, Filtre[] filtreler ) {
            return wsComm.sendWebRequestAndGetDataSet( islem: "belgeler"
                        , request: request
                        , filtreler: filtreler
                        , ekArgs: new string[][] {
                                    new string[] { "pifTipi", pifTipi.ToString() }
                                    , new string[] { "almSat", almSat.ToString() }
                                    , new string[] { "iademi", iademi.ToString() }
                                    }.asEkArgs()
                        );
        }

        [WebMethod()]
        public Cevap_TicariBelge[] belgeler2( CRRMRequest request, TicariBelgePIFTipi pifTipi, TicariBelgeAlmSat almSat, bool iademi, Filtre[] filtreler ) {
            List<Cevap_TicariBelge> aCollection = null;

            wsComm.sendWebRequestWithXMLDocument( islem: "belgeler2"
                , request: request
                , filtreler: filtreler
                , ekArgs: new string[][] {
                                    new string[] { "pifTipi", pifTipi.ToString() }
                                    , new string[] { "almSat", almSat.ToString() }
                                    , new string[] { "iademi", iademi.ToString() }
                                    }.asEkArgs()
                , postResponseBlock: ( resp, xdoc, aStream, req ) => {
                    XmlElement xroot;

                    xroot = (XmlElement)xdoc.DocumentElement.SelectSingleNode( "//Result" ).ChildNodes[0];
                    aCollection = CParserBase.XmlReadFromElementList<Cevap_TicariBelge>( null, xroot );
                } );

            return ( aCollection == null
                        ? null
                        : aCollection.ToArray() );
        }*/
        #endregion

        #region Yardimci
        /*public string masterKaydet( CRRMRequest request, string islem, params CMasterBase[] kayitlar ) {
            string kod = null;

            wsComm.sendWebRequest(
                islem: islem
                , request: request
                , outputType: CIOType.tab
                , requestBlock: ( req, aStream ) => {
                    wsComm.sendWebRequestWithXMLReader_requestProc(
                        req: req
                        , aStream: aStream
                        , postRequestBlock: ( _req, xw, _aStream ) => {
                            #region #function block#
                            xw.WriteStartDocument();
                            if (kayitlar != null) {
                                xw.WriteStartElement( "Kayitlar" );
                                foreach (var kayit in kayitlar)
                                    kayit.xmlWriteTo( xw );
                                xw.WriteEndElement();
                            }
                            xw.WriteEndDocument();
                            #endregion
                        }
                    );
                }
                , responseBlock: ( resp, aStream, req ) => {
                    #region #function block#
                    StreamReader sr;

                    ( sr = new StreamReader( aStream ) ).ReadLine();
                    kod = sr.ReadLine().Split( '\t' )[1].Trim( '"' );
                    #endregion
                } );

            return kod;
        }*/
        #endregion

        #region Not Categorized
        public VioWS() : base() {
            wsComm = new CWSComm();
        }
        #endregion
    }
}