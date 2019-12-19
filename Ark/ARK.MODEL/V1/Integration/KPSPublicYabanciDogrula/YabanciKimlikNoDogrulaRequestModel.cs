namespace ARK.MODEL.V1.Integration.KPSPublicYabanciDogrula
{
    public class YabanciKimlikNoDogrulaRequestModel
    {
        public long KimlikNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public System.Nullable<int> DogumGun { get; set; }
        public System.Nullable<int> DogumAy { get; set; }
        public int DogumYil { get; set; }
    }
}
