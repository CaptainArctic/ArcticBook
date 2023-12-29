using ArcticBook.Models.Domain;
using ArcticBook.Models.DTO;

namespace ArcticBook.Repositories.Abstract
{
    public interface IMangaService
    {
        bool Add(Manga model);
        bool DeleteManga(int id);
        Manga GetById(int id);
        IQueryable<Manga> MangaList();

    }
}
