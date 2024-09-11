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
    /* [WebService( Namespace = "http://tempuri.org/" )] */
    [WebService(Namespace = "http://vioyazilim.com.tr/viows"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1), System.ComponentModel.ToolboxItem(false), ScriptService()]
    [XmlInclude(typeof(CIOType)), XmlInclude(typeof(DataTable)), XmlInclude(typeof(DataSet))]
    [XmlInclude(typeof(Filtre)), XmlInclude(typeof(FiltreBasiSonu)), XmlInclude(typeof(FiltreOzellik)), XmlInclude(typeof(FiltreListe))]
    [XmlInclude(typeof(CRRMRequest)), XmlInclude(typeof(CRRMSimpleRequest)), XmlInclude(typeof(CRRMXmlRequest)), XmlInclude(typeof(CRRMErrorResponse)), XmlInclude(typeof(CRRMErrorCategory))]
    [XmlInclude(typeof(CRRMBinaryRequest)), XmlInclude(typeof(CRRMDownloadRequest)), XmlInclude(typeof(CRRMResponse)), XmlInclude(typeof(CRRMStringResponse)), XmlInclude(typeof(CRRMBoolResponse)), XmlInclude(typeof(CRRMIntegerResponse))]
    [XmlInclude(typeof(CRRMBasicXmlResponse)), XmlInclude(typeof(CRRMXmlResponse)), XmlInclude(typeof(CRRMBinaryResponse)), XmlInclude(typeof(CRRMDownloadResponse))]

    public class VioWS_Guleryuz_Personel : WebService {
        protected CWSComm wsComm;

        public VioWS_Guleryuz_Personel() : base() { wsComm = new CWSComm() { WSUrlPrefix = "ws/modul/guleryuz/personel" }; }
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
        [WebMethod()] public CRRM_GYPerSGKIsyerleriVerResponse perSGKIsyerleriVer(CRRM_GYPerSGKIsyerleriVerRequest request) { return (CRRM_GYPerSGKIsyerleriVerResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerSGKMeslekleriVerResponse perSGKMeslekleriVer(CRRM_GYPerSGKMeslekleriVerRequest request) { return (CRRM_GYPerSGKMeslekleriVerResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerMasraflariVerResponse perMasraflariVer(CRRM_GYPerMasraflariVerRequest request) { return (CRRM_GYPerMasraflariVerResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerGruplariVerResponse perGruplariVer(CRRM_GYPerGruplariVerRequest request) { return (CRRM_GYPerGruplariVerResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerGorevleriVerResponse perGorevleriVer(CRRM_GYPerGorevleriVerRequest request) { return (CRRM_GYPerGorevleriVerResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerIstenCikisNedenleriVerResponse perIstenCikisNedenleriVer(CRRM_GYPerIstenCikisNedenleriVerRequest request) { return (CRRM_GYPerIstenCikisNedenleriVerResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerEksikGunNedenleriVerResponse perEksikGunNedenleriVer(CRRM_GYPerEksikGunNedenleriVerRequest request) { return (CRRM_GYPerEksikGunNedenleriVerResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerYanOdemeListeResponse perYanOdemeListe(CRRM_GYPerYanOdemeListeRequest request) { return (CRRM_GYPerYanOdemeListeResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerKesintiOdemeListeResponse perKesintiOdemeListe(CRRM_GYPerKesintiOdemeListeRequest request) { return (CRRM_GYPerKesintiOdemeListeResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerTarFirmaMaliyetlerVerResponse perTarFirmaMaliyetlerVer(CRRM_GYPerTarFirmaMaliyetlerVerRequest request) { return (CRRM_GYPerTarFirmaMaliyetlerVerResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerSozlesmeliFirmaMaliyetlerVerResponse perSozlesmeliFirmaMaliyetlerVer(CRRM_GYPerSozlesmeliFirmaMaliyetlerVerRequest request) { return (CRRM_GYPerSozlesmeliFirmaMaliyetlerVerResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerPersonelOlusturVeIseGirisYapResponse perPersonelOlusturVeIseGirisYap(CRRM_GYPerPersonelOlusturVeIseGirisYapRequest request) { return (CRRM_GYPerPersonelOlusturVeIseGirisYapResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerSozlesmeliPersonelOlusturVeIseGirisYapResponse perSozlesmeliPersonelOlusturVeIseGirisYap(CRRM_GYPerSozlesmeliPersonelOlusturVeIseGirisYapRequest request) { return (CRRM_GYPerSozlesmeliPersonelOlusturVeIseGirisYapResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerPersonelOlusturResponse perPersonelOlustur(CRRM_GYPerPersonelOlusturRequest request) { return (CRRM_GYPerPersonelOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerSozlesmeliPersonelOlusturResponse perSozlesmeliPersonelOlustur(CRRM_GYPerSozlesmeliPersonelOlusturRequest request) { return (CRRM_GYPerSozlesmeliPersonelOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerPersonelSilResponse perPersonelSil(CRRM_GYPerPersonelSilRequest request) { return (CRRM_GYPerPersonelSilResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerPersonelListeResponse perPersonelListe(CRRM_GYPerPersonelListeRequest request) { return (CRRM_GYPerPersonelListeResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerIseGirisYapResponse perIseGirisYap(CRRM_GYPerIseGirisYapRequest request) { return (CRRM_GYPerIseGirisYapResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerIstenCikisYapResponse perIstenCikisYap(CRRM_GYPerIstenCikisYapRequest request) { return (CRRM_GYPerIstenCikisYapResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerIseGirisPdfVerResponse perIseGirisPDFVer(CRRM_GYPerIseGirisPdfVerRequest request) { return (CRRM_GYPerIseGirisPdfVerResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerIstenCikisPdfVerResponse perIstenCikisPDFVer(CRRM_GYPerIstenCikisPdfVerRequest request) { return (CRRM_GYPerIstenCikisPdfVerResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerUcretPusulaGonderResponse perUcretPusulaGonder(CRRM_GYPerUcretPusulaGonderRequest request) { return (CRRM_GYPerUcretPusulaGonderResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerBolgeOlusturResponse perBolgeOlustur(CRRM_GYPerBolgeOlusturRequest request) { return (CRRM_GYPerBolgeOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerBolgeSilResponse perBolgeSil(CRRM_GYPerBolgeSilRequest request) { return (CRRM_GYPerBolgeSilResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerYetkiliOlusturResponse perYetkiliOlustur(CRRM_GYPerYetkiliOlusturRequest request) { return (CRRM_GYPerYetkiliOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerYetkiliSilResponse perYetkiliSil(CRRM_GYPerYetkiliSilRequest request) { return (CRRM_GYPerYetkiliSilResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerYetkiliListeResponse perYetkiliListe(CRRM_GYPerYetkiliListeRequest request) { return (CRRM_GYPerYetkiliListeResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerPersonelRefOlusturResponse perPersonelRefOlustur(CRRM_GYPerPersonelRefOlusturRequest request) { return (CRRM_GYPerPersonelRefOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerCalismaAlaniOlusturResponse perCalismaAlaniOlustur(CRRM_GYPerCalismaAlaniOlusturRequest request) { return (CRRM_GYPerCalismaAlaniOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerCalismaAlaniSilResponse perCalismaAlaniSil(CRRM_GYPerCalismaAlaniSilRequest request) { return (CRRM_GYPerCalismaAlaniSilResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerFirmaOlusturResponse perFirmaOlustur(CRRM_GYPerFirmaOlusturRequest request) { return (CRRM_GYPerFirmaOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerFirmaSilResponse perFirmaSil(CRRM_GYPerFirmaSilRequest request) { return (CRRM_GYPerFirmaSilResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerFirmaCalismaAlaniOlusturResponse perFirmaCalismaAlaniOlustur(CRRM_GYPerFirmaCalismaAlaniOlusturRequest request) { return (CRRM_GYPerFirmaCalismaAlaniOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerFirmaCalismaAlaniSilResponse perFirmaCalismaAlaniSil(CRRM_GYPerFirmaCalismaAlaniSilRequest request) { return (CRRM_GYPerFirmaCalismaAlaniSilResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerSozlesmeliDonemOlusturResponse perSozlesmeliDonemOlustur(CRRM_GYPerSozlesmeliDonemOlusturRequest request) { return (CRRM_GYPerSozlesmeliDonemOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerSozlesmeliDonemSilResponse perSozlesmeliDonemSil(CRRM_GYPerSozlesmeliDonemSilRequest request) { return (CRRM_GYPerSozlesmeliDonemSilResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerTarDonemOlusturResponse perTarDonemOlustur(CRRM_GYPerTarDonemOlusturRequest request) { return (CRRM_GYPerTarDonemOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerTarDonemSilResponse perTarDonemSil(CRRM_GYPerTarDonemSilRequest request) { return (CRRM_GYPerTarDonemSilResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerTarCalismaOlusturResponse perTarCalismaOlustur(CRRM_GYPerTarCalismaOlusturRequest request) { return (CRRM_GYPerTarCalismaOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerTarCalismaSilResponse perTarCalismaSil(CRRM_GYPerTarCalismaSilRequest request) { return (CRRM_GYPerTarCalismaSilResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerTarTahakkukYapResponse perTarTahakkukYap(CRRM_GYPerTarTahakkukYapRequest request) { return (CRRM_GYPerTarTahakkukYapResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerYasalTahakkukYapResponse perYasalTahakkukYap(CRRM_GYPerYasalTahakkukYapRequest request) { return (CRRM_GYPerYasalTahakkukYapResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerSozlesmeliPuantajOlusturResponse perSozlesmeliPuantajOlustur(CRRM_GYPerSozlesmeliPuantajOlusturRequest request) { return (CRRM_GYPerSozlesmeliPuantajOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerSozlesmeliTotalPuantajOlusturResponse perSozlesmeliTotalPuantajOlustur(CRRM_GYPerSozlesmeliTotalPuantajOlusturRequest request) { return (CRRM_GYPerSozlesmeliTotalPuantajOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerSozlesmeliPuantajSilResponse perSozlesmeliPuantajSil(CRRM_GYPerSozlesmeliPuantajSilRequest request) { return (CRRM_GYPerSozlesmeliPuantajSilResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerSozlesmeliAvansOlusturResponse perSozlesmeliAvansOlustur(CRRM_GYPerSozlesmeliAvansOlusturRequest request) { return (CRRM_GYPerSozlesmeliAvansOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerSGKIsyeriOlusturResponse perSGKIsyeriOlustur(CRRM_GYPerSGKIsyeriOlusturRequest request) { return (CRRM_GYPerSGKIsyeriOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerGrupOlusturResponse perGrupOlustur(CRRM_GYPerGrupOlusturRequest request) { return (CRRM_GYPerGrupOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerYanOdemeOlusturResponse perYanOdemeOlustur(CRRM_GYPerYanOdemeOlusturRequest request) { return (CRRM_GYPerYanOdemeOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerKesintiOdemeOlusturResponse perKesintiOdemeOlustur(CRRM_GYPerKesintiOdemeOlusturRequest request) { return (CRRM_GYPerKesintiOdemeOlusturResponse)request.wsCall(wsComm); }
        [WebMethod()] public CRRM_GYPerMasrafOlusturResponse perMasrafOlustur(CRRM_GYPerMasrafOlusturRequest request) { return (CRRM_GYPerMasrafOlusturResponse)request.wsCall(wsComm); }
        [WebMethod(), Obsolete("Bu API kullanımdan kaldırılmıştır", true)] public CRRM_GYPerPersonelOlusturVeIstenCikisYapResponse perPersonelOlusturVeIstenCikisYap(CRRM_GYPerPersonelOlusturVeIstenCikisYapRequest request) { return (CRRM_GYPerPersonelOlusturVeIstenCikisYapResponse)request.wsCall(wsComm); }
        [WebMethod(), Obsolete("Bu API kullanımdan kaldırılmıştır", true)] public CRRM_GYPerSozlesmeliPersonelOlusturVeIstenCikisYapResponse perSozlesmeliPersonelOlusturVeIstenCikisYap(CRRM_GYPerSozlesmeliPersonelOlusturVeIstenCikisYapRequest request) { return (CRRM_GYPerSozlesmeliPersonelOlusturVeIstenCikisYapResponse)request.wsCall(wsComm); }
        #endregion
    }
}