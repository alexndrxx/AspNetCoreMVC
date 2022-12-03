using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [StringLength(255, MinimumLength = 3)]      
        [Required(ErrorMessage = "Please enter the title")]
        public string Title { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Required(ErrorMessage = "Please enter the author")] 
        public string Author { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Please enter the total pages")]
        public string TotalPages { get; set; }

        public string Category { get; set; }
    }
}
