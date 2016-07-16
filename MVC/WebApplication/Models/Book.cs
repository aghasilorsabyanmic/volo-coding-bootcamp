using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication.Models
{
    public class Book
    {
        public string Id { get; set; }

        [Required]
        [DisplayName("Book Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Date of Publishing")]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Issued { get; set; }

        [Required]
        [DisplayName("Pages count")]
        [Range(1, 500, ErrorMessage = "Invalid pages count")]
        public int PagesCount { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "Max length exceeded")]
        public string Author { get; set; }
    }
}