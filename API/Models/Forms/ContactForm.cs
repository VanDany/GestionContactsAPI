using API.Infrastructures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Forms
{
    public class ContactForm
    {
        [Required]
        [StringLength(75)]
        public string LastName { get; set; }
        [Required]
        [StringLength(75)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(384)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [CategoryIdValidation]
        public int CategoryId { get; set; }
        [Required]
        public int UserId { get; set; }

    }
}
