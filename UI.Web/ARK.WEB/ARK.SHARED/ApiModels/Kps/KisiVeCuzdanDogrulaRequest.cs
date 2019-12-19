namespace ARK.SHARED.ApiModels.Kps
{
    public class KisiVeCuzdanDogrulaRequest
    {
        public long TCKimlikNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public bool SoyadYok { get; set; }
        public System.Nullable<int> DogumGun { get; set; }
        public bool DogumGunYok { get; set; }
        public System.Nullable<int> DogumAy { get; set; }
        public bool DogumAyYok { get; set; }
        public int DogumYil { get; set; }
        //public string CuzdanSeri { get; set; }
        //public System.Nullable<int> CuzdanNo { get; set; }
        public string TCKKSeriNo { get; set; }
    }
}
