using ArcticBook.Models.Domain;
using ArcticBook.Models.DTO;

namespace ArcticBook.Repositories.Abstract
{
    public interface IGenreService
    {
        bool Add(Genre model);
        bool Update(Genre model);
        Genre GetById(int id);
        bool Delete(int id);
        IQueryable<Genre> List();


    }
}
