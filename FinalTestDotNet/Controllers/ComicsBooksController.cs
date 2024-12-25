using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalTestDotNet.Data;
using FinalTestDotNet.Models;

namespace FinalTestDotNet.Controllers
{
    public class ComicsBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComicsBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ComicsBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.ComicBooks.ToListAsync());
        }

        // GET: ComicsBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicBooks = await _context.ComicBooks
                .FirstOrDefaultAsync(m => m.ComicBookId == id);
            if (comicBooks == null)
            {
                return NotFound();
            }

            return View(comicBooks);
        }

        // GET: ComicsBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComicsBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComicBookId,Title,Author,PricePerDay")] ComicBooks comicBooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comicBooks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comicBooks);
        }

        // GET: ComicsBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicBooks = await _context.ComicBooks.FindAsync(id);
            if (comicBooks == null)
            {
                return NotFound();
            }
            return View(comicBooks);
        }

        // POST: ComicsBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComicBookId,Title,Author,PricePerDay")] ComicBooks comicBooks)
        {
            if (id != comicBooks.ComicBookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comicBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComicBooksExists(comicBooks.ComicBookId))
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
            return View(comicBooks);
        }

        // GET: ComicsBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comicBooks = await _context.ComicBooks
                .FirstOrDefaultAsync(m => m.ComicBookId == id);
            if (comicBooks == null)
            {
                return NotFound();
            }

            return View(comicBooks);
        }

        // POST: ComicsBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comicBooks = await _context.ComicBooks.FindAsync(id);
            if (comicBooks != null)
            {
                _context.ComicBooks.Remove(comicBooks);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComicBooksExists(int id)
        {
            return _context.ComicBooks.Any(e => e.ComicBookId == id);
        }
    }
}
