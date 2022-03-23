using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Display order")]
        public int DisplayOrder { get; set; }
    }
}
