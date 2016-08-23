using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BooksEditor.MVC.Attributes;

namespace BooksEditor.MVC.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "The {0} must be maximum {1} characters long.")]
        public string Header { get; set; }

        [Range(0, 10000, ErrorMessage = "The {0} must be between {1} and {2}.")]
        public int NumberOfPages { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "The {0} must be maximum {1} characters long.")]
        public string PublishingHouse { get; set; }

        [MinValue(1800, ErrorMessage = "The {0} must be more then {1}.")]
        public int PublishingYear { get; set; }

        [Required]
        public string ISBN { get; set; }

        public string Image { get; set; }

        public IEnumerable<AuthorModel> Authors { get; set; }
    }
}
