namespace ARK.MODEL.V1.Integration.TarifeSorgulama
{
    public class TarifeSorguSonucModel
    {

        public double aylikSabitUcret { get; set; }
        public int hiz { get; set; }
        public string hizAciklama { get; set; }
        public string paketAdi { get; set; }
        public int paketTuru { get; set; }
        public int tarifeTuru { get; set; }
    }
}
