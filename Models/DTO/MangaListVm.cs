using ArcticBook.Models.Domain;

namespace ArcticBook.Models.DTO
{
    public class MangaListVm
    {
        public IQueryable<Manga> MangaList { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Term { get; set; }
    }
}
