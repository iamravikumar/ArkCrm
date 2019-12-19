namespace ARK.SHARED.ApiModels.Kps
{
    public class NufusSorguResponse
    {
        //RESPONSE: {"success":true,"obj":{"TcKimlikNo":52108492584,"Il":"Muğla","Ilce":"Fethiye","Ad":"HALİL","Soyad":"KOCA",
        //"MahalleKoy":"","BabaAdi":"ŞERİF","AnneAdi":"PAKİZE","DogumYil":1987,"Cinsiyet":"Erkek","CiltNo":78,"AileSiraNo":184,"BireySiraNo":351,"HataAciklama":null}}

        public bool success { get; set; }
        public TcBilgileri obj { get; set; }
    }

    public class TcBilgileri
    {
        public string TcKimlikNo { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string MahalleKoy { get; set; }
        public string BabaAdi { get; set; }
        public string AnneAdi { get; set; }
        public string DogumYil { get; set; }
        public string Cinsiyet { get; set; }
        public string CiltNo { get; set; }
        public string AileSiraNo { get; set; }
        public string BireySiraNo { get; set; }
    }
}
