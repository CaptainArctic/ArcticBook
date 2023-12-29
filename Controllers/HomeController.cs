using ArcticBook.Models.Domain;
using ArcticBook.Models.DTO;
using ArcticBook.Repositories.Abstract;
using ArcticBook.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ArcticBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IFileService _fileService;
        private readonly IMangaService _mangaService;
        public HomeController(IBookService bookService, IFileService fileService, IMangaService mangaService)
        {
            _bookService = bookService;
            _fileService = fileService;
            _mangaService = mangaService;


        }
        public IActionResult Index(string term="", int currentPage = 0)
        {
            var books = _bookService.List(term, true, currentPage);
            return View(books);
        }

        //public IActionResult MangaDetail(int BookId, string term = "", int currentPage = 0)
        //{
        //    // var mangas = _mangaService.List(term, true, currentPage);
        //    // return View(mangas);
        //    var book = _mangaService.GetById(BookId);
        //    return View(book);
        //}


        public IActionResult About()
        {
            return View();
        }


        //public IActionResult MangaList()
        //{
        //    var data = this._mangaService.List();
        //    return View(data);
        //}



        public IActionResult BookDetail(int bookId, string term = "", int currentPage = 0)
        {
            var book = _bookService.GetById(bookId, term, true, currentPage);
            return View(book);
        }

        public IActionResult DeleteManga(int id)
        {
            var result = _mangaService.DeleteManga(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
