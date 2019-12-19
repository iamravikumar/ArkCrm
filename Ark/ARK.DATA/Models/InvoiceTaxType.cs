using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class InvoiceTaxType
    {
        public int ID { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Rate { get; set; }
    }
}
