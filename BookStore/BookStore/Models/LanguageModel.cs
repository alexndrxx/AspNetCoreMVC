using BookStore.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class LanguageModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please choose the language")]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Books> Books { get; set; }
    }
}
