using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArcticBook.Models.Domain
{
    public class Manga
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string? MangaImage { get; set; }

        [NotMapped]
        [Required]
        public List<int>? Books { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? BookListForManga { get; set; }
        [NotMapped]
        public string? BookNames { get; set; }
        [NotMapped]
        public MultiSelectList? MultiBookList { get; set; }
        [NotMapped]
        public string? Term { get; set; }
    }
}
