using ArcticBook.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArcticBook.Models.DTO
{
    public class BookListVm
    {
        public IQueryable<Book> BookList { get; set; }
        public IQueryable<Manga> MangaList { get; set; }

        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }
    }
}
