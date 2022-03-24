using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display order")]
        [Required]
        [Range(1, 100, ErrorMessage ="Display order must be more than 1 and less then 100")]
        public int DisplayOrder { get; set; }
    }
}
