using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Forms
{
    public class UpdateCategoryForm
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(125)]
        public string Name { get; set; }
    }
}
