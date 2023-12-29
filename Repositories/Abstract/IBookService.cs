using ArcticBook.Models.Domain;
using ArcticBook.Models.DTO;

namespace ArcticBook.Repositories.Abstract
{
    public interface IBookService
    {
        bool Add(Book model);
        bool Update(Book model);
        Book GetById(int id, string term = "", bool paging = false, int currentPage = 0);
        bool Delete(int id);
        IQueryable<Book> ListOfBooks();
        BookListVm List(string term = "", bool paging = false, int currentPage = 0);
        List<int>GetGenreByBookId(int bookId);


    }
}
