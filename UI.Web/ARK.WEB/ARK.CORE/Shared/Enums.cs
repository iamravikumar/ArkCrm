using System.ComponentModel;

namespace ARK.CORE.Shared
{
   public enum MembershipType
    {
        [Description("Bireysel Müşteri")]
        Bireysel = 1,
        [Description("Kurumsal Müşteri")]
        Kurumsal = 2
    }
    public enum Identity
    {
        [Description("TC Çipli Kimlik Kartı")]
        Cipli = 1,
        [Description("TC Nufüs Cüzdanı")]
        NufusCuzdani = 2,
        //[Description("TC Yabancı Kimlik Belgesi(Yabancı Misyon Kimlik Kartı, Geçici Koruma Kimlik Belgesi, İkametgah İzin  Belgesi, Çalışma İzin Belgesi, Vatansız Kişi Kimlik Belgesi)")]
        [Description("TC Yabancı Kimlik Belgesi")]
        YabanciKimlikBelgesi = 3,
        [Description("TC Sürücü Belgesi")]
        SurucuBelgesi = 4,
        //[Description("TC Pasaport: Yeni Tip Çipli ePasaport(Tüm Tipler)")]
        //YeniPasaport = 5,
        //[Description("TC Pasaport: Eski Tip Lacivert(Umuma Mahsus)")]
        //EskiPasaportLacivert = 6,
        //[Description("TC Pasaport: Eski Tip Yeşil(Hususi)")]
        //EskiPasaportYesil = 7,
        //[Description("TC Pasaport: Eski Tip Gri(Hizmet)")]
        //EskiPasaportGri = 8,
        //[Description("TC Pasaport: Eski Tip Kırmızı(Diplomatik)")]
        //EskiPasaportKirmizi = 9,
        //[Description("TC Pasaport: Geçici")]
        //EskiPasaportGecici = 10,
        //[Description("Yabancı Pasaport")]
        //YabanciPasaport = 11,
        //[Description("Uçuş Mürettebatı Belgesi")]
        //UcusMurettebatBelgesi = 12,
        //[Description("Gemi Adamı Cüzdanı")]
        //GemiAdamiCuzdani = 13,
        //[Description("NATO Emri Belgesi")]
        //NatoEmriBelgesi = 14,
        //[Description("Seyahat Belgesi")]
        //SeyahatBelgesi = 15,
        //[Description("Hudut Geçiş Belgesi")]
        //HudutGecisBelgesi = 16,
        //[Description("Gemi Komutanı Onaylı Personel Listesi ")]
        //GemiKomutaniOnayli = 17,
        //[Description("TC Hakim/Savci Mesleki Kimlik Kartı")]
        //HakimSavciMeslekiKimlikKarti = 18,
        //[Description("TC Avutkatlık Belgesi")]
        //AvukatlikBelgesi = 19,
        //[Description("TC Geçiçi Kimlik Belgesi")]
        //GeciciKimlikBelgesi = 20,
        //[Description("TC Mavi Kart ")]
        //MaviKart = 21,
        //[Description("TC Uluslararası Aile Cüzdanı")]
        //UluslararasiAileCuzdani = 22
    }
     
    public enum Gender
    {
        [Description("Kadın")]
        Kadin = 1,
        [Description("Erkek")]
        Erkek = 2,
    }
   
}
