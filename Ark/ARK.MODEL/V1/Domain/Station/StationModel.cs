using System.ComponentModel.DataAnnotations;

namespace ARK.MODEL.V1.Domain.Station
{
    public class StationModel : BaseModel
    {
        public int ID { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
        public int? Code { get; set; }
    }
}