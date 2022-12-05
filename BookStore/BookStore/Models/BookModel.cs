using BookStore.Helpers;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
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

        [Display(Name = "Language")]
        [Required]
        public int LanguageId { get; set; }

        public string Language { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Please enter the total pages")]
        public string TotalPages { get; set; }

        public string Category { get; set; }

        [Display(Name = "Choose the cover photo of your book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }

        public string CoverImageUrl { get; set; }
        
        [Display(Name = "Upload your book in pdf format")]
        public IFormFile BookPdf { get; set; }

        [Display(Name = "Choose the gallery files of your book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }

		[Required]
        public string BookPdfUrl { get; set; }
    }
}
