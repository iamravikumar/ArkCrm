namespace ARK.SHARED.ApiModels.Kps
{
    public class NufusSorguRequest
    {
        //REQUEST: {"SeriNo":"A19F49933","Ad":"HALİL","Soyad":"KOCA","BabaAdi":"ŞERİF","AnneAdi":"PAKİZE","DogumYil":"1987","Cinsiyet":"1"}
        public string SeriNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string BabaAdi { get; set; }
        public string AnneAdi { get; set; }
        public string DogumYil { get; set; }
        public string Cinsiyet { get; set; }
    }
}
