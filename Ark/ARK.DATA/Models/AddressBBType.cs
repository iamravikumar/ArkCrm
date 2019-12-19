﻿using System.ComponentModel.DataAnnotations;

namespace ARK.DATA.Models
{
    public class AddressBBType : BaseModel.ServiceBaseData
    {
        public int ID { get; set; }        
        [MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(128)]
        public string CodeName { get; set; }
    }
}