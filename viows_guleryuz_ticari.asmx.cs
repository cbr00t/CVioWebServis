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

namespace CVioWebServis.modul {
    /// <summary>Vio WebServis Islemleri</summary>
    //[WebService( Namespace = "http://tempuri.org/" )]
    [WebService(Namespace = "http://vioyazilim.com.tr/viows")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    [ScriptService()]
    [XmlInclude(typeof(CIOType)), XmlInclude(typeof(DataTable)), XmlInclude(typeof(DataSet))]
    [XmlInclude(typeof(Filtre)), XmlInclude(typeof(FiltreBasiSonu)), XmlInclude(typeof(FiltreOzellik)), XmlInclude(typeof(FiltreListe))]
    [XmlInclude(typeof(CRRMRequest)), XmlInclude(typeof(CRRMSimpleRequest)), XmlInclude(typeof(CRRMXmlRequest)), XmlInclude(typeof(CRRMErrorResponse)), XmlInclude(typeof(CRRMErrorCategory))]
    [XmlInclude(typeof(CRRMBinaryRequest)), XmlInclude(typeof(CRRMDownloadRequest))]
    [XmlInclude(typeof(CRRMResponse)), XmlInclude(typeof(CRRMStringResponse)), XmlInclude(typeof(CRRMBoolResponse)), XmlInclude(typeof(CRRMIntegerResponse))]
    [XmlInclude(typeof(CRRMBasicXmlResponse)), XmlInclude(typeof(CRRMXmlResponse))]
    [XmlInclude(typeof(CRRMBinaryResponse)), XmlInclude(typeof(CRRMDownloadResponse))]

    public class VioWS_Guleryuz_Ticari : WebService {
        protected CWSComm wsComm;

        public VioWS_Guleryuz_Ticari() : base() { wsComm = new CWSComm() { WSUrlPrefix = "ws/modul/guleryuz/ticari" }; }
        #region Web Service Methods
        [WebMethod()] public bool pingBasit() { var response = ping(new CRRMPingRequest()); return response == null ? false : response.Value; }
        [WebMethod()] public CRRMPingResponse ping(CRRMPingRequest request) { return (CRRMPingResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRMIslemListesiResponse islemListesi(CRRMIslemListesiRequest request) { return (CRRMIslemListesiResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRMSessionInfoResponse getSessionInfo(CRRMSessionInfoRequest request) { return (CRRMSessionInfoResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRMWSBilgiResponse wsBilgi(CRRMWSBilgiRequest request) { return (CRRMWSBilgiResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRMProgramVersionResponse programVersion(CRRMProgramVersionRequest request) { return (CRRMProgramVersionResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRMLoginResponse login(CRRMLoginRequest request) { return (CRRMLoginResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRMLogoutResponse logout(CRRMLogoutRequest request) { return (CRRMLogoutResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRMKayitDegistiKontroluResponse kayitDegistiKontrolu(CRRMKayitDegistiKontroluRequest request) { return (CRRMKayitDegistiKontroluResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_FRRaporBilgilerResponse frRaporBilgiler(CRRM_FRRaporBilgilerRequest request) { return (CRRM_FRRaporBilgilerResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_FRRaporOlusturResponse frRaporOlustur(CRRM_FRRaporOlusturRequest request) { return (CRRM_FRRaporOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_FRRaporOlusturResponse frRaporGetStream(CRRM_FRRaporGetStreamRequest request) { return (CRRM_FRRaporOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYTicEFaturalariVerResponse ticEFaturalariVer(CRRM_GYTicEFaturalariVerRequest request) { return (CRRM_GYTicEFaturalariVerResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYTicEFaturaPdfVerResponse ticEFaturaPDFVer(CRRM_GYTicEFaturaPdfVerRequest request) { return (CRRM_GYTicEFaturaPdfVerResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYTicBolgeOlusturResponse ticBolgeOlustur(CRRM_GYTicBolgeOlusturRequest request) { return (CRRM_GYTicBolgeOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYTicGorevOlusturResponse ticGorevOlustur(CRRM_GYTicGorevOlusturRequest request) { return (CRRM_GYTicGorevOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYTicDonemOlusturResponse ticDonemOlustur(CRRM_GYTicDonemOlusturRequest request) { return (CRRM_GYTicDonemOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYTicFirmaOlusturResponse ticFirmaOlustur(CRRM_GYTicFirmaOlusturRequest request) { return (CRRM_GYTicFirmaOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYTicFirmaHakedisOlusturResponse ticFirmaHakedisOlustur(CRRM_GYTicFirmaHakedisOlusturRequest request) { return (CRRM_GYTicFirmaHakedisOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYTicKategorileriVerResponse ticKategorileriVer(CRRM_GYTicKategorileriVerRequest request) { return (CRRM_GYTicKategorileriVerResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYTicHizmetleriVerResponse ticHizmetleriVer(CRRM_GYTicHizmetleriVerRequest request) { return (CRRM_GYTicHizmetleriVerResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYTicBolgeleriVerResponse ticBolgeleriVer(CRRM_GYTicBolgeleriVerRequest request) { return (CRRM_GYTicBolgeleriVerResponse)request.wsCall(wsComm); }
		[WebMethod()] public CRRM_GYTicTakipNolariVerResponse ticTakipNolariVer(CRRM_GYTicTakipNolariVerRequest request) { return (CRRM_GYTicTakipNolariVerResponse)request.wsCall(wsComm); }
		[WebMethod()] public CRRM_GYTicFaturaVeriOlusturResponse ticFaturaVeriOlustur(CRRM_GYTicFaturaVeriOlusturRequest request) { return (CRRM_GYTicFaturaVeriOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYTicHizmetleriEslestirResponse ticHizmetleriEslestir(CRRM_GYTicHizmetleriEslestirRequest request) { return (CRRM_GYTicHizmetleriEslestirResponse)request.wsCall(wsComm); }
		[WebMethod()] public CRRM_GYTicHizmetHakedisVeMaliyetResponse ticHizmetHakedisVeMaliyet(CRRM_GYTicHizmetHakedisVeMaliyetRequest request) { return (CRRM_GYTicHizmetHakedisVeMaliyetResponse)request.wsCall(wsComm); }
		#region -------------------------------------------- İPTAL OLANLAR --------------------------------------------
		/*[WebMethod(), Obsolete("Bu API kullanımdan kaldırılmıştır", true)] public CRRM_GYTicFirmaIDAtaResponse ticFirmaIDAta( CRRM_GYTicFirmaIDAtaRequest request ) { return (CRRM_GYTicFirmaIDAtaResponse)request.wsCall( wsComm ); }
        [WebMethod(), Obsolete("Bu API kullanımdan kaldırılmıştır", true)] public CRRM_GYTicGorevIDAtaResponse ticGorevIDAta( CRRM_GYTicGorevIDAtaRequest request ) { return (CRRM_GYTicGorevIDAtaResponse)request.wsCall( wsComm ); }
        [WebMethod(), Obsolete("Bu API kullanımdan kaldırılmıştır", true)] public CRRM_GYTicFirmalariVerResponse ticFirmalariVer( CRRM_GYTicFirmalariVerRequest request ) { return (CRRM_GYTicFirmalariVerResponse)request.wsCall( wsComm ); }
        [WebMethod(), Obsolete("Bu API kullanımdan kaldırılmıştır", true)] public CRRM_GYTicGorevleriVerResponse ticGorevleriVer( CRRM_GYTicGorevleriVerRequest request ) { return (CRRM_GYTicGorevleriVerResponse)request.wsCall( wsComm ); }
        [WebMethod(), Obsolete("Bu API kullanımdan kaldırılmıştır", true)] public CRRM_GYTicHizmetKategorileriVerResponse ticHizmetKategorileriVer( CRRM_GYTicHizmetKategorileriVerRequest request ) { return (CRRM_GYTicHizmetKategorileriVerResponse)request.wsCall( wsComm ); }
        [WebMethod(), Obsolete("Bu API kullanımdan kaldırılmıştır", true)] public CRRM_GYTicHizmetTurleriVerResponse ticHizmetTurleriVer( CRRM_GYTicHizmetTurleriVerRequest request ) { return (CRRM_GYTicHizmetTurleriVerResponse)request.wsCall( wsComm ); }
        [WebMethod(), Obsolete("Bu API kullanımdan kaldırılmıştır", true)] public CRRM_GYTicGiderGruplariVerResponse ticGiderGruplariVer( CRRM_GYTicGiderGruplariVerRequest request ) { return (CRRM_GYTicGiderGruplariVerResponse)request.wsCall( wsComm ); }
        [WebMethod(), Obsolete("Bu API kullanımdan kaldırılmıştır", true)] public CRRM_GYTicGiderMasrafVerResponse ticGiderMasrafVer( CRRM_GYTicGiderMasrafVerRequest request ) { return (CRRM_GYTicGiderMasrafVerResponse)request.wsCall( wsComm ); }
        [WebMethod(), Obsolete("Bu API kullanımdan kaldırılmıştır", true)] public CRRM_GYTicFaturaBilgiVerResponse ticFaturaBilgiVer( CRRM_GYTicFaturaBilgiVerRequest request ) { return (CRRM_GYTicFaturaBilgiVerResponse)request.wsCall( wsComm ); }*/
		#endregion
		#endregion
	}
}
