using System.Collections.Generic;

namespace ARK.MODEL.V1.Integration.TarifeSorgulama
{
    public class TarifeSorguServisSonucModel
    {
        public string Mesaj { get; set; }
        public int SonucKod { get; set; }
        public List<TarifeSorguSonucModel> TarifeSorguSonuc { get; set; }
    }
}
