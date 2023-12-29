using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArcticBook.Models.Domain
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? ReleaseYear { get; set; }

        public string? BookImage { get; set; }
        [Required]
        public string? Author { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        [NotMapped]
        [Required]
        public List<int>? Genres { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? GenreList { get; set; }
        [NotMapped]
        public string ? GenreNames { get; set; }
        [NotMapped]
        public MultiSelectList ? MultiGenreList { get; set; }
   
        [NotMapped]
        public string? MangaNames { get; set; }
        [NotMapped]
        public List<string>? MangaImages { get; set; }
        [NotMapped]
        public int PageSize { get; set; }
        [NotMapped]
        public int CurrentPage { get; set; }
        [NotMapped]
        public int TotalPages { get; set; }
        [NotMapped]
        public string? Term { get; set; }

    }

}
