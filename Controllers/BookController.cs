using ArcticBook.Models.Domain;
using ArcticBook.Repositories.Abstract;
using ArcticBook.Repositories.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArcticBook.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IFileService _fileService;
        private readonly IGenreService _genService;
        private readonly IMangaService _mangaService;

        public BookController(IBookService BookService, IGenreService genService, IFileService fileService, IMangaService mangaService)
        {
            _bookService = BookService;
            _fileService = fileService;
            _genService = genService;
            _mangaService = mangaService;
        }
        public IActionResult Add()
        {
            var model = new Book();
            model.GenreList = _genService.List().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString() });
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Book model)
        {
            model.GenreList = _genService.List().Select(a => new SelectListItem { Text = a.GenreName, Value = a.Id.ToString() });
            if (model.ImageFile != null)
            {
                var fileResult = this._fileService.SaveImage(model.ImageFile);
                if (fileResult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileResult.Item2;
                model.BookImage = imageName;
            }
            var result = _bookService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on server side...";
                return View(model);
            }
        }

        public IActionResult Edit( int id)
        {
            var model = _bookService.GetById(id);
            var selectedGenres = _bookService.GetGenreByBookId(model.Id);
            MultiSelectList multiGenreList = new MultiSelectList(_genService.List(), "Id", "GenreName", selectedGenres);
            model.MultiGenreList = multiGenreList;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Book model)
        {
            var selectedGenres = _bookService.GetGenreByBookId(model.Id);
            MultiSelectList multiGenreList = new MultiSelectList(_genService.List(), "Id", "GenreName", selectedGenres);
            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileResult = this._fileService.SaveImage(model.ImageFile);
                if(fileResult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileResult.Item2;
                model.BookImage = imageName;
            }
            var result = _bookService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(BookList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult AddManga()
        {
            var model = new Manga();
            model.BookListForManga = _bookService.ListOfBooks().Select(a => new SelectListItem { Text = a.Title, Value = a.Id.ToString() });
            return View(model);
        }

        [HttpPost]
        public IActionResult AddManga(Manga model)
        {
            model.BookListForManga = _bookService.ListOfBooks().Select(a => new SelectListItem { Text = a.Title, Value = a.Id.ToString() });
            if (model.ImageFile != null)
            {
                var fileResult = this._fileService.SaveImage(model.ImageFile);
                if (fileResult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileResult.Item2;
                model.MangaImage = imageName;
            }
            var result = _mangaService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(AddManga));
            }
            else
            {
                TempData["msg"] = "Error on server side...";
                return View(model);
            }
        }

        public IActionResult BookList()
        {
            var data = this._bookService.List();
            return View(data);
        }

        public IActionResult MangaList()
        {
            var data = this._mangaService.MangaList();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var result = _bookService.Delete(id);
            return RedirectToAction(nameof(BookList));
        }
    }
}
