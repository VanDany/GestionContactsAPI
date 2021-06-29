﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BxlForm.DemoSecurity.Models.Forms
{
    public class EditContactForm
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [StringLength(75)]
        [DisplayName("Nom : ")]
        public string LastName { get; set; }
        [Required]
        [StringLength(75)]
        [DisplayName("Prenom : ")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(384)]
        [EmailAddress]
        [DisplayName("Email : ")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Catégorie : ")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        //public IEnumerable<Category> Categories { get; set; }
    }
}
