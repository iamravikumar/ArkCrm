namespace ARK.MODEL.V1.Domain.Radius
{
    public class NasModel
    {
        public int Id { get; set; }
        public string Nasname { get; set; } // ip adresi
        public string Shortname { get; set; } // isim
        public string Type { get; set; } // other
        public int? Ports { get; set; } // 0
        public string Secret { get; set; } // secret
        public string Server { get; set; } // boş
        public string Community { get; set; } // boş
        public string Description { get; set; } // Radius Client
    }
}
