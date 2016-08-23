using System.ComponentModel.DataAnnotations;

namespace BooksEditor.MVC.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "The {0} must be maximum {1} characters long.")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "The {0} must be maximum {1} characters long.")]
        public string LastName { get; set; }
    }
}
