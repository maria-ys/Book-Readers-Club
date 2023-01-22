using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BRC.Models
{
    public class BookReview
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Book Title")]
        public string Title { get; set; }
        [Required]
        [Range(1.0f,5.0f)]
        [DisplayName("Rating(1-5)")]
        public float Rating { get; set; }
        [Required]
        [DisplayName("Book Author")]
        public string Author { get; set; }
        [Required]
        public string Review { get; set; }
        public string ReviewBy { get; set; }
    }
}
