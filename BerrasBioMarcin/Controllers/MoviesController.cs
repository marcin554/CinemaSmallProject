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
using BerrasBioMarcin.ViewModels;

namespace BerrasBioMarcin.Controllers
{
    public class MoviesController : Controller
    {
        private readonly BerrasBioMarcinContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public MoviesController(BerrasBioMarcinContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            GetGenres();
            return View(await _context.Movie.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {

            GetGenres();
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel viewMovie)
        {
            if (ModelState.IsValid)
            {
                //Using method to generate filename. And to save it on the desktop. 
                string uniqueFileName = UploadFile(viewMovie);

                //Creating new movie.
                Movie movie = new Movie
                {
                    MovieTitleName = viewMovie.MovieTitleName,
                    MovieDescription = viewMovie.MovieDescription,
                    MovieReleaseDate = viewMovie.MovieReleaseDate,
                    GenreId = viewMovie.GenreId,
                    MoviePath = uniqueFileName,
                    Price = viewMovie.Price,

                };

                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewMovie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,MovieTitleName,MovieDescription,MovieReleaseDate,GenresId,Price")] Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
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
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.MovieId == id);
        }

        //Using method to generate filename. And to save it on the desktop. 
        private string UploadFile (MovieViewModel movie)
        {
            string uniqueFileName = null;

            if(movie.MovieImage != null)
            {
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "Content\\MovieImages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + movie.MovieImage.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    movie.MovieImage.CopyTo(fileStream);
                }                
            }
            return uniqueFileName;
        }
        //getting the genres (did it before i knew that the scaffolding can do it for you, if you configure the model correctly.) The "proper" method is used in other controllers.
        private void GetGenres()
        {
            var items = _context.Genres.ToList();
            
            if (items != null)
            {
                ViewBag.Genres = items;
                
            }
        }
    }
}
