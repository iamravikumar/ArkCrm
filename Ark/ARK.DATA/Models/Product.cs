using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class Product : BaseModel.BaseData
    {
        public int ID { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }        
        public int? Code { get; set; }
        [MaxLength(128)]
        public string CodeName { get; set; }
        [MaxLength(128)]
        public string Price { get; set; }        
        [MaxLength(128)]
        public string SerialNumber { get; set; }
        [MaxLength(128)]
        public string MacIDACSParameter { get; set; } //cihaz mac id


        public int? BrandId { get; set; }
        public ProductBrand Brand { get; set; }
        public int? ModelId { get; set; }
        public ProductModel Model { get; set; }
        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
    }
}