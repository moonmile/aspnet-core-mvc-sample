using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleControllerMvc.Data;
using SampleListDetailMvc.Models;

namespace SampleListDetailMvc.Controllers
{
    public class BooksController : Controller
    {
        private readonly MvcdbContext _context;

        public BooksController(MvcdbContext context)
        {
            _context = context;
        }

#if false

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var mvcdbContext = 
                _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher);
            return View(await mvcdbContext.ToListAsync());
        }
#elif true
        /// <summary>
        /// ページングと検索処理
        /// </summary>
        /// <param name="page"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(int? page, string search)
        {
            if (page == null)
            {
                page = 0;
            }
            int max = 5;

            var books = from m in _context.Book select m;
            if (!string.IsNullOrEmpty(search))
            {
                books = books.Where(b => b.Title.Contains(search));
            }
            books = books
                .Skip(max * page.Value).Take(max)
                .Include(b => b.Author)
                .Include(b => b.Publisher);

            if (page.Value > 0)
            {
                ViewData["prev"] = page.Value - 1;
            }
            if (books.Count() >= max)
            {
                ViewData["next"] = page.Value + 1;
                if (_context.Book.Skip(max * (page.Value + 1)).Take(max).Count() == 0)
                {
                    ViewData["next"] = null;
                }
            }
            ViewData["search"] = search;
            return View(await books.ToListAsync());
        }
#elif false
        // ページング処理
        public async Task<IActionResult> Index(int? page)
        {
            // ページング機能
            if (page == null)
            {
                page = 0;
            }
            int max = 5;

            var books = _context.Book
                .Skip(max * page.Value).Take(max)
                .Include(b => b.Author).Include(b => b.Publisher)
                .OrderBy( b => b.Id )
                ;

            if (page.Value > 0)
            {
                ViewData["prev"] = page.Value - 1;
            }
            if (books.Count() >= max)
            {
                ViewData["next"] = page.Value + 1;
                // 次のページがあるか調べる
                if ( _context.Book.Skip(max * (page.Value+1)).Take(max).Count() == 0 )
                {
                    ViewData["next"] = null;
                }
            }
            return View(await books.ToListAsync());
        }
#endif
        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Name");
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,AuthorId,PublisherId,Price,PublishDate,ISBN")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Name", book.AuthorId);
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Name", book.PublisherId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Name", book.AuthorId);
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Name", book.PublisherId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,AuthorId,PublisherId,Price,PublishDate,ISBN")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Name", book.AuthorId);
            ViewData["PublisherId"] = new SelectList(_context.Publisher, "Id", "Name", book.PublisherId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Book == null)
            {
                return Problem("Entity set 'MvcdbContext.Book'  is null.");
            }
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return (_context.Book?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
