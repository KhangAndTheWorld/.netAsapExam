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
    public class RentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers
                .Select(c => new { c.CustomerID, c.FullName })
                .ToList();

            ViewBag.ComicBooks = _context.ComicBooks
                .Select(cb => new { cb.ComicBookId, cb.Title })
                .ToList();
            return View();
        }

        // POST: Rentals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int customerId, DateTime rentalDate, DateTime returnDate, int comicBookId, int quantity)
        {
            if (ModelState.IsValid)
            {
                var rental = new Rentals
                {
                    CustomerID = customerId,
                    RentalDate = rentalDate,
                    ReturnDate = returnDate,
                    Status = "Lending"
                };
                _context.Rentals.Add(rental);
                await _context.SaveChangesAsync();

                var comicBook = await _context.ComicBooks.FindAsync(comicBookId);

                if (comicBook != null)
                {
                    var rentalDetail = new RentalDetails
                    {
                        RentalID = rental.RentalID,
                        ComicBookID = comicBookId,
                        Quantity = quantity,
                        PricePerDay = comicBook.PricePerDay
                    };
                    _context.RentalDetails.Add(rentalDetail);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "ComicsBooks");
            }
            return View();
        }
    }
}
