using ArcticBook.Models.Domain;
using ArcticBook.Models.DTO;
using ArcticBook.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace ArcticBook.Repositories.Implementation
{
    public class MangaService : IMangaService
    {
        private readonly DatabaseContext ctx;
        public MangaService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Manga model)
        {
            try
            {
                ctx.Manga.Add(model);
                ctx.SaveChanges();
                foreach (int bookId in model.Books)
                {
                    var bookManga = new BookManga
                    {
                        MangaId = model.Id,
                        BookId = bookId
                    };
                    ctx.BookManga.Add(bookManga);
                }
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IQueryable<Manga> MangaList()
        {
            var data = ctx.Manga.AsQueryable();
            return data;
        }

        public Manga GetById(int id)
        {
            return ctx.Manga.Find(id);
        }

        public bool DeleteManga(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;
                ctx.Manga.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
