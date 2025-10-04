using MeuTccMvc.Data;
using MeuTccMvc.Models;
using MeuTccMvc.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogApp.Controllers
{
    public class CatalogController : Controller
    {
        private readonly AppDbContext _db;
        public CatalogController(AppDbContext db) { _db = db; }

        // GET: /Catalog
        public async Task<IActionResult> Index(string searchString, string type)
        {
            var query = _db.MediaItems.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(m => EF.Functions.ILike(m.Title, $"%{searchString}%")
                    || (m is Book && EF.Functions.ILike(((Book)m).Author ?? "", $"%{searchString}%"))
                    || (m is Movie && EF.Functions.ILike(((Movie)m).Director ?? "", $"%{searchString}%"))
                    || (m is Series && EF.Functions.ILike(((Series)m).Director ?? "", $"%{searchString}%")));
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                if (type == "Book") query = query.OfType<Book>();
                if (type == "Movie") query = query.OfType<Movie>();
                if (type == "Series") query = query.OfType<Series>();
            }

            var list = await query.OrderBy(m => m.Title).ToListAsync();
            return View(list);
        }

        // GET: /Catalog/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _db.MediaItems.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        // GET: /Catalog/CreateBook
        public IActionResult CreateBook()
        {
            return View(new Book());
        }

        // POST: /Catalog/CreateBook
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBook(Book book)
        {
            if (ModelState.IsValid)
            {
                if (_db.MediaItems.Where(m => EF.Functions.ILike(m.Title, $"%{book.Title}%")).Any())
                {
                    ModelState.AddModelError(string.Empty, "Livro já cadastrado.");
                    return View(book); 
                }
                book.MediaType = MediaType.Book;
                _db.Add(book);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: /Catalog/CreateMovie
        public IActionResult CreateMovie()
        {
            return View(new Movie());
        }

        // POST: /Catalog/CreateMovie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (_db.MediaItems.Where(m => EF.Functions.ILike(m.Title, $"%{movie.Title}%")).Any())
                {
                    ModelState.AddModelError(string.Empty, "Filme já cadastrado.");
                    return View(movie); 
                }
                movie.MediaType = MediaType.Movie;
                _db.Add(movie);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: /Catalog/CreateSeries
        public IActionResult CreateSeries()
        {
            return View(new Series());
        }

        // POST: /Catalog/CreateSeries
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSeries(Series series)
        {
            if (ModelState.IsValid)
            {
                if (_db.MediaItems.Where(m => EF.Functions.ILike(m.Title, $"%{series.Title}%")).Any())
                {
                    ModelState.AddModelError(string.Empty, "Séria já cadastrada.");
                    return View(series); 
                }
                series.MediaType = MediaType.Series;
                _db.Add(series);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(series);
        }

        // GET: /Catalog/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _db.MediaItems.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MediaItemEditViewModel item)
        {
            if (id != item.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(item);

            // Recupera o item original do banco
            var dbItem = await _db.MediaItems.FindAsync(id);
            if (dbItem == null)
                return NotFound();

            // Atualiza campos comuns
            dbItem.Title = item.Title;
            dbItem.ReleaseYear = item.ReleaseYear;
            dbItem.Genre = item.Genre;
            dbItem.Sinopse = item.Sinopse;

            switch (item.MediaType)
            {
                case MediaType.Book:
                    if (dbItem is Book book)
                    {
                        book.Author = item.Author;
                        book.ISBN = item.ISBN;
                        book.Publisher = item.Publisher;
                    }
                    break;
                case MediaType.Movie:
                    if (dbItem is Movie movie)
                    {
                        movie.Director = item.Director;
                        movie.DurationMinutes = item.DurationMinutes;
                    }
                    break;
                case MediaType.Series:
                    if (dbItem is Series series)
                    {
                        series.Director = item.Director;
                        series.Seasons = item.Seasons;
                    }
                    break;
            }

            // Salva no banco
            _db.Update(dbItem);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: /Catalog/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _db.MediaItems.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // POST: /Catalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _db.MediaItems.FindAsync(id);
            if (item != null)
            {
                _db.Remove(item);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}