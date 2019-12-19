using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class AccountType // hesabın türü bireysel - kurumsal
    {
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int? Code { get; set; }
        [MaxLength(128)]
        public string CodeName { get; set; }
    }
}