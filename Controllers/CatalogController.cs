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
                    || (m is Movie && EF.Functions.ILike(((Movie)m).Director ?? "", $"%{searchString}%")));
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                if (type == "Book") query = query.OfType<Book>();
                if (type == "Movie") query = query.OfType<Movie>();
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
                movie.MediaType = MediaType.Movie;
                _db.Add(movie);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: /Catalog/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _db.MediaItems.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // POST: /Catalog/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MediaItem item)
        {
            if (id != item.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _db.Update(item);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
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