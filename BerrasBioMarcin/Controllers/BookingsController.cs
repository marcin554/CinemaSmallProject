#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BerrasBioMarcin.Data;
using BerrasBioMarcin.Models;

namespace BerrasBioMarcin.Controllers
{
    public class BookingsController : Controller
    {
        private readonly BerrasBioMarcinContext _context;

        public BookingsController(BerrasBioMarcinContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var berrasBioMarcinContext = _context.Booking.Include(b => b.Shows);
            return View(await berrasBioMarcinContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Shows)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["ShowsID"] = new SelectList(_context.Show, "ShowID", "ShowID");

            
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingID,AmountSeats,ShowsID,BookingCanceled")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                // Getting the objects that have same ID as the booking got. 
                Show show = _context.Show.Where(s => s.ShowID == booking.ShowsID).FirstOrDefault();
                Movie movie = _context.Movie.Where(s => s.MovieId == show.MovieId).FirstOrDefault();

                //Using CountHowManyFreeSeats to count how many free slots are left in show.
                int c = CountHowManyFreeSeats(booking);

                
                booking.TotalPrice = (int?)(booking.AmountSeats * movie.Price);
                booking.TimeWhen = show.ShowDate;
                _context.Add(booking);

                //if c have slots for the amount the customer wanted to run it
                if (c >= booking.AmountSeats)
                {
                    //It run code as many times as many times customer picked slots.
                    for (int i = 0; i < booking.AmountSeats; i++)
                    {
                        //It get the spots that are in that show and check if the spot is empty.
                        Spot spots = _context.Spot.Where(s => s.ShowId == booking.ShowsID).Where(s => s.SpotIsTaken != true).FirstOrDefault();

                       
                        if (spots == null)
                        {

                        }
                        // check again if the slot is empty or not.
                        else if (spots.SpotIsTaken == false)
                        {

                           
                            spots.BookingId = booking.BookingID;
                            spots.SpotIsTaken = true;

                            _context.Update(spots);
                            await _context.SaveChangesAsync();

                        }
                    }
                    return RedirectToAction("BookingResult", "Bookings", booking);
                }

                //else show message that there isnt enough seats.
                else
                {
                    ViewBag.ErrorMessage = "Not enough seats.";
                }
                
                
            }
            ViewData["ShowsID"] = new SelectList(_context.Show, "ShowID", "ShowID", booking.ShowsID);
            return View(booking);
        }



        public async Task<IActionResult> BookingResult(Booking booking)
        {
            Show shows = _context.Show.Where(s => s.ShowID == booking.ShowsID).FirstOrDefault();
            Movie movie = _context.Movie.Where(s => s.MovieId == shows.MovieId).FirstOrDefault();


            return View(booking);

        }
        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["ShowsID"] = new SelectList(_context.Show, "ShowID", "ShowID", booking.ShowsID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingID,AmountSeats,ShowsID,BookingCanceled")] Booking booking)
        {
            if (id != booking.BookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingID))
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
            ViewData["ShowsID"] = new SelectList(_context.Show, "ShowID", "ShowID", booking.ShowsID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Shows)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.BookingID == id);
        }

        //Checking how many slots are left in a show. Its getting the booking information Create function got. Its returning the amount of slots left. 
        public int CountHowManyFreeSeats(Booking booking) 
        {
            Show show = _context.Show.Where(s => s.ShowID == booking.ShowsID).FirstOrDefault();
            Salon salon = _context.Salon.Where(s => s.SalonId == show.SalonId).FirstOrDefault();

            int b = 0;
            for (int i = 0; i < salon.AvailableSpace; i++)
            {

                IQueryable<Spot> spots = _context.Spot.Where(s => s.ShowId == booking.ShowsID).Where(s => s.SpotIsTaken != true);
                b = spots.Count();

                

            }
            return b;
        }
    }
}
